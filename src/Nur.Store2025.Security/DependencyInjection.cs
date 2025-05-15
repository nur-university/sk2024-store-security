using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nur.Store2025.Security.Config;
using System.Text;

namespace Nur.Store2025.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services, JwtOptions jwtoptions, IEnumerable<string> permissions)
    {
        services.AddAuthorization(config =>
        {
            var defaultAuthBuilder = new AuthorizationPolicyBuilder();
            var defaultAuthPolicy = defaultAuthBuilder
                .RequireAuthenticatedUser()
                .Build();


            config.DefaultPolicy = defaultAuthPolicy;

            permissions.ToList().ForEach(permission =>
            {
                config.AddPolicy(permission, policy =>
                {
                    policy.RequireAssertion(context => 
                        context.User.HasClaim( 
                            c => c.Type == "scope" && c.Value.Split(" ").Contains(permission)
                        )
                    );
                });
            });
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
            jwtOptions.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = jwtoptions.ValidateIssuer,
                ValidateAudience = jwtoptions.ValidateAudience,
                ValidIssuer = jwtoptions.ValidIssuer,
                ValidAudience = jwtoptions.ValidAudience
            };
        });


        return services;
    }
}
