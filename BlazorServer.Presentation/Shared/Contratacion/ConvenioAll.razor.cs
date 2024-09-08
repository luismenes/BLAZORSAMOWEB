using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static BlazorServer.Business.BLL.Contratacion.ConveniosSAM;

namespace BlazorServer.Presentation.Shared.Contratacion
{
    public partial class ConvenioAll
    {
        private RequestContratacion model { get; set; } = new RequestContratacion();

        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinue { get; set; }
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

        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();
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
            convenioAdd.GuardarDatosBasicos();

        }

        private void BtnAnularClick()
        {
            LimpiarFormulario();
        }


        private void LimpiarFormulario()
        {
            convenioAdd.LimpiarFormulario();
            isGuardarDisabled = true;
            isAnularDisabled = true;
            isNuevoDisabled = false;
            isComponentConsulta = true;
            isComponentAdd = false;
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

            var resultado = await ConveniosSAMService.EditarConvenio(id);
            await SetContinue.InvokeAsync(resultado);


        }

        private async Task CargarDatos()
        {
            var resultado = await ConveniosSAMService.ObtenerConvenios(nombreConvenio, tipoConvenio, paginaActual, tamañoPagina, Convert.ToInt64(urlParametersDTO.KeySession));
            listaConvenios = resultado.Elementos;
            totalPaginas = resultado.TotalPaginas;
            mostrarMensaje = listaConvenios.Count == 0;
            StateHasChanged();
        }

        private string GetEstado(bool activo)
        {
            return activo ? "Activo" : "Inactivo";
        }

        private void CambiarEstado(long id)
        {
            // Lógica para cambiar el estado del convenio (Activo/Inactivo)
        }

        private void OnInputHandler(ChangeEventArgs e)
        {
            nombreConvenio = e.Value.ToString();
            Filtrar();
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
