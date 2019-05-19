using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wings.Projects.Web
{
    [Table("leave")]
    public class Leave
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime createTime { get; set; } = DateTime.Now;
        public DateTime startTime { get; set; }
        public DateTime returnTime { get; set; }
        public int userId { get; set; }
        public string remark { get; set; }
        public LeaveStatus status { get; set; } = LeaveStatus.Submit;
        public int companyId { get; set; }
        public int orgId { get; set; }
    }

    public enum LeaveStatus
    {
        Submit,
        Approve,
        Return
    }


    [Table("routine")]
    public class Routine
    {
        public int id { get; set; }
        public int subjectId { get; set; }
        public DateTime datetime { get; set; }
        public DateTime createTime { get; set; } = DateTime.Now;
        public RoutineStatus status { get; set; } = RoutineStatus.Submit;
        public int userId { get; set; }
        public int companyId { get; set; }
        public int orgId { get; set; }

        [NotMapped]
        public Subject subject { get; set; }
    }
    public enum RoutineStatus
    {
        Submit,
        Aprrove,
        Expire
    }
    [Table("subject")]
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public DateTime startTime { get; set; } = DateTime.Now;
        public DateTime endTime { get; set; } = DateTime.Now;
        public DateTime createTime { get; set; } = DateTime.Now;
        public int companyId { get; set; }
        public SubjectStatus status { get; set; } = SubjectStatus.Active;
        /// <summary>
        /// 日期
        /// </summary>
        /// <value></value>
        public string fullDates { get; set; }

    }

    public enum SubjectStatus
    {
        Active,
        Deprecated
    }



    [Table("menu")]
    public class Menu
    {
        public int id { get; set; }
        public string text { get; set; }
        public string link { get; set; }
        public int level { get; set; } = 0;
        public string path { get; set; } = "";
        /// <summary>
        /// 权限编码
        /// </summary>
        /// <value></value>
        public string code { get; set; }
        public int parentId { get; set; } = 0;
        public DateTime createTime { get; set; } = DateTime.Now;

    }




    [Table("role")]
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string roleName { get; set; }
        public string menuIds { get; set; } = "";
        public DateTime createTime { get; set; } = DateTime.Now;
        public int orgId { get; set; }
        public int companyId { get; set; }
        [NotMapped]
        public Org org { get; set; }

    }

    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public int orgId { get; set; } = 0;
        /// <summary>
        /// 昵称
        /// </summary>
        /// <value></value>
        public string nickname { get; set; }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        public string roleIds { get; set; } = "";
        public string password { get; set; }
        [NotMapped]
        public Org org { get; set; }

        public DateTime createTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public int companyId { get; set; }
        public string subjectIds { get; set; }
        [NotMapped]
        public List<Role> roles { get; set; } = new List<Role>();
        [NotMapped]
        public List<Menu> menus { get; set; } = new List<Menu>();

        public UserStatus? status { get; set; } = UserStatus.Active;

        public RoleType roleType { get; set; } = RoleType.Student;



    }
    public enum RoleType
    {
        Teacher = 1,
        Student = 2
    }
    public enum UserStatus
    {
        Active,
        /// <summary>
        /// 离校
        /// </summary>
        Disabled
    }
    [Table("org")]
    public class Org
    {

        public int orgId { get; set; }
        public string orgName { get; set; }
        public DateTime? createTime { get; set; } = DateTime.Now;
        public int? companyId { get; set; }
        public int parentId { get; set; } = 0;
        /// <summary>
        /// 存储上级id路径
        /// </summary>
        /// <value></value>
        public string path { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        /// <value></value>
        public int level { get; set; } = 0;

        [NotMapped]

        public int roleNum { get; set; } = 0;
        [NotMapped]
        public int userNum { get; set; } = 0;


    }
    [Table("company")]
    public class Company
    {

        public int id { get; set; }
        public string name { get; set; }
        public DateTime? createTime { get; set; }
        public decimal? lat { get; set; } = 0;
        public decimal? lng { get; set; } = 0;
    }

    /// <summary>
    /// 航空数据环境
    /// </summary>
    public partial class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DataContext() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        /// <summary>
        /// 用户表
        /// </summary>
        /// <value></value>
        public DbSet<User> users { get; set; }

        public DbSet<Org> orgs { get; set; }

        public DbSet<Company> companys { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Routine> routine { get; set; }
        /// <summary>
        /// 请假列表
        /// </summary>
        /// <value></value>
        public DbSet<Leave> leaves { get; set; }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        /// <summary>
        /// 数据库实体创建时
        /// 1.null 扫描Wings.Hk 命名空间下的所有表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}