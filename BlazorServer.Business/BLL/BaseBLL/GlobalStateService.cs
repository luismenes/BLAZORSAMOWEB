using BlazorServer.Business.Interfaces;
using BlazorServer.Business.Interfaces.EncryDecrypt;
using BlazorServer.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL.BaseBLL
{
    public class GlobalStateService
    {
        private readonly IEncryDecrypt _encryDecrypt;
        private readonly IUser _user;
        public UrlParametersDTO UrlParametersDTO { get; private set; }
        public bool? IsAuthorized { get; private set; }

        public event Action OnChange;

        public GlobalStateService(IEncryDecrypt encryDecrypt, IUser user)
        {
            _encryDecrypt = encryDecrypt;
            _user = user;
        }

        public async Task SetUrlParameters(string? encryptedParam)
        {
            if (!string.IsNullOrWhiteSpace(encryptedParam))
            {
                UrlParametersDTO = _encryDecrypt.DecryptURL(encryptedParam);
                await ValidateAuthorization();
            }
            else
            {
                UrlParametersDTO = null;
                IsAuthorized = false;
            }

            NotifyStateChanged();
        }

        public async Task ValidateAuthorization()
        {
            if (UrlParametersDTO != null && !string.IsNullOrEmpty(UrlParametersDTO.KeySession))
            {
                IsAuthorized = await _user.IsLoggedIn(UrlParametersDTO.UserId, UrlParametersDTO.KeySession);
            }
            else
            {
                IsAuthorized = false;
            }

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
