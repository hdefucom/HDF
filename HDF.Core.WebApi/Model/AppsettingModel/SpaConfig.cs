namespace Gocent.GTCMCDS.Model.AppsettingModel
{
    /// <summary>
    /// SPA配置
    /// </summary>
    public class SpaConfig
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 开发模式SPA开发服务器的代理URL
        /// </summary>
        public string DevUrl { get; set; }
        /// <summary>
        /// 生产模式代理到build后的源文件目录
        /// </summary>
        public string SourcePath { get; set; }
        /// <summary>
        /// 根路径
        /// </summary>
        public string RootPath { get; set; }
    }
}