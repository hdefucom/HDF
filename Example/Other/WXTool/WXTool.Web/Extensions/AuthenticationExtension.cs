using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WXTool.Web.Config;

namespace WXTool.Web.Extensions;

/// <summary>
/// API身份验证
/// </summary>
public static class AuthenticationExtension
{
    /// <summary>
    /// 配置Authentication service
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddAuthenticationService(this IServiceCollection services, TokenConfig config)
    {
        services.AddAuthentication(configureOptions =>
        {
            configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.RequireHttpsMetadata = false;
            jwtBearerOptions.SaveToken = true;
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, //是否验证SecurityKey
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Secret)),
                ValidateIssuer = true, //是否验证Issuer
                    ValidateAudience = true, //是否验证Audience
                    ValidateLifetime = true, //是否验证失效时间
                    ValidAudience = config.Audience, //Audience
                    ValidIssuer = config.Issuer, //Issuer，这两项和前面签发jwt的设置一致
                    ClockSkew = TimeSpan.FromSeconds(30), //Token过期时间偏差

                };
        });

    }


}
