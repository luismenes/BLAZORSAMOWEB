using static BlazorServer.Business.BLL.EntidadSamo;

namespace BlazorServer.Presentation.Shared.GlobalesComponet
{
    public partial class EntidadesRedis
    {
        private List<EntidadDto> listaEntidades = new List<EntidadDto>();
        private string identificacion;
        private long? documentoIdentidadID;
        private bool mostrarMensaje;
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private int tamañoPagina = 5; // Ajusta según el tamaño de la página deseado
    
        protected override async Task OnInitializedAsync()
        {
            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            var resultado = await EntidadService.ObtenerEntidades(identificacion, documentoIdentidadID, paginaActual, tamañoPagina);
            listaEntidades = resultado.Elementos;
            totalPaginas = resultado.TotalPaginas;
            mostrarMensaje = listaEntidades.Count == 0;
        }


        private async Task Filtrar()
        {
            paginaActual = 1; // Reiniciar a la primera página al filtrar
            await CargarDatos();
        }

        private void LimpiarCampos()
        {
            identificacion = string.Empty;
            documentoIdentidadID = null;
            paginaActual = 1; // Reiniciar a la primera página al limpiar
        }
        private async void OnPageChanged(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > totalPaginas) return;
            paginaActual = pageNumber;
            await CargarDatos();
        }

        private void CargarDatosEntidad(long id)
        {
            // Implementar lógica para cargar los datos de la entidad seleccionada
        }
    }
}
