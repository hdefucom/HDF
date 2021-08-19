using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    internal class Stream3 : CryptoStream
    {
        private const int int_0 = 10;

        private const int int_1 = 16;

        private Stream stream_0;

        private Class225 class225_0;

        private byte[] byte_0;

        private int int_2;

        private int int_3;

        private int int_4;

        public Stream3(Stream stream_1, Class225 class225_1, CryptoStreamMode cryptoStreamMode_0) : base(stream_1, class225_1, cryptoStreamMode_0)
        {

            int num = 9;
            //base._002Ector(stream_1, class225_1, cryptoStreamMode_0);
            stream_0 = stream_1;
            class225_0 = class225_1;
            byte_0 = new byte[1024];
            int_4 = 26;
            if (cryptoStreamMode_0 != 0)
            {
                throw new Exception("ZipAESStream only for read");
            }
        }

        public override int Read(byte[] outBuffer, int offset, int count)
        {
            int num = 17;
            int num2 = 0;
            while (num2 < count)
            {
                int num3 = int_3 - int_2;
                int num4 = int_4 - num3;
                if (byte_0.Length - int_3 < num4)
                {
                    int num5 = 0;
                    int num6 = int_2;
                    while (num6 < int_3)
                    {
                        byte_0[num5] = byte_0[num6];
                        num6++;
                        num5++;
                    }
                    int_3 -= int_2;
                    int_2 = 0;
                }
                int num7 = stream_0.Read(byte_0, int_3, num4);
                int_3 += num7;
                num3 = int_3 - int_2;
                if (num3 >= int_4)
                {
                    class225_0.TransformBlock(byte_0, int_2, 16, outBuffer, offset);
                    num2 += 16;
                    offset += 16;
                    int_2 += 16;
                    continue;
                }
                if (num3 > 10)
                {
                    int num8 = num3 - 10;
                    class225_0.TransformBlock(byte_0, int_2, num8, outBuffer, offset);
                    num2 += num8;
                    int_2 += num8;
                }
                else if (num3 < 10)
                {
                    throw new Exception("Internal error missed auth code");
                }
                byte[] array = class225_0.method_1();
                for (int i = 0; i < 10; i++)
                {
                    if (array[i] != byte_0[int_2 + i])
                    {
                        throw new Exception("AES Authentication Code does not match. This is a super-CRC check on the data in the file after compression and encryption. \r\nThe file may be damaged.");
                    }
                }
                break;
            }
            return num2;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
