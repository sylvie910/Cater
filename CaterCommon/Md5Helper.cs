using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    public static partial class Md5Helper
    {
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] newBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte newByte in newBytes)
            {
                sb.Append(newByte.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
