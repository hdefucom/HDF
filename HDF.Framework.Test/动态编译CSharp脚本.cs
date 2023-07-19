using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace HDF.Framework.Test;

internal class 动态编译CSharp脚本
{


    private static string AnalysisCSharpExpression(string code)
    {

        //每次都要编译，性能太差 有ExpressionEvaluator
        try
        {
            CSharpCodeProvider cs = new CSharpCodeProvider();


            ICodeCompiler cc = cs.CreateCompiler();



            CompilerParameters cp = new CompilerParameters();




            cp.GenerateInMemory = true;//设定在内存中创建程序集
            cp.GenerateExecutable = false;//设定是否创建可执行文件,也就是exe文件或者dll文件
            cp.ReferencedAssemblies.Add("System.dll");//此处代码是添加对应dll文件的引用
            cp.ReferencedAssemblies.Add("System.Core.dll");//System.Linq存在于System.Core.dll文件中

            string strExpre = "using System;";
            strExpre += "      using System.Collections.Generic;                     ";
            strExpre += "      using System.Linq;                                    ";
            strExpre += "      using System.Text;                                    ";
            strExpre += "      using System.Threading.Tasks;                         ";

            strExpre += "      namespace HDFText{                                    ";
            strExpre += "          public class TestClass{                           ";
            strExpre += "              public string ExecuteCode(){                  ";
            strExpre += "                  var obj = default(string);                ";
            strExpre += "                  obj ??= \"Test:\";                        ";
            strExpre += "                  Func<string> func = ()=> obj + " + code + ";    ";
            strExpre += "                  return func.Invoke();                     ";
            strExpre += "              }                                             ";
            strExpre += "          }                                                 ";
            strExpre += "      }";
            CompilerResults cr = cc.CompileAssemblyFromSource(cp, strExpre);
            if (cr.Errors.HasErrors)
            {
                Func<string> func = () => "" + "(" + "".Replace("公司", "").Replace("有限", "") + ")";
                throw new Exception(cr.Errors.ToString());
            }
            else
            {
                //5.创建一个Assembly对象
                Assembly ass = cr.CompiledAssembly;//动态编译程序集
                object obj = ass.CreateInstance("HDFText.TestClass");
                MethodInfo mi = obj.GetType().GetMethod("ExecuteCode");
                return mi.Invoke(obj, null).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return "";
    }
}
