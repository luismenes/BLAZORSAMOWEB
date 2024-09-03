using BlazorServer.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.Interfaces.EncryDecrypt
{
    public interface IEncryDecrypt
    {
        string EncryptURL(string input);
        UrlParametersDTO DecryptURL(string input);
    }
}
