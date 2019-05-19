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

    public class CreateLeaveInput
    {
        public int userId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime returnTime { get; set; }
        public string remark { get; set; }
    }

    /// <summary>
    /// 请假
    /// </summary>
    [Route("api/admin/study/[controller]/[action]")]
    public class LeaveController : Controller
    {
        public DataContext dataContext { get; set; }
        public LeaveController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        [HttpPost]
        public object insert(DevExtremInput bodyData)
        {
            var newLeave = new Leave();
            JsonConvert.PopulateObject(bodyData.values, newLeave);
            this.dataContext.leaves.Add(newLeave);
            this.dataContext.SaveChanges();
            return true;
        }
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from r in this.dataContext.leaves orderby r.createTime descending select r;
            return DataSourceLoader.Load(query, options);
        }

        [HttpPut]
        public object update(DevExtremInput bodyData)
        {
            var leave = this.dataContext.leaves.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, leave);
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

            var leave = this.dataContext.leaves.Find(key);
            this.dataContext.leaves.Remove(leave);
            this.dataContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// 申请离校
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public bool createLeave([FromBody]CreateLeaveInput input)
        {
            var user = this.dataContext.users.Find(input.userId);
            if (user != null)
            {
                var newLeave = new Leave
                {
                    userId = input.userId,
                    username = user.nickname,
                    status = LeaveStatus.Approve,
                    startTime = input.startTime,
                    returnTime = input.returnTime,
                    remark = input.remark,
                    orgId = user.orgId,
                    companyId = user.companyId
                };
                newLeave.status = LeaveStatus.Approve;
                this.dataContext.leaves.Add(newLeave);
                this.dataContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 返校
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>

        [HttpPost]
        public bool returnSchool(int leaveId)
        {
            var leave = this.dataContext.leaves.Find(leaveId);
            if (leave != null)
            {
                var user = this.dataContext.users.Find(leave.userId);
                if (user != null)
                {

                    leave.status = LeaveStatus.Return;
                    user.status = UserStatus.Disabled;
                    this.dataContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}