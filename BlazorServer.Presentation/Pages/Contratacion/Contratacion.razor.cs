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
        private bool isGuardarDisabled = true;
        private bool isAnularDisabled = true;
        private bool isNuevoDisabled = false;
        private bool isComponentConsulta = true;
        private bool isComponentAdd = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await obtenerParametrosUrl();
                await IsLoggedIn();
            }
        }
        public void BtnNuevoClick()
        {
            isGuardarDisabled = false;
            isAnularDisabled = false;
            isNuevoDisabled = true;
            isComponentConsulta = false;
            isComponentAdd = true;

        }

        private void BtnGuardarClick()
        {
            //convenioAdd.GuardarDatosBasicos();

        }

        private void BtnAnularClick()
        {
            LimpiarFormulario();
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

     

        private void LimpiarFormulario()
        {
            isGuardarDisabled = true;
            isAnularDisabled = true;
            isNuevoDisabled = false;
            isComponentConsulta = true;
            isComponentAdd = false;
        }

    

        private async Task EditarFormularioCliente(ConvenioDTO formCliente)
        {
            if (convenioAll != null)
            {
                BtnNuevoClick();
                await convenioAll.EditarFormularioCliente(formCliente);
            }

        }

    }
}
