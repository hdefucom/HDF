using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands.Design
{
	/// <summary>
	///       编辑器命令简单的说明信息
	///       </summary>
	[DCInternal]
	[ComVisible(false)]
	public class WriterCommandSimpleInfo : IComparable<WriterCommandSimpleInfo>
	{
		private string _Name = null;

		private string _Description = null;

		private string _ModuleName = null;

		private Image _Image = null;

		private int _ImageIndex = -1;

		/// <summary>
		///       命令名称
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
		///       说明
		///       </summary>
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		/// <summary>
		///       模块名称
		///       </summary>
		public string ModuleName
		{
			get
			{
				return _ModuleName;
			}
			set
			{
				_ModuleName = value;
			}
		}

		/// <summary>
		///       图标
		///       </summary>
		public Image Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
			}
		}

		/// <summary>
		///       图标编号
		///       </summary>
		public int ImageIndex
		{
			get
			{
				return _ImageIndex;
			}
			set
			{
				_ImageIndex = value;
			}
		}

		public WriterCommandSimpleInfo(GClass133 cmdDesc)
		{
			_Name = cmdDesc.method_4();
			_Description = cmdDesc.method_14();
			_Image = cmdDesc.method_16();
		}

		/// <summary>
		///       比较名称
		///       </summary>
		/// <param name="other">
		/// </param>
		/// <returns>
		/// </returns>
		public int CompareTo(WriterCommandSimpleInfo other)
		{
			return string.Compare(_Name, other._Name);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
