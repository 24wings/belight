using System;
using System.Collections.Generic;
using System.Reflection;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;

namespace Wings.Base.Common.Services {
    /// <summary>
    /// DVO服务
    /// </summary>
    public interface IDVOService {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_namespace_"></param>
        /// <returns></returns>
        List<View> listViewByNamespace (string _namespace_);
    }
    /// <summary>
    /// 根据命名空间列出视图列表
    /// </summary>
    public class DVOService : IDVOService {

        /// <summary>
        /// 根据命名空间列出旗下的所有dvo
        /// </summary>
        /// <param name="_namespace_"></param>
        /// <returns></returns>
        public List<View> listViewByNamespace (string _namespace_) {
            var nsp = Assembly.GetEntryAssembly ().GetType (_namespace_);
            Console.WriteLine (nsp.Namespace);

            return null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dvo"></param>
        /// <returns></returns>
        public View getViewByName (string dvo) {
            var type = Assembly.GetEntryAssembly ().GetType (dvo);
            if (type != null) {
                var viewAttr = (ViewAttribute) type.GetCustomAttribute (typeof (ViewAttribute));
                var memberInfos = type.GetMembers ();
                var cols = new List<Col> ();
                var items = new List<Item> ();

                foreach (var m in memberInfos) {
                    var colAttr = (ColAttribute) m.GetCustomAttribute (typeof (ColAttribute));

                    if (colAttr != null) {
                        var col = new Col ();
                        col.caption = colAttr.caption;
                        cols.Add (col);
                    }

                    var itemAttr = (ItemAttribute) m.GetCustomAttribute (typeof (ItemAttribute));
                    if (itemAttr != null) {
                        var item = new Item ();
                        item.editorType = itemAttr.editorType.ToString ();
                        item.label = new Label { text = itemAttr.label };
                        item.dataField = itemAttr.dataField == null? m.Name : itemAttr.dataField;
                        items.Add (item);
                    }

                }

                var view = new View ();
                view.viewType = viewAttr.viewType.ToString ();
                view.title = viewAttr.title;
                view.cols = cols;
                view.items = items;
                return view;
            } else {
                return null;
            }
        }
    }
}