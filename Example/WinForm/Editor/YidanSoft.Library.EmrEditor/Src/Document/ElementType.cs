using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public enum ElementType
    {
        /// <summary>
        /// 单选
        /// </summary>
        SingleElement,
        /// <summary>
        /// 多选
        /// </summary>
        MultiElement,
        /// <summary>
        /// 有无选
        /// </summary>
        HaveNotElement,
        /// <summary>
        /// 固定文本
        /// </summary>
        FixedText,
        /// <summary>
        /// 文本,用于外部程序向编辑器内插入结构化内容
        /// </summary>
        Text,
        /// <summary>
        /// 录入提示
        /// </summary>
        PromptText,
        /// <summary>
        /// 格式化数字
        /// </summary>
        FormatNumber,
        /// <summary>
        /// 格式化字符串
        /// </summary>
        FormatString,
        /// <summary>
        /// 格式化日期时间
        /// </summary>
        FormatDatetime,
        /// <summary>
        /// 按钮
        /// </summary>
        Button,

        /// <summary>
        /// 月经史公式
        /// </summary>
        MensesFormula,
        /// <summary>
        /// 水平线
        /// </summary>
        HorizontalLine,
        /// <summary>
        /// 宏
        /// </summary>
        Macro,
        /// <summary>
        /// 可替换项
        /// </summary>
        Replace,
        /// <summary>
        /// 模板
        /// </summary>
        Template,
        /// <summary>
        /// 复选框
        /// </summary>
        CheckBox,
        /// <summary>
        /// 分页符
        /// </summary>
        PageEnd,
        /// <summary>
        /// 定位符
        /// </summary>
        Flag,
        /// <summary>
        /// 什么都不是
        /// </summary>
        None,
        /// <summary>
        /// 什么都可以
        /// </summary>
        All,
        /// <summary>
        /// 数据选择组件
        /// </summary>
        LookUpEditor,
        /// <summary>
        /// 数据元数据选择组件
        /// </summary>
        DataElementLookUpEditor,
        /// <summary>
        /// 牙齿检查
        /// add by ywk  2012年11月27日12:01:55
        /// 新增的牙齿检查功能
        /// </summary>
        ToothCheck,
        /// <summary>
        /// 2019.10.10-hdf
        /// 病人诊断
        /// </summary>
        Diag,
        /// <summary>
        /// 辅助录入
        /// </summary>
        Subject,
        /// <summary>
        /// 表格合计--2021.05.31
        /// </summary>
        TableSum

    }


}
