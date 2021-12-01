using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass140
	{
		private class Class144
		{
			public object object_0 = null;

			public PropertyInfo propertyInfo_0 = null;

			public int int_0 = -1;
		}

		private class Class145
		{
			public Class146 class146_0 = null;

			public byte[] byte_0 = null;

			public byte byte_1 = 0;

			public object object_0 = null;

			public byte[] byte_2 = null;

			public void method_0()
			{
				int num = (int)Math.Ceiling((double)class146_0.method_2().Length / 8.0);
				byte_2 = new byte[num];
			}

			public void method_1(int int_0, bool bool_0)
			{
				if (byte_2 == null)
				{
					int num = (int)Math.Ceiling((double)class146_0.method_2().Length / 8.0);
					byte_2 = new byte[num];
				}
				int num2 = (int)Math.Floor((double)int_0 / 8.0);
				int num3 = int_0 - num2 * 8;
				byte b = (byte)(1 << num3);
				byte_2[num2] = (byte)(bool_0 ? (byte_2[num2] | b) : (byte_2[num2] & ~b));
			}

			public bool method_2(int int_0)
			{
				if (byte_2 != null)
				{
					int num = (int)Math.Floor((double)int_0 / 8.0);
					int num2 = int_0 - num * 8;
					byte b = (byte)(1 << num2);
					if (byte_2.Length >= num)
					{
						return (byte_2[num] & b) == b;
					}
				}
				return false;
			}
		}

		private class Class146
		{
			private Type type_0 = null;

			private Class147[] class147_0 = null;

			public Type method_0()
			{
				return type_0;
			}

			public void method_1(Type type_1)
			{
				type_0 = type_1;
			}

			public Class147[] method_2()
			{
				return class147_0;
			}

			public void method_3(Class147[] class147_1)
			{
				class147_0 = class147_1;
			}
		}

		private class Class147
		{
			public static readonly object object_0 = new object();

			private byte byte_0 = 0;

			private PropertyInfo propertyInfo_0 = null;

			private object object_1 = object_0;

			public byte method_0()
			{
				return byte_0;
			}

			public void method_1(byte byte_1)
			{
				byte_0 = byte_1;
			}

			public PropertyInfo method_2()
			{
				return propertyInfo_0;
			}

			public void method_3(PropertyInfo propertyInfo_1)
			{
				propertyInfo_0 = propertyInfo_1;
			}

			public object method_4()
			{
				return object_1;
			}

			public void method_5(object object_2)
			{
				object_1 = object_2;
			}

			public bool method_6(object object_2)
			{
				if (object_1 == object_0)
				{
					return false;
				}
				if (object_1 == object_2)
				{
					return true;
				}
				return object.Equals(object_1, object_2);
			}

			public override string ToString()
			{
				return method_0() + ":" + method_2().Name + "[" + method_2().PropertyType.Name + "] default:" + method_4();
			}
		}

		private class Class148 : IComparer<Class147>
		{
			public int Compare(Class147 class147_0, Class147 class147_1)
			{
				int num = class147_0.method_0() - class147_1.method_0();
				if (num == 0)
				{
					return string.Compare(class147_0.method_2().Name, class147_1.method_2().Name);
				}
				return num;
			}
		}

		public const byte byte_0 = 49;

		public static readonly byte[] byte_1 = Encoding.UTF8.GetBytes("DCBin");

		private Encoding encoding_0 = Encoding.UTF8;

		private GEnum20 genum20_0 = GEnum20.const_0;

		private static Dictionary<Type, TypeConverter> dictionary_0 = new Dictionary<Type, TypeConverter>();

		private List<Class145> list_0 = new List<Class145>();

		private static Dictionary<Type, Class146> dictionary_1 = new Dictionary<Type, Class146>();

		public Encoding method_0()
		{
			return encoding_0;
		}

		public void method_1(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public GEnum20 method_2()
		{
			return genum20_0;
		}

		public void method_3(GEnum20 genum20_1)
		{
			genum20_0 = genum20_1;
		}

		public object method_4(Stream stream_0, Type type_0)
		{
			object obj = Activator.CreateInstance(type_0);
			method_5(stream_0, obj);
			return obj;
		}

		public int method_5(Stream stream_0, object object_0)
		{
			int num = 16;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			GClass142 gClass = new GClass142(stream_0);
			byte[] array = new byte[byte_1.Length];
			gClass.method_10(array, 0, array.Length);
			if (!Class153.smethod_1(array, byte_1))
			{
				return -1;
			}
			int num2 = gClass.method_3();
			if (num2 != 49)
			{
				return -1;
			}
			method_3((GEnum20)Enum.ToObject(typeof(GEnum20), gClass.method_3()));
			List<Class144> list = new List<Class144>();
			int num3 = gClass.method_3();
			list_0.Clear();
			for (int i = 0; i < num3; i++)
			{
				list_0.Add(new Class145());
			}
			list_0[0].object_0 = object_0;
			list_0[0].class146_0 = smethod_1(object_0.GetType());
			for (int i = 0; i < num3; i++)
			{
				Class145 @class = list_0[i];
				if (@class.object_0 == null)
				{
					@class.object_0 = Activator.CreateInstance(@class.class146_0.method_0());
				}
				object object_ = @class.object_0;
				Class146 class2 = smethod_1(object_.GetType());
				@class.byte_1 = gClass.method_3();
				int int_ = (int)Math.Ceiling((double)(int)@class.byte_1 / 8.0);
				@class.byte_2 = gClass.method_12(int_);
				for (int j = 0; j < @class.byte_1; j++)
				{
					int num4 = gClass.method_3();
					Class147 class3 = null;
					Class147[] array2 = class2.method_2();
					foreach (Class147 class4 in array2)
					{
						if (class4.method_0() == num4)
						{
							class3 = class4;
							break;
						}
					}
					if (class3 != null)
					{
						Type propertyType = class3.method_2().PropertyType;
						object value = null;
						if (propertyType.Equals(typeof(string)))
						{
							int num5 = 0;
							num5 = ((!@class.method_2(j)) ? gClass.method_3() : gClass.method_5());
							if (num5 > 0)
							{
								byte[] bytes = gClass.method_12(num5);
								value = method_0().GetString(bytes);
							}
						}
						else if (propertyType.Equals(typeof(byte)))
						{
							value = gClass.method_3();
						}
						else if (propertyType.Equals(typeof(short)))
						{
							value = gClass.method_4();
						}
						else if (propertyType.Equals(typeof(int)))
						{
							value = gClass.method_5();
						}
						else if (propertyType.Equals(typeof(long)))
						{
							value = gClass.method_6();
						}
						else if (propertyType.Equals(typeof(float)))
						{
							value = gClass.method_7();
						}
						else if (propertyType.Equals(typeof(double)))
						{
							value = gClass.method_8();
						}
						else if (propertyType.Equals(typeof(decimal)))
						{
							value = (decimal)gClass.method_8();
						}
						else if (propertyType.Equals(typeof(DateTime)))
						{
							long ticks = gClass.method_6();
							value = new DateTime(ticks);
						}
						else if (propertyType.Equals(typeof(byte[])))
						{
							int num5 = 0;
							num5 = ((!@class.method_2(j)) ? gClass.method_3() : gClass.method_5());
							value = gClass.method_12(num5);
						}
						else if (propertyType.Equals(typeof(Color)))
						{
							if (!@class.method_2(j))
							{
								string name = gClass.method_1();
								value = Color.FromName(name);
							}
							else
							{
								value = Color.FromArgb(gClass.method_5());
							}
						}
						else if (propertyType.Equals(typeof(Size)))
						{
							value = (@class.method_2(j) ? ((object)new Size(gClass.method_5(), gClass.method_5())) : ((object)Size.Empty));
						}
						else if (propertyType.Equals(typeof(SizeF)))
						{
							value = (@class.method_2(j) ? ((object)new SizeF(gClass.method_7(), gClass.method_7())) : ((object)SizeF.Empty));
						}
						else if (propertyType.Equals(typeof(Point)))
						{
							value = (@class.method_2(j) ? ((object)new Point(gClass.method_5(), gClass.method_5())) : ((object)Point.Empty));
						}
						else if (propertyType.Equals(typeof(PointF)))
						{
							value = (@class.method_2(j) ? ((object)new PointF(gClass.method_7(), gClass.method_7())) : ((object)PointF.Empty));
						}
						else if (propertyType.Equals(typeof(Rectangle)))
						{
							value = (@class.method_2(j) ? ((object)new Rectangle(gClass.method_5(), gClass.method_5(), gClass.method_5(), gClass.method_5())) : ((object)Rectangle.Empty));
						}
						else if (propertyType.Equals(typeof(RectangleF)))
						{
							value = (@class.method_2(j) ? ((object)new RectangleF(gClass.method_7(), gClass.method_7(), gClass.method_7(), gClass.method_7())) : ((object)RectangleF.Empty));
						}
						else if (propertyType.Equals(typeof(Font)))
						{
							TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
							value = converter.ConvertFrom(gClass.method_1());
						}
						else if (propertyType.IsEnum)
						{
							value = gClass.method_11(propertyType);
						}
						else if (propertyType.IsClass || propertyType.IsValueType)
						{
							TypeConverter converter = smethod_0(propertyType);
							if (converter != null)
							{
								value = converter.ConvertFromString(gClass.method_2());
							}
							else
							{
								byte b = gClass.method_3();
								if (b == byte.MaxValue)
								{
									value = null;
								}
								else
								{
									Class145 class5 = list_0[b];
									if (class5.object_0 == null)
									{
										class5.object_0 = Activator.CreateInstance(propertyType);
									}
									class5.class146_0 = smethod_1(propertyType);
									value = class5.object_0;
									if (propertyType.IsValueType)
									{
										Class144 class6 = new Class144();
										class6.object_0 = object_;
										class6.propertyInfo_0 = class3.method_2();
										class6.int_0 = b;
										list.Add(class6);
									}
								}
							}
						}
						class3.method_2().SetValue(object_, value, null);
						continue;
					}
					throw new InvalidOperationException("pindex:" + num4);
				}
			}
			if (list.Count > 0)
			{
				foreach (Class144 item in list)
				{
					object object_2 = list_0[item.int_0].object_0;
					item.propertyInfo_0.SetValue(item.object_0, object_2, null);
				}
			}
			return num3;
		}

		private static TypeConverter smethod_0(Type type_0)
		{
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			TypeConverter converter = TypeDescriptor.GetConverter(type_0);
			if (converter != null && !converter.GetType().Equals(typeof(TypeConverter)) && converter.CanConvertFrom(typeof(string)) && converter.CanConvertTo(typeof(string)))
			{
				dictionary_0[type_0] = converter;
				return converter;
			}
			dictionary_0[type_0] = null;
			return null;
		}

		public int method_6(Stream stream_0, object object_0)
		{
			int num = 4;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			list_0.Clear();
			method_7(object_0);
			int num2 = 0;
			stream_0.Write(byte_1, 0, byte_1.Length);
			num2 = 0 + byte_1.Length;
			stream_0.WriteByte(49);
			stream_0.WriteByte((byte)method_2());
			num2 += 2;
			stream_0.WriteByte((byte)list_0.Count);
			num2++;
			foreach (Class145 item in list_0)
			{
				stream_0.WriteByte(item.byte_1);
				int count = (int)Math.Ceiling((double)(int)item.byte_1 / 8.0);
				stream_0.Write(item.byte_2, 0, count);
				stream_0.Write(item.byte_0, 0, item.byte_0.Length);
				num2 = num2 + 1 + 1 + item.byte_0.Length;
			}
			return num2;
		}

		private void method_7(object object_0)
		{
			int num = 2;
			Class145 @class = method_8(object_0);
			if (@class == null)
			{
				@class = new Class145();
				list_0.Add(@class);
				@class.object_0 = object_0;
			}
			Class146 class2 = smethod_1(object_0.GetType());
			MemoryStream memoryStream = new MemoryStream();
			GClass141 gClass = new GClass141(memoryStream);
			@class.byte_1 = 0;
			@class.class146_0 = class2;
			@class.method_0();
			int num2 = -1;
			Class147[] array = class2.method_2();
			foreach (Class147 class3 in array)
			{
				num2++;
				Type propertyType = class3.method_2().PropertyType;
				object value = class3.method_2().GetValue(object_0, null);
				if (value == null || propertyType.Equals(value.GetType()))
				{
					if (class3.method_6(value))
					{
						continue;
					}
					gClass.method_3(class3.method_0());
					if (propertyType.Equals(typeof(string)))
					{
						string text = (string)value;
						if (string.IsNullOrEmpty(text))
						{
							@class.method_1(num2, bool_0: false);
							gClass.method_3(0);
						}
						else
						{
							byte[] bytes = method_0().GetBytes(text);
							if (bytes.Length < 254)
							{
								@class.method_1(num2, bool_0: false);
								gClass.method_3((byte)bytes.Length);
								gClass.method_11(bytes);
							}
							else
							{
								@class.method_1(num2, bool_0: true);
								gClass.method_5(bytes.Length);
								gClass.method_11(bytes);
							}
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(byte)))
					{
						gClass.method_3((byte)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(short)))
					{
						gClass.method_4((short)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(int)))
					{
						gClass.method_5((int)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(long)))
					{
						gClass.method_6((long)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(float)))
					{
						gClass.method_7((float)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(double)))
					{
						gClass.method_8((double)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(decimal)))
					{
						gClass.method_8(Convert.ToDouble(value));
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(DateTime)))
					{
						gClass.method_9((DateTime)value);
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(byte[])))
					{
						byte[] bytes = (byte[])value;
						if (bytes == null || bytes.Length < 255)
						{
							@class.method_1(num2, bool_0: false);
							if (bytes == null || bytes.Length == 0)
							{
								gClass.method_3(0);
							}
							else
							{
								gClass.method_3((byte)bytes.Length);
								gClass.method_11(bytes);
							}
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_5(bytes.Length);
							gClass.method_11(bytes);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(Color)))
					{
						Color color = (Color)value;
						if (color.IsKnownColor)
						{
							@class.method_1(num2, bool_0: false);
							gClass.method_1(color.Name);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_5(color.ToArgb());
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(Size)))
					{
						Size size = (Size)value;
						if (size.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_5(size.Width);
							gClass.method_5(size.Height);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(SizeF)))
					{
						SizeF sizeF = (SizeF)value;
						if (sizeF.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_7(sizeF.Width);
							gClass.method_7(sizeF.Height);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(Point)))
					{
						Point point = (Point)value;
						if (point.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_5(point.X);
							gClass.method_5(point.Y);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(PointF)))
					{
						PointF pointF = (PointF)value;
						if (pointF.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_7(pointF.X);
							gClass.method_7(pointF.Y);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(Rectangle)))
					{
						Rectangle rectangle = (Rectangle)value;
						if (rectangle.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_5(rectangle.Left);
							gClass.method_5(rectangle.Top);
							gClass.method_5(rectangle.Width);
							gClass.method_5(rectangle.Height);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(RectangleF)))
					{
						RectangleF rectangleF = (RectangleF)value;
						if (rectangleF.IsEmpty)
						{
							@class.method_1(num2, bool_0: false);
						}
						else
						{
							@class.method_1(num2, bool_0: true);
							gClass.method_7(rectangleF.Left);
							gClass.method_7(rectangleF.Top);
							gClass.method_7(rectangleF.Width);
							gClass.method_7(rectangleF.Height);
						}
						@class.byte_1++;
					}
					else if (propertyType.Equals(typeof(Font)))
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
						gClass.method_1(converter.ConvertToString(value));
						@class.byte_1++;
					}
					else if (propertyType.IsEnum)
					{
						gClass.method_13(value);
						@class.byte_1++;
					}
					else
					{
						if (!propertyType.IsClass && !propertyType.IsValueType)
						{
							continue;
						}
						TypeConverter converter = smethod_0(propertyType);
						if (converter != null)
						{
							string text = converter.ConvertToString(value);
							gClass.method_2(text);
						}
						else if (value == null)
						{
							gClass.method_3(byte.MaxValue);
						}
						else
						{
							Class145 class4 = method_8(value);
							if (class4 == null)
							{
								method_7(value);
								class4 = method_8(value);
							}
							gClass.method_3((byte)list_0.IndexOf(class4));
						}
						@class.byte_1++;
					}
					continue;
				}
				throw new InvalidOperationException(value.GetType().FullName + "!=" + propertyType.FullName);
			}
			@class.byte_0 = memoryStream.ToArray();
		}

		private Class145 method_8(object object_0)
		{
			foreach (Class145 item in list_0)
			{
				if (item.object_0 == object_0)
				{
					return item;
				}
			}
			return null;
		}

		private static Class146 smethod_1(Type type_0)
		{
			int num = 6;
			if (dictionary_1.ContainsKey(type_0))
			{
				return dictionary_1[type_0];
			}
			Class146 @class = new Class146();
			List<Class147> list = new List<Class147>();
			List<int> list2 = new List<int>();
			PropertyInfo[] properties = type_0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			int num2 = 0;
			PropertyInfo propertyInfo;
			while (true)
			{
				if (num2 < properties.Length)
				{
					propertyInfo = properties[num2];
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if ((indexParameters == null || indexParameters.Length <= 0) && propertyInfo.CanRead && propertyInfo.CanWrite)
					{
						GAttribute4 gAttribute = (GAttribute4)Attribute.GetCustomAttribute(propertyInfo, typeof(GAttribute4), inherit: true);
						if (gAttribute != null && !gAttribute.method_2())
						{
							if (list2.Contains(gAttribute.method_0()))
							{
								break;
							}
							list2.Add(gAttribute.method_0());
							Class147 class2 = new Class147();
							class2.method_1(gAttribute.method_0());
							DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DefaultValueAttribute), inherit: true);
							if (defaultValueAttribute != null)
							{
								try
								{
									if (defaultValueAttribute.Value == null)
									{
										class2.method_5(null);
									}
									else
									{
										class2.method_5(Convert.ChangeType(defaultValueAttribute.Value, propertyInfo.PropertyType));
									}
								}
								catch
								{
									class2.method_5(Class147.object_0);
								}
							}
							class2.method_3(propertyInfo);
							list.Add(class2);
						}
					}
					num2++;
					continue;
				}
				if (list.Count > 1)
				{
					list.Sort(new Class148());
					@class.method_3(list.ToArray());
					dictionary_1[type_0] = @class;
					return @class;
				}
				throw new InvalidOperationException(type_0.FullName + " no property");
			}
			throw new InvalidOperationException(type_0.FullName + "[" + propertyInfo.Name + "] 序号重复");
		}
	}
}
