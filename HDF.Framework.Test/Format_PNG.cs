using System.IO.Compression;
using System.Net;
using System.Text;

namespace HDF.Framework.Test
{
    internal class Format_PNG
    {
        static void Test()
        {



            {
                //using OpenFileDialog dialog = new OpenFileDialog();
                //dialog.ShowDialog();


                var filename = @"C:\Users\12131\Desktop\Logo.png";

                var stream = File.Open(filename, FileMode.Open);







                //PngBitmapDecoder decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);



                //png文件标准结构，8位固定字节
                if (stream.ReadByte() != 137) return;
                if (stream.ReadByte() != 80) return;
                if (stream.ReadByte() != 78) return;
                if (stream.ReadByte() != 71) return;
                if (stream.ReadByte() != 13) return;
                if (stream.ReadByte() != 10) return;
                if (stream.ReadByte() != 26) return;
                if (stream.ReadByte() != 10) return;

                byte[] bytes = new byte[4];

                while (stream.Read(bytes, 0, 4) != 0)
                {
                    //if (BitConverter.IsLittleEndian)
                    //    Array.Reverse(bytes);

                    var len = BitConverter.ToInt32(bytes, 0);

                    //除了手动颠倒byte数组顺序，还可以用.Net类库自带方法进行大小端字节转换（网络字节序->主机字节序）
                    if (BitConverter.IsLittleEndian)
                        len = IPAddress.NetworkToHostOrder(len);


                    stream.Read(bytes, 0, 4);
                    var id = Encoding.ASCII.GetString(bytes, 0, 4);



                    if (id == "IHDR")
                    {//len=13
                        stream.Read(bytes, 0, 4);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        var w = BitConverter.ToInt32(bytes, 0);

                        stream.Read(bytes, 0, 4);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        var h = BitConverter.ToInt32(bytes, 0);

                        var bitdepth = stream.ReadByte();
                        var colortype = stream.ReadByte();
                        var Compressionmethod = stream.ReadByte();
                        var Filtermethod = stream.ReadByte();
                        var Interlacemethod = stream.ReadByte();
                    }
                    else if (id == "pHYs")
                    {//len=9
                        stream.Read(bytes, 0, 4);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        var x = BitConverter.ToInt32(bytes, 0);

                        stream.Read(bytes, 0, 4);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        var y = BitConverter.ToInt32(bytes, 0);

                        var unit = stream.ReadByte();
                    }
                    else if (id == "IDAT")
                    {
                        bytes = new byte[len];
                        stream.Read(bytes, 0, len);



                        MemoryStream compressed = new MemoryStream(bytes); // 这里举例用的是内存中的数据；需要对文本进行压缩的话，使用 FileStream 即可
                        MemoryStream uncompressed = new MemoryStream();
                        DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Decompress); // 注意：这里第一个参数填写的是压缩后的数据应该被输出到的地方
                        deflateStream.CopyTo(uncompressed); // 用 CopyTo 将需要压缩的数据一次性输入；也可以使用Write进行部分输入
                        deflateStream.Close();  // 在Close中，会先后执行 Finish 和 Flush 操作。
                        byte[] result = uncompressed.ToArray();




                    }


                    stream.Read(bytes, 0, 4);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                }


            }





        }
    }
}
