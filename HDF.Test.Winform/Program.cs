using GHIS.Service.Common;
using GHIS.Service.Modules.Emr.EmrSmallTemplateCatagory;
using GHIS.Service.Modules.Emr.EmrSmallTemplateCatagory.Gen;
using GHIS.Service.Modules.System.Oauth;
using HDF.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace HDF.Test.Winform;



[Serializable]
public class DtoInfo
{
    public string Field { get; set; }
    public string Value { get; set; }


}

internal static class Program
{

    public class DtoInfoConverter : JsonConverter
    {

        public override bool CanConvert(Type t)
        {
            return typeof(DtoInfo).IsAssignableFrom(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DtoInfo dto = (DtoInfo)value;

            JObject obj = new JObject();

            obj[dto.Field] = dto.Value;

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (JObject)JObject.ReadFrom(reader);


            JProperty property = obj.Properties().FirstOrDefault();

            return new DtoInfo
            {
                Field = property.Name,
                Value = property.Value.Value<string>()
            };
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }


    public class ListoConverter : JsonConverter
    {

        public override bool CanConvert(Type t)
        {
            return typeof(List<DtoInfo>).IsAssignableFrom(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<DtoInfo> dto = (List<DtoInfo>)value;

            JObject obj = new JObject();

            foreach (var item in dto)
            {
                obj[item.Field] = item.Value;
            }

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (JObject)JObject.ReadFrom(reader);


            return obj.Properties().Select(a => new DtoInfo
            {
                Field = a.Name,
                Value = a.Value.Value<string>()
            }).ToList();
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }




    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        if (false)
        {
            ////C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中

            //{
            //    var array = Enumerable.Range(0, 100).ToArray();
            //    fixed (int* p = array)
            //    {
            //        //C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中
            //        //由于int占用4字节，long占用8字节，所以要转成long*进行 long*-1 或者使用 int*-2
            //        var len = *((long*)p - 1);
            //        var len2 = *(p - 2);
            //        var res = len == len2;//true

            //        var first = *p;//0
            //        var last = *(p + len - 1);//99

            //        p[0] = 'h';//最后array[0]==104，h的ASCII码为104
            //    }
            //}

            //{
            //    var array = Enumerable.Range(0, 100).Select(i => (char)i).ToArray();
            //    fixed (char* p = array)
            //    {
            //        var len = *((long*)p - 1);

            //        var first = *p;
            //        var last = *(p + len - 1);// 'c'

            //        p[0] = 'h';
            //    }
            //}

            {
                /*
    struct AAA
    {
    public int MyProperty { get; set; }
    }
                 */

                //var array = Enumerable.Range(0, 100).Select(i => new AAA() { MyProperty = i }).ToArray();
                //fixed (AAA* p = array)
                //{
                //    var len = *((long*)p - 1);
                //    var len2 = *(p - 2);

                //    var first = *p;
                //    var last = *(p + len - 1);// 'c'
                //}
            }

            {
                /*
                 对于基础数据类型都有明确的内存占用大小
                 */

                var s1 = sizeof(sbyte);
                var s2 = sizeof(short);
                var s3 = sizeof(int);
                var s4 = sizeof(long);

                var s5 = sizeof(byte);
                var s6 = sizeof(ushort);
                var s7 = sizeof(uint);
                var s8 = sizeof(ulong);

                var s9 = sizeof(float);
                var s10 = sizeof(double);
                var s11 = sizeof(decimal);

                var s12 = sizeof(char);
                var s13 = sizeof(bool);

                //var s14 = sizeof(nint);
                //var s15 = sizeof(nuint);

                /*
                 基础值类型的可空类型大小为基础类型的双倍
                 */

                //var s38 = sizeof(bool?);//2
                //var s39 = sizeof(byte?);//2
                //var s40 = sizeof(short?);//4
                //var s17 = sizeof(int?);//8
                //var s27 = sizeof(long?);//16
                //var s28 = sizeof(char?);//4
                //var s43 = sizeof(float?);//8
                //var s41 = sizeof(double?);//16
                //var s42 = sizeof(decimal?);//20  ??? decimal为16

                //var s16 = sizeof(ValueTuple);

                //var s18 = sizeof(Point);

                //var s19 = sizeof(IntPtr);

                //var s20 = sizeof(UIntPtr);

                //var s21 = IntPtr.Size;
                //var s22 = UIntPtr.Size;

                //var s23 = sizeof(ValueTuple<int>);
                //var s24 = sizeof(ValueTuple<int?>);
                //var s25 = sizeof(bool?);
                //var s26 = sizeof(Nullable<int>);

                //var s29 = sizeof(Rectangle);
                //var s30 = sizeof(Rectangle?);
                //var s31 = sizeof(Point?);

                //var s32 = sizeof(ValueTuple<int>?);
                //var s33 = sizeof(ValueTuple<int?>?);

                //var s34 = sizeof(ValueTuple<int, bool>?);
                //var s35 = sizeof(ValueTuple<int?, bool>?);

                //var s36 = sizeof(ValueTuple<int, bool>);
                //var s37 = sizeof(ValueTuple<int?, bool?>?);

                //fixed (string* p = array)
                //{
                //    var len = *((long*)p - 1);

                //    var first = *p;
                //    var last = *(p + len - 1);// 'c'
                //}
            }
        }

        if (false)
        {
            var str = "你好";

            var res1 = string.Join(" ", Encoding.GetEncoding("gb2312").GetBytes(str).Select(b => Convert.ToString(b, 2)));

            var res2 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 2)));
            var res3 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 16)));

            var res4 = string.Join(" ", Encoding.Unicode.GetBytes(str).Select(b => Convert.ToString(b, 16)));
            // 60 4f 7d 59 //Encoding返回的byte数组和下方明文编码相反，byte为网络字节序（大端），明文为主机字节序（小端）

            var str2 = "\u4f60 \u597d";

            //sdfsdfsdf

            var str3 = "💩";

            var res5 = string.Join(" ", Encoding.Unicode.GetBytes(str3).Select(b => Convert.ToString(b, 16)));
            var res6 = string.Join(" ", Encoding.UTF8.GetBytes(str3).Select(b => Convert.ToString(b, 16)));







            //ArrayPool

            var str4 = "123😊😊话法撒旦";

            var bytecount = Encoding.Unicode.GetByteCount(str4);
            var bytecount2 = Encoding.UTF8.GetByteCount(str4);
            var bytecount3 = Encoding.UTF32.GetByteCount(str4);


            //😊😊
            //བོད་ཡིག
            //𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟


            //判断字符是否存在emoji
            var res = Regex.IsMatch("", @"\p{Cs}");


            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine("😊");
        }

        if (false)
        {





            void SaveXml(string name, string xml, string dir, string type, string user = null)
            {
                if (type.IsNullOrWhiteSpace())
                    return;

                var tdir = $"{dir}\\{type}";
                if (user != null)
                    tdir = $"{dir}\\{user}\\{type}";


                if (!Directory.Exists(tdir))
                    Directory.CreateDirectory(tdir);

                if ((xml.Length % 4 == 0) && Regex.IsMatch(xml, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
                    xml = xml.GZipDecompressString(Encoding.UTF8);


                name = name.Replace("\r\n", "")
                        //.Replace("\n", "")
                        .Replace("\\", "")
                        .Replace("/", "")
                        .Replace(":", "")
                        .Replace("*", "")
                        .Replace("?", "")
                        .Replace("\"", "")
                        .Replace("|", "")
                        .Replace(">", "")
                        .Replace("<", "");

                var file = $"{tdir}\\{name}.xml";

                if (File.Exists(file))
                {
                    var dddd = Directory.GetFiles(tdir, name + "*");

                    file = $"{tdir}\\{name}({dddd.Length}).xml";
                }


                File.WriteAllText(file, xml);

            }


            void SelectXml(OracleConnection con, string dir, string sql, string namefield, string typefield, string contentfield, string userfield = null)
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var cmd = con.CreateCommand();

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    var name = reader[namefield].ToString();

                    var xml = reader[contentfield].ToString();

                    var type = reader[typefield].ToString();

                    if (userfield != null)
                    {
                        var user = reader[userfield].ToString();
                        SaveXml(name, xml, dir, type, user);
                    }
                    else
                        SaveXml(name, xml, dir, type);
                }
            }



            #region sql

            /* 
             
             
SELECT * FROM RECORDDETAIL --病历表


SELECT * from template_person --type ：2科室 1个人

select* from emrtemplet  a where  a.templet_id in (select c.templateid  from recorddetail c )


SELECT 
mr_class ,
mr_name,
xml_doc_new

from emrtemplet a --模板表
where  a.templet_id in (select c.templateid  from recorddetail c )


SELECT userid,name,content FROM template_person WHERE valid='1' AND TYPE=1;

SELECT DEPTID,name,content FROM template_person WHERE valid='1' AND TYPE=2;

             
             */

            #endregion



            var constr = @"Data Source=192.168.117.33/emr;User Id=nydba;Password=sa;";


            using OracleConnection con = new OracleConnection(constr);


            {
                con.Open();
                var dir = Application.StartupPath + "\\旧电子病历模板\\普通模板";

                var sql = @"
SELECT 
mr_class ,
mr_name,
xml_doc_new

from emrtemplet a
where  a.templet_id in (select c.templateid  from recorddetail c )
";

                SelectXml(con, dir, sql, "mr_name", "mr_class", "xml_doc_new");

                con.Close();
            }


            {

                con.Open();
                var dir = Application.StartupPath + "\\旧电子病历模板\\科室";

                var sql = @"SELECT DEPTID,name || memo AS name,sortid,content FROM template_person WHERE valid='1' AND TYPE=2";

                SelectXml(con, dir, sql, "name", "sortid", "content", "DEPTID");

                con.Close();
            }


            {

                con.Open();
                var dir = Application.StartupPath + "\\旧电子病历模板\\个人";

                var sql = @"
SELECT userid,name || memo AS name,sortid,content FROM template_person WHERE valid='1' AND TYPE=1
";

                SelectXml(con, dir, sql, "name", "sortid", "content", "userid");

                con.Close();
            }




        }

        if (false)
        {
            var constr = @" ";

            using OracleConnection con = new OracleConnection(constr);

            con.Open();


            var cmd = con.CreateCommand();
            cmd.CommandText = @"
INSERT INTO GHIS3DBA.EMR_TEMPLATE
(EMR_TEMPLATE_ID, ORG_CODE, VALID, 
VISIT_TYPE_CODE, VISIT_TYPE_NAME, 
TEMP_NAME, DOC_TYPE_CODE, DOC_TYPE_NAME, 
USED_TYPE_CODE, USED_TYPE_NAME, DEPT_CODE, DEPT_NAME, EMP_CODE, EMP_NAME, 
TEMP_CONTENT)
VALUES(:id, '360009083103360923', '1', 
:VisitTypeCode, :VisitTypeName, 
:Name, :DocTypeCode, :DocTypeName, 
:UsedTypeCode, :UsedTypeName, :DeptCode, :DeptName, :EmpCode, :EmpName,
:Content);
           
";



            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var path = dialog.SelectedPath;


            var dir = new DirectoryInfo(path);


            foreach (var type in dir.GetDirectories())
            {


                foreach (var cata in type.GetDirectories())
                {

                    foreach (var file in cata.GetFiles())
                    {
                        var xml = File.ReadAllText(file.FullName);



                    }

                }

            }




        }


        Console.WriteLine("完成");


        if (false)
        {

            var sourceText = "";


            var syntaxTree = CSharpSyntaxTree.ParseText(sourceText, new CSharpParseOptions(LanguageVersion.Latest));

            // 配置引用
            var references = new[]
            {
    typeof(object).Assembly,
    Assembly.Load("netstandard"),
    Assembly.Load("System.Runtime"),
}
            .Select(assembly => assembly.Location)
                .Distinct()
                .Select(l => MetadataReference.CreateFromFile(l))
                .Cast<MetadataReference>()
                .ToArray();

            //var assemblyName = $"DbTool.DynamicGenerated.{GuidIdGenerator.Instance.NewId()}";
            var assemblyName = $"DbTool.DynamicGenerated.{DateTime.Now:yyyyMMddHHmmss}";


            // 获取编译
            var compilation = CSharpCompilation.Create(assemblyName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);

            using var ms = new MemoryStream();
            // 生成编译结果并导出程序集信息到 stream 中
            var compilationResult = compilation.Emit(ms);
            if (compilationResult.Success)
            {
                var assemblyBytes = ms.ToArray();
                // 加载程序集
                var assembly = Assembly.Load(assemblyBytes);
            }

            var error = new StringBuilder();
            foreach (var t in compilationResult.Diagnostics)
            {
                error.AppendLine($"{t.GetMessage()}");
            }







        }





        if (false)
        {



            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Clear();
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("HisBaseUrl", "http://192.168.117.50:9090/his"));
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("MsgUrl", "http://192.168.117.50:9090/his/websocket"));
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("LoginTitle", "国讯股份一体化医院信息系统"));
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("RequestMode", "Rest"));
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("ClientSettingsProvider", ""));
            configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("EnableWindowsFormsHighDpiAutoResizing", "true"));
            configuration.Save();

            ServiceFactory.GetService<IOAuth2Service>().Login("360009083103360923", "admin", "");

            var service = ServiceFactory.GetService<IEmrSmallTemplateCatagoryService>();



            var c1 = new EmrSmallTemplateCatagoryCriteria();

            var catagoryList = service.SelectList(c1);




            var c = new EmrSmallTemplateCriteria();
            c.And().CatagoryType().IsNull();
            var tempList = service.SelectEmrSmallTemplateList(c);



            var list2 = new List<EmrSmallTemplateDto>();

            foreach (var item in tempList)
            {

                var cata = catagoryList.FirstOrDefault(c => c.TempCatagoryId == item.TempCatagoryId);
                if (cata != null)
                {
                    item.CatagoryType = cata.CatagoryType;
                    item.DeptCode = cata.DeptCode;
                    item.DeptName = cata.DeptName;
                    item.EmpCode = cata.EmpCode;
                    item.EmpName = cata.EmpName;

                    list2.Add(item);
                }

            }


            var res = list2.GroupBy(t => t.TempCatagoryId);

            foreach (var item in res)
            {

                // service.UpdateEmrSmallTemplateList(item.ToList(), false);
            }





        }


        if (false)
        {


            var xml = @" <FabrikamCustomer>
                              <Id>0001</Id>
                              <FirstName>John</FirstName>
                              <LastName>Dow</LastName>
                          </FabrikamCustomer>";

            Enumerable.Range(0, 30000)
                 .Select(i => GetCustomer(i, "FabrikamCustomer", xml))
                 .ToList();

            Console.WriteLine("处理完成！");
            Console.ReadLine();
        }







        //7890


        Application.Run(new Form2());
    }




    public static Customer GetCustomer(int i, string rootElementName, string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(Customer),
                        new XmlRootAttribute(rootElementName));

        using (var textReader = new StringReader(xml))
        {
            using (var xmlReader = XmlReader.Create(textReader))
            {
                Console.WriteLine(i);

                return (Customer)xmlSerializer.Deserialize(xmlReader);
            }
        }

    }




    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }















}










