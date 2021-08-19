using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       编辑器可引用的组件类型信息
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ComponentTypeInfo : IComparable
	{
		private string _Name = null;

		private string _Namespace = null;

		private string _FullName = null;

		[NonSerialized]
		private Type _BaseType = null;

		private string _BaseTypeFullName = null;

		private string _AssemblyFullName = null;

		private Image _ToolboxImage = null;

		                                                                    /// <summary>
		                                                                    ///       控件类型名称
		                                                                    ///       </summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       类型命名空间
		                                                                    ///       </summary>
		public string Namespace
		{
			get
			{
				return _Namespace;
			}
			set
			{
				_Namespace = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       全名
		                                                                    ///       </summary>
		public string FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				_FullName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       命中的基础类型
		                                                                    ///       </summary>
		public Type BaseType
		{
			get
			{
				return _BaseType;
			}
			set
			{
				_BaseType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       指定的基础类型全名
		                                                                    ///       </summary>
		[Browsable(false)]
		public string BaseTypeFullName
		{
			get
			{
				return _BaseTypeFullName;
			}
			set
			{
				_BaseTypeFullName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       程序集名称
		                                                                    ///       </summary>
		public string AssemblyFullName
		{
			get
			{
				return _AssemblyFullName;
			}
			set
			{
				_AssemblyFullName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       图标图片
		                                                                    ///       </summary>
		public Image ToolboxImage
		{
			get
			{
				return _ToolboxImage;
			}
			set
			{
				_ToolboxImage = value;
			}
		}

		public override string ToString()
		{
			return FullName;
		}

		public int CompareTo(object target)
		{
			ComponentTypeInfo componentTypeInfo = (ComponentTypeInfo)target;
			return string.Compare(FullName, componentTypeInfo.FullName);
		}
	}
}
