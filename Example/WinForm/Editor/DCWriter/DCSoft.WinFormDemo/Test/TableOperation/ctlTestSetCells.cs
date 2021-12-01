using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Commands;
using System.IO;
using DCSoft.Writer.WinFormDemo.EMR.Model;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ctlTestSetCells : UserControl 
    {
        public ctlTestSetCells()
        {
            InitializeComponent();
        }
         
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlTestSetCells_Load(object sender, EventArgs e)
        {
            string Name =Path.Combine( Application.StartupPath,"Test\\TestSetCells.xml");
           // string Name = "..\\DCSoft.Writer.Demo\\WinFormDemo\\Test\\TestSetCells.xml";
            myControl.ExecuteCommand("FileOpen", false,Name );
            ElementEventTemplate eet = new ElementEventTemplate();
            eet.MouseDblClick += new ElementMouseEventHandler(eet_MouseDblClick);
            eet.Name = "病人信息表格行";
            myControl.EventTemplates.Add(eet);

            ElementEventTemplate cellEvents = new ElementEventTemplate();
            cellEvents.KeyPress += new ElementKeyEventHandler(cellEvents_KeyPress);
            myControl.GlobalEventTemplate_Cell = cellEvents;
        }

        /// <summary>
        /// 处理文档中单元格键盘按键字符事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void cellEvents_KeyPress(object sender, ElementKeyEventArgs args)
        {
            if (args.KeyChar == '\r')
            {
                // 当在表格的最后一行的最后一个单元格按下Enter键则新建一个表格行
                XTextTableCellElement cell = args.Element as XTextTableCellElement;
                if (cell != null)
                {
                    XTextTableElement table = cell.OwnerTable;
                    if (cell.RowIndex == table.Rows.Count - 1 
                        && cell.ColIndex == table.Columns.Count - 1)
                    {
                        XTextTableRowElement newRow = (XTextTableRowElement)myControl.ExecuteCommand(
                            "Table_InsertRowDown",
                            false, 
                            null);
                        if (newRow != null)
                        {
                            newRow.Cells[0].Focus();
                            // 事件已经处理了，无需进行默认处理
                            args.Handled = true;
                        }
                    }
                }
            }
        }
         

        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void eet_MouseDblClick(object sender, ElementMouseEventArgs args)
        {
            using (dlgSelectPatients dlg = new dlgSelectPatients())
            {
                if( dlg.ShowDialog( this ) == System.Windows.Forms.DialogResult.OK )
                {
                    XTextTableRowElement row = ( XTextTableRowElement ) args.Element.GetOwnerParent(
                        typeof ( XTextTableRowElement ) ,
                        true );
                    XTextElementList fields = row.GetElementsByType(typeof(XTextInputFieldElement));
                    foreach (XTextInputFieldElement field in fields)
                    {
                        if (field.Name == "ID")
                        {
                            field.EditorTextExt =dlg.EMR_Patients.PA_ID;
                        }
                       else  if (field.Name == "Name")
                        {
                            field.EditorTextExt = dlg.EMR_Patients.PA_NAME;
                        }
                        else if (field.Name == "Sex")
                        {
                            field.EditorTextExt = dlg.EMR_Patients.PA_SEX ;
                        }
                        else if (field.Name == "Space")
                        {
                            field.EditorTextExt = dlg.EMR_Patients.PA_PIH_PATIENT_SAPCE;
                        }
                        else if (field.Name == "Home")
                        {
                            field.EditorTextExt = dlg.EMR_Patients.PA_HOMEPLACE ;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnGetDate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Sex", typeof(string));
            dt.Columns.Add("Space", typeof(string));
            dt.Columns.Add("Home", typeof(string));
            XTextTableElement myTable = (XTextTableElement)myControl.GetElementById("PatientTable");

            for (int i = 1; i < myTable.Rows.Count; i++)
            {
                // 从第二行开始遍历表格行
                XTextTableRowElement tableRow = (XTextTableRowElement)myTable.Rows[i];
                DataRow dr = dt.NewRow();
                // 获得表格行中所有的输入域对象
                XTextElementList fields = tableRow.GetElementsByType(typeof(XTextInputFieldElement));
                if (fields != null && fields.Count > 0)
                {
                    foreach (XTextInputFieldElement field in fields)
                    {
                        // 根据输入域的名称设置数据行各个数据栏目的数值
                        switch( field.Name )
                        {
                            case "ID":
                                dr["ID"] = field.Text ;
                                break;
                            case "Name":
                                dr["Name"] = field.Text;
                                break;
                            case "Sex":
                                dr["Sex"] = field.Text;
                                break;
                            case "Space":
                                dr["Space"] = field.Text;
                                break;
                            case "Home":
                                dr["Home"] = field.Text;
                                break;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            string we = dt.Rows.Count.ToString();
            frmShowData dlgDate = new frmShowData();
            dlgDate.dateTable = dt;
            dlgDate.ShowDialog();
        }
        

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSaveFile_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("FileSave", true, null);
        }




        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("FilePrint", true, null);
        }
        /// <summary>
        /// 重做
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnRedo_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("Redo", true, null);
        }
        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnUndo_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("Undo", true, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("ViewXMLSource", true, null);
        }

        private void btnTableRowProperties_Click(object sender, EventArgs e)
        {
            myControl.ExecuteCommand("TableRowProperties", true, null);
        }
    }
}
