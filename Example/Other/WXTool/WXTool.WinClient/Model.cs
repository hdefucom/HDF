namespace WXTool.WinClient;

/// <summary>
/// 微信用户实体（包括个人、群聊、公众号）
/// </summary>
public class WxUserSimple
{
    public string wxid { get; set; }


    /// <summary>
    /// 显示名称
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 微信号
    /// </summary>
    public string wxcode { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string remarks { get; set; }
    /// <summary>
    /// 头像图片
    /// </summary>
    public string headimg { get; set; }


    public string Lable => $"{name}{(string.IsNullOrEmpty(remarks) ? "" : $"({remarks})")}";

}

public class WxChatMemberSimple
{
    public string nickname { get; set; }
    public string roomid { get; set; }
    public string wxid { get; set; }
    public string label => $"{nickname} | {wxid}";
}

public class WxServerSendData
{
    public string id { get; set; }
    public string wxid { get; set; }
    public object content { get; set; }
    public int type { get; set; }
    public string roomid { get; set; }
}


public class WxServerRecData
{
    public string id { get; set; }
    public string id1 { get; set; }
    public string roomsender => id1;
    public bool isroom => wxid?.EndsWith("@chatroom") ?? false;



    public string wxid { get; set; }
    public object content { get; set; }
    public int type { get; set; }
    public string sender { get; set; }
    public string time { get; set; }
    public string status { get; set; }
    public int srvid { get; set; }
    public string receiver { get; set; }
}

public class WxUserDetail
{
    public string big_headimg { get; set; }
    public string city { get; set; }
    public string cover { get; set; }
    public string little_headimg { get; set; }
    public string name1 { get; set; }
    public string name2 { get; set; }
    public string nation { get; set; }
    public string provice { get; set; }
    public string signature { get; set; }
    public string v1 { get; set; }
    public string wxcode { get; set; }
}
