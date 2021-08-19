using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlInsertImages : UserControl
    {
        public ctlInsertImages()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            lstItems.SelectedIndexChanged += new EventHandler(lstItems_SelectedIndexChanged);
            myWriterControl.EventElementMouseDblClick += 
                new ElementMouseEventHandler(myWriterControl_EventElementMouseDblClick);
                
            this.BeginInvoke(new EventHandler(this.InitControl) ,new object[]{ null  , null });
        }

        /// <summary>
        /// 在一个定时器中加载界面内容用于改善用户体验。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InitControl(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.myWriterControl.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
                this.myWriterControl.SetToMSWordVisualStyle();
                ImageListItem.InitControl(this.lstItems);
                this.lstItems.Items.Clear();
                string[] fns = System.IO.Directory.GetFiles(
                    System.IO.Path.Combine(Application.StartupPath, "BigImages"),
                    "*.jpg");
                foreach (string fn in fns)
                {
                    ImageListItem item = new ImageListItem();
                    System.Drawing.Image img = System.Drawing.Image.FromFile(fn);
                    // 获得缩略图
                    System.Drawing.Image img2 = img.GetThumbnailImage(400, 400 * img.Height / img.Width, null, IntPtr.Zero);
                    item.Image = img2;
                    item.FileName = fn;
                    this.lstItems.Items.Add(item);
                }
                string fileName = System.IO.Path.Combine(
                    Application.StartupPath, 
                    "Test\\DOMAuxiliaryOperation\\检查报告单.xml");
                System.Collections.Hashtable entry = new System.Collections.Hashtable();
                entry["姓名"] = "张三";
                entry["性别"] = "男";
                entry["年龄"] = "46岁";
                entry["检查号"] = "00001";
                entry["科室"] = "骨科";
                entry["门诊号"] = "0005";
                entry["住院号"] = "";
                entry["病区"] = "";
                entry["床号"] = "";
                entry["检查部位"] = "胸";
                entry["检查时间"] = "2016-6-6 14:42:33";
                entry["报告医生"] = "张仲景";
                myWriterControl.SetDocumentParameterValue("检查报告信息", entry);
                myWriterControl.LoadDocumentFromFile(fileName, "xml");
                myWriterControl.WriteDataFromDataSourceToDocument();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// 处理文档元素双击事件
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventElementMouseDblClick(object eventSender, ElementMouseEventArgs args)
        {
            if (args.Element is XTextImageElement)
            {
                string fileName = args.Element.GetAttribute("FileName");
                if (System.IO.File.Exists(fileName))
                {
                    // 存在对应的高清图片
                    using (frmShowImage frm = new frmShowImage())
                    {
                        frm.ImageFileName = fileName;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog(this);
                    }
                    args.Handled = true;
                }
            }
        }


        private void btnLayoutByTable_Click(object sender, EventArgs e)
        {
            lstItems_SelectedIndexChanged(null, null);
        }

        
        void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.btnLayoutByTable.Checked)
            {
                LayoutByTable();
            }
            else
            {
                LayoutFree();
            }
        }

        /// <summary>
        /// 自由排版模式
        /// </summary>
        void LayoutFree()
        {
            // 查找容纳图片的单元格对象，需要事先在检查单模板中放置好单元格。
            XTextTableCellElement rootCell = this.myWriterControl.GetElementById("cellImages") as XTextTableCellElement ;
            if (rootCell == null)
            {
                return;
            }
            // 清空单元格内容
            rootCell.Elements.Clear();
            List<ImageListItem> selectedItems = new List<ImageListItem>();
            foreach (ImageListItem item in lstItems.SelectedItems)
            {
                if (selectedItems.Count == 8)
                {
                    // 不能选择超过8个图片
                    break;
                }
                selectedItems.Add(item);
            }
            if (selectedItems.Count > 0)
            {
                // 标准的一行的图片的个数
                int stdImageCountOneLine = 4;

                float clientHeight = rootCell.ClientHeight - 20;
                float clientWidth = rootCell.ClientWidth - 20;
                int imgCount = selectedItems.Count;
                if (selectedItems.Count > stdImageCountOneLine)
                {
                    clientHeight = clientHeight / 2;
                    imgCount = stdImageCountOneLine;
                }
                // 一行图片的总宽度
                float totalImageWidth = 0;
                // 一行图片的平均高度
                float avgImageHeight = 0;
                for( int iCount = 0 ; iCount < imgCount; iCount ++)
                {
                    ImageListItem item = selectedItems[iCount];
                    totalImageWidth = totalImageWidth + item.Image.Width;
                    avgImageHeight = avgImageHeight + item.Image.Height;
                }
                avgImageHeight = avgImageHeight / imgCount ;
                totalImageWidth += 80;
                float imgHeight = clientHeight ;
                if (clientWidth / clientHeight  < (totalImageWidth )/ avgImageHeight)
                {
                    // 图片比较宽,重新计算图片元素高度
                    imgHeight = clientWidth / (  totalImageWidth / avgImageHeight );  
                }
                // 动态的插入图片内容
                foreach (ImageListItem item in selectedItems)
                {
                    System.Drawing.Image img = (Image)item.Image.Clone();
                    XTextImageElement imgElement = new XTextImageElement();
                    imgElement.Image = new Drawing.XImageValue(img);
                    imgElement.SetAttribute("FileName", item.FileName);
                    imgElement.Height = imgHeight;
                    imgElement.Width = imgElement.Height * img.Width / img.Height;
                    imgElement.Title = "双击查看高清大图";
                    rootCell.Elements.Add(imgElement);
                    // 插一个空格
                    XTextStringElement str = new XTextStringElement();
                    str.Text = " ";
                    rootCell.Elements.Add(str);
                }
            }
            XTextParagraphFlagElement flag = new XTextParagraphFlagElement();
            flag.Style.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
            rootCell.Elements.Add(flag);
            myWriterControl.ExecuteCommand("ClearUndo", false, null);
            myWriterControl.RefreshDocument();
        }

        /// <summary>
        /// 表格排版模式
        /// </summary>
        void LayoutByTable()
        {
            // 查找容纳图片的单元格对象，需要事先在检查单模板中放置好单元格。
            XTextTableCellElement rootCell = this.myWriterControl.GetElementById("cellImages") as XTextTableCellElement;
            if (rootCell == null)
            {
                return;
            }
            // 清空单元格内容
            rootCell.Elements.Clear();
            List<ImageListItem> selectedItems = new List<ImageListItem>();
            foreach (ImageListItem item in lstItems.SelectedItems)
            {
                if (selectedItems.Count == 8)
                {
                    // 不能选择超过8个图片
                    break;
                }
                selectedItems.Add(item);
            }
            
            if (selectedItems.Count > 0)
            {
                // 表格行数
                int numOfRows = 1;
                // 表格列数
                int numOfCols = 1;
                int labelHeight = 66;
                // 标准的一行的图片的个数
                int stdImageCountOneLine = 4;

                float clientHeight = rootCell.ClientHeight - 20;
                float clientWidth = rootCell.ClientWidth - 20;
                int imgCount = selectedItems.Count;
                if (selectedItems.Count > stdImageCountOneLine)
                {
                    clientHeight = clientHeight / 2;
                    imgCount = stdImageCountOneLine;
                }
                // 一行图片的总宽度
                float totalImageWidth = 0;
                // 一行图片的平均高度
                float avgImageHeight = 0;
                for (int iCount = 0; iCount < imgCount; iCount++)
                {
                    ImageListItem item = selectedItems[iCount];
                    totalImageWidth = totalImageWidth + item.Image.Width;
                    avgImageHeight = avgImageHeight + item.Image.Height + labelHeight ;
                }
                avgImageHeight = avgImageHeight / imgCount;
                totalImageWidth += 80;
                float imgHeight = clientHeight;
                if (clientWidth / clientHeight < (totalImageWidth) / avgImageHeight)
                {
                    // 图片比较宽,重新计算图片元素高度
                    imgHeight = clientWidth / (totalImageWidth / avgImageHeight);
                }
                XTextTableElement table = new XTextTableElement();
                table.ShowCellNoneBorder = DCBooleanValue.False;
                if (selectedItems.Count <= stdImageCountOneLine)
                {
                    // 一行图片
                    table.Reset(2, selectedItems.Count);
                }
                else
                {
                    // 两行图片
                    table.Reset(4, stdImageCountOneLine);
                }
                rootCell.Elements.Clear();
                rootCell.Elements.Add(table);
                // 调整列宽度
                foreach (XTextTableColumnElement col in table.Columns)
                {
                    col.Width = (rootCell.ClientWidth - 10 ) / table.Columns.Count ;
                }
                // 动态的插入图片内容
                for( int iCount = 0 ; iCount < selectedItems.Count ; iCount ++ )
                {
                    ImageListItem item = selectedItems[ iCount ] ;
                    int rowIndex = iCount >= stdImageCountOneLine ? 2 : 0;
                    int colIndex = iCount % stdImageCountOneLine;
                    System.Drawing.Image img = (Image)item.Image.Clone();
                    XTextImageElement imgElement = new XTextImageElement();
                    imgElement.Image = new Drawing.XImageValue(img);
                    imgElement.SetAttribute("FileName", item.FileName);
                    imgElement.Height = imgHeight - labelHeight ;
                    imgElement.Width = imgElement.Height * img.Width / img.Height;
                    imgElement.Title = "双击查看高清大图";
                    // 图片单元格
                    XTextTableCellElement imgCell = table.GetCell(rowIndex, colIndex, true );
                    imgCell.Elements.Clear();
                    imgCell.Elements.Add(imgElement);
                    XTextParagraphFlagElement flag = new XTextParagraphFlagElement();
                    flag.Style.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
                    imgCell.Elements.Add(flag);

                    // 标签单元格
                    XTextTableCellElement txtCell = table.GetCell(rowIndex + 1, colIndex, true);
                    txtCell.Elements.Clear();
                    XTextStringElement str = new XTextStringElement();
                    str.Text = System.IO.Path.GetFileNameWithoutExtension(item.FileName);
                    txtCell.Elements.Add(str);

                    flag = new XTextParagraphFlagElement();
                    flag.Style.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
                    txtCell.Elements.Add(flag);
                }
            }
            
            myWriterControl.ExecuteCommand("ClearUndo", false, null);
            myWriterControl.RefreshDocument();
        }

        public class ImageListItem
        {
            public static void InitControl(System.Windows.Forms.ListBox ctl)
            {
                if (ctl == null)
                {
                    throw new ArgumentNullException("ctl");
                }
                ctl.DrawMode = DrawMode.OwnerDrawFixed;
                ctl.ItemHeight = 200;
                ctl.DrawItem += new DrawItemEventHandler(ctl_DrawItem);
                ctl.Disposed += new EventHandler(ctl_Disposed);
            }

            static void ctl_Disposed(object sender, EventArgs e)
            {
                System.Windows.Forms.ListBox ctl = (System.Windows.Forms.ListBox)sender;
                foreach (ImageListItem item in ctl.Items)
                {
                    if (item.Image != null)
                    {
                        item.Image.Dispose();
                        item.Image = null;
                    }
                }
                ctl.Items.Clear();
            }

            static void ctl_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (e.Index < 0)
                {
                    return;
                }
                System.Windows.Forms.ListBox ctl = ( System.Windows.Forms.ListBox ) sender ;
                ImageListItem item = (ImageListItem)ctl.Items[e.Index];
                //e.DrawBackground();
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                if (item.Image != null)
                {
                    DrawImageCenter(e.Graphics, item.Image, e.Bounds);
                }
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    using (Pen p = new Pen(Color.Blue, 3))
                    {
                        e.Graphics.DrawRectangle(
                            p,
                            e.Bounds.Left+3, 
                            e.Bounds.Top+3,
                            e.Bounds.Width - 6,
                            e.Bounds.Height - 6);
                    }
                }
                e.DrawFocusRectangle();
            }

            /// <summary>
            /// 以居中方式绘制图片，自动缩放图片来填充区域，并保持图片的长宽比
            /// </summary>
            /// <param name="g">画布对象</param>
            /// <param name="img">图片对象</param>
            /// <param name="bounds">要显示的区域</param>
            /// <returns>实际显示图片的区域</returns>
            public static System.Drawing.Rectangle DrawImageCenter(
                System.Drawing.Graphics g ,
                System.Drawing.Image img ,
                System.Drawing.Rectangle bounds )
            {
                if (g == null)
                {
                    throw new ArgumentNullException("g");
                }
                if (img == null)
                {
                    throw new ArgumentNullException("img");
                }
                if (bounds.Width <= 0 || bounds.Height <= 0)
                {
                    return Rectangle.Empty ;
                }
                int viewWidth = bounds.Width;
                int viewHeight = bounds.Height;
                if ((float)bounds.Width / (float)bounds.Height > (float)img.Width / (float)img.Height)
                {
                    // 绘制区域特别宽、图片特别窄
                    viewWidth = bounds.Height * img.Width / img.Height;
                    viewHeight = bounds.Height;
                }
                else
                {
                    // 绘制区域特别窄、图片特别宽
                    viewWidth = bounds.Width;
                    viewHeight = bounds.Width * img.Height / img.Width;
                }
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                    bounds.Left + (bounds.Width - viewWidth) / 2,
                    bounds.Top + (bounds.Height - viewHeight) / 2,
                    viewWidth,
                    viewHeight);
                g.DrawImage(img, rect);
                return rect;
            }

            private System.Drawing.Image _Image = null;
            /// <summary>
            /// 预览图片
            /// </summary>
            public System.Drawing.Image Image
            {
                get { return _Image; }
                set { _Image = value; }
            }

            private string _FileName = null;
            /// <summary>
            /// 原始图片文件名
            /// </summary>
            public string FileName
            {
                get { return _FileName; }
                set { _FileName = value; }
            }
        }

        private void btnShowFlag_Click(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.ViewOptions.ShowParagraphFlag = btnShowFlag.Checked;
            myWriterControl.RedrawDocument();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.InitControl(null, null);
        }



    }
}