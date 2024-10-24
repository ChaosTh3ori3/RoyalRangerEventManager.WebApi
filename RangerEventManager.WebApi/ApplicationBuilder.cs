using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RangerEventManager.WebApi.Services.UserService;
using Serilog;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RangerEventManager.Persistence;
using RangerEventManager.Persistence.Settings;
using RangerEventManager.WebApi.Mapper.UserMapper;
using RangerEventManager.WebApi.Repositories;
using RangerEventManager.WebApi.ScheduledTasks;
using RangerEventManager.WebApi.ScheduledTasks.Base;
using RangerEventManager.WebApi.Services.IAMService;

namespace RangerEventManager.WebApi;

public static class ApplicationBuilder
{
    public static void BuildServices(this WebApplicationBuilder builder)
    {
        // settings
        var databaseSettings = builder.Configuration.GetSection(nameof(DatabaseSettings));
        builder.Services.Configure<IAMSettings>(builder.Configuration.GetSection(nameof(IAMSettings)));

        // logging
        builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

        // authentication
        var jwtOptions = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.Authority = jwtOptions.Issuer;
                  options.Audience = jwtOptions.Audience;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = false,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = jwtOptions.Issuer,
                      ValidAudience = jwtOptions.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
                  };
              });

        // database
        builder.Services.AddDbContext<EventManagerContext>(opt => 
            opt.UseNpgsql(databaseSettings["ConnectionString"]));

        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        
        // scheduler
        builder.Services.AddScheduledTask<AddNewIAMUserSchedulerTask>("* * * * *");
        
        // mapper
        builder.Services.AddTransient<IUserMapper, UserMapper>();
        
        // services
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IIAMService, IAMService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
    }

    public static void BuilderWebApplication(this WebApplication app)
    {

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler("/Error");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        
        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.MapControllers();

        app.Run();
    }
}
