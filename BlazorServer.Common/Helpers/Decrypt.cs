using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Common.Helpers
{
    public static class Decrypt
    {
        public static string DecryptCitaURL(string textoEncriptado)
        {
            string clave = "CitaClave123";
            // Convertir el texto encriptado de Base64 a bytes
            byte[] textoBytes = Convert.FromBase64String(textoEncriptado);
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);

            // Realizar la operación XOR inversa para desencriptar
            for (int i = 0; i < textoBytes.Length; i++)
            {
                textoBytes[i] ^= claveBytes[i % claveBytes.Length];
            }

            // Convertir los bytes resultantes de nuevo a una cadena
            string textoDesencriptado = Encoding.UTF8.GetString(textoBytes);

            
            return textoDesencriptado;
        }
    }
}
