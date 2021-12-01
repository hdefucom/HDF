using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class ZYAttributeCollection : CollectionBase
	{
		private bool bolModified = false;

		public ZYTextElement OwnerElement;

		public bool Modified
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		public ZYAttribute this[string strName]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
						if (zYAttribute.Name == strName)
						{
							return zYAttribute;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		public bool EqualsValue(ZYAttributeCollection a)
		{
			if (a == null)
			{
				return false;
			}
			if (a == this)
			{
				return true;
			}
			return ToListString() == a.ToListString();
		}

		public void CopyTo(ZYAttributeCollection descSet)
		{
			descSet.List.Clear();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					descSet.List.Add(zYAttribute.Clone());
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void RemoveAttribute(string strName)
		{
			ZYAttribute zYAttribute = this[strName];
			if (zYAttribute != null)
			{
				base.List.Remove(zYAttribute);
			}
		}

		protected override void OnClear()
		{
			base.OnClear();
			bolModified = true;
		}

		public bool Contains(string strName)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.Name == strName)
					{
						return true;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return false;
		}

		public void SetValue(string strName, object vValue)
		{
			ZYAttribute zYAttribute = null;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute2 = (ZYAttribute)enumerator.Current;
					if (zYAttribute2.Name == strName)
					{
						zYAttribute = zYAttribute2;
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (zYAttribute == null)
			{
				zYAttribute = new ZYAttribute();
				zYAttribute.Name = strName;
				base.List.Add(zYAttribute);
			}
			if ((zYAttribute.Value == null || !zYAttribute.Value.Equals(vValue)) && (zYAttribute.Value != null || vValue != null))
			{
				if (OwnerElement != null && OwnerElement.OwnerDocument != null && OwnerElement.OwnerDocument.ContentChangeLog != null)
				{
					OwnerElement.OwnerDocument.ContentChangeLog.LogAttribute(OwnerElement, zYAttribute, vValue);
					OwnerElement.OwnerDocument.Modified = true;
				}
				zYAttribute.Value = vValue;
				bolModified = true;
			}
		}

		public bool SetDefaultValue()
		{
			bool result = false;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					object defaultValue = ZYAttribute.GetDefaultValue(zYAttribute.Name);
					if (defaultValue != null && defaultValue.Equals(zYAttribute.Value))
					{
						if (OwnerElement != null && OwnerElement.OwnerDocument != null && OwnerElement.OwnerDocument.ContentChangeLog != null)
						{
							OwnerElement.OwnerDocument.ContentChangeLog.LogAttribute(OwnerElement, zYAttribute, defaultValue);
						}
						zYAttribute.Value = defaultValue;
						bolModified = true;
						result = true;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}

		public bool GetBool(string strName)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.Name == strName)
					{
						return (bool)zYAttribute.Value;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return (bool)ZYAttribute.GetDefaultValue(strName);
		}

		public int GetInt32(string strName)
		{
			try
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
						if (zYAttribute.Name == strName)
						{
							return Convert.ToInt32(zYAttribute.Value);
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return (int)ZYAttribute.GetDefaultValue(strName);
			}
			catch
			{
				return 0;
			}
		}

		public float GetFloat(string strName)
		{
			try
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
						if (zYAttribute.Name == strName)
						{
							return Convert.ToSingle(zYAttribute.Value);
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return (float)ZYAttribute.GetDefaultValue(strName);
			}
			catch
			{
				return 0f;
			}
		}

		public string GetString(string strName)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.Name == strName)
					{
						return Convert.ToString(zYAttribute.Value);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return Convert.ToString(ZYAttribute.GetDefaultValue(strName));
		}

		public Color GetColor(string strName)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.Name == strName)
					{
						return (Color)zYAttribute.Value;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return SystemColors.WindowText;
		}

		public bool FromXML(XmlElement myElement)
		{
			Clear();
			if (myElement == null)
			{
				return false;
			}
			foreach (XmlAttribute attribute in myElement.Attributes)
			{
				ZYAttribute zYAttribute = new ZYAttribute();
				zYAttribute.Name = attribute.Name;
				zYAttribute.ValueString = attribute.Value;
				if (zYAttribute.Value != zYAttribute.DefaultValue)
				{
					base.List.Add(zYAttribute);
				}
			}
			bolModified = false;
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement == null)
			{
				return false;
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.isNeedSave())
					{
						string valueString = zYAttribute.ValueString;
						if (valueString != null)
						{
							myElement.SetAttribute(zYAttribute.Name, zYAttribute.ValueString);
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return true;
		}

		public string ToListString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYAttribute zYAttribute = (ZYAttribute)enumerator.Current;
					if (zYAttribute.isNeedSave())
					{
						string valueString = zYAttribute.ValueString;
						if (valueString != null)
						{
							stringBuilder.Append(zYAttribute.Name + "=" + valueString);
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return stringBuilder.ToString();
		}
	}
}
