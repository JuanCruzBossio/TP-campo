using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace SEG_62_BP
{
    public class Encriptacion_62_BP
    {
        public string EncriptarConSHA256_62_BP(string textoOriginal)
        {
            string textoHasheado = "";
            SHA256 hasher = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(textoOriginal);
            byte[] hash = hasher.ComputeHash(bytes);
            textoHasheado = Convert.ToBase64String(hash);
            return textoHasheado;
        }

        public string EncriptarConAES_62_BP(string clave, string textoOriginal)
        {
            string textoHasheado = "";
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(clave);

            var encryptor = aes.CreateEncryptor();
            byte[] input = Encoding.UTF8.GetBytes(textoOriginal);
            byte[] encrypted = encryptor.TransformFinalBlock(input, 0, input.Length);

            textoHasheado = Convert.ToBase64String(encrypted);
            return textoHasheado;
        }
        public string DesencriptarConAES_62_BP(string clave, string textoHasheado)
        {
            string textoOriginal = "";
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(clave);

            var decryptor = aes.CreateDecryptor();
            byte[] input = Convert.FromBase64String(textoHasheado);
            byte[] decrypted = decryptor.TransformFinalBlock(input, 0, input.Length);

            textoOriginal = Encoding.UTF8.GetString(decrypted);
            return textoOriginal;
        }

    }
}
