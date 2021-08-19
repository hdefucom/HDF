using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, new Rectangle(100, 100, 100, 100), Color.Blue, ButtonBorderStyle.Solid);




            if (Checked)
                e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(100, 100, 100 - 1, 100 - 1));
            else
                e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(100, 100, 100 - 1, 100 - 1));


            Debug.WriteLine($"触发重绘{e.ClipRectangle}");

        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Checked = rect.Contains(e.X, e.Y);
        }


        private Rectangle rect = new Rectangle(100, 100, 100, 100);


        private bool _check;

        private bool Checked
        {
            get => _check;
            set
            {
                if (_check == value)
                    return;
                _check = value;

                this.Invalidate(rect);
            }
        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {

        }


    }




    public static class Convertor
    {


        public static IList<T> DataTableToList<T>(this DataTable table)
        {
            var list = new List<T>();

            foreach (DataRow row in table?.Rows)
            {
                var dto = Activator.CreateInstance<T>();
                if (dto == null)
                    throw new Exception("DTO实例化失败");

                foreach (var prop in dto.GetType().GetProperties().Where(p => table.Columns.Contains(p.Name)))
                {
                    prop.SetValue(dto, row[prop.Name], null);
                }
                list.Add(dto);
            }

            return list;
        }

        public static DataTable ListToDataTable<T>(this IList<T> list)
        {
            DataTable table = new DataTable();

            foreach (var prop in typeof(T).GetProperties())
            {
                table.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
            }

            var props = typeof(T).GetProperties();

            foreach (var dto in list)
            {
                var row = table.NewRow();
                foreach (var prop in props)
                {
                    row[prop.Name] = prop.GetValue(dto, null);
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public static T DataRowToDto<T>(this DataRow row)
        {

            var dto = Activator.CreateInstance<T>();
            if (dto == null)
                throw new Exception("DTO实例化失败");

            foreach (var prop in dto.GetType().GetProperties().Where(p => row.Table.Columns.Contains(p.Name)))
            {
                prop.SetValue(dto, row[prop.Name], null);
            }
            return dto;
        }

        public static void DtoToDataRow<T>(this T dto, DataRow row)
        {
            foreach (var prop in dto.GetType().GetProperties().Where(p => row.Table.Columns.Contains(p.Name)))
            {
                row[prop.Name] = prop.GetValue(dto,null);
            }
        }




    }







}
