using System;
using System.Collections.Generic;
using Wings.Base.Common.Attrivute;

namespace Wings.Base.Common.DTO {
    public class DataSource {
        public string loadUrl { get; set; }
        public string insertUrl { get; set; }
        public string removeUrl { get; set; }
        public string updateUrl { get; set; }
    }

    public class Col : Attribute {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
        public string type { get; set; }
        public Col () { }
    }
    public class Field {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
        public string type { get; set; }
    }
    public class Com : Attribute {
        public string label { get; set; }
        public string type { get; set; }
        public Com (string _label) {
            this.label = _label;
        }
        public bool isEdit { get; set; } = true;
        public bool isShow { get; set; } = true;
    }

    public class View : Attribute {
        public string alias { get; set; }
        public string viewType { get; set; }
        public string keyExpr { get; set; } = "id";
        public string parentIdExpr { get; set; } = "parentId";
        public string displayExpr { get; set; }

        public View (string _alias, string _viewType) {
            this.alias = _alias;
            this.viewType = _viewType;
        }
        public DataSource dataSource { get; set; } = new DataSource ();

        public string loadUrl {
            set {
                this.dataSource.loadUrl = value;
            }
            get {
                return this.dataSource.loadUrl;
            }
        }

        public string insertUrl {
            set {
                this.dataSource.insertUrl = value;
            }
            get {
                return this.dataSource.insertUrl;
            }
        }
        public string updateUrl {
            set {
                this.dataSource.updateUrl = value;
            }
            get {
                return this.dataSource.updateUrl;
            }
        }

        public string removeUrl {
            set {
                this.dataSource.removeUrl = value;
            }
            get {
                return this.dataSource.removeUrl;
            }
        }

        public List<Col> cols { get; set; } = new List<Col> ();
        public List<Field> fields { get; set; } = new List<Field> ();

    }
    public enum ViewType {
        Table,
        TreeTable
    }

    [View ("MenuManagePage", nameof (ViewType.TreeTable),
        loadUrl = "/api/admin/Rbac/menu/load",
        removeUrl = "/api/admin/Rbac/menu/remove",
        updateUrl = "/api/admin/Rbac/menu/update",
        insertUrl = "/api/admin/Rbac/menu/insert",
        displayExpr = "text"
    )]
    public class MenuManagePage {
        public int id { get; set; }

        [Com ("地址")]
        public string link { get; set; }

        [Com ("地址")]
        public string text { get; set; }

        [Com ("创建时间", isEdit = false)]
        public DateTime createAt { get; set; }
        public int parentId { get; set; } = 0;

        [Com ("代码")]
        public string code { get; set; }

        [Com ("菜单类型", type = "Select")]
        public MenuType menuType { get; set; }
    }
    public enum MenuType {
        Menu,
        Power,
        Field
    }
}