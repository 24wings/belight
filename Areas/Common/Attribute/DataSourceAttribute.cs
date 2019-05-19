using System;
using System.Linq;

namespace Wings.Base.Common.Attrivute
{

    /// <summary>
    /// 数据源
    /// </summary>
    public class DataSourceAttribute : Attribute
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public string key { get; set; }
        /// <summary>
        /// 默认增删改查地址
        /// </summary>
        /// <value></value>
        public string url { get; set; }
        /// <summary>
        /// 查询地址
        /// </summary>
        /// <value></value>
        public string loadUrl { get; set; }
        /// <summary>
        /// 插入地址
        /// </summary>
        /// <value></value>
        public string insertUrl { get; set; }
        /// <summary>
        /// 移除地址
        /// </summary>
        /// <value></value>
        public string deleteUrl { get; set; }
        /// <summary>
        /// 更新地址
        /// </summary>
        /// <value></value>
        public string updateUrl { get; set; }
    }
}