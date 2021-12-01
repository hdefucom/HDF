using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YidanSoft.Library.EmrEditor.Src.DataElement
{
    public class DiagDictionary
    {
        private static DataTable xyzd;
        public static DataTable XiYiZhengDuan
        {
            get
            {
                if (xyzd == null || xyzd.Rows.Count == 0)
                {
                    string sql = "select  mapid as id,name,py,wb from diagnosis where valid='1'";
                    xyzd = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, CommandType.Text);
                    xyzd.Rows.Cast<DataRow>().ToList().ForEach(row => row["py"] = row["py"].ToString().ToLower());
                    xyzd.Rows.Cast<DataRow>().ToList().ForEach(row => row["wb"] = row["wb"].ToString().ToLower());
                }
                return xyzd;
            }
        }

        private static DataTable zyb;
        public static DataTable ZhongYiBing
        {
            get
            {
                if (zyb == null || zyb.Rows.Count == 0)
                {
                    string sql = "select id,name,py,wb from diagnosisofchinese where valid='1' and category='b'";
                    zyb = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, CommandType.Text);
                    zyb.Rows.Cast<DataRow>().ToList().ForEach(row => row["py"] = row["py"].ToString().ToLower());
                    zyb.Rows.Cast<DataRow>().ToList().ForEach(row => row["wb"] = row["wb"].ToString().ToLower());
                }
                return zyb;
            }
        }

        private static DataTable zyz;
        public static DataTable ZhongYiZheng
        {
            get
            {
                if (zyz == null || zyz.Rows.Count == 0)
                {
                    string sql = "select id,name,py,wb from diagnosisofchinese where valid='1' and category='z'";
                    zyz = YiDanSqlHelper.YD_SqlHelper.ExecuteDataTable(sql, CommandType.Text);
                    zyz.Rows.Cast<DataRow>().ToList().ForEach(row => row["py"] = row["py"].ToString().ToLower());
                    zyz.Rows.Cast<DataRow>().ToList().ForEach(row => row["wb"] = row["wb"].ToString().ToLower());
                }
                return zyz;
            }
        }




    }
}
