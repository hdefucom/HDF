using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace WinFormsApp1;

static class Program
{




    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    //[MTAThread]
    static unsafe void Main()
    {






        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        Application.Run(new Form5());


    }



}






#region EventBus Test








class Test1 : IInputData<int>
{
    public void InputData(int data)
    {
        throw new NotImplementedException();
    }
}


class Test2 : IInputData<string>
{
    public void InputData(string data)
    {
        throw new NotImplementedException();
    }
}










public interface IInputData<in T>
{
    /// <summary>
    /// 接收数据
    /// </summary>
    /// <param name="data"></param>
    void InputData(T data);
}

public interface IOutputData<out T>
{
    ///// <summary>
    ///// 被动输出数据
    ///// </summary>
    //T OutputData();

    /// <summary>
    /// 主动输出数据的事件
    /// </summary>
    event Action<T> OutputData;
}





public class EventBus
{
    private static EventBus _instance;

    public static EventBus Instance => _instance ??= new EventBus();



    private Dictionary<Type, IInputData<object>> dict = new Dictionary<Type, IInputData<object>>();





    private EventBus()
    {



    }

    public void Register<T>(IInputData<T> input)
    {
        //dict[input.GetType()] = input;

    }

    public void Publish<T>(T data)
    {
        if (dict.TryGetValue(data.GetType(), out var input))
            input.InputData(data);
    }









}


class Test : IInputData<int>
{
    public void InputData(int data)
    {

    }
}




class Publisher
{
    public void PublishTeatAEvent(string value)
    {

        //EventBus.Instance.Register();

        //EventBus.Instance.GetEvent<TestAEvent>().Publish(this, new TestAEventArgs() { Value = value });
    }

    public void PublishTeatBEvent(int value)
    {
        //EventBus.Instance.GetEvent<TestBEvent>().Publish(this, new TestBEventArgs() { Value = value });
    }
}

class ScbscriberA
{
    public string Name { get; set; }

    public ScbscriberA(string name)
    {
        Name = name;
        //EventBus.Instance.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
    }

    //public void TeatAEventHandler(object sender, TestAEventArgs e)
    //{
    //    //Console.WriteLine(Name + ":" + e.Value);
    //}
}

#endregion





