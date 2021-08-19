namespace ZYTextDocumentLib
{
	public class ZYVBEventObject
	{
		public ZYVBEventType EventType = ZYVBEventType.None;

		public bool AltKey = false;

		public bool CtlKey = false;

		public bool ShiftKey = false;

		public int KeyCode = 0;

		public object Source = null;

		public ZYTextElement Element = null;

		public int MouseButton = 0;

		public int ClientX = 0;

		public int ClientY = 0;

		public int X = 0;

		public int Y = 0;

		public int ScreenX = 0;

		public int ScreenY = 0;

		public bool CancelBubble = false;

		public object ReturnValue = null;

		public bool Cancel = false;
	}
}
