using System;
using System.Linq;

namespace Wings.Base.Common.Attrivute
{

    /// <summary>
    /// 视图特性
    /// </summary>
    public class TreeListViewAttribute : ViewAttribute
    {
        /// <summary>
        /// 覆盖视图类型 
        /// </summary>
        /// <value></value>
        public new string viewType { get; set; } = "TreeList";
        /// <summary>
        /// 主键表达式
        /// </summary>
        /// <value></value>
        public string keyExpr { get; set; }
        /// <summary>
        /// 上级id表达式
        /// </summary>
        /// <value></value>
        public string parentIdExpr { get; set; }

    }

}