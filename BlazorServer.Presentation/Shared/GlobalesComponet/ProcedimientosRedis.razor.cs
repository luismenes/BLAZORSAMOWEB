using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static BlazorServer.Business.BLL.ProcedimientoSamo;

namespace BlazorServer.Presentation.Shared.GlobalesComponet
{
    public partial class ProcedimientosRedis
    {
        [Parameter]
        public EventCallback<ProcedimientoDto> SetContinue { get; set; }

        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int tamañoPagina = 10;
        private List<ProcedimientoDto> listaProcedimientoDto = new List<ProcedimientoDto>();
        private bool mostrarMensaje = false;
        private string codigo;
        private string nombre;

        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();
        }
        public async Task OnPageChanged(int pageNumber)
        {
            paginaActual = pageNumber;
            await CargarDatos();
        }
        private async Task CargarDatos()
        {
            var resultado = await _IProcedimientoSamo.ObtenerProcedimeintos(codigo, nombre, paginaActual, tamañoPagina);
            listaProcedimientoDto = resultado.Elementos;
            totalPaginas = resultado.TotalPaginas;
            mostrarMensaje = listaProcedimientoDto.Count == 0;
            StateHasChanged();
        }

        private async Task OnStringChanged(string newValue)
        {
            _swaAlerts.ShowLoading();
            codigo = newValue;
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();

        }

        private async Task OnStringChanged2(string newValue)
        {
            _swaAlerts.ShowLoading();
            nombre = newValue;
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();

        }

        private async Task AsignarProcedimiento(long id)
        {
            bool confirmacion = await MostrarConfirmacion("Esta segur@ que requiere asignar el procedimiento?");

            if (confirmacion)
            {

                cargarDatos(id);
                await MostrarMensajeExitoso("El procedimiento ha sido asignado exitosamente.");

                await CargarDatos();
            }
        }

        public async void cargarDatos(long Id)
        {
            
            var resultado = await _IProcedimientoSamo.ObtenerProcedimeinto(Id);

            if (resultado != null)
            {


                ProcedimientoDto clienteRequest = new ProcedimientoDto();
                clienteRequest.Id = resultado.Id;


                _swaAlerts.ShowLoadingClose();
                await SetContinue.InvokeAsync(clienteRequest);
            }
            StateHasChanged();

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

    }
}
