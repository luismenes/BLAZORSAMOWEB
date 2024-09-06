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

        private ConvenioAdd convenioAdd;
        private RequestContratacion model { get; set; } = new RequestContratacion();

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
            convenioAdd.GuardarDatosBasicos();

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

        private async Task GuardarFormularioCliente(ConvenioDTO formCliente)
        {
            try
            {
                model.Datos = formCliente;
                var guardarExitoso = await GuardarConvenio(formCliente);
                if (guardarExitoso)
                {
                    LimpiarFormulario();
                    await MostrarMensajeExitoso("El formulario se guardó correctamente.");
                }
                else
                {
                    await MostrarMensajeError("No fue posible realizar el registro del formulario.");
                }
            }
            catch (Exception ex)
            {
                await MostrarMensajeError($"Ocurrió un error: {ex.Message}");
            }

            StateHasChanged();
        }

        private async Task<bool> GuardarConvenio(ConvenioDTO formCliente)
        {
            return await _ConveniosSAMService.SaveManagement(formCliente);
        }

        private void LimpiarFormulario()
        {
            convenioAdd.LimpiarFormulario();
        }

        private async Task MostrarMensajeExitoso(string mensaje)
        {
            var options = new
            {
                title = mensaje,
                icon = "success",
                confirmButtonText = "Entendido",
                confirmButtonColor = "#28a745", // Verde para mensajes de éxito
                customClass = new
                {
                    confirmButton = "btn-success"
                }
            };

            await JSRuntime.InvokeVoidAsync("Swal.fire", options);
        }

        private async Task MostrarMensajeError(string mensaje)
        {
            var options = new
            {
                title = mensaje,
                icon = "error",
                confirmButtonText = "Entendido",
                confirmButtonColor = "#d33", // Rojo para mensajes de error
                customClass = new
                {
                    confirmButton = "btn-danger"
                }
            };

            await JSRuntime.InvokeVoidAsync("Swal.fire", options);
        }

    }
}
