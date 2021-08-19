using System.Collections.Generic;
using System.Text;

namespace ZYTextDocumentLib
{
	public class ZYTextLine
	{
		public int LineSpacing = 0;

		public List<ZYTextElement> Elements = new List<ZYTextElement>();

		public int Index = 0;

		public int RealLeft = 0;

		public int RealTop = 0;

		public int Top = 0;

		public int Height = 0;

		public int RealIndex = 0;

		public ZYTextContainer Container = null;

		public int ContentWidth = 0;

		public int FullHeight => Height + LineSpacing;

		public ZYTextElement FirstElement
		{
			get
			{
				if (Elements != null && Elements.Count > 0)
				{
					return Elements[0];
				}
				return null;
			}
		}

		public ZYTextElement LastElement
		{
			get
			{
				if (Elements != null && Elements.Count > 0)
				{
					return Elements[Elements.Count - 1];
				}
				return null;
			}
		}

		public bool HasLineEnd => Elements != null && Elements.Count > 0 && Elements[Elements.Count - 1].isNewLine();

		public int RealBottom => RealTop + Height;

		public int Bottom => Top + Height;

		public string ToEMRString()
		{
			if (Elements != null && Elements.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (ZYTextElement element in Elements)
				{
					stringBuilder.Append(element.ToEMRString());
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		public int CalcuteRealIndex()
		{
			int num = Index;
			ZYTextContainer zYTextContainer = Container;
			while (zYTextContainer != null && zYTextContainer.OwnerLine != null)
			{
				num += zYTextContainer.OwnerLine.Index + zYTextContainer.LineSpan - 1;
				zYTextContainer = zYTextContainer.Parent;
			}
			return num;
		}
	}
}
