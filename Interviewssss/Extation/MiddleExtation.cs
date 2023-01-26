using DATA.Model;
using Interviewssss.Context;
using Interviewssss.Repostory;
using Interviewssss.Repostory.Interface;
using Interviewssss.Service;
using Interviewssss.Service.Identity;
using Interviewssss.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Interviewssss.Extation
{
    public static class MiddleExtation
    {
        public static void AddServise(this IServiceCollection services)
        {
            services.AddTransient<IOluvchiService, OluvchiService>();
            services.AddTransient<IToshiruvchiService, TopshiruvchiService>();
            services.AddTransient<IAuthManager,AuthManager>();
        }

        public static void AddRepostory(this IServiceCollection services)
        {
            services.AddTransient<IOluvchiRepo, OluvchiRepo>();
            services.AddTransient<ITopshiruvchiRepo, TopshiruvchiRepo>();
        }

        public static void AddSwager(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Exsemple project API",
                    Version = $"v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                    new string[] {}
                    }
                });

            });
        }
        
        public static void AddConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApiUser, Role>(q => q.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void AddConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(options =>
            {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {                     
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),                    
                    };
                });
        }
    }
}
