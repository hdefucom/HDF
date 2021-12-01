using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Document;
using YiDanCommon.Ctrs.FORM;
using System.Data.SqlClient;
using YidanSoft.Library.EmrEditor.Src.DataElement;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class DiagForm : DevBaseForm
    {
        /// <summary>
        /// 诊断元素
        /// </summary>
        ZYDiag zydiag;

        /// <summary>
        /// 全部诊断数据
        /// </summary>
        DataTable data;

        /// <summary>
        /// 病人诊断数据
        /// </summary>
        DataTable selectdata;

        /// <summary>
        /// 删除诊断列表
        /// </summary>
        List<string> delDiagCode = new List<string>();
 
        public DiagForm(ZYDiag ele)
        {
            InitializeComponent();

            zydiag = ele;
        }

        private void DiagForm_Load(object sender, EventArgs e)
        {
            if (zydiag == null) return;

            #region 初始化左边诊断列表

            string sql = "";
            switch (zydiag.DiagType)
            {
                case DiagType.XiYiZhenDuan:
                    //sql = "select  mapid as id,name,py,wb from diagnosis where valid='1'";
                    data = DiagDictionary.XiYiZhengDuan;
                    this.Text += "-西医诊断";
                    break;
                case DiagType.ZhongYiBing:
                    //sql = "select id,name,py,wb from diagnosisofchinese where valid='1' and category='b'";
                    data = DiagDictionary.ZhongYiBing;
                    this.Text += "-中医病";
                    break;
                case DiagType.ZhongYiZheng:
                    //sql = "select id,name,py,wb from diagnosisofchinese where valid='1' and category='z'";
                    data = DiagDictionary.ZhongYiZheng;
                    this.Text += "-中医病";
                    break;
            }
            //data = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, CommandType.Text);
            //data.Rows.Cast<DataRow>().ToList().ForEach(row => row["py"] = row["py"].ToString().ToLower());
            //data.Rows.Cast<DataRow>().ToList().ForEach(row => row["wb"] = row["wb"].ToString().ToLower());




            gcDiag.DataSource = data;

            #endregion


            #region 初始化右边病人诊断列表

            string sql2 = string.Format(@"select id,diagcode,diagname,diagcustumname from inpatient_diag 
                            where noofinpat='{0}' and diagtype='{1}' and valid='1' order by sortno"
                            , YiDanCommon.CommonObjects.CurrentPatient.NoOfFirstPage, zydiag.DiagType.ToString());
            selectdata = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql2, CommandType.Text);

            DataColumn dc = new DataColumn("check", typeof(bool)) { DefaultValue = false };
            selectdata.Columns.Add(dc);

            List<string> codes = zydiag.DiagCodes;
            foreach (string c in codes)
            {
                selectdata.Rows.Cast<DataRow>().ToList().ForEach(r =>
                {
                    if (r["diagcode"].ToString() == c) r["check"] = true;
                });
            }

            gcSelectDiag.DataSource = selectdata;


            #endregion

            //设置头部全选按钮
            GridCheckEdit(gvSelectDiag, "check",30);
        }



        private void txtFliter_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                FilterData(txtFliter.Text);
            }
            catch (Exception ex)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        /// <summary>
        /// 数据筛选方法
        /// </summary>
        /// <param name="filterStr"></param>
        public void FilterData(string filterStr)
        {
            try
            {
                string filter = txtFliter.Text.ToLower();
                data.DefaultView.RowFilter = "id like '%" + filter + "%' or name like '%" + filter + "%' or py like '%" + filter + "%' or wb like '%" + filter + "%'";
                gcDiag.DataSource = data.DefaultView.ToTable();
                gcDiag.RefreshDataSource();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 添加、去除、上移、下移、插入、关闭

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow selectrow = gvDiag.GetFocusedDataRow();
                if (selectrow == null) return;
                DataRow[] rows = selectdata.Select("diagcode='" + selectrow["id"] + "'");
                if (rows == null || rows.Length <= 0)
                {
                    DataRow row = selectdata.NewRow();
                    row["check"] = true;
                    row["id"] = "";
                    row["diagcode"] = selectrow["id"];
                    row["diagname"] = selectrow["name"];
                    row["diagcustumname"] = selectrow["name"];
                    //row["sort"] = selectdata.Rows.Count+1;
                    selectdata.Rows.Add(row);
                    selectdata = selectdata.DefaultView.ToTable();
                    gcSelectDiag.DataSource = selectdata;
                    gcSelectDiag.RefreshDataSource();
                }
                else
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("该诊断已经存在");
                }
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow selectrow = gvSelectDiag.GetFocusedDataRow();
                if (selectrow == null) return;

                if (selectrow["id"].ToString() != "") delDiagCode.Add(selectrow["id"].ToString());

                selectdata.Rows.Remove(selectrow);
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow selectrow = gvSelectDiag.GetFocusedDataRow();
                if (selectrow == null) return;

                int nowindex = selectdata.Rows.IndexOf(selectrow);

                if (nowindex <= 0) return;

                DataRow row = selectdata.NewRow();
                row.ItemArray = selectrow.ItemArray;

                selectdata.Rows.Remove(selectrow);
                selectdata.Rows.InsertAt(row, nowindex - 1);

                gcSelectDiag.DataSource = selectdata;
                gcSelectDiag.RefreshDataSource();

                gvSelectDiag.FocusedRowHandle = nowindex - 1;
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }

        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow selectrow = gvSelectDiag.GetFocusedDataRow();
                if (selectrow == null) return;

                int nowindex = selectdata.Rows.IndexOf(selectrow);

                if (nowindex >= selectdata.Rows.Count-1) return;

                DataRow row = selectdata.NewRow();
                row.ItemArray = selectrow.ItemArray;

                selectdata.Rows.Remove(selectrow);
                selectdata.Rows.InsertAt(row, nowindex+1);

                gcSelectDiag.DataSource = selectdata;
                gcSelectDiag.RefreshDataSource();

                gvSelectDiag.FocusedRowHandle = nowindex + 1;
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 0;//sql执行成功次数
                List<string> codes = new List<string>();//勾选的病人诊断编码
                List<string> names = new List<string>();//勾选的病人诊断名称
                List<string> text = new List<string>();//勾选的病人诊断自定义名称

                #region 病人诊断数据保存到数据库

                for (int i = 0; i < selectdata.Rows.Count; i++)
                {
                    DataRow dr = selectdata.Rows[i];
                    //判断右边列表那些数据是新增的，那些是修改的
                    if (dr["id"].ToString() == "")
                    {
                        string sql = @"insert into INPATIENT_DIAG(id,noofinpat,diagtype,diagcode,diagname,diagcustumname,sortno,createuser,createtime,updateuser,updatetime) 
                               values(@id,@noofinpat,@diagtype,@diagcode,@diagname,@diagcustumname,@sortno,@createuser,@createtime,@updateuser,@updatetime)";
                        SqlParameter[] paras = {
                                           new SqlParameter("@id",Guid.NewGuid().ToString()),
                                           new SqlParameter("@noofinpat",YiDanCommon.CommonObjects.CurrentPatient.NoOfFirstPage),
                                           new SqlParameter("@diagtype",zydiag.DiagType.ToString()),
                                           new SqlParameter("@diagcode",dr["diagcode"].ToString()),
                                           new SqlParameter("@diagname",dr["diagname"].ToString()),
                                           new SqlParameter("@diagcustumname",dr["diagcustumname"].ToString()),
                                           new SqlParameter("@sortno",i+1),
                                           new SqlParameter("@createuser",YiDanCommon.YD_Common.currentUser.Id),
                                           new SqlParameter("@createtime",SqlDbType.DateTime){Value=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                                           new SqlParameter("@updateuser",YiDanCommon.YD_Common.currentUser.Id),
                                           new SqlParameter("@updatetime",SqlDbType.DateTime){Value=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                                       };
                        num += YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(sql, paras, CommandType.Text);
                    }
                    else
                    {
                        string sql = @"update INPATIENT_DIAG set diagcustumname=@diagcustumname, updateuser=@updateuser ,updatetime=@updatetime,sortno=@sortno
                                       where id=@id and valid='1'";
                        SqlParameter[] paras = {
                                           new SqlParameter("@id",dr["id"].ToString()),
                                           new SqlParameter("@diagcustumname",dr["diagcustumname"].ToString()),
                                           new SqlParameter("@updateuser",YiDanCommon.YD_Common.currentUser.Id),
                                           new SqlParameter("@updatetime",SqlDbType.DateTime){Value=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                                           new SqlParameter("@sortno",i+1)
                                       };
                        num += YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(sql, paras, CommandType.Text);
                    }
                    //把选中的诊断保存到集合
                    if ((bool)dr["check"])
                    {
                        codes.Add(dr["diagcode"].ToString());
                        names.Add(dr["diagname"].ToString());
                        text.Add(dr["diagcustumname"].ToString());
                    }

                }

                #endregion

                //判断是否删除了病人诊断的数据
                if (delDiagCode.Count > 0)
                {
                    //删除病人移除了的诊断
                    foreach (string c in delDiagCode)
                    {
                        string sql = "delete from INPATIENT_DIAG where id='" + c + "'";
                        num += YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(sql, CommandType.Text);
                    }
                }

                //判断是否全部执行成功，提交或回滚事务
                if (num == selectdata.Rows.Count + delDiagCode.Count)
                {


                    zydiag.Text = "";
                    if (text.Count == 1)
                    {
                        zydiag.Text = " " + text[0] + " ";
                    }
                    else if (text.Count > 1)
                    {
                        for (int i = 0; i < text.Count; i++)
                        {
                            zydiag.Text += " " + (i + 1).ToString() + ". " + text[i];
                        }
                    }
                    else
                    {
                        zydiag.Text = zydiag.Name;
                    }

                    zydiag.DiagCodes = codes;
                    zydiag.DiagNames = names;

                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("插入成功！");

                    zydiag.OwnerDocument.RefreshSize();

                    if (zydiag.Parent.Parent is TPTextCell)
                    {
                        (zydiag.Parent.Parent as TPTextCell).AdjustHeight();
                    }

                    zydiag.OwnerDocument.ContentChanged();
                    zydiag.OwnerDocument.OwnerControl.Refresh();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("插入失败！");
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        //双击诊断列表添加到病人诊断中
        private void gcDiag_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvDiag.CalcHitInfo(new Point(e.X, e.Y));
                if (!hInfo.InRow) return;
                DataRow selectrow = gvDiag.GetFocusedDataRow();
                DataRow[] rows = selectdata.Select("diagcode='" + selectrow["id"] + "'");
                if (rows == null || rows.Length <= 0)
                {
                    DataRow row = selectdata.NewRow();
                    row["check"] = true;
                    row["id"] = "";
                    row["diagcode"] = selectrow["id"];
                    row["diagname"] = selectrow["name"];
                    row["diagcustumname"] = selectrow["name"];
                    //row["sort"] = selectdata.Rows.Count+1;
                    selectdata.Rows.Add(row);
                    selectdata = selectdata.DefaultView.ToTable();
                    gcSelectDiag.DataSource = selectdata;
                    gcSelectDiag.RefreshDataSource();
                }
                else
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("该诊断已经存在");
                }
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }
        }

        //双击病人诊断移除
        private void gcSelectDiag_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvSelectDiag.CalcHitInfo(new Point(e.X, e.Y));
                if (!hInfo.InRow) return;

                DataRow selectrow = gvSelectDiag.GetFocusedDataRow();
                if (selectrow == null) return;

                if (selectrow["id"].ToString() != "") delDiagCode.Add(selectrow["id"].ToString());

                selectdata.Rows.Remove(selectrow);
            }
            catch (Exception ex)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show(1, ex);
            }

        }




        #endregion




        #region GridControl 全选

        /// <summary>        
        /// 是否选中   
        /// </summary>      
        private static bool chkState = false;

        //复选框列名称      
        private static string chkFileName = "";

        //复选框列宽       
        private static int chkWidth = 30;

        //GridView        
        public static DevExpress.XtraGrid.Views.Grid.GridView GView = null;

        private DevExpress.XtraGrid.Views.Grid.GridView gView
        {
            get
            {
                if (GView == null)
                {
                    GView = new DevExpress.XtraGrid.Views.Grid.GridView();
                } return GView;
            }
            set
            {
                this.gView = value;
            }
        }

        public static void GridCheckEdit(DevExpress.XtraGrid.Views.Grid.GridView gv, string checkFileName, int checkWidth)
        {
            if (gv != null)
            {
                chkFileName = checkFileName;
                chkWidth = checkWidth;
                GView = gv;
                //不显示复选框的列标题   
                gv.Columns[chkFileName].OptionsColumn.ShowCaption = false;
                //复选框的形状   gv.Columns[chkFileName].ColumnEdit 实例是 repositoryItemCheckEdit1  
                //repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;        
                ////复选框加载的状态     实心   空心   空心打勾          
                //repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;   
                //点击事件        
                gv.Click += new System.EventHandler(gv_Click);
                //画列头CheckEdit           
                gv.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(gv_CustomDrawColumnHeader);
                gv.DataSourceChanged += new EventHandler(gv_DataSourceChanged);
            }
        }

        private static void gv_Click(object sender, EventArgs e)
        {
            if (ClickGridCheckBox(GView, chkFileName, chkState))
            {
                chkState = !chkState;
            }
        }

        private static void gv_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == chkFileName)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e, chkState);
                e.Handled = true;
            }
        }

        private static void gv_DataSourceChanged(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = GView.Columns.ColumnByFieldName(chkFileName);
            if (column != null)
            {
                column.Width = chkWidth;
                column.OptionsColumn.ShowCaption = false;
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            }
        }

        private static void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            if (repositoryCheck != null)
            {
                System.Drawing.Graphics g = e.Graphics;
                System.Drawing.Rectangle r = e.Bounds;
                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
                painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                info.EditValue = chk;
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }
        }

        private static bool ClickGridCheckBox(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName, bool currentStatus)
        {
            bool result = false;
            if (gridView != null)
            {
                //禁止排序       
                gridView.ClearSorting();
                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                System.Drawing.Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == fieldName)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        gridView.SetRowCellValue(i, fieldName, !currentStatus);
                    } 
                    return true;
                }
            } 
            return result;
        }

        #endregion












    }
}
