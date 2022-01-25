using System.Security.Cryptography;
using System.Text;

namespace SalesMvc.Web.Libraries.Text
{
    public class KeyGenerator
    {
        public static string GetUniqueKey(int size)
        {
            char[] chars = "abcdefghijklmnopqrstuvxzABCDEFGHIJKLMNOPQRSTUVXZYW0123456789".ToCharArray();
            byte[] data = new byte[size];

            //using RSACryptoServiceProvider cripto = new RSACryptoServiceProvider();
            

            StringBuilder result = new StringBuilder();

            foreach(var item in data)
            {
                result.Append(chars[item % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}
