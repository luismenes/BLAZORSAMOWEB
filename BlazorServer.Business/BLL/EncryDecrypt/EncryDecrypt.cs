using BlazorServer.Business.Interfaces.EncryDecrypt;
using BlazorServer.DTO.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL.EncryDecrypt
{
    public class EncryDecrypt : IEncryDecrypt
    {
        static readonly string passPhrase = "SDFTUHbvmnrfe54894efdef*";
        static readonly string saltValue = "s@1tValue";
        static readonly string hashAlgorithm = "MD5"; //can be "MD5"  "SHA1"
        static readonly int passwordIterations = 3;
        static readonly string initVector = "@1B2c3D4e5F6g7H8"; //must be 16 bytes
        static int keySize = 192;
        public string EncryptURL(string plainText)
        {
            try
            {
                byte[] initVectorBytes;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes;
                plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password;
                password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes;
                keyBytes = password.GetBytes((keySize / 8));
                RijndaelManaged symmetricKey;
                symmetricKey = new RijndaelManaged();
                symmetricKey.Padding = PaddingMode.Zeros;
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor;
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream;
                memoryStream = new MemoryStream();
                CryptoStream cryptoStream;
                cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();


                byte[] cipherTextBytes;
                cipherTextBytes = memoryStream.ToArray();

                cryptoStream.Close();
                memoryStream.Close();

                StringBuilder ret = new StringBuilder();

                byte[] b = cipherTextBytes;

                int I;
                for (I = 0; (I <= b.Length - 1); I++)
                {
                    ret.AppendFormat("{0:X2}", b[I]);
                }
                return ret.ToString();
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
        public UrlParametersDTO DecryptURL(string cipherText)
        {

            try
            {

                if (cipherText == String.Empty)
                {
                    return null;
                }



                byte[] initVectorBytes;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = new byte[Convert.ToInt32(cipherText.Length / 2)];
                int X;
                for (X = 0; (X <= (cipherTextBytes.Length - 1)); X++)
                {
                    Int32 IJ = Convert.ToInt32(cipherText.Substring((X * 2), 2), 16);
                    System.ComponentModel.ByteConverter BT = new System.ComponentModel.ByteConverter();
                    cipherTextBytes[X] = new byte();
                    cipherTextBytes[X] = ((byte)(BT.ConvertTo(IJ, typeof(byte))));
                }
                PasswordDeriveBytes password;
                password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes;
                keyBytes = password.GetBytes((keySize / 8));

                //  Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey;
                symmetricKey = new RijndaelManaged();
                symmetricKey.Padding = PaddingMode.Zeros;
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor;
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream;
                memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream;
                cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount;
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);


                StringBuilder ret = new StringBuilder();
                byte[] B = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                string format = plainText.TrimEnd("\0".ToCharArray());

                UrlParametersDTO urlParametersDTO = JsonConvert.DeserializeObject<UrlParametersDTO>(format);

                return urlParametersDTO;

            }
            catch (JsonReaderException) { return null; }
            catch (JsonSerializationException) { return null; }
            catch (JsonException ex) { return null; }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
