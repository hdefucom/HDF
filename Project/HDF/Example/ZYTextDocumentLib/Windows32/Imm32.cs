using System.Runtime.InteropServices;
using System.Text;

namespace Windows32
{
	public class Imm32
	{
		public struct CandidateForm
		{
			public int dwIndex;

			public int dwStyle;

			public POINT ptCurrentPos;

			public RECT rcArea;
		}

		public enum CandidateFormStyle
		{
			CFS_DEFAULT = 0,
			CFS_RECT = 1,
			CFS_POINT = 2,
			CFS_FORCE_POSITION = 0x20,
			CFS_CANDIDATEPOS = 0x40,
			CFS_EXCLUDE = 0x80
		}

		public struct CompositionForm
		{
			public int Style;

			public POINT CurrentPos;

			public RECT Area;
		}

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern int ImmCreateContext();

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmDestroyContext(int hImc);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmSetCandidateWindow(int hImc, ref CandidateForm frm);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmSetStatusWindowPos(int hImc, ref POINT pos);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern int ImmGetContext(int hwnd);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmReleaseContext(int hwnd, int hImc);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmGetOpenStatus(int hImc);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern bool ImmSetCompositionWindow(int hImc, ref CompositionForm frm);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		public static extern int ImmAssociateContext(int hWnd, int hIMC);

		[DllImport("imm32.dll")]
		public static extern int ImmGetCompositionString(int hIMC, int dwIndex, StringBuilder lpBuf, int dwBufLen);

		public static bool isImmOpen(int hWnd)
		{
			int num = ImmGetContext(hWnd);
			if (num == 0)
			{
				return false;
			}
			bool result = ImmGetOpenStatus(num);
			ImmReleaseContext(hWnd, num);
			return result;
		}

		public static void SetImmPos(int hWnd, int x, int y)
		{
			bool flag = false;
			uint num = 0u;
			int num2 = ImmGetContext(hWnd);
			if (num2 != 0)
			{
				CompositionForm frm = default(CompositionForm);
				frm.CurrentPos.x = x;
				frm.CurrentPos.y = y;
				frm.Style = 2;
				flag = ImmSetCompositionWindow(num2, ref frm);
				num = Kernel32.GetLastError();
				ImmReleaseContext(hWnd, num2);
			}
		}
	}
}
