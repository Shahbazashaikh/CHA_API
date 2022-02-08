using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CHA_API.Extensions
{
    public static class JWTAuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            string authority = config.GetSection("Authority").Value;
            string issuer = config.GetSection("Issuer").Value;
            string audience = config.GetSection("Audience").Value;
            string key = config.GetSection("SecretKey").Value;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.Authority = authority;
                options.Audience = audience;
                options.Configuration = new OpenIdConnectConfiguration();
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateIssuer = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
