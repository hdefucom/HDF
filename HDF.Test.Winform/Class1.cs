using HDF.Common;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HDF.Test.Winform;



/// <summary>
/// 解构拓展
/// </summary>
internal static class DeconstructExtensions
{



    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> item, out TKey key, out TValue value)
    {
        key = item.Key;
        value = item.Value;
    }

}



public static class ExcelHelper
{


    #region Private Class

    private interface IDataColumn
    {
        string Name { get; }

        Type DataType { get; }

        object GetValue(object row);
    }


    private class DataTableColumn : IDataColumn
    {
        public DataTableColumn(DataColumn column)
        {
            if (column == null)
                throw new ArgumentNullException(nameof(column));

            Column = column;
        }

        public DataColumn Column { get; }

        public string Name => Column.ColumnName;
        public Type DataType => Column.DataType;

        public object GetValue(object row)
        {
            if (row is DataRow dr)
                return dr[Column];

            return null;
        }
    }

    private class ObjectProperty : IDataColumn
    {
        public ObjectProperty(PropertyInfo prop)
        {
            if (prop == null)
                throw new ArgumentNullException(nameof(prop));

            Property = prop;
        }

        public PropertyInfo Property { get; }
        public string Name => Property.Name;
        public Type DataType => Property.PropertyType;

        public object GetValue(object row)
        {
            if (row == null)
                return null;

            return Property.GetValue(row);
        }
    }

    #endregion


    #region Private Method


    /// <summary>
    /// 根据文件后缀名生成指定版本的Excel对象
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static IWorkbook CreateWorkBook(string path)
    {
        if (path.EndsWith(".xlsx")) // 2007
            return new XSSFWorkbook();
        else if (path.EndsWith(".xls")) // 2003
            return new HSSFWorkbook();
        else
            throw new ArgumentException("该Excel文件后缀名不支持", nameof(path));
    }

    /// <summary>
    /// 初始化导出列
    /// </summary>
    /// <remarks>根据属性特性、显式指定列信息，生成排序好的列信息</remarks>
    /// <param name="dict"></param>
    /// <param name="columns"></param>
    private static void InitColumnInfo(ref Dictionary<IDataColumn, (ExcelColumnInfo Info, CellType Type)> dict, List<ExcelColumnInfo> columns)
    {
        //初始化列信息

        if (!columns.IsNullOrEmpty())//手动指定的列信息优先级比类属性标记特性高
        {
            for (int i = 0; i < dict.Keys.Count; i++)
            {
                var item = dict.Keys.ElementAt(i);
                var info = columns.FirstOrDefault(c => c.Key == item.Name);
                if (info != null)
                    dict[item] = (info, dict[item].Type);

            }
        }

        dict = dict
            //过滤不导出的列
            .Where(a => a.Value.Info.Export)
            .OrderBy(a => a.Value.Info.Order)
            .ToDictionary(a => a.Key, a => a.Value);
    }

    /// <summary>
    /// 创建导出Excel的表格表头
    /// </summary>
    /// <param name="sheet"></param>
    /// <param name="dict"></param>
    /// <param name="config"></param>
    private static void CreateTableHeader(ISheet sheet, Dictionary<IDataColumn, (ExcelColumnInfo Info, CellType Type)> dict, ExcelExportConfig config)
    {
        var dataStartRowIndex = config.DataStartRowIndex;
        var dataStartColIndex = config.DataStartColIndex;
        var exportHeader = config.ExportHeader;
        var customcolumn = config.Customcolumn;



        var header = sheet.CreateRow(dataStartRowIndex);
        var i = dataStartColIndex;
        foreach (var (prop, (info, type)) in dict)
        {

            if (exportHeader)
            {
                var cell = header.CreateCell(i, CellType.String);
                cell.SetCellValue(info.Title);
            }

            if (info.Width != -1)
                sheet.SetColumnWidth(i, info.Width);
            else
                sheet.AutoSizeColumn(i);//未指定宽度则自适应

            i++;
        }

        if (!customcolumn.IsNullOrEmpty())
        {
            foreach (var item in customcolumn)
            {
                var cell = header.CreateCell(i, CellType.String);
                cell.SetCellValue(item.Title);

                if (item.Width != -1)
                    sheet.SetColumnWidth(i, item.Width);
                else
                    sheet.AutoSizeColumn(i);//未指定宽度则自适应
                i++;
            }
        }
    }

