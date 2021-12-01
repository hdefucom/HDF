using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WXTool.WebService.Function;

namespace WXTool.WebService;

public partial class FormMain : Form
{

    #region 消息枚举

    public const int HEART_BEAT = 5005;
    public const int RECV_TXT_MSG = 1;
    public const int RECV_PIC_MSG = 3;
    public const int USER_LIST = 5000;
    public const int GET_USER_LIST_SUCCSESS = 5001;
    public const int GET_USER_LIST_FAIL = 5002;
    public const int TXT_MSG = 555;
    public const int PIC_MSG = 500;
    public const int AT_MSG = 550;
    public const int CHATROOM_MEMBER = 5010;
    public const int CHATROOM_MEMBER_NICK = 5020;
    public const int PERSONAL_INFO = 6500;
    public const int DEBUG_SWITCH = 6000;
    public const int PERSONAL_DETAIL = 6550;

    #endregion


    WebSocket WxSocket;

    List<WxUserSimple> WxUsers = new List<WxUserSimple>();


    public FormMain()
    {
        InitializeComponent();
        this.dgv_UserList.AutoGenerateColumns = false;
    }



    private void FormMain_Load(object sender, EventArgs e)
    {
        var port = Read("CONFIG", "prot", "5555", "C:\\temp\\wechat\\config.ini");
        this.txt_Url.Text = $"ws://127.0.0.1:{port}";
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (WxSocket?.ReadyState == WebSocketState.Open)
            WxSocket.Close(CloseStatusCode.Normal, "主动关闭");
    }

