using System.ComponentModel.DataAnnotations.Schema;

namespace WXTool.Web.Models;

public class Menu : BaseEntity
{
    /// <summary>
    /// 菜单主键
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MenuId { get; set; }

    /// <summary>
    /// 菜单编码
    /// </summary>
    public string MenuCode { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string MenuName { get; set; }

    /// <summary>
    /// 父级菜单ID
    /// </summary>
    public int ParentId { get; set; }


}
