using BlazorServer.DataAccess.Models;
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

        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        private List<EntidadDto> listaEntidades = new List<EntidadDto>();
        private string NombreDocumento { get; set; }
        private string NombreEntidad { get; set; }
        private string identificacion;
        private long? documentoIdentidadID;
        private bool mostrarMensaje;
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private int tamañoPagina = 5; // Ajusta según el tamaño de la página deseado
        private List<Dato> _tiposDocumentos = new List<Dato>();
        private bool disabledTipoIdentidad;
        private long? ClassIds = null;
        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            _swaAlerts.ShowLoadingClose();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // El componente ha terminado de renderizarse
                await Task.Delay(500); // Opcional: Un breve retraso para asegurar que todo esté listo
            }
        }
        public async Task OnPageChanged(int pageNumber)
        {
            paginaActual = pageNumber;
            await CargarDatos();
        }
        public async Task CargarDatos(long? ClassId = null)
        {
            if (_tiposDocumentos == null || !_tiposDocumentos.Any())
            {
                _tiposDocumentos = await TablaDatoService.ObtenerDatosTablaAsync(13);
            }
            // Si se proporciona ClassId, busca el tipo de documento seleccionado
            if (ClassId != null)
            {
                ClassIds = ClassId;
                var documentoSeleccionado = _tiposDocumentos.FirstOrDefault(t => t.Id == 126);
                disabledTipoIdentidad = true;
                if (documentoSeleccionado != null)
                {
                    // Si hay un documento seleccionado, actualiza el ID del documento de identidad
                    documentoIdentidadID = documentoSeleccionado.Id;
                    
                }
            }

            // Realiza la consulta según si hay o no ClassId
            var resultado = ClassId == null
                ? await EntidadService.ObtenerEntidades(identificacion, documentoIdentidadID, paginaActual, tamañoPagina, Convert.ToInt64(urlParametersDTO.KeySession))
                : await EntidadService.ObtenerEntidades(identificacion, documentoIdentidadID, paginaActual, tamañoPagina, Convert.ToInt64(urlParametersDTO.KeySession), ClassId);

            // Actualiza las listas y el estado de la interfaz
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

        private async Task HandleSelectionChange(long? selectedId)
        {
            _swaAlerts.ShowLoading();
            if (selectedId != 0)
            {
                documentoIdentidadID = 0;
            }

            documentoIdentidadID = selectedId;
            await CargarDatos();
            _swaAlerts.ShowLoadingClose();
            StateHasChanged();
        }

        private async Task OnStringChanged(string newValue)
        {
            identificacion = newValue;
            await CargarDatos(ClassIds);
        }
    }
}