    /// <summary>
    /// 填充导出数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sheet"></param>
    /// <param name="data"></param>
    /// <param name="dict"></param>
    /// <param name="config"></param>
    private static void FillData<T>(ISheet sheet, IEnumerable<T> data, Dictionary<IDataColumn, (ExcelColumnInfo Info, CellType Type)> dict, ExcelExportConfig config)
    {
        var dataStartRowIndex = config.DataStartRowIndex;
        var dataStartColIndex = config.DataStartColIndex;
        var exportHeader = config.ExportHeader;
        var datetimeformat = config.DatetimeFormat;


        var rowindex = dataStartRowIndex;
        if (exportHeader)
            rowindex++;

        foreach (var item in data)
        {
            var row = sheet.CreateRow(rowindex);

            var colindex = dataStartColIndex;
            foreach (var (prop, (info, type)) in dict)
            {
                var cell = row.CreateCell(colindex, type);

                SetCellValue(cell, type, prop.GetValue(item), prop.DataType, datetimeformat);

                colindex++;
            }

            rowindex++;
        }

        //调整列宽，datetime自适应宽度
        for (int i = 0; i < dict.Keys.Count; i++)
        {
            var p = dict.Keys.ElementAt(i);

            if ((p.DataType == typeof(DateTime) || p.DataType == typeof(DateTime?))
                && dict[p].Info.Width != -1)//未指定宽度则自适应
                sheet.AutoSizeColumn(i + dataStartColIndex);
        }


    }

    /// <summary>
    /// 设置合并单元格
    /// </summary>
    /// <param name="mergecell"></param>
    /// <param name="sheet"></param>
    /// <param name="datetimeformat"></param>
    private static void SetMergeCell(List<ExcelMergeCell> mergecell, ISheet sheet, string datetimeformat)
    {
        if (mergecell.IsNullOrEmpty())
            return;

        foreach (var item in mergecell)
        {
            var row = sheet.GetRow(item.StartRow);
            if (row == null)
                row = sheet.CreateRow(item.StartRow);

            var type = item.Value == null ? CellType.String : GetCellType(item.Value.GetType());

            var cell = row.CreateCell(item.StartColumn, type);

            SetCellValue(cell, type, item.Value, item.Value?.GetType(), datetimeformat);

            sheet.AddMergedRegion(item);
        }

    }

    /// <summary>
    /// 设置自定义单元格
    /// </summary>
    /// <param name="customcell"></param>
    /// <param name="sheet"></param>
    /// <param name="datetimeformat"></param>
    private static void SetCustomCell(List<ExcelCustomCell> customcell, ISheet sheet, string datetimeformat)
    {
        if (customcell.IsNullOrEmpty())
            return;

        foreach (var item in customcell)
        {
            var row = sheet.GetRow(item.Row);
            if (row == null)
                row = sheet.CreateRow(item.Row);

            var type = item.Value == null ? CellType.String : GetCellType(item.Value.GetType());

            var cell = row.CreateCell(item.Column, type);

            SetCellValue(cell, type, item.Value, item.Value?.GetType(), datetimeformat);

        }
    }


    private static CellType GetCellType(Type type)
    {
        if (type == typeof(Nullable<>))
            type = type.GenericTypeArguments[0];

        var t = CellType.String;
        if (type == typeof(int)
            || type == typeof(long)
            || type == typeof(short)
            || type == typeof(uint)
            || type == typeof(ulong)
            || type == typeof(ushort)
            || type == typeof(byte)
            || type == typeof(float)
            || type == typeof(double)
            || type == typeof(decimal)
            || type == typeof(DateTime)//NPOI中时间类型为Numeric
            )
            t = CellType.Numeric;
        else if (type == typeof(bool))
            t = CellType.Boolean;

        return t;
    }

