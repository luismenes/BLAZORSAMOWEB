using BlazorServer.Business.BLL;
using BlazorServer.Business.Interfaces;
using BlazorServer.Common.Helpers;
using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BlazorServer.Presentation.Shared.Contratacion
{
    public partial class ConvenioAdd
    {

        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinue { get; set; }

        public CustomValidation? customValidation;
        // Referencias a los MudDatePicker
        private MudDatePicker _pickerInicioConvenio;
        private MudDatePicker _pickerFinConvenio;
        private MudDatePicker _pickerInicioPrestacion;
        private MudDatePicker _pickerFinPrestacion;
        public ConvenioDTO ConvenioModel = new ConvenioDTO();
        private List<Dato> _clasesJuridicas = new List<Dato>();
        private List<Dato> _regimenUsuario = new List<Dato>();
        private List<Dato> _Tipo = new List<Dato>();
        private List<Dato> _Origen = new List<Dato>();

        private bool expandPanel = false;

        protected override async Task OnInitializedAsync()
        {
            _swaAlerts.ShowLoading();
            await CargarSelectores();
            _swaAlerts.ShowLoadingClose();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // El componente ha terminado de renderizarse
                await Task.Delay(100); // Opcional: Un breve retraso para asegurar que todo esté listo
            }
        }

        private async Task CargarSelectores()
        {
            _clasesJuridicas = await TablaDatoService.ObtenerClaseEntidadesJuridicaAsync();
            _regimenUsuario = await TablaDatoService.ObtenerDatosTablaAsync(44);
            _Tipo = await TablaDatoService.ObtenerDatosTablaAsync(50);
            _Origen = await TablaDatoService.ObtenerDatosTablaAsync(51);
        }

        public void GuardarDatosBasicos()
        {
            ValidaForm();
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

        private async void ValidaForm()
        {
            _swaAlerts.ShowLoading();
            customValidation?.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if (ConvenioModel!.Nombre == null)
            {
                errors.Add(nameof(ConvenioModel.Nombre), new() { "Campo obligatorio" });
            }
            if (ConvenioModel!.Codigo == null)
            {
                errors.Add(nameof(ConvenioModel.Codigo), new() { "Campo obligatorio" });
            }
            if (ConvenioModel!.ClaseId == 0)
            {
                errors.Add(nameof(ConvenioModel.ClaseId), new() { "Campo obligatorio" });
            }
            if (ConvenioModel!.NombreEntidad == null)
            {
                errors.Add(nameof(ConvenioModel.NombreEntidad), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.TipoConvenioId == 0)
            {
                errors.Add(nameof(ConvenioModel.TipoConvenioId), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.OrigenConvenioId == 0)
            {
                errors.Add(nameof(ConvenioModel.OrigenConvenioId), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.TipoUserRegimen == 0)
            {
                errors.Add(nameof(ConvenioModel.TipoUserRegimen), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.FechaInicio == null)
            {
                errors.Add(nameof(ConvenioModel.FechaInicio), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.FechaPrestaInicio == null)
            {
                errors.Add(nameof(ConvenioModel.FechaPrestaInicio), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.FechaFin == null)
            {
                errors.Add(nameof(ConvenioModel.FechaFin), new() { "Campo obligatorio" });
            }

            if (ConvenioModel!.FechaPrestaFin == null)
            {
                errors.Add(nameof(ConvenioModel.FechaPrestaFin), new() { "Campo obligatorio" });
            }




            if (errors.Any())
            {
                //MensajeDeError("Información requerida.");
                customValidation?.DisplayErrors(errors);
                _swaAlerts.ShowLoadingClose();

            }
            else
            {

                ConvenioDTO clienteRequest = new ConvenioDTO();
                clienteRequest.Codigo = ConvenioModel.Codigo;
                clienteRequest.Nombre = ConvenioModel.Nombre;
                clienteRequest.NombreEntidad = ConvenioModel.NombreEntidad;
                clienteRequest.ClaseId = ConvenioModel.ClaseId;
                clienteRequest.CodigoEapb = ConvenioModel.CodigoEapb;
                clienteRequest.TipoConvenioId = ConvenioModel.TipoConvenioId;
                clienteRequest.OrigenConvenioId = ConvenioModel.OrigenConvenioId;
                clienteRequest.TipoUserRegimen = ConvenioModel.TipoUserRegimen;
                clienteRequest.PoblacionAtiende = ConvenioModel.PoblacionAtiende;
                clienteRequest.FechaInicio = ConvenioModel.FechaInicio;
                clienteRequest.FechaFin = ConvenioModel.FechaFin;
                clienteRequest.FechaPrestaInicio = ConvenioModel.FechaPrestaInicio;
                clienteRequest.FechaPrestaFin = ConvenioModel.FechaPrestaFin;
                clienteRequest.EsTodaSede = ConvenioModel.EsTodaSede;
                clienteRequest.EsConBeneficiarios = ConvenioModel.EsConBeneficiarios;
                clienteRequest.EsJustNoPos = ConvenioModel.EsJustNoPos;
                clienteRequest.OperacionId = Convert.ToInt64(urlParametersDTO.KeySession);
                clienteRequest.Estado = true;
                clienteRequest.FechaCreacion = DateTime.Now;
                clienteRequest.UsuarioId = Convert.ToInt64(urlParametersDTO.UserId);
                clienteRequest.EntidadId = ConvenioModel.EntidadId;

                _swaAlerts.ShowLoadingClose();
                await SetContinue.InvokeAsync(clienteRequest);

            }
            StateHasChanged();
            //await CancelProgress();
        }

        private async Task HandleSelectionChange(long selectedId)
        {
            _swaAlerts.ShowLoading();
            if (selectedId != 0)
            {
                ConvenioModel.EntidadId = 0;
                expandPanel = true;
                customValidation?.EliminarMensajeError(nameof(ConvenioModel.ClaseId));
            }
            else
            {
                expandPanel = false;
            }
            ConvenioModel.NombreEntidad = string.Empty;
            ConvenioModel.ClaseId = selectedId;

            _swaAlerts.ShowLoadingClose();
            StateHasChanged();
        }

        private async Task GuardarFormularioCliente(EntidadIdDTO formCliente)
        {
            ConvenioModel.EntidadId = formCliente.IdEntidad;

            var resultado = await EntidadService.ObtenerEntidad(ConvenioModel.EntidadId);

            if (resultado != null)
            {
                string NombreEntidad = resultado.TipoPersonaId == 134 ? resultado.NombreCompleto : resultado.RazonSocial;
                string NombreDocumento = (resultado.IdTipoIdentificacionNavigation.Nombre ?? string.Empty) + " - " +
                        (resultado.TipoPersonaId == 134 ? resultado.NumeroIdentificacion :
                        $"{resultado.NumeroIdentificacion} - {resultado.DigitoVerificacion}");

                ConvenioModel.NombreEntidad = NombreDocumento + " " + NombreEntidad;

            }
        }

        public void LimpiarFormulario()
        {
            ConvenioModel = new ConvenioDTO();
            expandPanel = false;
            customValidation?.ClearErrors();
        }


        public async Task AsignarValoresConvenio(ConvenioDTO convenio)
        {
            LimpiarFormulario();
            // Asignar valores a las propiedades del componente
            ConvenioModel.Nombre = convenio.Nombre;
            ConvenioModel.Codigo = convenio.Codigo;
            ConvenioModel.TipoConvenioId = convenio.TipoConvenioId; // Si TipoConvenioId es nullable
            ConvenioModel.ClaseId = convenio.ClaseId;
            ConvenioModel.EntidadId = convenio.EntidadId;
            ConvenioModel.CodigoEapb = convenio.CodigoEapb;
            ConvenioModel.OrigenConvenioId = convenio.OrigenConvenioId;
            ConvenioModel.TipoUserRegimen = convenio.TipoUserRegimen;
            ConvenioModel.PoblacionAtiende = convenio.PoblacionAtiende;
            ConvenioModel.FechaInicio = convenio.FechaInicio;
            ConvenioModel.FechaFin = convenio.FechaFin;
            ConvenioModel.FechaPrestaInicio = convenio.FechaPrestaInicio;
            ConvenioModel.FechaPrestaFin = convenio.FechaPrestaFin;
            ConvenioModel.EsTodaSede = convenio.EsTodaSede;
            ConvenioModel.EsConBeneficiarios = convenio.EsConBeneficiarios;
            ConvenioModel.EsJustNoPos = convenio.EsJustNoPos;
            ConvenioModel.Id = convenio.Id;

            IEntidadSamo EntidadService = new EntidadSamo();
            var resultado = await EntidadService.ObtenerEntidad(convenio.EntidadId);

            if (resultado != null)
            {
                string NombreEntidad = resultado.TipoPersonaId == 134 ? resultado.NombreCompleto : resultado.RazonSocial;
                string NombreDocumento = (resultado.IdTipoIdentificacionNavigation.Nombre ?? string.Empty) + " - " +
                        (resultado.TipoPersonaId == 134 ? resultado.NumeroIdentificacion :
                        $"{resultado.NumeroIdentificacion} - {resultado.DigitoVerificacion}");

                ConvenioModel.NombreEntidad = NombreDocumento + " " + NombreEntidad;

            }
            StateHasChanged();

        }
    }
}
