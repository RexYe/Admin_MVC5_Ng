using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace admin.Extension
{
    public static class StringExtensions
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="oriString">原密码</param>
        /// <returns></returns>
        public static string Md5String(this string oriString)
        {
            if (string.IsNullOrEmpty(oriString))
            {
                throw new ArgumentNullException(nameof(oriString));
            }

            MD5 m = new MD5CryptoServiceProvider();
            var bl = m.ComputeHash(Encoding.UTF8.GetBytes(oriString));
            m.Clear();
            var hd5Str = BitConverter.ToString(bl);
            return hd5Str.Replace("-", string.Empty);
        }
    } 
}