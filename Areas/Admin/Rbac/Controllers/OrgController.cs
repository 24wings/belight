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
    public class OrgController : Controller
    {
        public DataContext dataContext { get; set; }
        public OrgController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {

            var newOrg = new Org();
            JsonConvert.PopulateObject(bodyData.values, newOrg);
            if (newOrg.parentId != 0)
            {
                var parnetOrg = this.dataContext.orgs.Find(newOrg.parentId);
                newOrg.path = parnetOrg.path + "," + parnetOrg.orgId;
            }

            this.dataContext.orgs.Add(newOrg);

            this.dataContext.SaveChanges();
            return true;

        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from org in this.dataContext.orgs
                        select new Org
                        {
                            userNum = (from user in this.dataContext.users where user.orgId == org.orgId select user).Count(),
                            orgName = org.orgName,
                            orgId = org.orgId,
                            createTime = org.createTime,
                            roleNum = 0,
                            parentId = org.parentId,
                            companyId = org.companyId,
                            level = org.level
                        };
            return DataSourceLoader.Load(query, options);
        }

        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var org = this.dataContext.orgs.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, org);
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

            var org = this.dataContext.orgs.Find(key);
            this.dataContext.orgs.Remove(org);
            this.dataContext.SaveChanges();
            return true;
        }
    }
    [Route("api/admin/Rbac/[controller]/[action]")]
    public class CompanyController : Controller
    {
        public DataContext dataContext { get; set; }
        public CompanyController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(this.dataContext.companys, options);
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {
            var newCompany = new Company();
            JsonConvert.PopulateObject(bodyData.values, newCompany);
            this.dataContext.companys.Add(newCompany);
            this.dataContext.SaveChanges();
            return true;

        }
        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var company = this.dataContext.companys.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, company);
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

            var company = this.dataContext.companys.Find(key);
            this.dataContext.companys.Remove(company);
            this.dataContext.SaveChanges();
            return true;
        }

    }

}