    private static void SetCellValue(ICell cell, CellType type, object value, Type dataType, string datetimeformat)
    {
        if (value == DBNull.Value)
            return;
        if (type == CellType.String)
            cell.SetCellValue(value?.ToString());
        else if (type == CellType.Numeric)
        {
            if (dataType == typeof(DateTime) || dataType == typeof(DateTime?))
            {
                cell.SetCellValue(Convert.ToDateTime(value));

                var format = cell.Row.Sheet.Workbook.CreateDataFormat();
                var style = cell.Row.Sheet.Workbook.CreateCellStyle();
                style.DataFormat = format.GetFormat(datetimeformat);
                cell.CellStyle = style;
            }
            else
                cell.SetCellValue(Convert.ToDouble(value));
        }
        else if (type == CellType.Boolean)
            cell.SetCellValue(Convert.ToBoolean(value));
        else
            cell.SetCellValue(value?.ToString());

    }



    #endregion


    #region Export Excel


    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data">导出的数据</param>
    /// <param name="path">导出的文件路径</param>
    /// <param name="columns">手动指定的列信息优先级比类属性标记特性高，一个列只能指定一个对象，指定多个对象只有首个生效</param>
    /// <param name="config">导出配置</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static void ExportExcel<T>(this IEnumerable<T> data, string path,
        List<ExcelColumnInfo> columns = null,
        ExcelExportConfig config = null)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        if (path.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(path));

        config ??= new ExcelExportConfig();

        if (config.DataStartRowIndex < 0)
            throw new ArgumentException(nameof(config.DataStartRowIndex));
        if (config.DataStartColIndex < 0)
            throw new ArgumentException(nameof(config.DataStartColIndex));

        var dict = typeof(T).GetProperties()
            .ToDictionary(p => (IDataColumn)new ObjectProperty(p), p => (
               Info: ExcelColumnInfo.Create(p.Name, p.GetCustomAttribute<ExcelColumnAttribute>(), config.NoSpecifyColIsExport),
               Type: GetCellType(p.PropertyType)
           ));

        ExportExcel(dict, data, path, columns, config);
    }




    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="data">导出的数据</param>
    /// <param name="path">导出的文件路径</param>
    /// <param name="columns">手动指定的列信息优先级比类属性标记特性高，一个列只能指定一个对象，指定多个对象只有首个生效</param>
    /// <param name="config">导出配置</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static void ExportExcel(this DataTable data, string path,
        List<ExcelColumnInfo> columns = null,
        ExcelExportConfig config = null)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        if (path.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(path));

        config ??= new ExcelExportConfig();

        if (config.DataStartRowIndex < 0)
            throw new ArgumentException(nameof(config.DataStartRowIndex));
        if (config.DataStartColIndex < 0)
            throw new ArgumentException(nameof(config.DataStartColIndex));

        var dict = data.Columns.Cast<DataColumn>()
            .ToDictionary(p => (IDataColumn)new DataTableColumn(p), p => (
                Info: new ExcelColumnInfo
                {
                    Key = p.ColumnName,
                    Title = p.ColumnName,
                    Export = config.NoSpecifyColIsExport,
                },
                Type: GetCellType(p.DataType)
            ));

        ExportExcel(dict, data.Rows.Cast<DataRow>(), path, columns, config);
    }




    private static void ExportExcel<T>(Dictionary<IDataColumn, (ExcelColumnInfo Info, CellType Type)> dict,
        IEnumerable<T> data,
        string path,
        List<ExcelColumnInfo> columns,
        ExcelExportConfig config)
    {
        config ??= new ExcelExportConfig();
        string datetimeformat = config.DatetimeFormat;
        List<ExcelCustomCell> customcell = config.Customcell;
        List<ExcelMergeCell> mergecell = config.Mergecell;


        IWorkbook workbook = CreateWorkBook(path);

        var sheet = workbook.CreateSheet();


        //初始化列信息
        InitColumnInfo(ref dict, columns);

        //创建表头
        CreateTableHeader(sheet, dict, config);

        //填充数据
        FillData(sheet, data, dict, config);

        //设置合并单元格
        SetMergeCell(mergecell, sheet, datetimeformat);

        //设置自定义单元格
        SetCustomCell(customcell, sheet, datetimeformat);

        config.ExportBeforeOperation?.Invoke(workbook);

        //如果写入一个已经存在的excel文件，使用filestream会导致文件尾部有一串无意义的00数据，导致excel数据错误无法打开
        if (File.Exists(path))
            File.Delete(path);

        //保存文件
        using FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

        workbook.Write(file);

    }


    #endregion







}





#region Excel Export About Class


