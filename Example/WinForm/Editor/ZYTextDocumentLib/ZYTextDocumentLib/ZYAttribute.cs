using System;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYAttribute
	{
		private string strName = null;

		private object objValue = null;

		public object DefaultValue = null;

		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
				DefaultValue = GetDefaultValue(strName);
			}
		}

		public object Value
		{
			get
			{
				if (objValue == null)
				{
					return DefaultValue;
				}
				return objValue;
			}
			set
			{
				objValue = value;
			}
		}

		public string ValueString
		{
			get
			{
				if (DefaultValue is bool)
				{
					if ((bool)objValue)
					{
						return "1";
					}
					return null;
				}
				if (DefaultValue is Color)
				{
					return StringCommon.ColorToHtml((Color)objValue);
				}
				if (objValue == null)
				{
					return null;
				}
				return objValue.ToString();
			}
			set
			{
				if (DefaultValue is bool)
				{
					objValue = (value != null);
				}
				else if (DefaultValue is Color)
				{
					objValue = StringCommon.ColorFromHtml(value, Color.Black);
				}
				else if (DefaultValue is ParagraphAlignConst)
				{
					objValue = (ParagraphAlignConst)StringCommon.ToInt32Value(value, (int)DefaultValue);
				}
				else if (DefaultValue is int)
				{
					objValue = StringCommon.ToInt32Value(value, (int)DefaultValue);
				}
				else if (DefaultValue is float)
				{
					objValue = Convert.ToSingle(value);
				}
				else
				{
					objValue = value;
				}
			}
		}

		internal void SetValue(object v)
		{
			objValue = v;
		}

		public ZYAttribute Clone()
		{
			ZYAttribute zYAttribute = new ZYAttribute();
			zYAttribute.Name = strName;
			zYAttribute.objValue = objValue;
			zYAttribute.DefaultValue = DefaultValue;
			return zYAttribute;
		}

		public bool EqualsValue(ZYAttribute myAttr)
		{
			if (myAttr == null)
			{
				return false;
			}
			if (myAttr == this)
			{
				return true;
			}
			if (myAttr.Name != strName)
			{
				return false;
			}
			if (Value != null)
			{
				return Value.Equals(myAttr.Value);
			}
			return myAttr.Value == null;
		}

		public bool isNeedSave()
		{
			if (objValue == null)
			{
				return false;
			}
			if (objValue.Equals(DefaultValue))
			{
				return false;
			}
			if (objValue is bool)
			{
				return (bool)objValue;
			}
			return true;
		}

		public static object GetDefaultValue(string strName)
		{
			switch (strName)
			{
			case "fontname":
				return ZYFont.GetFontNameForCurrentSystem(ZYConfig.FontName);
			case "fontsize":
				return ZYConfig.FontSize;
			case "fontbold":
				return false;
			case "fontitalic":
				return false;
			case "fontunderline":
				return false;
			case "forecolor":
				return SystemColors.WindowText;
			case "sub":
				return false;
			case "sup":
				return false;
			case "deleter":
				return -1;
			case "creator":
				return 0;
			case "savelist":
				return true;
			case "align":
				return 0;
			case "source":
				return "0000000000";
			case "listsource":
				return "0000000000";
			case "saveinfile":
				return false;
			case "multiple":
				return false;
			case "hidetitle":
				return false;
			case "height":
				return 1;
			case "nocontent":
				return false;
			case "titleline":
				return false;
			case "titlealign":
				return "left";
			case "textalign":
				return "left";
			case "need":
				return false;
			case "rightborder":
				return 1;
			case "topborder":
				return 1;
			case "bottomborder":
				return 1;
			case "leftborder":
				return 1;
			default:
				return null;
			}
		}
	}
}
