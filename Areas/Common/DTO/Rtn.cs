using System;
using System.Collections.Generic;

namespace Wings.Base.Common.DTO
{

    /// <summary>
    /// 返回给前端的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Rtn<T>
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <value></value>
        public string message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        /// <value></value>
        public bool success { get; set; }
        /// <summary>
        /// 返回给前端的数据
        /// </summary>
        /// <value></value>
        public T resData { get; set; }
        /// <summary>
        ///  状态码
        /// </summary>
        /// <value></value>
        public int code { get; set; }
        /// <summary>
        /// 便捷方法返回错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Rtn<T> Error(string message)
        {
            return new Rtn<T> { success = false, message = message, resData = default(T), code = 400 };
        }
        /// <summary>
        /// 便捷方法返回正确消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Rtn<T> Success(T data, string message = "")
        {
            return new Rtn<T> { success = true, message = message, resData = data, code = 200 };
        }
    }
}