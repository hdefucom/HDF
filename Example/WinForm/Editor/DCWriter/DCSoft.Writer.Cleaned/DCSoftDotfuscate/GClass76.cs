using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass76 : GClass75
	{
		public const int int_0 = 2147439148;

		private NumberFormatInfo numberFormatInfo_0;

		protected object object_0;

		private GDelegate3 gdelegate3_0 = null;

		private GDelegate2 gdelegate2_0;

		private GDelegate1 gdelegate1_0;

		private IDictionary idictionary_0 = new Hashtable();

		private static string smethod_0(object object_1)
		{
			if (object_1 == null || DBNull.Value.Equals(object_1))
			{
				return null;
			}
			if (object_1.GetType().IsArray)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (object item in (IEnumerable)object_1)
				{
					if (item != null)
					{
						string value = smethod_0(item);
						if (!string.IsNullOrEmpty(value))
						{
							stringBuilder.Append(value);
						}
					}
				}
				return stringBuilder.ToString();
			}
			return Convert.ToString(object_1);
		}

		private static double smethod_1(object object_1, double double_0 = 0.0)
		{
			if (object_1 is float)
			{
				if (float.IsNaN((float)object_1))
				{
					return double_0;
				}
				return (double)object_1;
			}
			if (object_1 is double)
			{
				if (double.IsNaN((double)object_1))
				{
					return double_0;
				}
				return (double)object_1;
			}
			if (object_1 != null && object_1.GetType().IsArray)
			{
				foreach (object item in (IEnumerable)object_1)
				{
					if (item != null)
					{
						double num = smethod_1(item, double.NaN);
						if (!double.IsNaN(num))
						{
							return num;
						}
					}
				}
				return double_0;
			}
			if (object_1 is string)
			{
				string text = (string)object_1;
				if (string.IsNullOrEmpty(text))
				{
					return double_0;
				}
				double num = double_0;
				if (double.TryParse(text, out num))
				{
					return num;
				}
				return double_0;
			}
			double num2 = Convert.ToDouble(object_1);
			if (double.IsNaN(num2))
			{
				return double_0;
			}
			return num2;
		}

		public GClass76()
		{
			numberFormatInfo_0 = new NumberFormatInfo();
			numberFormatInfo_0.NumberDecimalSeparator = ".";
		}

		public object method_0()
		{
			return object_0;
		}

		private object method_1(GClass55 gclass55_0)
		{
			gclass55_0.vmethod_0(this);
			return object_0;
		}

		public override void vmethod_0(GClass55 gclass55_0)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public override void vmethod_1(GClass57 gclass57_0)
		{
			if (gclass57_0.method_4() == GEnum2.const_0)
			{
				gclass57_0.method_2().vmethod_0(this);
				if (!Convert.ToBoolean(object_0))
				{
					object_0 = false;
					return;
				}
				gclass57_0.method_3().vmethod_0(this);
				object_0 = Convert.ToBoolean(object_0);
				return;
			}
			if (gclass57_0.method_4() == GEnum2.const_1)
			{
				gclass57_0.method_2().vmethod_0(this);
				if (Convert.ToBoolean(object_0))
				{
					object_0 = true;
					return;
				}
				gclass57_0.method_3().vmethod_0(this);
				object_0 = Convert.ToBoolean(object_0);
				return;
			}
			gclass57_0.method_2().vmethod_0(this);
			object object_ = object_0;
			gclass57_0.method_3().vmethod_0(this);
			object object_2 = object_0;
			switch (gclass57_0.method_4())
			{
			case GEnum2.const_2:
				object_2 = method_2(object_2, ref object_);
				object_0 = (Comparer.Default.Compare(object_, object_2) != 0);
				break;
			case GEnum2.const_3:
				if (gclass57_0.method_2() is GClass58)
				{
					object_ = method_2(object_, ref object_2);
					object_0 = (Comparer.Default.Compare(object_, object_2) <= 0);
				}
				else
				{
					object_2 = method_2(object_2, ref object_);
					object_0 = (Comparer.Default.Compare(object_, object_2) <= 0);
				}
				break;
			case GEnum2.const_4:
				if (gclass57_0.method_2() is GClass58)
				{
					object_ = method_2(object_, ref object_2);
					object_0 = (Comparer.Default.Compare(object_, object_2) >= 0);
				}
				else
				{
					object_2 = method_2(object_2, ref object_);
					object_0 = (Comparer.Default.Compare(object_, object_2) >= 0);
				}
				break;
			case GEnum2.const_5:
				if (gclass57_0.method_2() is GClass58)
				{
					object_ = method_2(object_, ref object_2);
					object_0 = (Comparer.Default.Compare(object_, object_2) < 0);
				}
				else
				{
					object_2 = method_2(object_2, ref object_);
					object_0 = (Comparer.Default.Compare(object_, object_2) < 0);
				}
				break;
			case GEnum2.const_6:
				if (gclass57_0.method_2() is GClass58)
				{
					object_ = method_2(object_, ref object_2);
					object_0 = (Comparer.Default.Compare(object_, object_2) > 0);
				}
				else
				{
					object_2 = method_2(object_2, ref object_);
					object_0 = (Comparer.Default.Compare(object_, object_2) > 0);
				}
				break;
			case GEnum2.const_7:
				if (gclass57_0.method_2() is GClass58)
				{
					object_ = method_2(object_, ref object_2);
					object_0 = (Comparer.Default.Compare(object_, object_2) == 0);
				}
				else
				{
					object_2 = method_2(object_2, ref object_);
					object_0 = (Comparer.Default.Compare(object_, object_2) == 0);
				}
				break;
			case GEnum2.const_8:
				object_0 = smethod_1(object_) - smethod_1(object_2);
				break;
			case GEnum2.const_9:
			{
				bool flag = false;
				if (gclass57_0.method_2() is GClass59)
				{
					GClass59 gClass = (GClass59)gclass57_0.method_2();
					if (gClass.method_3() == GEnum3.const_1)
					{
						flag = true;
					}
				}
				if (!flag && gclass57_0.method_3() is GClass59)
				{
					GClass59 gClass = (GClass59)gclass57_0.method_3();
					if (gClass.method_3() == GEnum3.const_1)
					{
						flag = true;
					}
				}
				double num3 = smethod_1(object_);
				double num4 = smethod_1(object_2);
				object_0 = num3 + num4;
				break;
			}
			case GEnum2.const_10:
				object_0 = smethod_1(object_) % smethod_1(object_2);
				break;
			case GEnum2.const_11:
			{
				double num = smethod_1(object_);
				double num2 = smethod_1(object_2);
				if (num2 == 0.0)
				{
					object_0 = 0;
				}
				else
				{
					object_0 = num / num2;
				}
				break;
			}
			case GEnum2.const_12:
				object_0 = smethod_1(object_) * smethod_1(object_2);
				break;
			}
		}

		private object method_2(object object_1, ref object object_2)
		{
			if (object_2 == null)
			{
				return object_1;
			}
			if (object_1 is string && (object_2 is int || object_2 is float || object_2 is double || object_2 is long || object_2 is short))
			{
				string text = (string)object_1;
				if (text.IndexOf('.') >= 0)
				{
					object_2 = Convert.ToDouble(object_2);
					return Convert.ToDouble(object_1);
				}
			}
			if (object_1 == null || DBNull.Value.Equals(object_1))
			{
				if (object_2 is int)
				{
					return 0;
				}
				if (object_2 is float)
				{
					return 0f;
				}
				if (object_2 is double)
				{
					return 0.0;
				}
				if (object_2 is long)
				{
					return 0L;
				}
				if (object_2 is short)
				{
					return (short)0;
				}
				return null;
			}
			return Convert.ChangeType(object_1, object_2.GetType());
		}

		public override void vmethod_2(GClass56 gclass56_0)
		{
			gclass56_0.method_2().vmethod_0(this);
			switch (gclass56_0.method_3())
			{
			case GEnum1.const_0:
				object_0 = !Convert.ToBoolean(object_0);
				break;
			case GEnum1.const_1:
				object_0 = -Convert.ToDecimal(object_0);
				break;
			}
		}

		public override void vmethod_3(GClass59 gclass59_0)
		{
			switch (gclass59_0.method_3())
			{
			case GEnum3.const_0:
				if (gclass59_0.method_2() == 2147439148.ToString())
				{
					object_0 = double.NaN;
				}
				else
				{
					object_0 = long.Parse(gclass59_0.method_2());
				}
				break;
			case GEnum3.const_1:
				if (gdelegate3_0 != null)
				{
					gdelegate3_0(gclass59_0);
				}
				object_0 = gclass59_0.method_2();
				break;
			case GEnum3.const_2:
				object_0 = DateTime.Parse(gclass59_0.method_2());
				break;
			case GEnum3.const_3:
				if (gclass59_0.method_2() == 2147439148.ToString())
				{
					object_0 = double.NaN;
				}
				else
				{
					object_0 = double.Parse(gclass59_0.method_2(), numberFormatInfo_0);
				}
				break;
			case GEnum3.const_4:
				object_0 = bool.Parse(gclass59_0.method_2());
				break;
			}
		}

		public void method_3(GDelegate3 gdelegate3_1)
		{
			GDelegate3 gDelegate = gdelegate3_0;
			GDelegate3 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate3 value = (GDelegate3)Delegate.Combine(gDelegate2, gdelegate3_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate3_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_4(GDelegate3 gdelegate3_1)
		{
			GDelegate3 gDelegate = gdelegate3_0;
			GDelegate3 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate3 value = (GDelegate3)Delegate.Remove(gDelegate2, gdelegate3_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate3_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public override void vmethod_4(GClass60 gclass60_0)
		{
			int num = 4;
			ArrayList arrayList = new ArrayList();
			GClass55[] array = gclass60_0.method_3();
			foreach (GClass55 gclass55_ in array)
			{
				object value = method_1(gclass55_);
				arrayList.Add(value);
			}
			GEventArgs1 gEventArgs = new GEventArgs1();
			gEventArgs.method_5(arrayList.ToArray());
			method_7(gclass60_0.method_2(), gEventArgs);
			if (gEventArgs.method_0() != null || gEventArgs.method_2())
			{
				object_0 = gEventArgs.method_0();
				return;
			}
			switch (gclass60_0.method_2())
			{
			case "Math.abs":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("abs 函数需要一个参数");
				}
				object_0 = Math.Abs(Convert.ToDecimal(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.acos":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("acode 函数需要一个函数");
				}
				object_0 = Math.Acos(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.asin":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("asin 函数需要一个参数");
				}
				object_0 = Math.Asin(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.atan":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("atan 函数需要一个参数");
				}
				object_0 = Math.Atan(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.ceil":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("ceil 函数需要一个参数");
				}
				object_0 = Math.Ceiling(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.cos":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("cos 函数需要一个参数");
				}
				object_0 = Math.Cos(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.exp":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("exp 函数需要一个参数");
				}
				object_0 = Math.Exp(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.floor":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("floor 函数需要一个参数");
				}
				object_0 = Math.Floor(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.log":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("log 函数需要一个参数");
				}
				object_0 = Math.Log(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.pow":
				if (gclass60_0.method_3().Length != 2)
				{
					throw new ArgumentException("pow 函数需要两个参数");
				}
				object_0 = Math.Pow(Convert.ToDouble(method_1(gclass60_0.method_3()[0])), Convert.ToDouble(method_1(gclass60_0.method_3()[1])));
				break;
			case "Math.round":
				if (gclass60_0.method_3().Length != 2)
				{
					throw new ArgumentException("round 函数需要两个参数");
				}
				object_0 = Math.Round(Convert.ToDouble(method_1(gclass60_0.method_3()[0])), Convert.ToInt16(method_1(gclass60_0.method_3()[1])));
				break;
			case "Math.sin":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("sin 函数需要一个参数");
				}
				object_0 = Math.Sin(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.sqrt":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("sqrt 函数需要一个参数");
				}
				object_0 = Math.Sqrt(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.tan":
				if (gclass60_0.method_3().Length != 1)
				{
					throw new ArgumentException("tan 函数需要一个参数");
				}
				object_0 = Math.Tan(Convert.ToDouble(method_1(gclass60_0.method_3()[0])));
				break;
			case "Math.max":
			{
				if (gclass60_0.method_3().Length < 2)
				{
					throw new ArgumentException("max 函数至少需要两个参数");
				}
				double num4 = double.NaN;
				for (int j = 0; j < gclass60_0.method_3().Length; j++)
				{
					double num3 = Convert.ToDouble(method_1(gclass60_0.method_3()[j]));
					if (double.IsNaN(num4) || num4 < num3)
					{
						num4 = num3;
					}
				}
				object_0 = num4;
				break;
			}
			case "Math.min":
			{
				if (gclass60_0.method_3().Length < 2)
				{
					throw new ArgumentException("min 函数至少需要两个参数");
				}
				double num2 = double.NaN;
				for (int j = 0; j < gclass60_0.method_3().Length; j++)
				{
					double num3 = Convert.ToDouble(method_1(gclass60_0.method_3()[j]));
					if (double.IsNaN(num2) || num2 > num3)
					{
						num2 = num3;
					}
				}
				object_0 = num2;
				break;
			}
			default:
				throw new ArgumentException("系统未定义函数 " + gclass60_0.method_2());
			}
		}

		public void method_5(GDelegate2 gdelegate2_1)
		{
			GDelegate2 gDelegate = gdelegate2_0;
			GDelegate2 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate2 value = (GDelegate2)Delegate.Combine(gDelegate2, gdelegate2_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate2_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_6(GDelegate2 gdelegate2_1)
		{
			GDelegate2 gDelegate = gdelegate2_0;
			GDelegate2 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate2 value = (GDelegate2)Delegate.Remove(gDelegate2, gdelegate2_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate2_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		private void method_7(string string_0, GEventArgs1 geventArgs1_0)
		{
			if (gdelegate2_0 != null)
			{
				gdelegate2_0(string_0, geventArgs1_0);
			}
		}

		public override void vmethod_5(GClass58 gclass58_0)
		{
			int num = 13;
			if (method_11() != null && method_11().Contains(gclass58_0.Name))
			{
				object_0 = method_11()[gclass58_0.Name];
				if (object_0 is GClass52)
				{
					GClass52 gClass = (GClass52)idictionary_0[gclass58_0.Name];
					gClass.method_10(idictionary_0);
					gClass.method_5(gdelegate2_0);
					gClass.method_7(gdelegate1_0);
					object_0 = ((GClass52)idictionary_0[gclass58_0.Name]).vmethod_1();
				}
			}
			else
			{
				GEventArgs0 gEventArgs = new GEventArgs0();
				gEventArgs.method_1(gclass58_0.Name);
				gEventArgs.method_3(gclass58_0.method_0());
				method_10(gclass58_0.Name, gEventArgs);
				if (gEventArgs.method_4() == null)
				{
					throw new ArgumentException("Parameter was not defined", gclass58_0.Name);
				}
				object_0 = gEventArgs.method_4();
			}
		}

		public void method_8(GDelegate1 gdelegate1_1)
		{
			GDelegate1 gDelegate = gdelegate1_0;
			GDelegate1 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate1 value = (GDelegate1)Delegate.Combine(gDelegate2, gdelegate1_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate1_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_9(GDelegate1 gdelegate1_1)
		{
			GDelegate1 gDelegate = gdelegate1_0;
			GDelegate1 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate1 value = (GDelegate1)Delegate.Remove(gDelegate2, gdelegate1_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate1_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		private void method_10(string string_0, GEventArgs0 geventArgs0_0)
		{
			if (gdelegate1_0 != null)
			{
				gdelegate1_0(string_0, geventArgs0_0);
			}
		}

		public IDictionary method_11()
		{
			return idictionary_0;
		}

		public void method_12(IDictionary idictionary_1)
		{
			idictionary_0 = idictionary_1;
		}
	}
}
