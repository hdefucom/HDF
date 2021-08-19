using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       具有附加属性系统的对象类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[Serializable]
	public abstract class XDependencyObject
	{
		protected GClass374 gclass374_0 = new GClass374();

		private bool bool_0 = false;

		private bool bool_1 = false;

		[NonSerialized]
		[XmlIgnore]
		[DCInternal]
		public bool bool_2 = false;

		[NonSerialized]
		private GDelegate22 gdelegate22_0 = null;

		[NonSerialized]
		private GDelegate22 gdelegate22_1 = null;

		                                                                    /// <summary>
		                                                                    ///       内部的数据列表
		                                                                    ///       </summary>
		protected Dictionary<GClass371, object> InnerValues
		{
			get
			{
				gclass374_0.method_0(GetType());
				return gclass374_0;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否锁定数据
		                                                                    ///       </summary>
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(false)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ValueLocked
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       禁止默认值规则
		                                                                    ///       </summary>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[XmlIgnore]
		public bool DisableDefaultValue
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象数据发生改变时的处理，此时可以取消操作或者修改要设置的新的数值
		                                                                    ///       </summary>
		public event GDelegate22 ValueChanging
		{
			add
			{
				GDelegate22 gDelegate = gdelegate22_0;
				GDelegate22 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate22 value2 = (GDelegate22)Delegate.Combine(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate22_0, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
			remove
			{
				GDelegate22 gDelegate = gdelegate22_0;
				GDelegate22 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate22 value2 = (GDelegate22)Delegate.Remove(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate22_0, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象数据发生改变后的处理，此时仅仅通知操作，不能取消和修改新数值
		                                                                    ///       </summary>
		public event GDelegate22 ValueChanged
		{
			add
			{
				GDelegate22 gDelegate = gdelegate22_1;
				GDelegate22 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate22 value2 = (GDelegate22)Delegate.Combine(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate22_1, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
			remove
			{
				GDelegate22 gDelegate = gdelegate22_1;
				GDelegate22 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate22 value2 = (GDelegate22)Delegate.Remove(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate22_1, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
		}

		public static int smethod_0(XDependencyObject xdependencyObject_0)
		{
			return xdependencyObject_0?.gclass374_0.Count ?? 0;
		}

		public static int smethod_1(XDependencyObject xdependencyObject_0, XDependencyObject xdependencyObject_1)
		{
			if (xdependencyObject_0 == null)
			{
				return 0;
			}
			if (xdependencyObject_0 == xdependencyObject_1)
			{
				return 0;
			}
			if (xdependencyObject_0.DisableDefaultValue)
			{
				return 0;
			}
			int num = 0;
			if (xdependencyObject_1 == null)
			{
				ArrayList arrayList = new ArrayList(xdependencyObject_0.gclass374_0.Keys);
				foreach (GClass371 item in arrayList)
				{
					if (object.Equals(item.method_3(), xdependencyObject_0.gclass374_0[item]))
					{
						xdependencyObject_0.gclass374_0.Remove(item);
						xdependencyObject_0.vmethod_2(item);
						xdependencyObject_0.bool_2 = true;
						num++;
					}
				}
			}
			else
			{
				ArrayList arrayList = new ArrayList(xdependencyObject_0.gclass374_0.Keys);
				foreach (GClass371 item2 in arrayList)
				{
					foreach (GClass371 key in xdependencyObject_1.gclass374_0.Keys)
					{
						if (item2 == key && object.Equals(xdependencyObject_0.gclass374_0[item2], xdependencyObject_1.gclass374_0[item2]))
						{
							xdependencyObject_0.gclass374_0.Remove(item2);
							xdependencyObject_0.bool_2 = true;
							xdependencyObject_0.vmethod_2(item2);
							num++;
						}
					}
				}
			}
			return num;
		}

		public static void smethod_2(XDependencyObject xdependencyObject_0, string string_0, XDependencyObject xdependencyObject_1)
		{
			if (string.IsNullOrEmpty(string_0) || xdependencyObject_0 == null)
			{
				return;
			}
			string[] array = string_0.Split(',');
			foreach (string text in array)
			{
				bool flag = false;
				foreach (GClass371 key in xdependencyObject_0.InnerValues.Keys)
				{
					if (key.Name.Equals(text, StringComparison.CurrentCultureIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				GClass371 current = GClass371.smethod_2(xdependencyObject_0.GetType(), text);
				if (current != null)
				{
					if (xdependencyObject_1 != null)
					{
						xdependencyObject_0.InnerValues[current] = xdependencyObject_1.vmethod_0(current);
					}
					else
					{
						xdependencyObject_0.InnerValues[current] = current.method_3();
					}
					xdependencyObject_0.vmethod_2(current);
				}
			}
		}

		public static string smethod_3(XDependencyObject xdependencyObject_0)
		{
			int num = 13;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(key.Name + ":" + xdependencyObject_0.gclass374_0[key]);
			}
			return stringBuilder.ToString();
		}

		public static bool smethod_4(XDependencyObject xdependencyObject_0, string string_0)
		{
			int num = 4;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string_0 == null || string_0.Trim().Length == 0)
			{
				throw new ArgumentNullException("propertyName");
			}
			if (xdependencyObject_0.gclass374_0 != null && xdependencyObject_0.gclass374_0.Count > 0)
			{
				string_0 = string_0.Trim();
				foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
				{
					if (string.Compare(key.Name, string_0, ignoreCase: true) == 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static GClass371[] smethod_5(XDependencyObject xdependencyObject_0, XDependencyObject xdependencyObject_1)
		{
			int num = 15;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance1");
			}
			if (xdependencyObject_1 == null)
			{
				throw new ArgumentNullException("instance2");
			}
			List<GClass371> list = new List<GClass371>();
			foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
			{
				if (xdependencyObject_1.InnerValues.ContainsKey(key))
				{
					object obj = xdependencyObject_0.InnerValues[key];
					object obj2 = xdependencyObject_1.InnerValues[key];
					if (obj != obj2)
					{
						list.Add(key);
					}
				}
				else
				{
					list.Add(key);
				}
			}
			foreach (GClass371 key2 in xdependencyObject_1.InnerValues.Keys)
			{
				if (!list.Contains(key2) && !xdependencyObject_0.InnerValues.ContainsKey(key2))
				{
					list.Add(key2);
				}
			}
			return list.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       快速复制对象数据，不进行默认值的判断
		                                                                    ///       </summary>
		                                                                    /// <param name="source">数据来源</param>
		                                                                    /// <param name="destination">复制目标</param>
		public static void CopyValueFast(XDependencyObject source, XDependencyObject destination)
		{
			if (source != destination && source != null && destination != null)
			{
				destination.InnerValues.Clear();
				foreach (GClass371 key in source.InnerValues.Keys)
				{
					object obj = source.InnerValues[key];
					if (obj is ICloneable)
					{
						obj = ((ICloneable)obj).Clone();
					}
					destination.gclass374_0[key] = obj;
					destination.bool_2 = true;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       快速复制对象数据，不进行默认值的判断
		                                                                    ///       </summary>
		                                                                    /// <param name="source">数据来源</param>
		                                                                    /// <param name="destination">复制目标</param>
		public static void CopyValueFast(XDependencyObject source, XDependencyObject destination, bool overWrite)
		{
			if (source != destination && source != null && destination != null)
			{
				foreach (GClass371 key in source.InnerValues.Keys)
				{
					if (overWrite || !destination.gclass374_0.ContainsKey(key))
					{
						object obj = source.InnerValues[key];
						if (obj is ICloneable)
						{
							obj = ((ICloneable)obj).Clone();
						}
						destination.gclass374_0[key] = obj;
						destination.bool_2 = true;
					}
				}
			}
		}

		public static void smethod_6(XDependencyObject xdependencyObject_0, XDependencyObject xdependencyObject_1)
		{
			if (xdependencyObject_0 != xdependencyObject_1 && xdependencyObject_0 != null && xdependencyObject_1 != null)
			{
				xdependencyObject_1.InnerValues.Clear();
				xdependencyObject_1.bool_2 = true;
				foreach (GClass371 key in xdependencyObject_0.InnerValues.Keys)
				{
					object obj = xdependencyObject_0.InnerValues[key];
					if (obj is ICloneable)
					{
						obj = ((ICloneable)obj).Clone();
					}
					xdependencyObject_1.vmethod_1(key, obj);
				}
			}
		}

		public static int smethod_7(XDependencyObject xdependencyObject_0, XDependencyObject xdependencyObject_1, bool bool_3)
		{
			if (xdependencyObject_0 == xdependencyObject_1)
			{
				return 0;
			}
			if (xdependencyObject_0 == null || xdependencyObject_1 == null)
			{
				return 0;
			}
			int num = 0;
			foreach (GClass371 key in xdependencyObject_0.InnerValues.Keys)
			{
				if (!xdependencyObject_1.InnerValues.ContainsKey(key))
				{
					object obj = xdependencyObject_0.vmethod_0(key);
					if (obj is ICloneable)
					{
						obj = ((ICloneable)obj).Clone();
					}
					if (xdependencyObject_0.bool_1 || xdependencyObject_1.bool_1)
					{
						xdependencyObject_1.InnerValues[key] = obj;
						xdependencyObject_1.bool_2 = true;
						xdependencyObject_1.vmethod_2(key);
					}
					else
					{
						xdependencyObject_1.vmethod_1(key, obj);
					}
					num++;
				}
				else if (bool_3)
				{
					bool flag = xdependencyObject_1.bool_1;
					xdependencyObject_1.bool_1 = xdependencyObject_0.bool_1;
					xdependencyObject_1.InnerValues[key] = xdependencyObject_0.InnerValues[key];
					xdependencyObject_1.bool_2 = true;
					xdependencyObject_1.bool_1 = flag;
					xdependencyObject_1.vmethod_2(key);
					num++;
				}
			}
			return num;
		}

		public static bool smethod_8(XDependencyObject xdependencyObject_0, string string_0)
		{
			int num = 17;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("propertyName");
			}
			xdependencyObject_0.method_2();
			foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
			{
				if (string.Compare(key.Name, string_0, ignoreCase: true) == 0)
				{
					xdependencyObject_0.gclass374_0.Remove(key);
					xdependencyObject_0.bool_2 = true;
					xdependencyObject_0.vmethod_2(key);
					return true;
				}
			}
			return false;
		}

		public static bool smethod_9(XDependencyObject xdependencyObject_0, XDependencyObject xdependencyObject_1)
		{
			if (xdependencyObject_0 == xdependencyObject_1)
			{
				return true;
			}
			if (xdependencyObject_0 == null || xdependencyObject_1 == null)
			{
				return false;
			}
			if (xdependencyObject_0.InnerValues.Count != xdependencyObject_1.InnerValues.Count)
			{
				return false;
			}
			foreach (GClass371 key in xdependencyObject_0.InnerValues.Keys)
			{
				if (!xdependencyObject_1.InnerValues.ContainsKey(key))
				{
					return false;
				}
				object objA = xdependencyObject_0.InnerValues[key];
				object objB = xdependencyObject_1.InnerValues[key];
				if (!object.Equals(objA, objB))
				{
					return false;
				}
			}
			return true;
		}

		public static string[] smethod_10(XDependencyObject xdependencyObject_0)
		{
			int num = 1;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (xdependencyObject_0.gclass374_0 != null)
			{
				string[] array = new string[xdependencyObject_0.gclass374_0.Count];
				int num2 = 0;
				foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
				{
					array[num2] = key.Name;
					num2++;
				}
				return array;
			}
			return null;
		}

		public static Hashtable smethod_11(XDependencyObject xdependencyObject_0)
		{
			int num = 2;
			if (xdependencyObject_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (xdependencyObject_0.gclass374_0 != null)
			{
				Hashtable hashtable = new Hashtable();
				foreach (GClass371 key in xdependencyObject_0.gclass374_0.Keys)
				{
					hashtable[key.Name] = xdependencyObject_0.gclass374_0[key];
				}
				return hashtable;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public XDependencyObject()
		{
		}

		protected void method_0()
		{
			if (gclass374_0 != null)
			{
				foreach (object value in gclass374_0.Values)
				{
					if (value is IDisposable)
					{
						((IDisposable)value).Dispose();
					}
				}
				gclass374_0.Clear();
				vmethod_2(null);
			}
		}

		protected virtual object vmethod_0(GClass371 gclass371_0)
		{
			int num = 1;
			if (gclass371_0 == null)
			{
				throw new ArgumentNullException("property");
			}
			gclass374_0.method_0(GetType());
			object value = null;
			if (gclass374_0.TryGetValue(gclass371_0, out value))
			{
				return value;
			}
			return gclass371_0.method_3();
		}

		internal object method_1(GClass371 gclass371_0)
		{
			return vmethod_0(gclass371_0);
		}

		private void method_2()
		{
			int num = 14;
			if (bool_0)
			{
				throw new InvalidOperationException("属性值被锁定了");
			}
		}

		public virtual void vmethod_1(GClass371 gclass371_0, object object_0)
		{
			int num = 15;
			method_2();
			if (gclass371_0 == null)
			{
				throw new ArgumentNullException("property");
			}
			if (!gclass371_0.method_0().IsInstanceOfType(this))
			{
				throw new ArgumentException("need " + gclass371_0.method_0().FullName);
			}
			gclass374_0.method_0(GetType());
			if (gdelegate22_0 != null || this is GInterface0)
			{
				object obj = null;
				obj = ((!gclass374_0.ContainsKey(gclass371_0)) ? gclass371_0.method_3() : gclass374_0[gclass371_0]);
				if (gdelegate22_0 != null)
				{
					GEventArgs12 gEventArgs = new GEventArgs12(this, gclass371_0, obj, object_0);
					gdelegate22_0(this, gEventArgs);
					if (gEventArgs.method_5())
					{
						return;
					}
					object_0 = gEventArgs.method_3();
				}
				if (this is GInterface0)
				{
					GInterface22 gInterface = ((GInterface0)this).imethod_0();
					if (gInterface != null && gInterface.imethod_0())
					{
						gInterface.imethod_1(this, gclass371_0, obj, object_0);
					}
				}
				if (!bool_1 && gclass371_0.method_5(object_0))
				{
					if (gclass374_0.ContainsKey(gclass371_0))
					{
						gclass374_0.Remove(gclass371_0);
					}
				}
				else
				{
					gclass374_0[gclass371_0] = object_0;
				}
				vmethod_2(gclass371_0);
				if (gdelegate22_1 != null)
				{
					GEventArgs12 e = new GEventArgs12(this, gclass371_0, object_0, object_0);
					gdelegate22_1(this, e);
				}
			}
			else
			{
				if (gclass371_0.method_5(object_0))
				{
					if (gclass374_0.ContainsKey(gclass371_0))
					{
						gclass374_0.Remove(gclass371_0);
					}
				}
				else
				{
					gclass374_0[gclass371_0] = object_0;
				}
				vmethod_2(gclass371_0);
				if (gdelegate22_1 != null)
				{
					GEventArgs12 e = new GEventArgs12(this, gclass371_0, object_0, object_0);
					gdelegate22_1(this, e);
				}
			}
			bool_2 = true;
		}

		protected virtual void vmethod_2(GClass371 gclass371_0)
		{
		}
	}
}
