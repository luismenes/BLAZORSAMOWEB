using static BlazorServer.Business.BLL.ProcedimientoSamo;

namespace BlazorServer.Presentation.Shared.GlobalesComponet
{
    public partial class ProcedimientosRedis
    {
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
            //bool confirmacion = await MostrarConfirmacion("Esta segur@ que requiere cambiar el estado?");

            //if (confirmacion)
            //{

            //    bool resultado = await _ConveniosSAMService.CambiarEstadoConvenio(id, Convert.ToInt64(AuthorizationService.UrlParametersDTO.UserId));

            //    if (resultado)
            //    {
            //        // Mostrar un mensaje de éxito
            //        await MostrarMensajeExitoso("El estado del convenio ha sido cambiado exitosamente.");
            //    }
            //    await CargarDatos();
            //}
        }
    }
}
