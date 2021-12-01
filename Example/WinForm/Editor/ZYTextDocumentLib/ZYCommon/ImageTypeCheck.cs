#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZYCommon
{
	public class ImageTypeCheck
	{
		public enum ImageType
		{
			None = 0,
			BMP = 19778,
			JPG = 55551,
			GIF = 18759,
			PCX = 1290,
			PNG = 20617,
			PSD = 16952,
			RAS = 42585,
			SGI = 55809,
			TIFF = 18761
		}

		private static SortedDictionary<int, ImageType> _imageTag = InitImageTag();

		public static readonly string ErrType = ImageType.None.ToString();

		private static SortedDictionary<int, ImageType> InitImageTag()
		{
			SortedDictionary<int, ImageType> sortedDictionary = new SortedDictionary<int, ImageType>();
			sortedDictionary.Add(19778, ImageType.BMP);
			sortedDictionary.Add(55551, ImageType.JPG);
			sortedDictionary.Add(18759, ImageType.GIF);
			sortedDictionary.Add(1290, ImageType.PCX);
			sortedDictionary.Add(20617, ImageType.PNG);
			sortedDictionary.Add(16952, ImageType.PSD);
			sortedDictionary.Add(42585, ImageType.RAS);
			sortedDictionary.Add(55809, ImageType.SGI);
			sortedDictionary.Add(18761, ImageType.TIFF);
			return sortedDictionary;
		}

		public static string CheckImageTypeName(string path)
		{
			return CheckImageType(path).ToString();
		}

		public static ImageType CheckImageType(string path)
		{
			byte[] array = new byte[2];
			try
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					int num = streamReader.BaseStream.Read(array, 0, array.Length);
					if (num != array.Length)
					{
						return ImageType.None;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.ToString());
				return ImageType.None;
			}
			return CheckImageType(array);
		}

		public static ImageType CheckImageType(byte[] buf)
		{
			if (buf == null || buf.Length < 2)
			{
				return ImageType.None;
			}
			int key = buf[1] * 256 + buf[0];
			if (_imageTag.TryGetValue(key, out ImageType value))
			{
				return value;
			}
			return ImageType.None;
		}

		public static ImageFormat CheckImageType(Image myImage)
		{
			ImageFormat rawFormat = myImage.RawFormat;
			if (rawFormat.Equals(ImageFormat.Bmp))
			{
				return ImageFormat.Bmp;
			}
			if (rawFormat.Equals(ImageFormat.Emf))
			{
				return ImageFormat.Emf;
			}
			if (rawFormat.Equals(ImageFormat.Exif))
			{
				return ImageFormat.Exif;
			}
			if (rawFormat.Equals(ImageFormat.Gif))
			{
				return ImageFormat.Gif;
			}
			if (rawFormat.Equals(ImageFormat.Icon))
			{
				return ImageFormat.Icon;
			}
			if (rawFormat.Equals(ImageFormat.Jpeg))
			{
				return ImageFormat.Jpeg;
			}
			if (rawFormat.Equals(ImageFormat.MemoryBmp))
			{
				return ImageFormat.Png;
			}
			if (rawFormat.Equals(ImageFormat.Png))
			{
				return ImageFormat.Png;
			}
			if (rawFormat.Equals(ImageFormat.Tiff))
			{
				return ImageFormat.Tiff;
			}
			if (rawFormat.Equals(ImageFormat.Wmf))
			{
				return ImageFormat.Wmf;
			}
			return ImageFormat.Png;
		}
	}
}
