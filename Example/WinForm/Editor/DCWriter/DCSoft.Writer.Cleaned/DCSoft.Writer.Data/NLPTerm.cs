using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	[ComVisible(false)]
	public class NLPTerm
	{
		private int _StartPosition = 0;

		private int _EndPosition = 0;

		private string _Text = null;

		private string _Type = null;

		public int StartPosition
		{
			get
			{
				return _StartPosition;
			}
			set
			{
				_StartPosition = value;
			}
		}

		public int EndPosition
		{
			get
			{
				return _EndPosition;
			}
			set
			{
				_EndPosition = value;
			}
		}

		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		public string Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}
	}
}
