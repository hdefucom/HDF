using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form8 : Form7
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            MagneticManager manager = new MagneticManager(this);


            var l = new Form7();
            var t = new Form7();
            var r = new Form7();
            var b = new Form7();
            l.Show();
            t.Show();
            r.Show();
            b.Show();


            manager.addChild(l, MagneticLocation.Left);
            manager.addChild(t, MagneticLocation.Top);
            manager.addChild(r, MagneticLocation.Right);
            manager.addChild(b, MagneticLocation.Bottom);


        }
    }




    /// <summary>
    /// 磁吸位置
    /// </summary>
    public enum MagneticLocation
    {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3
    }

    /// <summary>
    /// 磁吸状态
    /// </summary>
    public enum MagneticState
    {
        Adsorbent, // 吸附
        Separation // 分离
    }

    /// <summary>
    /// 磁吸管理器
    /// </summary>
    public class MagneticManager
    {
        public class ChildFormInfo
        {
            public Form Child { get; set; }
            public MagneticLocation Location { get; set; }
            public MagneticState State { get; set; }
            public bool CutstomSetLocation { get; set; }
        }

        public int Step { get; set; }

        private Form m_mainForm = null;
        private List<ChildFormInfo> m_childs = new List<ChildFormInfo>();

        public MagneticManager(Form form)
        {
            m_mainForm = form;
            form.LocationChanged += MainForm_LocationChanged;
            form.SizeChanged += MainForm_SizeChanged;
            form.FormClosed += MainForm_FormClosed;
            Step = 20;
        }

        public void addChild(Form childForm, MagneticLocation loc)
        {
            foreach (ChildFormInfo info in m_childs)
            {
                if (info.Child == childForm)
                {
                    return;
                }
            }

            ChildFormInfo childInfo = new ChildFormInfo();
            childInfo.Child = childForm;
            childInfo.Location = loc;
            childInfo.State = MagneticState.Adsorbent;
            childInfo.CutstomSetLocation = false;
            childForm.LocationChanged += ChildForm_LocationChanged;
            childForm.SizeChanged += ChildForm_SizeChanged;
            childForm.FormClosed += ChildForm_FormClosed;

            m_childs.Add(childInfo);
            adsorbentChild(childInfo);
        }

        private ChildFormInfo getInfo(Form form)
        {
            if (form == null)
            {
                return null;
            }

            foreach (ChildFormInfo info in m_childs)
            {
                if (info.Child == form)
                {
                    return info;
                }
            }

            return null;
        }

        private Point getLocation(ChildFormInfo info)
        {
            Point pos = Point.Empty;

            switch (info.Location)
            {
                case MagneticLocation.Left:
                    pos = new Point(m_mainForm.Left - info.Child.Width + 14, m_mainForm.Top);
                    break;
                case MagneticLocation.Right:
                    pos = new Point(m_mainForm.Right - 14, m_mainForm.Top);
                    break;
                case MagneticLocation.Top:
                    pos = new Point(m_mainForm.Left, m_mainForm.Top - info.Child.Height);
                    break;
                case MagneticLocation.Bottom:
                    pos = new Point(m_mainForm.Left, m_mainForm.Bottom);
                    break;
                default:
                    break;
            }

            return pos;
        }

        private void setChildLocation(ChildFormInfo info, Point location)
        {
            if (info.Child == null)
            {
                return;
            }

            info.CutstomSetLocation = true;
            info.Child.Location = location;
            info.CutstomSetLocation = false;
        }

        private void setChildLocation(ChildFormInfo info, int x, int y)
        {
            setChildLocation(info, new Point(x, y));
        }

        private void resetChildLocation(ChildFormInfo info)
        {
            if (info.Child == null)
            {
                return;
            }

            Point pos = getLocation(info);
            setChildLocation(info, pos);
        }

        private void adsorbentChild(ChildFormInfo info)
        {
            info.State = MagneticState.Adsorbent;
            resetChildLocation(info);
        }

        private void separationChild(ChildFormInfo info)
        {
            info.State = MagneticState.Separation;
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            foreach (ChildFormInfo info in m_childs)
            {
                if (info.State == MagneticState.Adsorbent)
                {
                    resetChildLocation(info);
                }
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (ChildFormInfo info in m_childs)
            {
                if (info.State == MagneticState.Adsorbent)
                {
                    resetChildLocation(info);
                }
            }
        }

        private void MainForm_FormClosed(object sender, EventArgs e)
        {
        }

        private void ChildForm_LocationChanged(object sender, EventArgs e)
        {
            ChildFormInfo info = getInfo(sender as Form);

            if (info == null)
            {
                return;
            }

            if (info.CutstomSetLocation == true)
            {
                return;
            }

            Point location = getLocation(info);

            if (info.Child.Left > location.X && info.Location == MagneticLocation.Right)
            {
                if (info.Child.Left - location.X > Step)
                {
                    separationChild(info);
                }
                else
                {
                    adsorbentChild(info);
                }
            }
            else if (info.Child.Left < location.X && info.Location == MagneticLocation.Left)
            {
                if (info.Child.Left - location.X < -Step)
                {
                    separationChild(info);
                }
                else
                {
                    adsorbentChild(info);
                }
            }
            if (info.Child.Top > location.Y && info.Location == MagneticLocation.Bottom)
            {
                if (info.Child.Top - location.Y > Step)
                {
                    separationChild(info);
                }
                else
                {
                    adsorbentChild(info);
                }
            }
            else if (info.Child.Top < location.Y && info.Location == MagneticLocation.Top)
            {
                if (info.Child.Top - location.Y < -Step)
                {
                    separationChild(info);
                }
                else
                {
                    adsorbentChild(info);
                }
            }
        }

        private void ChildForm_SizeChanged(object sender, EventArgs e)
        {
            ChildFormInfo info = getInfo(sender as Form);

            if (info != null && info.State == MagneticState.Adsorbent)
            {
                resetChildLocation(info);
            }
        }

        private void ChildForm_FormClosed(object sender, EventArgs e)
        {
            ChildFormInfo info = getInfo(sender as Form);

            if (info != null)
            {
                m_childs.Remove(info);
            }
        }
    }



































}