    private void 注入微信ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new FormInject().ShowDialog();
    }

    private void 清空消息记录ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        txt_Record.Clear();
    }


    private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        txt_Log.Clear();
    }

    private void 获取好友列表ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var sendContent = new
        {
            id = DateTime.Now.ToString("yyyyMMddHHmmss"),
            type = USER_LIST,
            content = "user list",
            wxid = "null"
        }.ObjectToJson();

        WxSocket.SendAsync(sendContent, (result) =>
        {
            Log($"【获取用户列表】 发送数据：{sendContent}\n结果：{result}");
        });
    }




    private void btn_Connect_Click(object sender, EventArgs _)
    {
        if (string.IsNullOrEmpty(txt_Url.Text))
        {
            Log("请先设置url");
            return;
        }
        WxSocket = new WebSocket(txt_Url.Text);
        WxSocket.OnOpen += (_, _) =>
        {
            Log($"【WS连接事件】：已连接到{txt_Url.Text}");
            lbl_Status.Invoke(() =>
            {
                lbl_Status.ForeColor = Color.Green;
                lbl_Status.Text = "已连接";
            });
        };
        WxSocket.OnClose += (_, e) =>
        {
            Log($"【WS关闭事件】：与{txt_Url.Text}的连接以关闭，原因：{e.Reason}");
            lbl_Status.Invoke(() =>
            {
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "未连接";
            });
        };
        WxSocket.OnError += (_, e) =>
        {
            Log($"【WS错误事件】");
            Log($"【错误类型】:{e?.Exception?.GetType()}");
            Log($"【错误堆栈】:{e?.Exception?.StackTrace}");
        };
        WxSocket.OnMessage += (_, e) =>
        {
            if (e == null)
                Log($"【WS信息事件】：获取到空信息");
            else if (e.IsText)
                this.Invoke(() => HandleMessage(e.Data));
            else
                Log($"【WS信息事件】：获取到无法处理的事件，消息内容：\n{e}");
        };

        try
        {
            WxSocket.ConnectAsync();
        }
        catch (Exception ex)
        {
            Log($"【WS连接错误】");
            Log($"【错误类型】:{ex?.GetType()}");
            Log($"【错误堆栈】:{ex?.StackTrace}");
        }

    }

    private void btn_Disconnect_Click(object sender, EventArgs e)
    {
        if (WxSocket == null || WxSocket.ReadyState != WebSocketState.Open)
        {
            Log($"***********未连接***********");
            return;
        }

        WxSocket.Close(CloseStatusCode.Normal, "主动关闭");
    }



    private void Log(string log) => txt_Log.Invoke(() => txt_Log.AppendText($"【{DateTime.Now}】：{log}{Environment.NewLine}"));
    private void Record(DateTime time, string send, string msg) => txt_Record.Invoke(() => txt_Record.AppendText($"【{time}-send】：{msg}{Environment.NewLine}"));




    private void HandleMessage(string json)
    {
        var data = json.JsonToObject<WxServerRecData>();

        // 可处理
        switch (data.type)
        {
            case 0:
                Log($"xxxxx");
                break;
            case RECV_TXT_MSG:
                HandleRecTxtMsg(data);
                break;
            case HEART_BEAT:
                HandleHeartBeat(data);
                break;
            case DEBUG_SWITCH:
                //HandleSetDebug(data);
                break;
            case PERSONAL_DETAIL:
                //HandlePersonalDetail(data);
                break;
            case USER_LIST:
                HandleUserList(data);
                break;
            case GET_USER_LIST_SUCCSESS:
                HandleUserList(data);
                break;
            case GET_USER_LIST_FAIL:
                //HandleError(data);
                break;
            case CHATROOM_MEMBER_NICK:
                //HandleChatMemberNickname(data);
                break;
            default:
                //WriteLog($"{Environment.NewLine}{msg}{Environment.NewLine}");
                break;
        }



    }


    private void HandleHeartBeat(WxServerRecData data)
    {
        lbl_Status.Invoke(() => lbl_Status.Text = data.time);
        var contentJson = data.content.ObjectToJson();
        Log($"【WS处理服务器心跳】 已获取信息：{contentJson}");
    }


    private void HandleRecTxtMsg(WxServerRecData data)
    {

        var type = data.isroom ? "群聊" : "个人";


        var user = WxUsers.FirstOrDefault(u => u.wxid == data.wxid);



        var lab = user?.Lable ?? data.wxid;

        if (data.isroom)
            lab += $"({WxUsers.FirstOrDefault(u => u.wxid == data.id1)?.name ?? data.id1})";


        txt_Record.AppendText($"【{DateTime.Now}-{type}-{lab}】:{data.content}");

        if (user.name != "测试小组" && user.name != "测试群1号")
            return;

        if (data.content.ToString().ToLower().StartsWith("PMID:".ToLower()) || data.content.ToString().ToLower().StartsWith("PMID：".ToLower()))
        {
            var roomwxid = data.wxid;//群id

            var atwxid = data.id1;//成员id

            var name = WxUsers.FirstOrDefault(u => u.wxid == data.id1)?.name ?? data.id1;

            var res = data.content.ToString().Substring(5, data.content.ToString().Length - 5);

            var sendContent = new
            {
                id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                type = AT_MSG,
                content = $"你发送的是：{res}",
                wxid = atwxid,
                roomid = roomwxid,
                //nickname = member.nickname
                nickname = name,
                ext = "null"//此处为空
            }.ObjectToJson();

            WxSocket.SendAsync(sendContent, (result) =>
            {
                Log($"【发送群消息】发送数据：{sendContent}\n结果：{result}");
            });
        }
    }





    private void HandleUserList(WxServerRecData data)
    {
        var contentJson = data.content.ObjectToJson();
        var users = contentJson.JsonToObject<WxUserSimple[]>();
        Log($"【处理用户列表获取】已获取信息：{contentJson}");
        WxUsers.Clear();
        WxUsers.AddRange(users);

        //var  lists = new BindingList<WxUserSimple>();


        //BindingSource source = new BindingSource();

        dgv_UserList.Invoke(() => dgv_UserList.DataSource = new BindingList<WxUserSimple>(WxUsers));



    }








    //两个读写ini文件的API

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);


    //读取ini文件 section表示ini文件中的节点名，key表示键名 def没有查到的话返回的默认值 filePath文件路径
    public string Read(string section, string key, string def, string filePath)
    {
        StringBuilder sb = new StringBuilder(1024);
        GetPrivateProfileString(section, key, def, sb, 1024, filePath);
        return sb.ToString();
    }

}





public static class JsonExtensions
{

    public static T JsonToObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);

    public static object JsonToObject(this string json) => JsonConvert.DeserializeObject(json);


    public static string ObjectToJson(this object obj) => JsonConvert.SerializeObject(obj);



}








