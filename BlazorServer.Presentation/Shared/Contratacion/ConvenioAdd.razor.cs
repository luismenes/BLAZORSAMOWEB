using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.Presentation.Shared.Contratacion
{
    public partial class ConvenioAdd
    {
        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        // Referencias a los MudDatePicker
        private MudDatePicker _pickerInicioConvenio;
        private MudDatePicker _pickerFinConvenio;
        private MudDatePicker _pickerInicioPrestacion;
        private MudDatePicker _pickerFinPrestacion;
        public ConvenioDTO ConvenioModel = new ConvenioDTO();
        private List<Dato> _clasesJuridicas = new List<Dato>();

        private bool expandPanel = true;
        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            await CargarSelectores();
            _swaAlerts.ShowLoadingClose();
        }

        private async Task CargarSelectores()
        {
            _clasesJuridicas = await TablaDatoService.ObtenerClaseEntidadesJuridicaAsync();
        }

        private void GuardarDatosBasicos()
        {
            // Lógica para guardar datos
        }

        // Métodos para manejar las acciones de los MudDatePicker
        Task ClearPicker(MudDatePicker picker)
        {
            picker.Clear();
            return Task.CompletedTask;
        }

        Task CancelPicker(MudDatePicker picker)
        {
            picker.Close(false);
            return Task.CompletedTask;
        }

        Task OkPicker(MudDatePicker picker)
        {
            picker.Close();
            return Task.CompletedTask;
        }

    }
}
