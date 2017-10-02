using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CAD.Core.Util.Extensao
{
    public static class StringUtil
    {

        public static string Criptografado(this string text)
        {
            var inputByteArray = Encoding.UTF8.GetBytes(text);
            byte[] rgbIv = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };
            try
            {
                var key = Encoding.UTF8.GetBytes("A0D1nX0Q");
                var des = new DESCryptoServiceProvider();
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(key, rgbIv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Descriptografado(this string criptText)
        {
            byte[] rgbIv = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };

            try
            {
                var key = Encoding.UTF8.GetBytes("A0D1nX0Q");
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Convert.FromBase64String(criptText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(key, rgbIv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Sanitizado(this string input)
        {
            return input.Replace("-", string.Empty).Replace(" ", string.Empty).Replace(".", string.Empty).Trim();
        }
    }
}
