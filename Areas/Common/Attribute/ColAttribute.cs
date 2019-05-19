using System;
using System.Linq;

namespace Wings.Base.Common.Attrivute {
    /// <summary>
    /// 列特性
    /// </summary>
    public class ColAttribute : Attribute {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string caption { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        /// <value></value>
        public ColDataType dataType { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }
        /// <summary>
        /// 计算显示值
        /// </summary>
        /// <value></value>
        public string calculateDisplayValue { get; set; }
    }
    /// <summary>
    /// 列的数据类型
    /// </summary>
    /// 
    public enum ColDataType {
        /// <summary>
        /// 列的数据类型
        /// </summary>
        /// 
        String,
        /// <summary>
        /// 列的数据类型
        /// </summary>
        Number,
        /// <summary>
        /// 日期类型
        /// </summary>

        date
    }
}