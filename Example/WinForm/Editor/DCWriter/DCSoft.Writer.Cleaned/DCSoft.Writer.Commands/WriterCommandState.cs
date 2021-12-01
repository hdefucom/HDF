using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器动作对象状态
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class WriterCommandState : XDependencyObject
	{
		private static GClass371 gclass371_0 = GClass371.smethod_1("Name", typeof(string), typeof(WriterCommandState), null);

		private static GClass371 gclass371_1 = GClass371.smethod_1("Icon", typeof(XImageValue), typeof(WriterCommandState), null);

		private static GClass371 gclass371_2 = GClass371.smethod_1("Text", typeof(string), typeof(WriterCommandState), null);

		private static GClass371 gclass371_3 = GClass371.smethod_1("Enabled", typeof(bool), typeof(WriterCommandState), true);

		private static GClass371 gclass371_4 = GClass371.smethod_1("Visible", typeof(bool), typeof(WriterCommandState), true);

		private static GClass371 gclass371_5 = GClass371.smethod_1("Checked", typeof(bool), typeof(WriterCommandState), true);

		private static GClass371 gclass371_6 = GClass371.smethod_1("ReferenceCount", typeof(int), typeof(WriterCommandState), true);

		/// <summary>
		///       动作名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return (string)base.vmethod_0(gclass371_0);
			}
			set
			{
				base.vmethod_1(gclass371_0, value);
			}
		}

		/// <summary>
		///       图标
		///       </summary>
		[DefaultValue(null)]
		public XImageValue Icon
		{
			get
			{
				return (XImageValue)base.vmethod_0(gclass371_1);
			}
			set
			{
				vmethod_1(gclass371_1, value);
			}
		}

		/// <summary>
		///       动作文本
		///       </summary>
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return (string)base.vmethod_0(gclass371_2);
			}
			set
			{
				base.vmethod_1(gclass371_2, value);
			}
		}

		/// <summary>
		///       动作是否可用
		///       </summary>
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return (bool)base.vmethod_0(gclass371_3);
			}
			set
			{
				base.vmethod_1(gclass371_3, value);
			}
		}

		/// <summary>
		///       动作是否可见
		///       </summary>
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return (bool)base.vmethod_0(gclass371_4);
			}
			set
			{
				base.vmethod_1(gclass371_4, value);
			}
		}

		/// <summary>
		///       动作选择状态
		///       </summary>
		[DefaultValue(true)]
		public bool Checked
		{
			get
			{
				return (bool)base.vmethod_0(gclass371_5);
			}
			set
			{
				base.vmethod_1(gclass371_5, value);
			}
		}

		/// <summary>
		///       引用次数
		///       </summary>
		[DefaultValue(0)]
		public int ReferenceCount
		{
			get
			{
				return (int)vmethod_0(gclass371_6);
			}
			set
			{
				base.vmethod_1(gclass371_6, value);
			}
		}
	}
}
