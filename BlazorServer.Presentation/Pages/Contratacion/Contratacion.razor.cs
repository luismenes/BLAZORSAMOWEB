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

        private void BtnBuscarClick()
        {
            // Acción para el botón Buscar
        }
    }
}
