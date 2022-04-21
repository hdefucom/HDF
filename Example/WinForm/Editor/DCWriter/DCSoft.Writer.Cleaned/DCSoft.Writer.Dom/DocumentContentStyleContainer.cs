using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档样式容器
	///       </summary>
	[Serializable]
	
	[ClassInterface(ClassInterfaceType.None)]
	
	[ComDefaultInterface(typeof(IDocumentContentStyleContainer))]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890045")]
	[ComClass("00012345-6789-ABCD-EF01-234567890045", "403CE00C-8CB7-44E3-8A7A-5668B6830A51")]
	public class DocumentContentStyleContainer : ContentStyleContainer, IDocumentContentStyleContainer
	{
		internal const string string_0 = "00012345-6789-ABCD-EF01-234567890045";

		internal const string string_1 = "403CE00C-8CB7-44E3-8A7A-5668B6830A51";

		internal bool bool_0 = true;

		private XTextDocument xtextDocument_0 = null;

		[NonSerialized]
		private List<int> list_0 = null;

		/// <summary>
		///       对象所示文档对象
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       默认样式
		///       </summary>
		[XmlElement("Default", typeof(DocumentContentStyle))]
		
		public override ContentStyle Default
		{
			get
			{
				return base.Default;
			}
			set
			{
				if (value != null && value.GetType().Equals(typeof(ContentStyle)))
				{
					DocumentContentStyle documentContentStyle = new DocumentContentStyle();
					XDependencyObject.CopyValueFast(value, documentContentStyle);
					base.Default = documentContentStyle;
				}
				else
				{
					base.Default = value;
				}
			}
		}

		/// <summary>
		///       样式列表
		///       </summary>
		
		[XmlArrayItem("Style", typeof(DocumentContentStyle))]
		public override ContentStyleList Styles
		{
			get
			{
				return base.Styles;
			}
			set
			{
				base.Styles = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentContentStyleContainer()
		{
		}

		
		public RuntimeDocumentContentStyle method_3(int int_0)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)GetStyle(int_0);
			if (documentContentStyle == null || documentContentStyle == Default)
			{
				return ((DocumentContentStyle)Default).MyRuntimeStyle;
			}
			return documentContentStyle.MyRuntimeStyle;
		}

		internal void method_4()
		{
			if (bool_0)
			{
				if (Default != null)
				{
					((DocumentContentStyle)Default).vmethod_3();
				}
				foreach (ContentStyle style in Styles)
				{
					((DocumentContentStyle)style).vmethod_3();
					if (style.RuntimeStyle != null)
					{
						((DocumentContentStyle)style).vmethod_3();
					}
				}
			}
		}

		
		public override void vmethod_0()
		{
			base.vmethod_0();
			list_0 = null;
		}

		internal bool method_5(int int_0, bool bool_1)
		{
			if (int_0 < 0)
			{
				return true;
			}
			ContentStyleList styles = Styles;
			if (styles == null || bool_1)
			{
				return true;
			}
			if (list_0 == null)
			{
				list_0 = new List<int>();
				for (int i = 0; i < styles.Count; i++)
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[i];
					if (documentContentStyle.DeleterIndex >= 0)
					{
						list_0.Add(i);
					}
				}
			}
			if (list_0.Count == 0)
			{
				return true;
			}
			return !list_0.Contains(int_0);
		}

		internal bool method_6(int int_0)
		{
			if (int_0 < 0)
			{
				return true;
			}
			if (Styles == null || Document == null || Document.Options.SecurityOptions.ShowLogicDeletedContent)
			{
				return true;
			}
			if (list_0 == null)
			{
				list_0 = new List<int>();
				for (int i = 0; i < Styles.Count; i++)
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)Styles[i];
					if (documentContentStyle.DeleterIndex >= 0)
					{
						list_0.Add(i);
					}
				}
			}
			if (list_0.Count == 0)
			{
				return true;
			}
			return !list_0.Contains(int_0);
		}

		internal List<int> method_7()
		{
			List<int> list = new List<int>();
			foreach (DocumentContentStyle style in Styles)
			{
				if (style.HasTitleLevel)
				{
					list.Add(Styles.IndexOf(style));
				}
			}
			if (list.Count > 0)
			{
				return list;
			}
			return null;
		}

		/// <summary>
		///       创建文档样式信息对象
		///       </summary>
		/// <returns>创建的信息对象</returns>
		
		public override ContentStyle CreateStyleInstance()
		{
			return new DocumentContentStyle();
		}

		
		public void method_8(DCGraphics dcgraphics_0)
		{
			int num = 17;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			if (Default != null)
			{
				((DocumentContentStyle)Default).method_32(dcgraphics_0);
			}
			method_1();
			for (int i = 0; i < Styles.Count; i++)
			{
				((DocumentContentStyle)Styles[i]).method_32(dcgraphics_0);
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)GetRuntimeStyle(i);
				documentContentStyle.method_32(dcgraphics_0);
			}
		}
	}
}
