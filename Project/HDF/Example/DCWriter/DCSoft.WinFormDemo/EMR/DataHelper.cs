using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DCSoft.Writer.Data;
using System.IO;
using System.Windows.Forms;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    public class DataHelper
    {
        /// <summary>
        /// 检查演示数据库文件是否存在
        /// </summary>
        /// <returns></returns>
        public static bool CheckDBFileName()
        {
            //string fileName = Path.GetDirectoryName(Application.StartupPath);
            //fileName = Path.Combine( fileName , "Data\\EMR.DB" );
            //if( File.Exists( fileName ) == false )
            //{
            //    MessageBox.Show(
            //        null ,
            //        "未找到数据库文件 " + fileName + " , 本演示程序将有很多功能无法运行!",
            //        "系统提示" ,
            //        MessageBoxButtons.OK ,
            //        MessageBoxIcon.Error );
            //    return false ;
            //}
            return true ;
        }

        
    }
}
