namespace WXTool.Web.Config;

/// <summary>
/// 系统设置映射实体 
/// </summary>
public class AppSettings
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public Dictionary<string, string> ConnectionStrings { get; set; }

    /// <summary>
    /// Token配置
    /// </summary>
    public TokenConfig TokenConfig { get; set; }
    /// <summary>
    /// 跨域配置
    /// </summary>
    public CorsConfig CorsConfig { get; set; }

    /// <summary>
    /// 是否使用SPAd代理
    /// </summary>
    public SpaConfig SpaConfig { get; set; }


}



/// <summary>
/// Token颁发配置
/// </summary>
public class TokenConfig
{
    /// <summary>
    /// 秘钥
    /// </summary>
    public string Secret { get; set; }
    /// <summary>
    /// 发行者
    /// </summary>
    public string Issuer { get; set; }
    /// <summary>
    /// 接收者
    /// </summary>
    public string Audience { get; set; }
    /// <summary>
    /// 过期时间
    /// </summary>
    public int AccessExpiration { get; set; }
    /// <summary>
    /// 暂时无用
    /// </summary>
    public int RefreshExpiration { get; set; }
}



/// <summary>
/// 跨域配置
/// </summary>
public class CorsConfig
{
    /// <summary>
    /// 启用
    /// </summary>
    public bool Enable { get; set; }

    /// <summary>
    /// 策略名称
    /// </summary>
    public string PolicyName { get; set; }
    /// <summary>
    /// 支持所有IP
    /// </summary>
    public bool SupportAllIPs { get; set; }
    /// <summary>
    /// 支持的IP，多个IP用逗号分隔
    /// </summary>
    public string IPs { get; set; }
}


/// <summary>
/// SPA配置
/// </summary>
public class SpaConfig
{
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enable { get; set; }
    /// <summary>
    /// 开发模式SPA开发服务器的代理URL
    /// </summary>
    public string DevUrl { get; set; }
    /// <summary>
    /// 生产模式代理到build后的源文件目录
    /// </summary>
    public string SourcePath { get; set; }
    /// <summary>
    /// 根路径
    /// </summary>
    public string RootPath { get; set; }
}