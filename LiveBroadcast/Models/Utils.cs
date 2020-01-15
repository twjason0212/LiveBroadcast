using System;
using System.Security.Cryptography;
using System.Text;

namespace LiveBroadcast.Models
{
    public class Utils
    {
        public static string MD5(string text)
        {
            MD5CryptoServiceProvider arg_11_0 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] array = arg_11_0.ComputeHash(bytes);
            arg_11_0.Clear();
            string text2 = "";
            for (int i = 0; i < array.Length; i++)
            {
                text2 += array[i].ToString("x").PadLeft(2, '0');
            }
            return text2;
        }
    }
}
