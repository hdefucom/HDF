using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    public partial class ctlChinesecharacter : UserControl, DCSoft.Writer.Controls.IInputFieldElementEditorControl
    {
        public ctlChinesecharacter()
        {
            InitializeComponent();

        }
        private InputFieldElementEditorEventArgs _InputArgs = null;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    string spellCode = textBox1.Text;
                    if (spellCode != null)
                    {
                        spellCode = spellCode.Trim().ToLower();
                    }
                    if (string.IsNullOrEmpty(spellCode))
                    {
                        cmd.CommandText = "Select top 100 name ,name From  EMR_DOCEX   order by name";
                    }
                    else
                    {
                        cmd.CommandText = "Select top 100 name ,name From  EMR_DOCEX   where name like '" + spellCode + "%'  order by name ";
                    }
                    IDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        
                        listBox1.Items.Add(Convert.ToString(reader.GetValue(0))); 
                        
                    }
                    reader.Close();
                    
                }
            }
             
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)_InputArgs.Element;
            field.EditorTextExt = this.listBox1.SelectedItem.ToString();
            _InputArgs.Result = ElementValueEditResult.UserAccept;
            _InputArgs.CloseDropDown();
        }

        public void EditorInitalize(DCSoft.Writer.Controls.InputFieldElementEditorEventArgs args)
        {
            _InputArgs = args;
            string txt = args.Element.Text;
            // 设置内容
            this.textBox1.Text = txt;
        }

    }
}
