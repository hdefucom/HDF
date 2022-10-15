using System.Collections.Generic;

namespace HDF.Share
{
    public class Class1
    {

        public List<int> MyProperty { get; set; }


        async void test()
        {
            //    var count = Debug.Listeners.Count;
            //    long total = fsql.Select<object>().WithSql(sql, queryParams).Count();

            //    if (pageSize > 0)
            //    {
            //        pageCount = (int)(total / pageSize + ((total % pageSize == 0) ? 0 : 1));
            //    }

            //    //创建excel临时文件夹
            //    if (!Directory.Exists(tempDirectory))
            //    {
            //        Directory.CreateDirectory(tempDirectory);
            //    }

            //    //检查并创建POI临时文件夹
            //    string poiTempPath = @"C:\Windows\Temp\poifiles";
            //    if (!Directory.Exists(poiTempPath))
            //    {
            //        Directory.CreateDirectory(poiTempPath);
            //        //POI临时文件夹授予Everyone用户所有权限
            //        DirectoryUtil.AddSecurityControll2Folder(poiTempPath);
            //    }

            //    //防止POI临时文件夹中的历史文件占用磁盘，删除30分钟以前的临时文件
            //    DirectoryInfo poiTempDir = new DirectoryInfo(poiTempPath);
            //    FileInfo[] files = poiTempDir.GetFiles();
            //    if (files != null)
            //    {
            //        foreach (FileInfo file in files)
            //        {
            //            if (file.LastWriteTime.Add(TimeSpan.FromMinutes(30)) < DateTime.Now)
            //            {
            //                file.Delete();
            //            }
            //        }
            //    }


            //    string filePath = $"{tempDirectory}\\{reportDefine.ReportName}-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            //    using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        //表示SXSSFWorkbook只会保留pageSize条数据在内存中，避免内存溢出
            //        SXSSFWorkbook sxssfWorkbook = new SXSSFWorkbook(pageSize);
            //        var sheet1 = sxssfWorkbook.CreateSheet("sheet1");

            //        ICellStyle defaultCellStyle = sxssfWorkbook.CreateCellStyle();
            //        defaultCellStyle.Alignment = HorizontalAlignment.Center;
            //        defaultCellStyle.VerticalAlignment = VerticalAlignment.Center;

            //        //列头是否已创建
            //        bool columnHeaderRowCreated = false;

            //        //行索引
            //        int rowIndex = 0;

            //        int columnCount = 0;

            //        //分页导出
            //        for (int pageIndex = 1; pageIndex <= pageCount; pageIndex++)
            //        {

            //            DataTable dataTable = await fsql.Select<object>()
            //                .WithSql(sql, queryParams).As("t1")
            //                .Page(pageIndex, pageSize)
            //                .ToDataTableAsync("t1.*");
            //            dataTable.TableName = "t1";

            //            //移除自动产生的字段
            //            if (dataTable.Columns.Contains("__rownum__"))
            //            {
            //                dataTable.Columns.Remove(dataTable.Columns["__rownum__"]);
            //            }

            //            if (columnCount == 0)
            //            {
            //                columnCount = dataTable.Columns.Count;
            //            }

            //            //列头
            //            if (!columnHeaderRowCreated)
            //            {
            //                //正文标题
            //                IRow titleRow = sheet1.CreateRow(rowIndex);//rowIndex:0
            //                CreateEmptyCells(titleRow, dataTable.Columns.Count);
            //                titleRow.Cells[0].SetCellValue(reportDefine.ReportName);
            //                sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, dataTable.Columns.Count - 1));
            //                titleRow.Cells[0].CellStyle = defaultCellStyle;
            //                rowIndex++;

            //                //左上角内容、右上角内容
            //                IRow pageHeaderRow = sheet1.CreateRow(rowIndex++);//rowIndex:1
            //                CreateEmptyCells(pageHeaderRow, dataTable.Columns.Count);
            //                //左上角
            //                pageHeaderRow.Cells[0].SetCellValue(ParseVariable(reportDefine.LtContent, queryParams));
            //                pageHeaderRow.Cells[0].CellStyle.Alignment = HorizontalAlignment.Left;
            //                //右上角
            //                pageHeaderRow.Cells[dataTable.Columns.Count - 1].SetCellValue(ParseVariable(reportDefine.RtContent, queryParams));
            //                pageHeaderRow.Cells[dataTable.Columns.Count - 1].CellStyle.Alignment = HorizontalAlignment.Right;

            //                //列头
            //                IRow columnHeaderRow = sheet1.CreateRow(rowIndex++);//rowIndex:2
            //                for (int i = 0; i < dataTable.Columns.Count; i++)
            //                {
            //                    DataColumn dataColumn = dataTable.Columns[i];
            //                    ICell cell = columnHeaderRow.CreateCell(i);
            //                    cell.SetCellValue(dataColumn.ColumnName);
            //                    cell.CellStyle = defaultCellStyle;
            //                    sheet1.SetColumnWidth(i, (dataColumn.ColumnName.Length + 2) * 2 * 256);
            //                }
            //                columnHeaderRowCreated = true;
            //            }

            //            //数据行，从第1行开始
            //            for (int r = 0; r < dataTable.Rows.Count; r++)
            //            {
            //                DataRow dataRow = dataTable.Rows[r];

            //                IRow excelRow = sheet1.CreateRow(rowIndex++);
            //                for (int c = 0; c < dataTable.Columns.Count; c++)
            //                {
            //                    ICell cell = excelRow.CreateCell(c);
            //                    object cellObjValue = dataRow[c];
            //                    if (dataTable.Columns[c].DataType == typeof(decimal)
            //                        || dataTable.Columns[c].DataType == typeof(double)
            //                        || dataTable.Columns[c].DataType == typeof(float)
            //                        || dataTable.Columns[c].DataType == typeof(int)
            //                        || dataTable.Columns[c].DataType == typeof(long)
            //                        || dataTable.Columns[c].DataType == typeof(short))
            //                    {
            //                        cell.SetCellType(CellType.Numeric);
            //                        if (cellObjValue != null)
            //                        {
            //                            string cellValue = cellObjValue.ToString();
            //                            if (!string.IsNullOrWhiteSpace(cellValue))
            //                            {
            //                                cell.SetCellValue(Convert.ToDouble(cellValue));
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        cell.SetCellType(CellType.String);
            //                        if (cellObjValue != null)
            //                        {
            //                            string cellValue = cellObjValue.ToString();
            //                            if (!string.IsNullOrWhiteSpace(cellValue))
            //                            {
            //                                cell.SetCellValue(cellValue);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        //左下角内容、右下角内容
            //        IRow pageFooterRow = sheet1.CreateRow(rowIndex++);
            //        CreateEmptyCells(pageFooterRow, columnCount);
            //        //左下角
            //        pageFooterRow.Cells[0].SetCellValue(ParseVariable(reportDefine.LbContent, queryParams));
            //        pageFooterRow.Cells[0].CellStyle.Alignment = HorizontalAlignment.Left;
            //        //右下角
            //        pageFooterRow.Cells[columnCount - 1].SetCellValue(ParseVariable(reportDefine.RbContent, queryParams));
            //        pageFooterRow.Cells[columnCount - 1].CellStyle.Alignment = HorizontalAlignment.Right;

            //        sxssfWorkbook.Write(fs);
            //    }

        }

    }
}
