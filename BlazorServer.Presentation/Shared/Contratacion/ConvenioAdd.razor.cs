using BlazorServer.DTO.Request;
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

        private string codigoGeneral;
        private string nombreGeneral;
        private string paisGeneral;
        private string claseGeneral;
        private string buscarTercero;
        private string nombreTercero;
        private string codigoRips;
        private string tipoGeneral;
        private string origenGeneral;
        private string tipoRegimen;
        private string poblacionAtender;
        private DateTime? fechaInicioConvenio;
        private DateTime? fechaFinConvenio;
        private DateTime? fechaInicioPrestacion;
        private DateTime? fechaFinPrestacion;
        private bool todasLasSedes;
        private bool aceptaBeneficiarios;
        private bool activo = true;
        private bool justificacionNoPos;

        private bool expandPanel = false;

        private List<Tercero> terceros; // Asume que tienes una lista de terceros
        private Tercero selectedTercero; // Asume que tienes un objeto tercero seleccionado

        private void BuscarTercero()
        {
            // Lógica para buscar terceros
            expandPanel = true;
        }


        private void GuardarDatosBasicos()
        {
            // Lógica para guardar datos
        }

        // Clase de ejemplo para Tercero
        public class Tercero
        {
            public string NombreCompleto { get; set; }
            public string NumeroIdentificacion { get; set; }
            public string CodigoRips { get; set; }
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
