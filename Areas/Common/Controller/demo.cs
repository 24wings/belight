// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Linq;
// using System.Reflection;
// using System.Threading.Tasks;
// using DevExtreme.AspNet.Data;
// using DevExtreme.AspNet.Mvc;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;
// using Wings.Base.Common.Attrivute;
// using Wings.Base.Common.DTO;
// using Wings.Projects.Rcxh.RBAC.Entity;

// namespace Wings.Projects.Rcxh.Controllers
// {
//     /// <summary>
//     /// 自动化管理控制器
//     /// </summary>
//     [Route("/api/Hk/DVO")]
//     public class DVOController
//     {

//         private RcxhContext db { get; set; }
//         /// <summary>
//         /// 
//         /// </summary>
//         /// <param name="_db"></param>
//         public DVOController(RcxhContext _db) { db = _db; }

//         /// <summary>
//         /// dvo查询
//         /// </summary>
//         /// <param name="dvoFullName"></param>
//         /// <param name="options"></param>
//         /// <returns></returns>
//         [HttpGet("[action]/{dvoFullName}")]
//         public object load([FromRoute] string dvoFullName, [FromQuery] DataSourceLoadOptionsBase options)
//         {
//             var type = Assembly.GetEntryAssembly().GetType(dvoFullName);
//             var viewAttr = (ViewAttribute)type.GetCustomAttribute(typeof(ViewAttribute));
//             var dbSet = this.getEntityByName(viewAttr.entity);
//             return DataSourceLoader.Load(dbSet, options);
//         }

//         /// <summary>
//         /// 实力方法
//         /// </summary>
//         /// <returns></returns>
//         private IQueryable<object> getEntityByName(string entity)
//         {
//             switch (entity.ToLower())
//             {
//                 case "users":
//                     var query = (from user in this.db.users select user);
//                     return query;
//                 case "orgs":
//                     return (from org in this.db.orgs select org);
//                 default:
//                     return (from user in this.db.users select user);
//             }
//         }

//         /// <summary>
//         /// 插入数据
//         /// </summary>
//         /// <param name="dvoFullName"></param>
//         /// <param name="input"></param>
//         /// <returns></returns>
//         [HttpPost("[action]/{dvoFullName}")]

//         public object insert([FromRoute] string dvoFullName, [FromForm] DevExtremInput input)
//         {
//             var type = Assembly.GetEntryAssembly().GetType(dvoFullName);
//             var viewAttr = (ViewAttribute)type.GetCustomAttribute(typeof(ViewAttribute));
//             var dbSet = (from m in this.db.GetType().GetMembers() where m.Name == viewAttr.entity select m).FirstOrDefault();

//             if (dbSet != null)
//             {
//                 // viewAttr.entity
//                 // var dbSetMethodInfo = typeof (DbContext).GetMethod ("Set");

//                 // dynamic dbSet = dbSetMethodInfo.MakeGenericMethod (type).Invoke (this.db, null);
//                 dynamic instance = Activator.CreateInstance(type);
//                 JsonConvert.PopulateObject(input.values, instance);
//                 //Validate(order);
//                 // if (!ModelState.IsValid)
//                 // return false;
//                 // this.hk.orgManage.Add (user);
//                 // dbSet.Add (instance);
//                 // db.SaveChanges ();
//                 return null;

//                 // return instance;
//             }
//             else
//             {
//                 return CommonRtn.Error("找不到DVO");
//             }

//         }
//         /// <summary>
//         /// 更新数据
//         /// </summary>
//         /// <param name="dvoFullName"></param>
//         /// <param name="input"></param>
//         /// <returns></returns>

//         [HttpPut("[action]/{dvoFullName}")]
//         public object update([FromRoute] string dvoFullName, [FromForm] DevExtremInput input)
//         {
//             var type = Assembly.GetEntryAssembly().GetType(dvoFullName);
//             var dbSetMethodInfo = typeof(DbContext).GetMethod("Set");

//             dynamic dbSet = dbSetMethodInfo.MakeGenericMethod(type).Invoke(this.db, null);
//             dynamic instance = dbSet.Find(input.key);

//             JsonConvert.PopulateObject(input.values, instance);
//             //Validate(order);
//             // if (!ModelState.IsValid)
//             // return false;
//             // this.hk.orgManage.Add (user);
//             // dbSet.Add (instance);
//             db.SaveChanges();

//             return instance;
//         }

//         /// <summary>
//         /// 删除
//         /// </summary>
//         /// <param name="dvoFullName"></param>
//         /// <param name="input"></param>
//         /// <returns></returns>
//         [HttpDelete("[action]/{dvoFullName}")]
//         public object remove([FromRoute] string dvoFullName, [FromForm] DevExtremInput input)
//         {
//             var type = Assembly.GetEntryAssembly().GetType(dvoFullName);
//             var dbSetMethodInfo = typeof(DbContext).GetMethod("Set");

//             dynamic dbSet = dbSetMethodInfo.MakeGenericMethod(type).Invoke(this.db, null);
//             var item = ((Microsoft.EntityFrameworkCore.Internal.InternalDbSet<object>)dbSet).Find(input.key);
//             dbSet.Remove(item);
//             db.SaveChanges();
//             return true;
//         }

