namespace Gocent.GTCMCDS.Model.AppsettingModel
{
    /// <summary>
    /// 跨域配置
    /// </summary>
    public class CorsConfig
    {
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 策略名称
        /// </summary>
        public string PolicyName { get; set; }
        /// <summary>
        /// 支持所有IP
        /// </summary>
        public bool SupportAllIPs { get; set; }
        /// <summary>
        /// 支持的IP，多个IP用逗号分隔
        /// </summary>
        public string IPs { get; set; }
    }
}