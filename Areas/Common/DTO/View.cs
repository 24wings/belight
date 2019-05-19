using System;
using System.Collections.Generic;
using Wings.Base.Common.Attrivute;

namespace Wings.Base.Common.DTO
{
    /// <summary>
    /// 列
    /// </summary>
    public class Col
    {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string caption { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }
        /// <summary>
        /// 列的数据类型
        /// </summary>
        /// <value></value>
        public string dataType { get; set; }
        /// <summary>
        /// 显示值
        /// </summary>
        /// <value></value>
        public string calculateDisplayValue { get; set; }
    }
    /// <summary>
    /// 表单元数据
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public Label label { get; set; }
        /// <summary>
        /// 编辑类型
        /// </summary>
        /// <value></value>
        public string editorType { get; set; }

        /// <summary>
        /// 数据字段
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }

        /// <summary>
        /// 编辑器选项
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> editorOptions { get; set; }
    }
    /// <summary>
    /// 视图元数据
    /// </summary>
    public class View
    {
        /// <summary>
        /// 数据视图对象名称
        /// </summary>
        /// <value></value>
        public string dvo { get; set; }
        /// <summary>
        /// 完全限定名
        /// </summary>
        /// <value></value>
        public string fullName { get; set; }
        /// <summary>
        /// 视图类型
        /// </summary>
        /// <value></value>
        public string viewType { get; set; }

        /// <summary>
        /// 页面标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        /// <value></value>
        public List<Col> cols { get; set; }
        /// <summary>
        /// 表单字段
        /// </summary>
        /// <value></value>
        public List<Item> items { get; set; }

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
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value></value>
        public DataSource dataSource { get; set; }
    }
    /// <summary>
    /// 标签文本
    /// </summary>
    public class Label
    {
        /// <summary>
        /// 标签文本
        /// </summary>
        /// <value></value>
        public string text { get; set; }
        //    visible?: boolean, showColon?: boolean, location?: 'left' | 'right' | 'top', alignment?: 'center' | 'left' | 'right' };
    }

    /// <summary>
    ///   editorOptions: {
    ///     dxDropbox: {
    ///       displayExpr: "name"
    ///     },
    ///     dxTreeView: {
    ///       dataSource: new DataSource(
    ///         new LocalStore({
    ///           key: "id",
    ///           immediate: true,
    ///           name: "local-menu",
    ///           flushInterval: 1000
    ///         })
    ///       ),
    ///       selectionMode: "multiple",
    ///       keyExpr: "id",
    ///       displayExpr: "name",
    ///       parentIdExpr: "parentId",
    ///       placeholder: "勾选菜单列表"
    ///     }
    ///   }
    /// </summary>
    public class EditorOptions
    {
        /// <summary>
        /// 配置下拉菜单
        /// </summary>
        /// <value></value>
        public DxDropbox dxDropbox { get; set; }
        /// <summary>
        /// 树形视图
        /// </summary>
        /// <value></value>
        public DxTreeView dxTreeView { get; set; }

    }

    /// <summary>
    /// 下拉菜单
    /// </summary>
    public class DxDropbox
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
    public class DxTreeView : DataSource
    {
        /// <summary>
        /// 菜单选择模式
        /// </summary>
        public static class SelectionMode
        {
            /// <summary>
            /// 多选
            /// </summary>
            /// <value></value>
            public static string multiple { get; } = "multiple";
            /// <summary>
            /// 单选
            /// </summary>
            /// <value></value>
            public static string single { get; } = "single";

        }

        /// <summary>
        /// 数据源
        /// </summary>
        /// <value></value>
        public DataSource dataSource { get; set; }
        /// <summary>
        /// 选择模式
        /// </summary>
        /// <value></value>
        public string selectionMode { get; set; } = "multiple";
        /// <summary>
        /// 主键表达式
        /// </summary>
        /// <value></value>
        public string keyExpr { get; set; } = "id";
        /// <summary>
        /// 显示表达式
        /// </summary>
        /// <value></value>
        public string displayExpr { get; set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        /// <value></value>
        public string parentIdExpr { get; set; } = "parentId";
        /// <summary>
        /// 悬浮提示
        /// </summary>
        /// <value></value>
        public string placeholder { get; set; } = "下拉勾选";

    }
}