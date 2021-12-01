using DevExpress.XtraTab;
using DevExpress.XtraTab.Drawing;
using DevExpress.XtraTab.Registrator;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WinFormsApp2.TabControl
{
    public class HDFViewTabPainter : BaseTabPainter
    {
        public HDFViewTabPainter(IXtraTab tabControl) : base(tabControl)
        {
        }

        protected override Rectangle GetHeaderClipBounds(TabDrawArgs e)
        {
            return e.ViewInfo.HeaderInfo.Client;
        }

        protected override void DrawHeaderPage(TabDrawArgs e, BaseTabRowViewInfo row, BaseTabPageViewInfo pInfo)
        {
            PropertyViewTabPageViewInfo propertyViewTabPageViewInfo = pInfo as PropertyViewTabPageViewInfo;
            if (propertyViewTabPageViewInfo.PagePath != null && !propertyViewTabPageViewInfo.Bounds.IsEmpty)
            {
                e.Cache.Graphics.FillPath(pInfo.PaintAppearance.GetBackBrush(e.Cache, pInfo.Bounds), propertyViewTabPageViewInfo.PagePath);
                e.Cache.Graphics.DrawPath(e.Cache.GetPen(GetBorderColor(pInfo)), propertyViewTabPageViewInfo.PagePath);
                DrawHeaderPageBorder(e, pInfo);
                DrawHeaderFocus(e, pInfo);
                DrawHeaderPageImageText(e, pInfo);
            }
        }

        protected virtual void DrawHeaderPageBorder(TabDrawArgs e, BaseTabPageViewInfo pInfo)
        {
            Rectangle rect = new Rectangle(pInfo.Bounds.X + 1, pInfo.Bounds.Bottom - 1, pInfo.Bounds.Width - 2, 1);
            TabHeaderLocation headerLocation = e.ViewInfo.HeaderInfo.HeaderLocation;
            bool flag = true;
            if (headerLocation == TabHeaderLocation.Top || headerLocation == TabHeaderLocation.Bottom)
            {
                if (headerLocation == TabHeaderLocation.Bottom)
                {
                    rect.Y = pInfo.Bounds.Top;
                }
            }
            else
            {
                flag = false;
                rect = new Rectangle(pInfo.Bounds.Right - 1, pInfo.Bounds.Top + 1, 1, pInfo.Bounds.Height - 2);
                if (headerLocation == TabHeaderLocation.Right)
                {
                    rect.X = pInfo.Bounds.Left;
                }
            }

            Color color = e.ViewInfo.HeaderInfo.PaintAppearance.BorderColor;
            if (pInfo.IsActiveState)
            {
                color = ((pInfo.PaintAppearance.BackColor2 == Color.Empty) ? pInfo.PaintAppearance.BackColor : pInfo.PaintAppearance.BackColor2);
            }
            else
            {
                rect.Inflate(flag ? 1 : 0, (!flag) ? 1 : 0);
            }

            e.Graphics.FillRectangle(e.Cache.GetSolidBrush(color), rect);
        }

        private Color GetBorderColor(BaseTabPageViewInfo pInfo)
        {
            if (pInfo.PaintAppearance.BorderColor != Color.Empty)
            {
                return pInfo.PaintAppearance.BorderColor;
            }

            return pInfo.ViewInfo.GetDefaultAppearance(pInfo.IsActiveState ? TabPageAppearance.PageHeaderActive : TabPageAppearance.PageHeader).BorderColor;
        }

        protected override void ExcludeHeaderButtonsClip(TabDrawArgs e)
        {
            Rectangle buttonsBounds = e.ViewInfo.HeaderInfo.ButtonsBounds;
            if (e.ViewInfo.HeaderInfo.IsSideLocation)
            {
                buttonsBounds.Width--;
                if (e.ViewInfo.HeaderInfo.IsRightLocation)
                {
                    buttonsBounds.X++;
                }
            }
            else
            {
                buttonsBounds.Height--;
                if (e.ViewInfo.HeaderInfo.IsBottomLocation)
                {
                    buttonsBounds.Y++;
                }
            }

            e.Cache.ClipInfo.ExcludeClip(buttonsBounds);
        }

        protected override void DrawHeaderButtons(TabDrawArgs e)
        {
            BaseTabHeaderViewInfo headerInfo = e.ViewInfo.HeaderInfo;
            if (!headerInfo.ButtonsBounds.IsEmpty)
            {
                headerInfo.Buttons.Draw(e.Cache);
                Rectangle client = headerInfo.Buttons.Client;
                Rectangle rectangle = (e.ViewInfo.HeaderInfo.Rows.LastRow == null) ? e.ViewInfo.HeaderInfo.Client : e.ViewInfo.HeaderInfo.Rows.LastRow.Client;
                if (e.ViewInfo.HeaderInfo.IsSideLocation)
                {
                    client.X = rectangle.X + (e.ViewInfo.HeaderInfo.IsRightLocation ? 1 : 0);
                    client.Width = rectangle.Width - (e.ViewInfo.HeaderInfo.IsLeftLocation ? 1 : 0);
                }
                else
                {
                    client.Y = rectangle.Top + (e.ViewInfo.HeaderInfo.IsBottomLocation ? 1 : 0);
                    client.Height = rectangle.Height - (e.ViewInfo.HeaderInfo.IsTopLocation ? 1 : 0);
                }

                e.Graphics.ExcludeClip(client);
            }
        }
    }
}
