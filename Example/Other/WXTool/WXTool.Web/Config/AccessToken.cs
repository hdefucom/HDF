using Microsoft.AspNetCore.Http;

namespace WXTool.Web.Config;

/// <summary>
/// Token映射实体
/// 此实体注册为scoped生命周期，注入HttpContextAccessor服务构建对象
/// </summary>
public class AccessToken
{
    public AccessToken(IHttpContextAccessor contextAccessor)
    {
        var context = contextAccessor.HttpContext;

        if (context == default || context.User == default)
            return;

        Id = context.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
        UserCode = context.User.Claims.FirstOrDefault(c => c.Type == "UserCode")?.Value;
        UserName = context.User.Claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
        UserRoles = context.User.Claims.FirstOrDefault(c => c.Type == "UserRoles")?.Value;
        UserType = context.User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
    }

    public bool Valid => !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(UserCode);


    public string Id { get; }

    public string UserCode { get; }
    public string UserName { get; }
    public string UserRoles { get; }
    public string UserType { get; set; }
}
