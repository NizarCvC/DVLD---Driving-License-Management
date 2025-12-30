using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DVLD_Business_Layer {

    public class clsCryptographics {

        /// <summary>
        /// The Method is used for hashing the input using hashing encryption.
        /// </summary>
        public static string Hashing(string input) {

            using (SHA256 sha256 = SHA256.Create()) {

                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
            }
        }

        /// <summary>
        /// The Method is used for encrypt the plain text using symmetric encryption.
        /// </summary>
        public static string Encrypt(string plainText, string key) {

            using (Aes aesAlg = Aes.Create()) {

                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream()) {

                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))

                    using (var swEncrypt = new StreamWriter(csEncrypt)) {

                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// The method is used for decrypt the cipher text using symmetric encryption.
        /// </summary>
        public static string Decrypt(string cipherText, string key) {

            using (Aes aesAlg = Aes.Create()) {

                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt)) {

                    return srDecrypt.ReadToEnd();
                }
            }
        }

        //public static void EncryptFile(string inputFile, string outputFile, string key, byte[] iv) {

        //    using (Aes aesAlg = Aes.Create()) {

        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = iv;

        //        using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
        //        using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
        //        using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
        //        using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write)) {
                    
        //            fsOutput.Write(iv, 0, iv.Length);
        //            fsInput.CopyTo(cryptoStream);
        //        }
        //    }
        //}

        //public static void DecryptFile(string inputFile, string outputFile, string key, byte[] iv) {

        //    using (Aes aesAlg = Aes.Create()) {

        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = iv;

        //        using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
        //        using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
        //        using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
        //        using (CryptoStream cryptoStream = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write)) {
                    
        //            fsInput.Seek(iv.Length, SeekOrigin.Begin);
        //            fsInput.CopyTo(cryptoStream);
        //        }
        //    }
        //}

    }
}