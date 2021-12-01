namespace WXTool.Web.Models;

public class Users : BaseEntity
{
    /// <summary>
    /// ??????    
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// ????(???)    
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// ????    
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// ????    
    /// </summary>
    public byte[] UserPassword { get; set; }


}
