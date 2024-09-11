using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using BlazorServer.Presentation.Shared.Contratacion;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorServer.Presentation.Pages.Contratacion
{
    public partial class Contratacion
    {
        [Parameter]
        public string? param { get; set; }

        private ConvenioAll convenioAll;

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


        private async Task EditarFormularioCliente(ConvenioDTO formCliente)
        {
            if (convenioAll != null)
            {
                await convenioAll.EditarFormularioCliente(formCliente);
            }

        }

        private async Task ConfigConvenio(ConvenioDTO formCliente)
        {
            if (convenioAll != null)
            {
                await convenioAll.ConfigConvenioRd(formCliente);
            }

        }

    }
}
