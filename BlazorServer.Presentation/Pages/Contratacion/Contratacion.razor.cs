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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                urlParametersDTO = AuthorizationService.UrlParametersDTO;

            }
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
