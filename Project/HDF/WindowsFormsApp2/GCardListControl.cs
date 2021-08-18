using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHIS.Ctrl
{
    /// <summary>
    /// 提供自定义绘制的卡片列表控件
    /// </summary>
    [Description("提供自定义绘制的卡片列表控件")]
    public class GCardListControl : ScrollableControl
    {

        public GCardListControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.ContainerControl, false);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        #region 卡片事件

        /// <summary>
        /// 卡片鼠标单击事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标单击事件")]
        public event Action<Card, MouseEventArgs> CardMouseClick;
        /// <summary>
        /// 卡片鼠标双击事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标双击事件")]
        public event Action<Card, MouseEventArgs> CardMouseDoubleClick;
        /// <summary>
        /// 卡片鼠标移动事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标移动事件")]
        public event Action<Card, MouseEventArgs> CardMouseMove;
        /// <summary>
        /// 卡片鼠标进入事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标进入事件")]
        public event Action<Card, MouseEventArgs> CardMouseEnter;
        /// <summary>
        /// 卡片鼠标离开事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标离开事件")]
        public event Action<Card, EventArgs> CardMouseLeave;
        /// <summary>
        /// 卡片鼠标悬浮事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片鼠标悬浮事件")]
        public event Action<Card, EventArgs> CardMouseHover;

        /// <summary>
        /// 卡片绘制事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片绘制事件")]
        public event Action<Card, PaintEventArgs> CardPaint;

        /// <summary>
        /// 卡片选中事件
        /// </summary>
        [Category("CardList事件")]
        [Description("卡片选中改变事件")]
        public event Action<Card> CardCheckedChanged;


        public virtual void OnCardMouseClick(Card obj, MouseEventArgs e) => CardMouseClick?.Invoke(obj, e);
        public virtual void OnCardMouseDoubleClick(Card obj, MouseEventArgs e) => CardMouseDoubleClick?.Invoke(obj, e);
        public virtual void OnCardMouseMove(Card obj, MouseEventArgs e) => CardMouseMove?.Invoke(obj, e);
        public virtual void OnCardMouseEnter(Card obj, MouseEventArgs e) => CardMouseEnter?.Invoke(obj, e);
        public virtual void OnCardMouseLeave(Card obj, EventArgs e) => CardMouseLeave?.Invoke(obj, e);
        public virtual void OnCardMouseHover(Card obj, EventArgs e) => CardMouseHover?.Invoke(obj, e);
        public virtual void OnCardPaint(Card obj, PaintEventArgs e) => CardPaint?.Invoke(obj, e);
        public virtual void OnCardCheckedChanged(Card obj) => CardCheckedChanged?.Invoke(obj);

        #endregion

        #region  卡片属性

        /// <summary>
        /// 卡片大小
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片大小")]
        [DefaultValue(typeof(Size), "100,100")]
        public Size CardSize { get; set; } = new Size(100, 100);

        /// <summary>
        /// 卡片背景色
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片背景色")]
        [DefaultValue(typeof(Color), "White")]
        public Color CardBackColor { get; set; } = Color.White;

        /// <summary>
        /// 卡片选中边框特效颜色
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片选中边框特效颜色")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color CardSelectionBorderColor { get; set; } = Color.Silver;

        /// <summary>
        /// 卡片选中边框特效宽度
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片选中边框特效宽度")]
        [DefaultValue(10)]
        public int CardSelectionBorderWidth { get; set; } = 10;

        /// <summary>
        /// 卡片是否显示选中边框特效
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片是否显示选中边框特效")]
        [DefaultValue(true)]
        public bool CardShowSelectionBorder { get; set; } = true;

        /// <summary>
        /// 卡片最小间距
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片最小间距")]
        [DefaultValue(10)]
        public int CardMinPadding { get; set; } = 10;

        /// <summary>
        /// 卡片是否自定义绘制背景
        /// </summary>
        [Category("CardList属性")]
        [Description("卡片是否自定义绘制背景")]
        [DefaultValue(false)]
        public bool CardIsCustomPaintBack { get; set; }

        #endregion


        private List<Card> Cards = new List<Card>();

        /// <summary>
        /// 设置card列表数据
        /// </summary>
        /// <param name="data"></param>
        public void SetDataSource<T>(IEnumerable<T> data)
        {
            if (data == null || data.Count() == 0)
                return;
            Cards.Clear();
            Cards.AddRange(data.Select(d => new Card(this) { Tag = d }));
            SetLayout();
            this.Refresh();
        }

        /// <summary>
        /// 设置card布局信息
        /// </summary>
        private void SetLayout()
        {
            if (Cards == null || Cards.Count == 0)
                return;


            var w = this.ClientSize.Width;

            if (w < this.CardSize.Width + this.CardMinPadding * 2)
                w = this.CardSize.Width + this.CardMinPadding * 2;

            var minpadding = this.CardMinPadding;

            var cardw = this.CardSize.Width;
            var cardh = this.CardSize.Height;

            var column = (w - minpadding) / (cardw + minpadding);

            var 剩余宽度 = (w - minpadding) % (cardw + minpadding);

            minpadding += 剩余宽度 / (column + 1);

            var row = Cards.Count % column == 0 ? Cards.Count / column : (Cards.Count / column) + 1;

            var x = minpadding;
            var y = minpadding;

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    var index = c + r * column;
                    if (index >= Cards.Count)
                    {
                        SetAutoScrollMinSize();
                        return;
                    }
                    Cards[index].Location = new Point(x, y);
                    x += cardw + minpadding;
                }
                x = minpadding;
                y += cardh + minpadding;
            }

            SetAutoScrollMinSize();
        }

        private void SetAutoScrollMinSize()
        {
            var clientbound = Rectangle.Empty;
            this.Cards.ForEach(a => clientbound = Rectangle.Union(clientbound, a.Bound));
            clientbound.Width += this.CardMinPadding;
            clientbound.Height += this.CardMinPadding;
            this.AutoScrollMinSize = clientbound.Size;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            SetLayout();

            base.OnResize(eventargs);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //偏移无效区域原点坐标进行card无效区域校验
            var rect = e.ClipRectangle;
            rect.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);

            foreach (var card in Cards)
            {
                if (rect.IntersectsWith(card.Bound))
                {//如果该card无效，进行画板原点偏移触发重绘，card内部绘制时坐标原点在card相对于CardList的Location位置

                    //    //存在内存爆炸问题
                    //    using (var img = new Bitmap(CardSize.Width, CardSize.Height))
                    //    {
                    //        var g = Graphics.FromImage(img);
                    //        card.OnPaint(new PaintEventArgs(g, new Rectangle(Point.Empty, card.Size)));

                    //        e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                    //        e.Graphics.DrawImage(img, card.Location);

                    //        e.Graphics.ResetTransform();
                    //    }

                    if (CardShowSelectionBorder && card.Checked)
                        DrawSelectionBorder(e.Graphics, card.Bound, CardSelectionBorderColor, CardSelectionBorderWidth);

                    var state = e.Graphics.Save();
                    //矩阵偏移坐标原点
                    e.Graphics.TranslateTransform(this.AutoScrollPosition.X + card.Bound.Location.X, this.AutoScrollPosition.Y + card.Bound.Location.Y);
                    e.Graphics.SetClip(new Rectangle(Point.Empty, card.Size));//限制卡片绘制区域
                    card.OnPaint(e);
                    e.Graphics.Restore(state);



                }
            }
        }

        private void DrawSelectionBorder(Graphics g, RectangleF rect, Color c, float len)
        {
            rect.Offset(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

            GraphicsPath path = new GraphicsPath();
            path.AddBezier(rect.X - len, rect.Y, rect.X - len, rect.Y - len, rect.X, rect.Y - len, rect.X, rect.Y - len);
            path.AddLine(rect.X, rect.Y - len, rect.Right, rect.Y - len);
            path.AddBezier(rect.Right, rect.Y - len, rect.Right + len, rect.Y - len, rect.Right + len, rect.Y, rect.Right + len, rect.Y);
            path.AddLine(rect.Right + len, rect.Y, rect.Right + len, rect.Bottom);
            path.AddBezier(rect.Right + len, rect.Bottom, rect.Right + len, rect.Bottom + len, rect.Right, rect.Bottom + len, rect.Right, rect.Bottom + len);
            path.AddLine(rect.Right, rect.Bottom + len, rect.X, rect.Bottom + len);
            path.AddBezier(rect.X, rect.Bottom + len, rect.X - len, rect.Bottom + len, rect.X - len, rect.Bottom, rect.X - len, rect.Bottom);
            path.AddLine(rect.X - len, rect.Bottom, rect.X - len, rect.Y);

            //生成一个圆角矩形渐变画刷
            PathGradientBrush pb = new PathGradientBrush(path);

            //从外到内渐变颜色
            Color[] colors =
            {
               Color.Transparent,
               c,
              Color.Black,
            };

            var rate = 2 * len / (rect.Width + rect.Height);

            //从内到外渐变位置百分比
            float[] relativePositions =
            {
               0f,
               rate,
               1f,
            };

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = colors;
            colorBlend.Positions = relativePositions;

            pb.InterpolationColors = colorBlend;

            //去圆角毛刺
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(pb, path);
            //g.FillRectangle(new SolidBrush(Host.CardBackColor), rect);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            var p = e.Location;
            p.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);

            foreach (var card in Cards)
            {
                if (card.Bound.Contains(p))
                {
                    p.Offset(-card.Location.X, -card.Location.Y);
                    card.OnMouseClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            var p = e.Location;
            p.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);

            foreach (var card in Cards)
            {
                if (card.Bound.Contains(p))
                {
                    p.Offset(-card.Location.X, -card.Location.Y);
                    card.OnMouseDoubleClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                }
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var p = e.Location;
            p.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);

            foreach (var card in Cards)
            {
                if (card.Bound.Contains(p))
                {
                    p.Offset(-card.Location.X, -card.Location.Y);
                    if (!card.Checked)
                        card.OnMouseEnter(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                    card.OnMouseMove(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                }
                else
                {
                    if (card.Checked)
                    {
                        var p2 = p;
                        p2.Offset(-card.Location.X, -card.Location.Y);
                        card.OnMouseLeave(new MouseEventArgs(e.Button, e.Clicks, p2.X, p2.Y, e.Delta));
                    }

                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var card in Cards)
            {
                card.Checked = false;
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            foreach (var card in Cards)
            {
                if (card.Checked)
                    card.OnMouseHover(e);
            }
        }


        /// <summary>
        /// 内部单个卡片类
        /// </summary>
        public class Card
        {
            public Card(GCardListControl host)
            {
                Host = host;
            }
            private GCardListControl Host;
            public Size Size => Host.CardSize;
            public Point Location { get; set; }
            public Rectangle Bound => new Rectangle(this.Location, this.Size);

            public object Tag { get; set; }

            private bool check;
            public bool Checked
            {
                get => check; set
                {
                    if (check == value)
                        return;

                    check = value;

                    this.Host.OnCardCheckedChanged(this);

                    this.Invalidate();
                }
            }


            public void OnPaint(PaintEventArgs e)
            {
                //此时坐标原点已经偏移到了card的Location处
                var rect = new Rectangle(Point.Empty, Size);

                if (!Host.CardIsCustomPaintBack)
                    e.Graphics.FillRectangle(new SolidBrush(Host.CardBackColor), rect);

                //去除普通边框，在外部添加选中特效边框
                //if (Host.CardShowBorder && !Host.CardIsCustomPaintBack)
                //{
                //    rect.Width -= 1;
                //    rect.Height -= 1;
                //    e.Graphics.DrawRectangle(new Pen(Host.CardBorderColor), rect);
                //}

                this.Host.OnCardPaint(this, e);
            }

            public void OnMouseClick(MouseEventArgs e)
            {
                this.Host.OnCardMouseClick(this, e);
            }
            public void OnMouseDoubleClick(MouseEventArgs e)
            {
                this.Host.OnCardMouseDoubleClick(this, e);
            }

            public void OnMouseMove(MouseEventArgs e)
            {
                this.Host.OnCardMouseMove(this, e);
            }
            public void OnMouseEnter(MouseEventArgs e)
            {
                this.Checked = true;
                this.Host.OnCardMouseEnter(this, e);
            }
            public void OnMouseLeave(MouseEventArgs e)
            {
                this.Checked = false;
                this.Host.OnCardMouseLeave(this, e);
            }
            public void OnMouseHover(EventArgs e)
            {
                this.Host.OnCardMouseHover(this, e);
            }



            public void Invalidate()
            {
                var rect = this.Bound;
                //边框特效区域必须包含在无效区域，否则无法绘制选中边框特效
                rect.Inflate(Host.CardSelectionBorderWidth, Host.CardSelectionBorderWidth);
                rect.Offset(Host.AutoScrollPosition.X, Host.AutoScrollPosition.Y);
                Host.Invalidate(rect);
            }

        }




    }
}
