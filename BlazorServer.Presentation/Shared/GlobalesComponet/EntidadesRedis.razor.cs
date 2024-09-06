using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using static BlazorServer.Business.BLL.EntidadSamo;

namespace BlazorServer.Presentation.Shared.GlobalesComponet
{
    public partial class EntidadesRedis
    {
        [Parameter]
        public EventCallback<EntidadIdDTO> SetContinue { get; set; }
        private List<EntidadDto> listaEntidades = new List<EntidadDto>();
        private string NombreDocumento { get; set; }
        private string NombreEntidad { get; set; }
        private string identificacion;
        private long? documentoIdentidadID;
        private bool mostrarMensaje;
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private int tamañoPagina = 5; // Ajusta según el tamaño de la página deseado

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
            var resultado = await EntidadService.ObtenerEntidades(identificacion, documentoIdentidadID, paginaActual, tamañoPagina);
            listaEntidades = resultado.Elementos;
            totalPaginas = resultado.TotalPaginas;
            mostrarMensaje = listaEntidades.Count == 0;
            limpiarCampos();
            StateHasChanged();
        }


        private async Task Filtrar()
        {
            paginaActual = 1; // Reiniciar a la primera página al filtrar
            await CargarDatos();
        }

        private async Task LimpiarCampos()
        {
            identificacion = string.Empty;
            documentoIdentidadID = null;
            paginaActual = 1; // Reiniciar a la primera página al limpiar
            await CargarDatos();
            

        }


        private void CargarDatosEntidad(long id)
        {
            cargarDatos(id);
        }

        public async void cargarDatos(long EntidadId)
        {
            limpiarCampos();
            var resultado = await EntidadService.ObtenerEntidad(EntidadId);

            if (resultado != null)
            {
                NombreEntidad = resultado.TipoPersonaId == 134 ? resultado.NombreCompleto : resultado.RazonSocial;
                NombreDocumento = (resultado.IdTipoIdentificacionNavigation.Nombre ?? string.Empty) + " - " +
                        (resultado.TipoPersonaId == 134 ? resultado.NumeroIdentificacion :
                        $"{resultado.NumeroIdentificacion} - {resultado.DigitoVerificacion}");

                EntidadIdDTO clienteRequest = new EntidadIdDTO();
                clienteRequest.IdEntidad = resultado.Id;
               

                _swaAlerts.ShowLoadingClose();
                await SetContinue.InvokeAsync(clienteRequest);
            }
            StateHasChanged();

        }

        private void limpiarCampos()
        {
            NombreDocumento = "";
            NombreEntidad = "";
            
        }
    }
}
