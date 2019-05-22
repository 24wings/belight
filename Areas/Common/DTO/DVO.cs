using System;
using System.Collections.Generic;
using Wings.Base.Common.Attrivute;

namespace Wings.Base.Common.DTO
{
    public class DataSource
    {
        public string loadUrl { get; set; }
        public string insertUrl { get; set; }
    }

    public class Col : Attribute
    {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
    }

    public class View : Attribute
    {
        public string viewType { get; set; }
        public string keyExpr { get; set; } = "id";
        public string parentIdExpr { get; set; } = "parentId";
        public string displayExpr { get; set; }




        public View(string _viewType)
        {
            this.viewType = _viewType;
        }

        public List<Col> cols { get; set; } = new List<Col>();


    }
    public enum ViewType
    {
        Table,
        TreeTable
    }

    [View(nameof(ViewType.TreeTable))]
    public class MenuManagePage
    {
        public int id { get; set; }
        public string link { get; set; }
        public string text { get; set; }
    }
}