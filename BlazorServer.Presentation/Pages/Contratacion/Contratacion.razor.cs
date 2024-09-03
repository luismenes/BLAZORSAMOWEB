using BlazorServer.DTO.Request;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Presentation.Pages.Contratacion
{
    public partial class Contratacion
    {
        [Parameter]
        public string? param { get; set; }


        private UrlParametersDTO urlParametersDTO { get; set; } = new UrlParametersDTO();
        private bool? isAuthorized = null;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await obtenerParametrosUrl();
                await IsLoggedIn();
            }
        }
        private void BtnNuevoClick()
        {
            // Acción para el botón Nuevo
        }

        private void BtnGuardarClick()
        {
            // Acción para el botón Guardar
        }

        private void BtnAnularClick()
        {
            // Acción para el botón Anular
        }

        private async Task obtenerParametrosUrl()
        {

            if (string.IsNullOrWhiteSpace(param))
            {
                StateHasChanged();
                return;
            }
            urlParametersDTO = _EncryDecrypt.DecryptURL(param);

            StateHasChanged();
        }
        private async Task IsLoggedIn()
        {
            isAuthorized = false;
            if (urlParametersDTO != null && !string.IsNullOrEmpty(urlParametersDTO.KeySession))
            {
                isAuthorized = await _User.IsLoggedIn(urlParametersDTO.UserId, urlParametersDTO.KeySession);
            }

            StateHasChanged();
        }
    }
}
