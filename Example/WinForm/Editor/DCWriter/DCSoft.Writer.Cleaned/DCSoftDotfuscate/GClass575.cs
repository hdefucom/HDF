using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    public class GClass575 : GClass574
    {
        private Stream stream_0;

        private string string_0;

        private string string_1;

        public GClass575(GClass571 gclass571_0, GEnum100 genum100_1) : base(genum100_1)
        {
            int num = 17;
            //base._002Ector(genum100_1);
            if (gclass571_0.Name == null)
            {
                throw new GException24("Cant handle non file archives");
            }
            string_0 = gclass571_0.Name;
        }

        public GClass575(GClass571 gclass571_0)
            : this(gclass571_0, GEnum100.const_0)
        {
        }

        public override Stream imethod_1()
        {
            if (string_1 != null)
            {
                string_1 = smethod_0(string_1, bool_0: true);
                stream_0 = File.Open(string_1, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            }
            else
            {
                string_1 = Path.GetTempFileName();
                stream_0 = File.Open(string_1, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            }
            return stream_0;
        }

        public override Stream imethod_2()
        {
            int num = 7;
            if (stream_0 == null)
            {
                throw new GException24("No temporary stream has been created");
            }
            Stream stream = null;
            string text = smethod_0(string_0, bool_0: false);
            bool flag = false;
            try
            {
                stream_0.Close();
                File.Move(string_0, text);
                File.Move(string_1, string_0);
                flag = true;
                File.Delete(text);
                return File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception)
            {
                stream = null;
                if (!flag)
                {
                    File.Move(text, string_0);
                    File.Delete(string_1);
                }
                throw;
            }
        }

        public override Stream imethod_3(Stream stream_1)
        {
            stream_1.Close();
            string_1 = smethod_0(string_0, bool_0: true);
            File.Copy(string_0, string_1, overwrite: true);
            stream_0 = new FileStream(string_1, FileMode.Open, FileAccess.ReadWrite);
            return stream_0;
        }

        public override Stream imethod_4(Stream stream_1)
        {
            if (!(stream_1?.CanWrite ?? false))
            {
                stream_1?.Close();
                return new FileStream(string_0, FileMode.Open, FileAccess.ReadWrite);
            }
            return stream_1;
        }

        public override void imethod_5()
        {
            if (stream_0 != null)
            {
                stream_0.Close();
            }
        }

        private static string smethod_0(string string_2, bool bool_0)
        {
            int num = 12;
            string text = null;
            if (string_2 == null)
            {
                text = Path.GetTempFileName();
            }
            else
            {
                int num2 = 0;
                int second = DateTime.Now.Second;
                while (text == null)
                {
                    num2++;
                    string text2 = $"{string_2}.{second}{num2}.tmp";
                    if (!File.Exists(text2))
                    {
                        if (bool_0)
                        {
                            try
                            {
                                using (File.Create(text2))
                                {
                                }
                                text = text2;
                            }
                            catch
                            {
                                second = DateTime.Now.Second;
                            }
                        }
                        else
                        {
                            text = text2;
                        }
                    }
                }
            }
            return text;
        }
    }
}
