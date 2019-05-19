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

namespace Wings.Areas.Admin.Study.Controllers
{

    public class CheckoutInput
    {
        public int userId { get; set; }

        public int subjectId { get; set; }

    }
    public class AddSubject
    {
        public int userId { get; set; }
        public int subjectId { get; set; }
    }
    [Route("api/admin/study/[controller]/[action]")]
    public class RoutineController : Controller
    {
        public DataContext dataContext { get; set; }
        public RoutineController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {
            var newRoutine = new Routine();
            JsonConvert.PopulateObject(bodyData.values, newRoutine);
            var user = this.dataContext.users.Find(newRoutine.userId);
            if (user != null)
            {
                newRoutine.orgId = user.orgId;
                newRoutine.companyId = user.companyId;
            }
            this.dataContext.routine.Add(newRoutine);

            this.dataContext.SaveChanges();
            return true;
        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from r in this.dataContext.routine
                        select new Routine
                        {
                            id = r.id,
                            companyId = r.companyId,
                            subject = (from s in this.dataContext.subjects where s.id == r.subjectId select s).FirstOrDefault(),
                            userId = r.userId,
                            orgId = r.orgId,
                            status = r.status,
                            subjectId = r.subjectId,
                            createTime = r.createTime,
                            datetime = r.datetime,

                        };
            return DataSourceLoader.Load(query, options);
        }

        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var subject = this.dataContext.routine.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, subject);
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

            var routine = this.dataContext.routine.Find(key);
            this.dataContext.routine.Remove(routine);
            this.dataContext.SaveChanges();
            return true;
        }
        [HttpPost]
        public object checkout([FromBody]CheckoutInput input)
        {
            var user = this.dataContext.users.Find(input.userId);
            var subject = this.dataContext.subjects.Find(input.subjectId);
            if (user != null && subject != null)
            {
                var newRoutine = new Routine
                {
                    userId = user.id,
                    subjectId = subject.id,
                    datetime = DateTime.Now,
                    status = RoutineStatus.Aprrove,
                    orgId = user.orgId,
                    companyId = user.companyId
                };
                this.dataContext.routine.Add(newRoutine);
                this.dataContext.SaveChanges();
                return newRoutine;
            }
            else
            {
                return false;
            }
        }
    }
}