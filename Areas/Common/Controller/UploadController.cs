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
    /// 上传响应
    /// </summary>
    public class UploadOutput
    {
        /// <summary>
        /// 文件名
        /// </summary>
        /// <value></value>
        public string filename { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        /// <value></value>
        public string url { get; set; }
    }
    /// <summary>
    /// 流式上传
    /// </summary>
    [ApiController]
    [Route("/api/Base/Common/upload")]
    public class UploadController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public UploadController() { }

        /// <summary>
        /// 流式上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object upload([FromForm(Name = "file")] IFormFile file, string filename)
        {
            filename = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds + filename;
            //将源文件 读取成文件流
            Stream fromFile = file.OpenReadStream();
            OSSService.uploadFile(fromFile, filename);
            return Rtn<UploadOutput>.Success(new UploadOutput { url = "http://tpjs.95t92.cn/" + filename, filename = filename }, "上传成功");
        }
    }
}