namespace WXTool.Web.Models;

public abstract class BaseEntity
{
    public bool IsValid { get; set; }

    public string CreateUserCode { get; set; }

    public DateTime? CreateTime { get; set; }

    public string ModifyUserCode { get; set; }

    public DateTime? ModifyTime { get; set; }

    public string DeleteUserCode { get; set; }

    public DateTime? DeleteTime { get; set; }

}
