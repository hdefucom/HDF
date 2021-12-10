using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WXTool.Web.Common;

namespace WXTool.Web.Controllers;

/// <summary>
/// 身份验证控制器
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly TokenConfig _tokenConfig;
    private readonly DapperHelper _dapper;
    private readonly ILogger<AuthorizationController> _logger;

    public AuthorizationController(TokenConfig tokenConfig, DapperHelper dapper, ILogger<AuthorizationController> logger)
    {
        _tokenConfig = tokenConfig;
        _dapper = dapper;
        _logger = logger;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<string>> UserLogin([FromForm] string userCode, [FromForm] string password)
    {
        var user = await _dapper.QueryFirstOrDefaultAsync<User>($"select * from users where usercode=@UserCode", new { UserCode = userCode });

        if (user == default)
            return ApiResult.Fail<string>("该用户不存在！");

        if (user.UserPassword != password)
            return ApiResult.Fail<string>("密码错误！");

        var claims = new Claim[]
        {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("UserCode", user.UserCode),
                new Claim("UserName", user.UserName),
                new Claim("UserRoles", string.Join(",", user.UserRoles)),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddMinutes(_tokenConfig.AccessExpiration)).ToUnixTimeSeconds().ToString()),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_tokenConfig.Secret));

        var token = new JwtSecurityToken(
            issuer: _tokenConfig.Issuer,
            audience: _tokenConfig.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_tokenConfig.AccessExpiration),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        //生成Token
        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        _logger.LogInformation($"【登录用户-->Id:{user.UserId}，Code:{user.UserCode}，Name:{user.UserName}】");

        return ApiResult.Success(jwtToken);
    }



    public record UserInfoModel(string UserName, List<Menu> Menus);

    /// <summary>
    /// 获取用户信息（姓名，菜单）
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public async Task<ApiResult<UserInfoModel>> GetUserInfo([FromServices] AccessToken token)
    {
        var user = await _dapper.QueryFirstOrDefaultAsync<User>($"select * from users where usercode=@UserCode", new { token.UserCode });

        if (user == default)
            return ApiResult.Fail<UserInfoModel>("登录用户无效！");

        //_dapper.Query("select * from users where ");



        //var menus = user.UserRoles
        //    .SelectMany(ur => ur.Role.RoleMenus.Select(rm => rm.Menu))
        //    .GroupBy(m => m.Id, m => m, (k, v) => v.First())
        //    .ToList();

        //return ApiResult.Success(new UserInfoModel(user.UserName, menus));
        return ApiResult.Success(new UserInfoModel(user.UserName, default));
    }


    [HttpPost]
    [Authorize]
    public async Task<ApiResult<bool>> UpdatePassWord(string oldPassWord, string newPassWord, [FromServices] AccessToken token)
    {
        var user = await _dapper.QueryFirstOrDefaultAsync<User>($"select * from users where usercode=@UserCode", new { token.UserCode });

        if (user == default)
            return ApiResult.Fail<bool>("登录用户无效！");

        if (user.UserPassword != oldPassWord)
            return ApiResult.Fail<bool>("旧密码错误！");


        var res = await _dapper.ExecuteAsync($"update users set userpassword=@Password where usercode=@UserCode", new { token.UserCode, Password = newPassWord });

        return res == 1 ? ApiResult.Success(true) : ApiResult.Fail<bool>("修改失败！");
    }





}