/// <summary>
/// 导出excel列配置（特性方式）
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ExcelColumnAttribute : Attribute
{
    public string Title { get; set; }

    /// <summary>
    /// the width in units of 1/256th of a character width<br/>
    /// default value is -1, autosize
    /// </summary>
    public int Width { get; set; } = -1;

    public int Order { get; set; } = -1;

    public bool Export { get; set; } = true;

}

/// <summary>
/// 导出excel列配置（显示指定方式）
/// </summary>
public class ExcelColumnInfo
{
    /// <summary>
    /// 绑定的列名
    /// </summary>
    public string Key { get; set; }
    public string Title { get; set; }

    /// <summary>
    /// the width in units of 1/256th of a character width<br/>
    /// default value is -1, autosize
    /// </summary>
    public int Width { get; set; } = -1;

    public int Order { get; set; } = 9999;

    public bool Export { get; set; } = true;


    public static ExcelColumnInfo Create(string key, ExcelColumnAttribute attr, bool export = true)
    {
        if (key.IsNullOrEmpty())
            throw new ArgumentException("无效的Key", nameof(key));

        if (attr == null)
            return new ExcelColumnInfo
            {
                Key = key,
                Title = key,
                Export = export,
            };

        return new ExcelColumnInfo
        {
            Key = key,
            Title = attr.Title,
            Width = attr.Width,
            Order = attr.Order,
            Export = attr.Export,
        };
    }
}

/// <summary>
/// 自定义合并单元格
/// </summary>
public class ExcelMergeCell
{
    public int StartRow { get; }
    public int EndRow { get; }
    public int StartColumn { get; }
    public int EndColumn { get; }

    public object Value { get; }

    public ExcelMergeCell(object value, int sr, int er, int sc, int ec)
    {
        Value = value;
        StartRow = sr;
        EndRow = er;
        StartColumn = sc;
        EndColumn = ec;
    }

    public static implicit operator CellRangeAddress(ExcelMergeCell a)
    {
        if (a == null)
            return null;

        return new CellRangeAddress(a.StartRow, a.EndRow, a.StartColumn, a.EndColumn);
    }
}

/// <summary>
/// 自定义单个单元格
/// </summary>
public class ExcelCustomCell
{
    public int Row { get; }
    public int Column { get; }

    public object Value { get; }

    public ExcelCustomCell(object value, int row, int col)
    {
        Value = value;
        Row = row;
        Column = col;
    }
}

/// <summary>
/// 自定义导出数据源中不包含的空列
/// </summary>
public class ExcelCustomEnptyColumn
{
    public string Title { get; set; }

    /// <summary>
    /// the width in units of 1/256th of a character width<br/>
    /// default value is -1, autosize
    /// </summary>
    public int Width { get; set; } = -1;

    public int Order { get; set; } = 9999;


}



/// <summary>
/// 导出Excel配置类
/// </summary>
public class ExcelExportConfig
{

    /// <summary>
    /// 是否导出表头（标题行）
    /// </summary>
    public bool ExportHeader { get; set; } = true;
    /// <summary>
    /// 数据起始行索引(包含标题行)，默认0行为标题，1行为起始数据
    /// </summary>
    public int DataStartRowIndex { get; set; }
    /// <summary>
    /// 数据起始列索引，默认0
    /// </summary>
    public int DataStartColIndex { get; set; }
    /// <summary>
    /// 未指定的列是否导出，默认为true，未指定的意思是既没有标记特性，有没有传递ExcelColumnInfo对象
    /// </summary>
    public bool NoSpecifyColIsExport { get; set; } = true;
    /// <summary>
    /// DateTime导出的格式
    /// </summary>
    public string DatetimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
    /// <summary>
    /// 自定义单元格
    /// </summary>
    public List<ExcelCustomCell> Customcell { get; set; }
    /// <summary>
    /// 合并单元格
    /// </summary>
    public List<ExcelMergeCell> Mergecell { get; set; }
    /// <summary>
    /// 自定义空列
    /// </summary>
    public List<ExcelCustomEnptyColumn> Customcolumn { get; set; }


    /// <summary>
    /// 即将导出之前的操作，用于配置样式等操作
    /// </summary>
    public Action<IWorkbook> ExportBeforeOperation { get; set; }

}


#endregion


















