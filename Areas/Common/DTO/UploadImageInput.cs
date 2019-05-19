using System;
namespace Wings.Base.Common.DTO
{
    /// <summary>
    /// 图片上传
    /// </summary>
    public class UploadImageInput
    {
        /// <summary>
        /// base64格式
        /// </summary>
        /// <value></value>
        public string base64 { get; set; }

        // public string ext { get; set; } = "png";
    }
}