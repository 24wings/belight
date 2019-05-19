using System;
using System.Linq;

namespace Wings.Base.Common.Attrivute
{

    /// <summary>
    /// 视图特性
    /// </summary>
    public class ViewAttribute : Attribute
    {
        /// <summary>
        /// 视图类型
        /// </summary>
        /// <value></value>
        public ViewType viewType { get; set; } = ViewType.Table;
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 指向更新实体
        /// </summary>
        /// <value></value>
        public string entity { get; set; }

    }

    /// <summary>
    /// 视图类型
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// 表格
        /// </summary>
        Table,
        /// <summary>
        /// 树形
        /// </summary>
        Tree
    }

    /// <summary>
    /// 下拉菜单
    /// </summary>
    public class DxDropboxAttribute : Attribute
    {
        /// <summary>
        /// 取值表达式
        /// </summary>
        /// <value></value>

        public string displayExpr { get; set; } = "name";
    }
    /// <summary>
    /// 树形视图
    /// </summary>
    public class DxTreeViewAttribute : DataSourceAttribute
    {
        /// <summary>
        /// 下拉显示数据
        /// </summary>
        /// <value></value>
        public string displayExpr { get; set; } = "name";
        /// <summary>
        ///  "multiple" |"single"
        /// </summary>
        /// <value></value>
        public string selectionMode { get; set; }
        /// <summary>
        /// 主键表达式
        /// </summary>
        /// <value></value>
        public string keyExpr { get; set; } = "id";
        /// <summary>
        /// 父级Id表达式
        /// </summary>
        /// <value></value>
        public string parentIdExpr { get; set; } = "parentId";
        /// <summary>
        /// 下拉勾选
        /// </summary>
        /// <value></value>
        public string placeholder { get; set; } = "下拉勾选";

    }
}