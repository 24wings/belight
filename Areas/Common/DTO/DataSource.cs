using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wings.Base.Common.DTO {

    /// <summary>
    ///    数据源
    /// </summary>
    public class DataSource {
        /// <summary>
        /// 数据存取方式, local,odata,custom
        /// </summary>
        /// <value></value>
        public string type { get; set; } = "odata";
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