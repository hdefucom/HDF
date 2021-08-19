using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DCSoft.Writer.Data;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Dom;
using System.Xml.Serialization;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test
{
    /// <summary>
    /// 数据源描述信息
    /// </summary>
    [Serializable]
    public partial class DCDataSourceDescriptor
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public DCDataSourceDescriptor()
        {
        }
           
        private bool _UserEditable = true;
        /// <summary>
        /// 是否允许用户编辑
        /// </summary>
        [DefaultValue(true)]
        public bool UserEditable
        {
            get { return _UserEditable; }
            set { _UserEditable = value; }
        }

        private InputFieldEditStyle _EditStyle = InputFieldEditStyle.Text;
        /// <summary>
        /// 输入域编辑方式
        /// </summary>
        [DefaultValue(InputFieldEditStyle.Text)]
        public InputFieldEditStyle EditStyle
        {
            get { return _EditStyle; }
            set { _EditStyle = value; }
        }

        private XDataBinding _ValueBinding = null;
        /// <summary>
        /// 数据绑定
        /// </summary>
        [DefaultValue(null)]
        public XDataBinding ValueBinding
        {
            get { return _ValueBinding; }
            set { _ValueBinding = value; }
        }

        private bool _Readonly = false;
        /// <summary>
        /// 是否只读
        /// </summary>
        [DefaultValue(false)]
        public bool Readonly
        {
            get { return _Readonly; }
            set { _Readonly = value; }
        }

        private string _BackgroundText = null;
        /// <summary>
        /// 背景文字
        /// </summary>
        [DefaultValue(null)]
        public string BackgroundText
        {
            get { return _BackgroundText; }
            set { _BackgroundText = value; }
        }

        private string _Name = null;
        /// <summary>
        /// 名称
        /// </summary>
        [DefaultValue(null)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private ListSourceInfo _ListSource = null;
        /// <summary>
        /// 列表项目
        /// </summary>
        [DefaultValue(null)]
        public ListSourceInfo ListSource
        {
            get { return _ListSource; }
            set { _ListSource = value; }
        }

        private ValueValidateStyle _ValidateStyle = null;
        /// <summary>
        /// 数据格式检查样式
        /// </summary>
        [DefaultValue(null)]
        public ValueValidateStyle ValidateStyle
        {
            get
            {
                return _ValidateStyle;
            }
            set
            {
                _ValidateStyle = value;
            }
        }

        private ValueFormater _DisplayFormat = null;
        /// <summary>
        /// 显示格式
        /// </summary>
        [DefaultValue(null)]
        public ValueFormater DisplayFormat
        {
            get { return _DisplayFormat; }
            set { _DisplayFormat = value; }
        }

        private string _TypeName = null;
        /// <summary>
        /// 数据类型名称
        /// </summary>
        [DefaultValue(null)]
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private string _Description = null;
        /// <summary>
        /// 说明
        /// </summary>
        [DefaultValue(null)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private DCDocumentElementType _ElementType = DCDocumentElementType.InputField;
        /// <summary>
        /// 文档元素类型
        /// </summary>
        [DefaultValue(DCDocumentElementType.InputField)]
        public DCDocumentElementType ElementType
        {
            get
            {
                return _ElementType;
            }
            set
            {
                _ElementType = value;
            }
        }

        private DCDataSourceDescriptorList _ChildDescriptors = new DCDataSourceDescriptorList();
        /// <summary>
        /// 子节点列表
        /// </summary>
        [DefaultValue(null)]
        [System.Xml.Serialization.XmlArrayItem("Descriptor", typeof(DCDataSourceDescriptor))]
        public DCDataSourceDescriptorList ChildDescriptors
        {
            get
            {
                return _ChildDescriptors;
            }
            set
            {
                _ChildDescriptors = value;
            }
        }
    }

    /// <summary>
    /// 数据源描述对象列表
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("Count={ Count }")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(DCSoft.Common.ListDebugView))]
    public partial class DCDataSourceDescriptorList : List<DCDataSourceDescriptor>
    {
    }

    /// <summary>
    /// 文档元素样式
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public enum DCDocumentElementType
    {
        /// <summary>
        /// 输入域
        /// </summary>
        InputField,
        /// <summary>
        /// 复选框
        /// </summary>
        CheckBox,
        /// <summary>
        /// 单选框
        /// </summary>
        RadioBox
    }
}