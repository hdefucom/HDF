using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    public partial class dlgTemplateBrowse : Form
    {
        public dlgTemplateBrowse()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private Dictionary<string, string> _FileNames = null;

        public Dictionary<string, string> FileNames
        {
            get { return _FileNames; }
            set { _FileNames = value; }
        }

        private string _SelectedFileName = null;

        public string SelectedFileName
        {
            get { return _SelectedFileName; }
            set { _SelectedFileName = value; }
        }

        private string _SelectedFileID = null;

        public string SelectedFileID
        {
            get { return _SelectedFileID; }
            set { _SelectedFileID = value; }
        }

        private void dlgTemplateBrowse_Load(object sender, EventArgs e)
        {
            if (_FileNames != null)
            {
                List<string> names = new List<string>();
                names.AddRange(_FileNames.Keys);
                names.Sort();
                foreach (string name in names)
                {
                    string[] items = name.Split('.');
                    TreeNodeCollection nodes = tvwTemplate.Nodes;
                    for( int iCount= 0 ; iCount < items.Length ; iCount ++ )
                    {
                        string item = items[iCount];
                        TreeNode subNode = null;
                        foreach (TreeNode node in nodes)
                        {
                            if (node.Text == item)
                            {
                                subNode = node;
                                break;
                            }
                        }
                        if (subNode == null)
                        {
                            subNode = new TreeNode(item);
                            subNode.ImageIndex = 0;
                            subNode.SelectedImageIndex = 0;
                            nodes.Add(subNode);
                        }
                        nodes = subNode.Nodes ;
                        if (iCount == items.Length - 1)
                        {
                            subNode.Tag = name;
                            subNode.Name = _FileNames[name];
                            subNode.ImageIndex = 1;
                            subNode.SelectedImageIndex = 1;
                            break;
                        }
                    }//for
                }//foreach

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode node = tvwTemplate.SelectedNode;
            if (node.ImageIndex == 1)
            {
                _SelectedFileID = node.Name;
                _SelectedFileName = (string)node.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvwTemplate_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }
    }
}
