using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GHIS.Ctrl
{
    /// <summary>
    /// 水平居中容器控件
    /// </summary>
    [Description("水平居中容器控件")]
    public class CenterLayoutPanel : Panel
    {
        [DefaultValue(0)]
        [Description("子控件垂直间距")]
        [Category("自定义属性")]
        public int ControlVerticalSpacing { get; set; }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            SetLayout();
        }


        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            SetLayout();
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }

        private void SetLayout(string text = null)
        {
            if (Controls.Count == 0)
                return;

            var max = Controls.Cast<Control>().Max(c => c.Width);

            if (max > ClientSize.Width - Padding.Horizontal)
                AutoScrollMinSize = new Size(max + Padding.Horizontal, ClientSize.Height);
            else
                AutoScrollMinSize = ClientSize;

            var width = AutoScrollMinSize.Width - Padding.Horizontal;

            var p = this.AutoScrollPosition;

            var y = Padding.Top;

            foreach (Control control in Controls)
            {
                if (control.Width > Width)
                    continue;

                //control.Text = text ?? max.ToString();
                control.Top = y + p.Y;
                control.Left = Padding.Left + (width - control.Width) / 2;
                y += control.Height + ControlVerticalSpacing;
            }
            y -= ControlVerticalSpacing;
            y += Padding.Bottom;
            AutoScrollMinSize = new Size(AutoScrollMinSize.Width, y);
        }





    }




}
