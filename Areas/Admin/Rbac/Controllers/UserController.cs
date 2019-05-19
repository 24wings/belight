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
    public class UserController : Controller
    {
        public DataContext dataContext { get; set; }
        public UserController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from u in this.dataContext.users
                        select new User
                        {
                            id = u.id,
                            org = (from org in this.dataContext.orgs where org.orgId == u.orgId select org).FirstOrDefault(),
                            username = u.username,
                            nickname = u.nickname,
                            password = u.password,
                            createTime = u.createTime,
                            roleIds = u.roleIds,
                            companyId = u.companyId,
                            orgId = u.orgId,
                            roles = (from r in this.dataContext.roles where u.roleIds.Contains("," + r.id.ToString() + ",") select r).ToList(),
                            status = u.status
                        };
            return DataSourceLoader.Load(query, options);
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {
            var newUser = new User();
            JsonConvert.PopulateObject(bodyData.values, newUser);
            this.dataContext.users.Add(newUser);
            this.dataContext.SaveChanges();
            return true;

        }
        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var user = this.dataContext.users.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, user);
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

            var user = this.dataContext.users.Find(key);
            this.dataContext.users.Remove(user);
            this.dataContext.SaveChanges();
            return true;
        }
        [HttpGet]
        public Company gerUserCompany(int userId)
        {
            var user = this.dataContext.users.Find(userId);
            if (user != null)
            {
                return this.dataContext.companys.Find(user.companyId);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public object studentRegister()
        {
            return true;
        }
    }
}