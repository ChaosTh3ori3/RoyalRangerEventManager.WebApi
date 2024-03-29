using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RangerEventManager.WebApi.Repositories.Camps;
using RangerEventManager.WebApi.Settings;
using Serilog;
using System.Text;

namespace RangerEventManager.WebApi;

public static class ApplicationBuilder
{
    public static WebApplicationBuilder BuildServices(this WebApplicationBuilder builder)
    {
        // settings
        builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection("MongoDbSettings"));

        // logging
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console());

        // authentication
        var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
        var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
         {
             options.TokenValidationParameters.ValidIssuer = jwtIssuer; 
             options.TokenValidationParameters.ValidateIssuer = true;
             options.TokenValidationParameters.ValidateIssuerSigningKey = true;
             options.TokenValidationParameters.IssuerSigningKey = key;
             options.TokenValidationParameters.ValidateLifetime = false;
             options.TokenValidationParameters.ValidateAudience = true;
             options.TokenValidationParameters.ValidAudience = "realm-management";
         });

        // repositories
        builder.Services.AddSingleton<ICampsRepository, CampsRepository>();

        builder.Services.AddControllers();

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


        return builder;
    }

    public static WebApplication BuilderWebApplication(this WebApplication app)
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

            IdentityModelEventSource.ShowPII = true;

        }

        app.UseSerilogRequestLogging();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();

        return app;
    }
}
