using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace HDF.Framework.Test;

internal class Dynamic类型拓展
{
}


public class TestDynamic : DynamicObject
{

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return new List<string>() { "A", "B" };
    }



    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {


        return base.TryGetMember(binder, out result);
    }




    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        return base.TrySetMember(binder, value);
    }






    public void Test([CallerFilePath] string str = "")
    {
        dynamic obj = this;

        var res = obj.A;


    }





}


