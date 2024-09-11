using BlazorServer.DTO.Request;
using BlazorServer.DTO.Request.Contratacion;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Presentation.Shared.Contratacion
{
   
    public partial class ConvenioConfig
    {
        [Parameter]
        public UrlParametersDTO urlParametersDTO { get; set; }
        [Parameter]
        public EventCallback<ConvenioDTO> SetContinue { get; set; }
        private bool showForm1 = false;
        private bool showForm2 = false;
        private bool showForm3 = false;
        private bool showForm4 = false;

        private void ToggleForm(int formNumber)
        {
            showForm1 = formNumber == 1;
            showForm2 = formNumber == 2;
            showForm3 = formNumber == 3;
            showForm4 = formNumber == 4;
            StateHasChanged();

        }
    }
}
