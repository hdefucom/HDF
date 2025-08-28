using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace HDF.Common;

/// <summary>
/// 压缩拓展
/// </summary>
public static class CompressExtensions
{

    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// 将传入字符串以GZip算法压缩
    /// </summary>
    /// <param name="value">需要压缩的字符串</param>
    /// <param name="encoding">需要压缩字符的编码</param>
    /// <returns>压缩后的Base64编码的字符串</returns>
    public static string GZipCompressString(this string value, Encoding? encoding = null)
    {
        if (value.IsNullOrEmpty())
            return string.Empty;

        encoding ??= Encoding.Default;
        return Convert.ToBase64String(encoding.GetBytes(value).Compress());
    }

    /// <summary>
    /// 将传入的Base64字符串以GZip算法解压
    /// </summary>
    /// <param name="value">经GZip压缩后的Base64字符串</param>
    /// <param name="encoding">需要解压字符的编码</param>
    /// <returns>原始未压缩字符串</returns>
    public static string GZipDecompressString(this string value, Encoding? encoding = null)
    {
        if (value.IsNullOrEmpty())
            return string.Empty;

        encoding ??= Encoding.Default;
        return encoding.GetString(Convert.FromBase64String(value).Decompress());
    }

    /// <summary>
    /// 将传入byte[]以GZip算法压缩
    /// </summary>
    /// <param name="data">要压缩的byte[]</param>
    /// <returns>压缩后的byte[]</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static byte[] Compress(this byte[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        if (data.Length == 0)
            throw new ArgumentOutOfRangeException(nameof(data));

        using MemoryStream ms = new();
        using GZipStream compressedzipStream = new(ms, CompressionMode.Compress, true);
        compressedzipStream.Write(data, 0, data.Length);
        compressedzipStream.Close();
        return ms.ToArray();
    }

    /// <summary>
    /// 将传入byte[]以GZip算法解压
    /// </summary>
    /// <param name="data">要解压的byte[]</param>
    /// <returns>解压后的byte[]</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static byte[] Decompress(this byte[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        if (data.Length == 0)
            throw new ArgumentOutOfRangeException(nameof(data));

        using MemoryStream ms = new(data);
        using GZipStream compressedzipStream = new(ms, CompressionMode.Decompress);
        using MemoryStream outBuffer = new();
        byte[] block = new byte[1024];
        while (true)
        {
            int bytesRead = compressedzipStream.Read(block, 0, block.Length);
            if (bytesRead <= 0)
                break;
            else
                outBuffer.Write(block, 0, bytesRead);
        }
        compressedzipStream.Close();
        return outBuffer.ToArray();
    }

}

