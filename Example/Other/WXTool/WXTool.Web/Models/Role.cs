using System.ComponentModel.DataAnnotations.Schema;

namespace WXTool.Web.Models;

public class Role : BaseEntity
{
    /// <summary>
    /// 角色主键
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    /// <summary>
    /// 角色编码
    /// </summary>
    public string RoleCode { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; set; }

}
