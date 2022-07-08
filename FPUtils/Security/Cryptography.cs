using System;
using System.Security.Cryptography;
using System.Text;

namespace FPUtils.Security
{
   public static class Cryptography
   {
      /// <summary>
      /// Encrypt a string
      /// </summary>
      /// <param name="value">The string value</param>
      /// <param name="Key">The encryption key</param>
      public static string Encrypt(string value, string Key)
      {
         if (string.IsNullOrEmpty(value))
         {
            return value;
         }

         byte[] keyArray;
         byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(value);

         MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
         keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

         hashmd5.Clear();

         TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
         {
            Key = keyArray,
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
         };

         ICryptoTransform cTransform = tdes.CreateEncryptor();
         byte[] resultArray =
           cTransform.TransformFinalBlock(toEncryptArray, 0,
           toEncryptArray.Length);
         tdes.Clear();

         return Convert.ToBase64String(resultArray, 0, resultArray.Length);
      }

      /// <summary>
      /// Decrypt a string
      /// </summary>
      /// <param name="value">The string value</param>
      /// <param name="Key">The decryption key</param>
      public static string Decrypt(string value, string Key)
      {
         if (string.IsNullOrEmpty(value))
         {
            return value;
         }

         try
         {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(value);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
               Key = keyArray,
               Mode = CipherMode.ECB,
               Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
         }
         catch
         {
            return null;
         }
      }
   }
}
