using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
    /// <summary>
    ///       会计数字单位字符类型
    ///       </summary>

    [ComVisible(true)]
    [Guid("B2EE9A23-186A-4637-A14D-A7AA5D658EDA")]
    public enum AccountingNumberUnitMode
    {
        /// <summary>
        ///       小写汉字数字
        ///       </summary>
        LowerCaseChinese,
        /// <summary>
        ///       大写汉字数字
        ///       </summary>
        CapitalChinese
    }
}
