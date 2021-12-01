using System;
using System.Drawing;

namespace Windows32
{
	public class CaptureMouseMoveEventArgs : EventArgs
	{
		private MouseCapturer mySender = null;

		private Point myStartPosition = Point.Empty;

		private Point myCurrentPosition = Point.Empty;

		private bool bolCancel = false;

		public MouseCapturer Sender => mySender;

		public Point StartPosition
		{
			get
			{
				return myStartPosition;
			}
			set
			{
				myStartPosition = value;
			}
		}

		public Point CurrentPosition
		{
			get
			{
				return myCurrentPosition;
			}
			set
			{
				myCurrentPosition = value;
			}
		}

		public int DX => myCurrentPosition.X - myStartPosition.X;

		public int DY => myCurrentPosition.Y - myStartPosition.Y;

		public bool Cancel
		{
			get
			{
				return bolCancel;
			}
			set
			{
				bolCancel = value;
			}
		}

		public CaptureMouseMoveEventArgs(MouseCapturer sender, Point sp, Point cp)
		{
			mySender = sender;
			myStartPosition = sp;
			myCurrentPosition = cp;
			bolCancel = false;
		}
	}
}
