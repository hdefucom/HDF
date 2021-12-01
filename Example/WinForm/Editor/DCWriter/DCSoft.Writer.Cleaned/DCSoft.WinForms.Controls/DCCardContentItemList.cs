using DCSoft.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片内容项目列表
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCCardContentItemList : List<DCCardContentItem>
	{
		/// <summary>
		///       或者指定字段名的卡片内容对象
		///       </summary>
		/// <param name="fieldName">字段名</param>
		/// <returns>获得的卡片内容对象</returns>
		public DCCardContentItem GetItemByFieldName(string fieldName)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCCardContentItem current = enumerator.Current;
					if (string.Compare(current.DataField, fieldName, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       添加图片列表元素
		///       </summary>
		/// <param name="fieldName">绑定的字段名</param>
		/// <param name="key">图片关键字</param>
		/// <param name="left">左端位置</param>
		/// <param name="top">顶端位置</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>创建的文本项目对象</returns>
		public DCCardImageListKeyItem AddImageListKey(string fieldName, string string_0, int left, int int_0, int width, int height)
		{
			DCCardImageListKeyItem dCCardImageListKeyItem = new DCCardImageListKeyItem();
			dCCardImageListKeyItem.DataField = fieldName;
			dCCardImageListKeyItem.ImageKey = string_0;
			dCCardImageListKeyItem.Left = left;
			dCCardImageListKeyItem.Top = int_0;
			dCCardImageListKeyItem.Width = width;
			dCCardImageListKeyItem.Height = height;
			Add(dCCardImageListKeyItem);
			return dCCardImageListKeyItem;
		}

		/// <summary>
		///       添加文本项目
		///       </summary>
		/// <param name="fieldName">绑定的字段名</param>
		/// <param name="text">默认文本</param>
		/// <param name="left">左端位置</param>
		/// <param name="top">顶端位置</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>创建的文本项目对象</returns>
		public DCCardStringItem AddString(string fieldName, string text, int left, int int_0, int width, int height)
		{
			DCCardStringItem dCCardStringItem = new DCCardStringItem();
			dCCardStringItem.DataField = fieldName;
			dCCardStringItem.Text = text;
			dCCardStringItem.Left = left;
			dCCardStringItem.Top = int_0;
			dCCardStringItem.Width = width;
			dCCardStringItem.Height = height;
			Add(dCCardStringItem);
			return dCCardStringItem;
		}

		/// <summary>
		///       添加矩形项目
		///       </summary>
		/// <param name="borderColor">边框色</param>
		/// <param name="backColor">背景色</param>
		/// <param name="left">左端位置</param>
		/// <param name="top">顶端位置</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>添加的项目</returns>
		public DCCardRectangleItem AddRectangle(Color borderColor, Color backColor, int left, int int_0, int width, int height)
		{
			DCCardRectangleItem dCCardRectangleItem = new DCCardRectangleItem();
			dCCardRectangleItem.BorderColor = borderColor;
			dCCardRectangleItem.BackColor = backColor;
			dCCardRectangleItem.Left = left;
			dCCardRectangleItem.Top = int_0;
			dCCardRectangleItem.Width = width;
			dCCardRectangleItem.Height = height;
			Add(dCCardRectangleItem);
			return dCCardRectangleItem;
		}

		/// <summary>
		///       添加图片项目
		///       </summary>
		/// <param name="fieldName">字段名</param>
		/// <param name="img">默认图片</param>
		/// <param name="left">左端位置</param>
		/// <param name="top">顶端位置</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>添加的项目</returns>
		public DCCardImageItem AddImage(string fieldName, Image image_0, int left, int int_0, int width, int height)
		{
			DCCardImageItem dCCardImageItem = new DCCardImageItem();
			dCCardImageItem.Image = image_0;
			dCCardImageItem.DataField = fieldName;
			dCCardImageItem.Left = left;
			dCCardImageItem.Top = int_0;
			dCCardImageItem.Width = width;
			dCCardImageItem.Height = height;
			Add(dCCardImageItem);
			return dCCardImageItem;
		}
	}
}
