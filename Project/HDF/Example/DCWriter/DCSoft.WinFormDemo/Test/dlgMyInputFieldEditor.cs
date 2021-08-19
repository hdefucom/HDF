using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom ;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [ToolboxItem( false )]
    public partial class dlgMyInputFieldEditor : Form
    {
        public dlgMyInputFieldEditor()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private XTextInputFieldElement _InputFieldElement = null;
        /// <summary>
        /// 输入域文档元素对象
        /// </summary>
        public XTextInputFieldElement InputFieldElement
        {
            get { return _InputFieldElement; }
            set { _InputFieldElement = value; }
        }


        private void frmMyInputFieldEditor_Load(object sender, EventArgs e)
        {
            if (this._InputFieldElement != null)
            {
                txtID.Text = this._InputFieldElement.ID;
                txtName.Text = this._InputFieldElement.Name;
                txtBackgroundText.Text = this._InputFieldElement.BackgroundText;
                txtToolTip.Text = this._InputFieldElement.ToolTip;
                txtUnitText.Text = this._InputFieldElement.UnitText;
                chkShowBorder.Checked = this._InputFieldElement.Style.HasVisibleBorder;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this._InputFieldElement != null)
            {
                this._InputFieldElement.ID = txtID.Text;
                this._InputFieldElement.Name = txtName.Text;
                this._InputFieldElement.BackgroundText = txtBackgroundText.Text;
                this._InputFieldElement.ToolTip = txtToolTip.Text;
                this._InputFieldElement.UnitText = txtUnitText.Text;
                if (chkShowBorder.Checked != this._InputFieldElement.Style.HasVisibleBorder)
                {
                    if (chkShowBorder.Checked)
                    {
                        this._InputFieldElement.Style.BorderColor = Color.Black;
                        this._InputFieldElement.Style.BorderWidth = 1;
                        this._InputFieldElement.Style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        this._InputFieldElement.Style.BorderLeft = true;
                        this._InputFieldElement.Style.BorderTop = true;
                        this._InputFieldElement.Style.BorderRight = true;
                        this._InputFieldElement.Style.BorderBottom = true;
                    }
                    else
                    {
                        this._InputFieldElement.Style.BorderLeft = false;
                        this._InputFieldElement.Style.BorderTop = false;
                        this._InputFieldElement.Style.BorderRight = false;
                        this._InputFieldElement.Style.BorderBottom = false;
                    }
                }
                this._InputFieldElement.EditorRefreshView();
                XTextDocument document = this._InputFieldElement.OwnerDocument;
                document.Modified = true;
                document.OnSelectionChanged();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
