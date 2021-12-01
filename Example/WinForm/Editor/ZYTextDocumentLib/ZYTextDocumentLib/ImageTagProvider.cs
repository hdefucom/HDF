using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 15;

		public override Point GetPos()
		{
			ZYTextImage currentImage = GetCurrentImage();
			if (currentImage != null)
			{
				return new Point(currentImage.Bounds.Right + 2, currentImage.Bounds.Top + 2);
			}
			return Point.Empty;
		}

		private ZYTextImage GetCurrentImage()
		{
			ZYTextImage zYTextImage = Element as ZYTextImage;
			if (zYTextImage == null)
			{
				return null;
			}
			if (!(zYTextImage?.Deleteted ?? true))
			{
				return zYTextImage;
			}
			return null;
		}

		public override bool isEnable()
		{
			return GetCurrentImage() != null;
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextImage currentImage = GetCurrentImage();
			if (currentImage != null && OwnerDocument.Info.DesignMode)
			{
				myList.Add(new SmartTagItem(this, 4, "设定名称[" + currentImage.ID + "]为..."));
				myList.Add(new SmartTagItem(this, 5, "编辑图像..."));
				myList.Add(new SmartTagItem(this, 0, "图片另存为..."));
				myList.Add(new SmartTagItem(this, 2, !currentImage.CanResize, "锁定大小"));
				if (currentImage.CanResize)
				{
					myList.Add(new SmartTagItem(this, 1, "设置为原始大小"));
					myList.Add(new SmartTagItem(this, 3, currentImage.ImageSizeRectLock, "锁定宽度和高度的比例"));
				}
			}
			if (currentImage != null && currentImage.ImageIndex == "-1")
			{
				myList.Add(new SmartTagItem(this, 6, "清除标记信息"));
			}
			else if (!string.IsNullOrEmpty(currentImage.ImageIndex))
			{
				myList.Add(new SmartTagItem(this, 7, "修改图片索引"));
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextImage currentImage = GetCurrentImage();
			if (currentImage == null)
			{
				return false;
			}
			Image image = currentImage.Image;
			switch (item.ID)
			{
			case 0:
				if (image != null)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.OverwritePrompt = true;
						saveFileDialog.CheckPathExists = true;
						saveFileDialog.Filter = "PNG图片|*.png";
						if (saveFileDialog.ShowDialog(OwnerControl) == DialogResult.OK)
						{
							image.Save(saveFileDialog.FileName, ImageFormat.Png);
						}
					}
					return true;
				}
				break;
			case 1:
				if (image != null)
				{
					OwnerDocument.BeginContentChangeLog();
					currentImage.Width = OwnerDocument.PixelToDocumentUnit(image.Size.Width);
					currentImage.Height = OwnerDocument.PixelToDocumentUnit(image.Size.Height);
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				}
				break;
			case 2:
				currentImage.CanResize = !currentImage.CanResize;
				OwnerDocument.RefreshElement(currentImage);
				return true;
			case 3:
				currentImage.ImageSizeRectLock = !currentImage.ImageSizeRectLock;
				if (currentImage.ImageSizeRectLock)
				{
					OwnerDocument.BeginContentChangeLog();
					currentImage.Height = (int)((double)currentImage.Width / currentImage.WidthHeightRate);
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
				}
				return true;
			case 4:
			{
				string text2 = dlgInputBox.InputBox("请输入图片新的编号", "修改编号", currentImage.ID);
				if (text2 != null)
				{
					currentImage.ID = text2;
				}
				return true;
			}
			case 5:
				currentImage.EditImage();
				return true;
			case 6:
				currentImage.ClearImgMark();
				return true;
			case 7:
			{
				string text = dlgInputBox.InputBox("请输入图片新的索引", "修改索引", currentImage.ImageIndex);
				if (text != null)
				{
					currentImage.ImageIndex = text;
				}
				return true;
			}
			}
			return false;
		}
	}
}
