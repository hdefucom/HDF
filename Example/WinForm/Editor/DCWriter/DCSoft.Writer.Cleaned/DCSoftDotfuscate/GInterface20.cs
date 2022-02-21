using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public interface GInterface20
	{
		WriterViewControl ViewControl
		{
			get;
			set;
		}

		bool Enable
		{
			get;
		}

		void imethod_0();

		void imethod_1();

		void InvalidateLayout(XTextControlHostElement element);

		void UpdateInvalidateLayout();

		void UpdateHostWindowsControlPosition();

		void UpdateHostWindowsControlPositionAsynic();

		void UpdateHostWindowsControlPositionAsynic(XTextControlHostElement element);

		void UpdateHostWindowsControlPosition(XTextControlHostElement element);

		void ResetHostControl(XTextControlHostElement element);

		Control ReloadControl(XTextControlHostElement element, bool checkDelayLoad, bool addAfterHostedControlLoaded);

		void RemoveControl(XTextControlHostElement element);

		Control GetControl(XTextControlHostElement element);

		void UpdateControlContentVersion(XTextControlHostElement element);

		SizeF TrySetControlSize(XTextControlHostElement element, float viewWidth, float viewHeight);

		void RemoveDeletedHostControl();

		void ReloadControls();

		void DeleteUnkownControls();

		void ClearControls();
	}
}
