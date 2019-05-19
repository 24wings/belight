using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wings.Base.Common.DTO;
using Wings.Projects.Web;

namespace Wings.Areas.Admin.Rbac.Controllers
{
    [Route("api/admin/Rbac/[controller]/[action]")]
    public class MenuController : Controller
    {
        public DataContext dataContext { get; set; }
        public MenuController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {

            var newMenu = new Menu();

            JsonConvert.PopulateObject(bodyData.values, newMenu);
            if (newMenu.parentId != 0)
            {
                var parentMenu = this.dataContext.menus.Find(newMenu.parentId);
                if (parentMenu != null)
                {
                    newMenu.path = parentMenu.path + "," + parentMenu.id + ",";
                    newMenu.level = parentMenu.level + 1;
                }

            }
            this.dataContext.menus.Add(newMenu);
            this.dataContext.SaveChanges();
            return true;

        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from r in this.dataContext.menus select r;
            return DataSourceLoader.Load(query, options);
        }

        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var menu = this.dataContext.menus.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, menu);
            this.dataContext.SaveChanges();
            return true;
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool delete(int key)
        {

            var menu = this.dataContext.menus.Find(key);
            this.dataContext.menus.Remove(menu);
            this.dataContext.SaveChanges();
            return true;
        }
    }
}