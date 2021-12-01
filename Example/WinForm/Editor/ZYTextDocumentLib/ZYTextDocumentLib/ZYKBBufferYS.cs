namespace ZYTextDocumentLib
{
	public class ZYKBBufferYS : ZYKBBuffer
	{
		private static ZYKBBufferYS myInstance = new ZYKBBufferYS();

		public new static ZYKBBufferYS Instance => myInstance;

		public ZYKBBufferYS()
		{
			Mod = 1;
		}
	}
}
