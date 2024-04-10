﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        var jwtOptions = builder.Configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();

        builder.Services.AddSingleton(jwtOptions);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.Authority = jwtOptions.Issuer;
                  options.Audience = "account";
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = false,
                      ValidateIssuerSigningKey = false,
                      ValidIssuer = jwtOptions.Issuer,
                      ValidAudience = "WebApi",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Q0uDCeAHiPMwFdRCBHktn27YYxhU2Id1"))
                  };
              });

        builder.Services.AddAuthorization();

        // repositories
        builder.Services.AddSingleton<ICampsRepository, CampsRepository>();

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

        return app;
    }
}
