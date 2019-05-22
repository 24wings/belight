using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;
using Wings.Base.Common.Services;

namespace Wings.Base.Common {

    /// <summary>
    /// 流式上传
    /// </summary>
    [ApiController]
    [Route ("/api/[controller]/[action]")]
    public class DTOController : Controller {
        /// <summary>
        /// 
        /// </summary>
        public DTOController () { }

        /// <summary>
        /// 流式上传
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object load () {
            var type = Assembly.GetEntryAssembly ().GetType ("Wings.Base.Common.DTO.MenuManagePage");

            var view = (View) type.GetCustomAttribute<View> ();
            // view

            var members = type.GetProperties ();
            foreach (var m in members) {
                var com = m.GetCustomAttribute<Com> ();
                if (com != null) {

                    if (com.isShow) {
                        view.cols.Add (new Col { label = com.label, type = com.type == null?m.PropertyType.ToString () : com.type });
                    }
                    if (com.isEdit) {
                        view.fields.Add (new Field { label = com.label, type = com.type == null?m.PropertyType.ToString () : com.type });
                    }
                    if (com.type == "Select") {
                        Console.WriteLine (m.PropertyType.ToString ());
                        Console.WriteLine (m.PropertyType.IsEnum);
                        var ms = m.PropertyType.GetMembers ();
                        foreach (var p in ms) {
                            Console.WriteLine (p);
                        }
                    }
                }

                // view.

            }

            // var dbSet = this.getEntityByName(viewAttr.entity);
            // var
            // return true;
            return view;

        }

        [HttpPost]
        public object redirectPost () {
            return true;

        }
    }
}