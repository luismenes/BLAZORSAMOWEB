using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorServer.Presentation.Shared.Contratacion
{

    public partial class ConvenioConfig
    {
        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinueConfig { get; set; }
        private bool showForm1 = false;
        private bool showForm2 = false;
        private bool showForm3 = false;
        private bool showForm4 = false;
        private bool showForm5 = false;
        private bool showForm6 = false;
        private bool showForm7 = false;
        private IEnumerable<SedeConvenioDTO> listaSedeConvenioDTO = new List<SedeConvenioDTO>();
        public ConvenioDTO ConvenioModel = new ConvenioDTO();
        private string searchString = "";
        private SedeConvenioDTO selectedItem = null;
        private bool dense = true;
      

        private async Task ToggleForm(int formNumber)
        {
            showForm1 = formNumber == 1;
            showForm2 = formNumber == 2;
            showForm3 = formNumber == 3;
            showForm4 = formNumber == 4;
            showForm5 = formNumber == 5;
            showForm6 = formNumber == 6;
            showForm7 = formNumber == 7;

            if (showForm1)
            {
                await CargarDatosSedesConvenio(ConvenioModel.Id);
            }
            StateHasChanged();
        }

        private string GetEstado(bool activo)
        {
            return activo ? "✔️" : "🛑";
        }

        private async Task CambiarEstado(long id)
        {
            bool confirmacion = await MostrarConfirmacion("Esta segur@ que requiere cambiar el estado?");

            if (confirmacion)
            {

                bool resultado = await _ConveniosSAMService.ActivarSede(ConvenioModel.Id, id, Convert.ToInt64(AuthorizationService.UrlParametersDTO.UserId));

                if (resultado)
                {
                    ToastService.ShowSuccess("Sede configurada!");

                }
                else
                {
                    ToastService.ShowError("Sede desactivada!");

                }
                StateHasChanged();
                await CargarDatosSedesConvenio(ConvenioModel.Id);
            }
        }

        private async Task CargarDatosSedesConvenio(long ConvenioId)
        {
            var resultado = await _ConveniosSAMService.ObtenerSedes(ConvenioId);
            listaSedeConvenioDTO = (await _ConveniosSAMService.ObtenerSedes(ConvenioId))?.ToList() ?? new List<SedeConvenioDTO>();
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

        private bool FilterFunc(SedeConvenioDTO entidad)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (entidad.NombreSede.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            string estado = GetEstado((bool)entidad.Activo);
            if (estado.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (entidad.SedeId.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        
    }
}
