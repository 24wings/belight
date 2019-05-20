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

namespace Wings.Base.Common
{
  
    /// <summary>
    /// 流式上传
    /// </summary>
    [ApiController]
    [Route("/apis/[controller]")]
    public class RedirectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public RedirectController() { }

        /// <summary>
        /// 流式上传
        /// </summary>
        /// <returns></returns>
        [HttpGet("{*url}")]
        public object redirect()
        {
            var
            return  true;
            
        }
           [HttpPost]
        public object redirectPost()
        {
            return  true; 
            
        }
    }
}