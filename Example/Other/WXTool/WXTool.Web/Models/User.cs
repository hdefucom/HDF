using System.ComponentModel.DataAnnotations.Schema;

namespace WXTool.Web.Models;

public class User : BaseEntity
{
    /// <summary>
    /// 用户主键
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    /// <summary>
    /// 用户编码（用户名）   
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 用户密码
    /// </summary>
    public string UserPassword { get; set; }


    public List<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
