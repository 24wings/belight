using System;
using System.Linq;
using Wings.Base.Common.DTO;

namespace Wings.Base.Common.Attrivute
{

    /// <summary>
    /// 编辑器
    /// </summary>
    public class EditorOptionsAttribute : Attribute
    {
        /// <summary>
        /// 树形视图
        /// </summary>
        /// <value></value>
        public DxTreeView dxTreeView { get; set; }
        /// <summary>
        /// 下拉菜单
        /// </summary>
        /// <value></value>
        public DxDropbox dxDropbox { get; set; }

    }
}