//         /// <summary>
//         /// 列出DVO
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet("[action]")]
//         public List<View> listDVO()
//         {
//             var _namespace_ = "Wings.Projects.Rcxh";
//             var dvos = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute(typeof(ViewAttribute)) != null && t.Namespace.StartsWith(_namespace_)).ToArray();
//             var views = new List<View>();
//             foreach (var dvo in dvos)
//             {
//                 var view = this.getViewByDVO(dvo.FullName);
//                 views.Add(view);
//             }
//             return views;
//         }
//         /// <summary>
//         /// 
//         /// </summary>
//         /// <param name="dvo"></param>
//         /// <returns></returns>
//         [HttpGet("[action]")]
//         public View getViewByDVO([FromQuery] string dvo)
//         {
//             var type = Assembly.GetEntryAssembly().GetType(dvo);
//             if (type != null)
//             {
//                 var view = this.getViewByType(type);
//                 var memberInfos = type.GetMembers();
//                 var cols = new List<Col>();
//                 var items = new List<Item>();
//                 foreach (var m in memberInfos)
//                 {
//                     var colAttr = (ColAttribute)m.GetCustomAttribute(typeof(ColAttribute));
//                     if (colAttr != null)
//                     {
//                         var col = new Col();
//                         col.caption = colAttr.caption;
//                         col.dataField = colAttr.dataField != null ? colAttr.dataField : m.Name;
//                         col.dataType = colAttr.dataType.ToString();
//                         if (colAttr.calculateDisplayValue != null)
//                         {

//                             col.calculateDisplayValue = colAttr.calculateDisplayValue;
//                         }

//                         cols.Add(col);
//                     }
//                     var itemAttr = (ItemAttribute)m.GetCustomAttribute(typeof(ItemAttribute));
//                     if (itemAttr != null)
//                     {
//                         var item = new Item();
//                         item.editorOptions = new Dictionary<string, object>();
//                         var dxDropboxAttribute = (DxDropboxAttribute)m.GetCustomAttribute(typeof(DxDropboxAttribute));
//                         var dxTreeViewAttribute = (DxTreeViewAttribute)m.GetCustomAttribute(typeof(DxTreeViewAttribute));
//                         if (dxDropboxAttribute != null)
//                         {
//                             item.editorOptions.Add("dxDropbox", new DxDropbox { displayExpr = dxDropboxAttribute.displayExpr });
//                         }
//                         if (dxTreeViewAttribute != null)
//                         {
//                             item.editorOptions.Add("dxTreeView", new DxTreeView
//                             {
//                                 displayExpr = dxTreeViewAttribute.displayExpr,
//                                 parentIdExpr = dxTreeViewAttribute.parentIdExpr,
//                                 key = dxTreeViewAttribute.key,
//                                 keyExpr = dxTreeViewAttribute.keyExpr,
//                                 dataSource = new DataSource { url = dxTreeViewAttribute.url }
//                             });

//                         }

//                         item.editorType = itemAttr.editorType.ToString();
//                         item.label = new Label { text = itemAttr.label };

//                         item.dataField = itemAttr.dataField == null ? m.Name : itemAttr.dataField;
//                         items.Add(item);
//                     }
//                 }
//                 view.cols = cols;
//                 view.items = items;
//                 return view;
//             }
//             else
//             {
//                 return null;
//             }

//         }
//         /// <summary>
//         /// 根据类型获取视图
//         /// </summary>
//         /// <param name="type"></param>
//         /// <returns></returns>
//         private View getViewByType(Type type)
//         {
//             var view = new View();
//             var viewAttr = (ViewAttribute)type.GetCustomAttribute(typeof(ViewAttribute));
//             if (viewAttr == null)
//             {
//                 Console.WriteLine(type);
//             }
//             view.viewType = viewAttr.viewType.ToString();
//             view.title = viewAttr.title;
//             view.fullName = type.FullName;
//             var treeViewAttr = (TreeListViewAttribute)type.GetCustomAttribute(typeof(TreeListViewAttribute));
//             view.dvo = type.Name;
//             if (treeViewAttr != null)
//             {
//                 view.keyExpr = treeViewAttr.keyExpr;
//                 view.parentIdExpr = treeViewAttr.parentIdExpr;
//                 view.viewType = treeViewAttr.viewType.ToString();
//             }
//             var dataSourceAttribute = (DataSourceAttribute)type.GetCustomAttribute(typeof(DataSourceAttribute));
//             var dataSource = new DataSource();
//             dataSource.key = dataSourceAttribute.key;
//             dataSource.url = dataSourceAttribute.url;
//             dataSource.insertUrl = dataSourceAttribute.insertUrl == null ? dataSourceAttribute.url : dataSourceAttribute.insertUrl;
//             dataSource.loadUrl = dataSourceAttribute.loadUrl == null ? dataSourceAttribute.url : dataSourceAttribute.loadUrl;
//             dataSource.deleteUrl = dataSourceAttribute.deleteUrl == null ? dataSourceAttribute.url : dataSourceAttribute.deleteUrl;
//             dataSource.updateUrl = dataSourceAttribute.updateUrl == null ? dataSourceAttribute.url : dataSourceAttribute.updateUrl;
//             view.dataSource = dataSource;
//             return view;

//         }

//     }
// }