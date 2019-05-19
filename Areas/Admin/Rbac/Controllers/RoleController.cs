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
    public class RoleController : Controller
    {
        public DataContext dataContext { get; set; }
        public RoleController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {

            var newRole = new Role();
            JsonConvert.PopulateObject(bodyData.values, newRole);
            this.dataContext.roles.Add(newRole);
            this.dataContext.SaveChanges();
            return true;

        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from r in this.dataContext.roles select r;
            return DataSourceLoader.Load(query, options);
        }

        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var role = this.dataContext.roles.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, role);
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

            var role = this.dataContext.roles.Find(key);
            this.dataContext.roles.Remove(role);
            this.dataContext.SaveChanges();
            return true;
        }
    }
}