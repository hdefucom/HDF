using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.WinFormDemo.EMR.Model;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    [ToolboxItem(false)]
    public partial class ctlPatientsList : UserControl
    {
        public ctlPatientsList()
        {
            InitializeComponent();
        }


        private void frmPatientsList_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() + "hahahha" + System.IO.Path.Combine(
           //   Application.StartupPath,
            //  "EMR\\TemplateDocument\\InpatientInfo.xml"));
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            lvwPatients.BeginUpdate();
            this.Cursor = Cursors.WaitCursor;
            lvwPatients.Items.Clear();

            //System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() + "232323");
            System.Collections.IEnumerable records = EMRDataProvider.Instance.ORM.ReadAllInstances(typeof(EMR_Patients));
           // System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() + "454545");
            foreach (EMR_Patients record in records)
            {
                ListViewItem item = new ListViewItem();
                FillListViewItem(item, record);
                lvwPatients.Items.Add(item);
            }
            this.Cursor = Cursors.Default;
            lvwPatients.EndUpdate();
            //System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() + "676767");
        }

        private void FillListViewItem(ListViewItem item, EMR_Patients record)
        {
            item.SubItems.Clear();
            item.Text = record.PA_ID;
            item.SubItems.Add(record.PA_CASE_HISTOR_CODE);
            item.SubItems.Add(record.PA_HIS_BEINHOSPITAL_CODE);
            item.SubItems.Add(record.PA_NAME);
            //item.SubItems.Add(record.PA_SEX);
            item.SubItems.Add( record.PA_PRITHTIME.ToLongDateString () );
            //item.SubItems.Add(record.PA_DOCTOR);
            item.SubItems.Add(record.PA_RY_TIME.ToLongDateString());
            item.SubItems.Add(record.PA_DISPLACE_KB);
            item.Tag = record;
        }


        private void btnNewPatients_Click(object sender, EventArgs e)
        {
            using (frmPatients frm = new frmPatients())
            {
                frm.PatientsInstance = ( EMR_Patients ) EMRDataProvider.Instance.ORM.CreateInstance(typeof(EMR_Patients));
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    EMR_Patients record = frm.PatientsInstance;
                    if (EMRDataProvider.Instance.ORM.Insert(record) > 0)
                    {
                        ListViewItem item = new ListViewItem();
                        FillListViewItem(item, record);
                        lvwPatients.Items.Add(item);
                        item.EnsureVisible();
                        item.Selected = true;
                    }
                }
            }
        }

        private void btnEditPatients_Click(object sender, EventArgs e)
        {
            if (lvwPatients.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwPatients.SelectedItems[0];
                EMR_Patients record = (EMR_Patients)item.Tag;
                using (frmPatients dlg = new frmPatients())
                {
                    dlg.PatientsInstance = record;
                    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (EMRDataProvider.Instance.ORM.Update(record) > 0)
                        {
                            FillListViewItem(item, record);
                        }
                    }
                }
            }
        }

        private void btnDeletePatients_Click(object sender, EventArgs e)
        {
            if (lvwPatients.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwPatients.SelectedItems[0];
                EMR_Patients record = (EMR_Patients)item.Tag;
                if (EMRDataProvider.Instance.ORM.Delete(record) > 0)
                {
                    lvwPatients.Items.Remove(item);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

    }
}
