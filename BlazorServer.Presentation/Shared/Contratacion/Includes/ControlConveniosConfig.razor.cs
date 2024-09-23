using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using BlazorServer.Presentation.Shared.GlobalesComponet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static BlazorServer.Business.BLL.ProcedimientoSamo;

namespace BlazorServer.Presentation.Shared.Contratacion.Includes
{
    public partial class ControlConveniosConfig
    {
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinueControlConveniosConfig { get; set; }
        [Parameter]
        public ConvenioDTO Model { get; set; }

        private int selectedTab = 0;
        private int innerTabFrecuenciaOption = 1; // Default to "Procedimiento" for "Frecuencia"
        private int innerTabAutorizacionesOption = 1; // Default to "Procedimiento" for "Autorizaciones"
        private bool isAnularDisabledProceFrecuencia = true;
        private bool isNuevoDisabledProceFrecuencia = false;
        private bool isComponentConsultaProceFrecuencia = true;
        private bool isComponentAddProceFrecuencia = false;
        public ConvenioDTO ConvenioModel = new ConvenioDTO();
        private IEnumerable<ProcedimientoDto> listaProceFrecuenciaDTO = new List<ProcedimientoDto>();
        private string searchString = "";
        private ProcedimientoDto selectedItem = null;
        private bool dense = true;
        private ProcedimientosRedis procedimientosRedis;

        //protected override async Task OnInitializedAsync()
        //{
        //    _swaAlerts.ShowLoading();
        //    await SetContinueControlConveniosConfig.InvokeAsync(ConvenioModel);
        //    _swaAlerts.ShowLoadingClose();
        //}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // El componente ha terminado de renderizarse
                await Task.Delay(100); // Opcional: Un breve retraso para asegurar que todo esté listo
            }
        }

        private async Task SaveSelectedTab(int index)
        {
            // Save the selected tab index to local storage
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "selectedTab", index.ToString());
        }

        public void SetInnerTabFrecuencia(int tab)
        {
            innerTabFrecuenciaOption = tab;
            Model.TipoControl = (long)ConfigurationKeys.TipoControl.Frecuencia;
            CargarProcedimiento(Model.Id, Model.TipoControl);
            SetContinueControlConveniosConfig.InvokeAsync(ConvenioModel);

        }

        private void SetInnerTabAutorizaciones(int tab)
        {
            innerTabAutorizacionesOption = tab;
            Model.TipoControl = (long)ConfigurationKeys.TipoControl.Autorizaciones;
            CargarProcedimiento(Model.Id, Model.TipoControl);
            SetContinueControlConveniosConfig.InvokeAsync(ConvenioModel);

        }

        public void BtnProceFrecuenciaNuevoClick()
        {

            isAnularDisabledProceFrecuencia = false;
            isNuevoDisabledProceFrecuencia = true;
            isComponentConsultaProceFrecuencia = false;
            isComponentAddProceFrecuencia = true;

        }



        private void BtnProceFrecuenciaAnularClick()
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {

            isAnularDisabledProceFrecuencia = true;
            isNuevoDisabledProceFrecuencia = false;
            isComponentConsultaProceFrecuencia = true;
            isComponentAddProceFrecuencia = false;

        }

        private string GetEstado(bool activo)
        {
            return activo ? "✔️" : "🛑";
        }

        private bool FilterFunc(ProcedimientoDto entidad)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (entidad.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            string estado = GetEstado((bool)entidad.Activo);
            if (estado.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (entidad.Tipo.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private async Task CambiarEstadoProceFrecuencia(long id)
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

        public async Task CargarProcedimiento(long ConvenioId, long tipo)
        {
            listaProceFrecuenciaDTO = (await _ConveniosSAMService.ObtenerProcedimientoFrecuencia(ConvenioId, tipo))?.ToList() ?? new List<ProcedimientoDto>();
            StateHasChanged();
        }

        private async Task GuardarFormularioCliente(ProcedimientoDto formCliente)
        {
            StateHasChanged();
            Model.ProcedimientoId = formCliente.Id;

            await _ConveniosSAMService.ActivarProcedimiento(Model.Id, Model.TipoControl, (long)Model.ProcedimientoId);

            if (Model.TipoControl == (long)ConfigurationKeys.TipoControl.Frecuencia)
            {
                SetInnerTabFrecuencia(innerTabFrecuenciaOption);
            }
            else if (Model.TipoControl == (long)ConfigurationKeys.TipoControl.Autorizaciones)
            {
                SetInnerTabAutorizaciones(innerTabAutorizacionesOption);
            }
        }


    }
}
