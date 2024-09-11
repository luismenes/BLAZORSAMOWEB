using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using BlazorServer.Presentation.Shared.GlobalesComponet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static BlazorServer.Business.BLL.Contratacion.ConveniosSAM;

namespace BlazorServer.Presentation.Shared.Contratacion
{
    public partial class ConvenioAll
    {
        private RequestContratacion model { get; set; } = new RequestContratacion();

        [Parameter]
        public EventCallback<ConvenioDTO> SetContinue { get; set; }
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinueConfig { get; set; }
        private List<ConveDto> listaConvenios = new List<ConveDto>();
        private ConvenioAdd convenioAdd;

        private string nombreConvenio;
        private long tipoConvenio;
        private bool mostrarMensaje = false;
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int tamañoPagina = 10;
        private bool isGuardarDisabled = true;
        private bool isAnularDisabled = true;
        private bool isNuevoDisabled = false;
        private bool isComponentConsulta = true;
        private bool isComponentAdd = false;
        private bool isComponentConfig = false;
        private List<Dato> _tipoConvenios = new List<Dato>();

        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            await CargarSelectores();
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();
        }
        private async Task CargarSelectores()
        {

            _tipoConvenios = await TablaDatoService.ObtenerDatosTablaAsync(50);
        }
        public void BtnNuevoClick()
        {
            isGuardarDisabled = false;
            isAnularDisabled = false;
            isNuevoDisabled = true;
            isComponentConsulta = false;
            isComponentAdd = true;
            isComponentConfig = false;

        }

        private void BtnGuardarClick()
        {
            convenioAdd.GuardarDatosBasicos();

        }

        private void BtnAnularClick()
        {
            LimpiarFormulario();
        }


        private void LimpiarFormulario()
        {
            if (convenioAdd != null)
            {

                convenioAdd.LimpiarFormulario();
            }
            isGuardarDisabled = true;
            isAnularDisabled = true;
            isNuevoDisabled = false;
            isComponentConsulta = true;
            isComponentAdd = false;
            isComponentConfig = false;

        }

        private async Task Filtrar()
        {
            paginaActual = 1; // Reiniciar a la primera página al filtrar
            await CargarDatos();
        }

        private void LimpiarCampos()
        {
            nombreConvenio = string.Empty;
            tipoConvenio = 0;

        }

        public async Task OnPageChanged(int pageNumber)
        {
            paginaActual = pageNumber;
            await CargarDatos();
        }

        private async Task EditarConvenioAsync(long id)
        {

            var resultado = await _ConveniosSAMService.EditarConvenio(id);
            await SetContinue.InvokeAsync(resultado);


        }

        private async Task CargarDatos()
        {
            var resultado = await _ConveniosSAMService.ObtenerConvenios(nombreConvenio, tipoConvenio, paginaActual, tamañoPagina, Convert.ToInt64(AuthorizationService.UrlParametersDTO.KeySession));
            listaConvenios = resultado.Elementos;
            totalPaginas = resultado.TotalPaginas;
            mostrarMensaje = listaConvenios.Count == 0;
            StateHasChanged();
        }

        private string GetEstado(bool activo)
        {
            return activo ? "Activo" : "Inactivo";
        }

        private async Task CambiarEstado(long id)
        {
            bool confirmacion = await MostrarConfirmacion("Esta segur@ que requiere cambiar el estado?");

            if (confirmacion)
            {

                bool resultado = await _ConveniosSAMService.CambiarEstadoConvenio(id, Convert.ToInt64(AuthorizationService.UrlParametersDTO.UserId));

                if (resultado)
                {
                    // Mostrar un mensaje de éxito
                    await MostrarMensajeExitoso("El estado del convenio ha sido cambiado exitosamente.");
                }
                await CargarDatos();
            }
        }

        private async Task OnNombreConvenioChanged(string newValue)
        {
            nombreConvenio = newValue;
            await CargarDatos();
        }

        public async Task EditarFormularioCliente(ConvenioDTO formCliente)
        {
            BtnNuevoClick();
            StateHasChanged(); // Forzar la actualización de la UI

            await Task.Delay(100); // Esperar a que los componentes se rendericen completamente
            if (convenioAdd != null)
            {
                await convenioAdd.AsignarValoresConvenio(formCliente);
            }

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
                    await CargarDatos();
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
            if (formCliente.Id != 0)
            {
                return await _ConveniosSAMService.UpdateManagement(formCliente);

            }
            else
            {

                return await _ConveniosSAMService.SaveManagement(formCliente);
            }
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

        public async Task<bool> MostrarConfirmacion(string mensaje)
        {
            var options = new
            {
                title = mensaje,
                icon = "warning",
                showCancelButton = true,
                confirmButtonText = "Sí, cambiar estado",
                cancelButtonText = "Cancelar",
                confirmButtonColor = "#d33", // Rojo para el botón de confirmación
                cancelButtonColor = "#3085d6" // Azul para el botón de cancelar
            };

            // La llamada a InvokeAsync debería recibir el tipo adecuado, que es un booleano
            var result = await JSRuntime.InvokeAsync<bool>("mostrarConfirmacion", options);

            return result; // Devuelve true si el usuario confirma la acción
        }

        private async Task HandleSelectionChange(long selectedId)
        {
            _swaAlerts.ShowLoading();
            if (selectedId != 0)
            {
                tipoConvenio = 0;
            }

            tipoConvenio = selectedId;
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();
            StateHasChanged();
        }

        private async Task ConfigConvenioAsync(long id)
        {

            var resultado = await _ConveniosSAMService.EditarConvenio(id);
            await SetContinueConfig.InvokeAsync(resultado);


        }

        public async Task ConfigConvenioRd(ConvenioDTO formCliente)
        {
            BtnConfigConvenio();
            StateHasChanged();

        }

        public void BtnConfigConvenio()
        {
            isGuardarDisabled = false;
            isAnularDisabled = false;
            isNuevoDisabled = true;
            isComponentConsulta = false;
            isComponentAdd = false;
            isComponentConfig = true;

        }
    }
}
