using DCSoft.Design.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass136
	{
		private static ImageList imageList_0 = null;

		public static ImageList smethod_0()
		{
			if (imageList_0 == null)
			{
				imageList_0 = new ImageList();
				imageList_0.TransparentColor = Color.White;
				imageList_0.Images.Add(DataBaseSchemaResource.DataBase);
				imageList_0.Images.Add(DataBaseSchemaResource.Field);
				imageList_0.Images.Add(DataBaseSchemaResource.Key);
				imageList_0.Images.Add(DataBaseSchemaResource.Table);
				imageList_0.Images.Add(DataBaseSchemaResource.Bitmap_0);
				imageList_0.Images.Add(DataBaseSchemaResource.SQLServer);
				imageList_0.Images.Add(DataBaseSchemaResource.Assembly);
			}
			return imageList_0;
		}

		public static int smethod_1(object object_0)
		{
			if (object_0 is DataBaseSchema)
			{
				DataBaseSchema dataBaseSchema = (DataBaseSchema)object_0;
				switch (dataBaseSchema.SourceStyle)
				{
				case DataBaseSchemaSourceStyle.Access2000:
					return 4;
				case DataBaseSchemaSourceStyle.SQLServer:
					return 5;
				default:
					return 0;
				case DataBaseSchemaSourceStyle.Assembly:
					return 6;
				}
			}
			if (object_0 is DataBaseSchemaTable)
			{
				return 3;
			}
			if (object_0 is DataBaseSchemaField)
			{
				DataBaseSchemaField dataBaseSchemaField = (DataBaseSchemaField)object_0;
				if (dataBaseSchemaField.PrimaryKey)
				{
					return 2;
				}
				return 1;
			}
			return 0;
		}

		public static Image smethod_2(object object_0)
		{
			int index = smethod_1(object_0);
			return smethod_0().Images[index];
		}
	}
}
