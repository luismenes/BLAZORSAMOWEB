using CurrieTechnologies.Razor.SweetAlert2;
using System.Drawing;
using static BlazorServer.Common.Helpers.SweetAlert.SweetAlertClasses;

namespace BlazorServer.Common.Helpers.SweetAlert
{
    public class SwaAlerts
    {

        private readonly SweetAlertService _sweetAlertService;

        public SwaAlerts(SweetAlertService sweetAlertService)
        {
            _sweetAlertService = sweetAlertService;
        }

        public async Task<SweetAlertResult> ShowWarningAlertWithImage(ShowErrorAlertWithImageclass showErrorAlertWithImageclass)
        {
            return await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = showErrorAlertWithImageclass.Title,
                Text = showErrorAlertWithImageclass.Mensaje,
                ImageUrl = showErrorAlertWithImageclass.ImageUrl,
                ImageHeight = showErrorAlertWithImageclass.ImageHeight,
                ImageWidth = showErrorAlertWithImageclass.ImageWidth,
                ShowCancelButton = showErrorAlertWithImageclass.ShowCancelButton,
                ConfirmButtonText = showErrorAlertWithImageclass.ConfirmButtonText,
                ConfirmButtonColor = showErrorAlertWithImageclass.ConfirmButtonColor
            });
        }

        public async Task<SweetAlertResult> ShowWarningAlertWithIcon(string title, string mensaje)
        {
            return await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Warning,
                //IconColor = SweetAlertIcon.iconc,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            });
        }

        public async Task<SweetAlertResult> ShowWarningAlertWithIconNoAction(string title, string mensaje)
        {
            return await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Warning,
                //IconColor = showWarningAlertWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            });
        }

        public async Task<SweetAlertResult> ShowWarningErrorWithIcon(string title, string mensaje)
        {
            return await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Error,
                //IconColor = showWarningAlertWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            });
        }

        public void ShowSuccesssTopEnd(string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Position = "top-end",
                Title = mensaje,
                Icon = SweetAlertIcon.Success,
                ShowConfirmButton = false,
                Timer = 1500
            });
        }

        public async Task<SweetAlertResult> ShowSuccesssWithIcon(string title, string mensaje)
        {
            return await _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Success,
                //IconColor = showSuccessWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            });
        }
        public void ShowSuccesssWithIcon(string title, string mensaje, Action<bool> onConfirm)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Success,
                //IconColor = showSuccessWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            }).ContinueWith(result =>
            {
                bool confirmed = result.Result.IsConfirmed;
                onConfirm?.Invoke(confirmed);
            });
        }
        public void ShowInfoWithIcon(string title, string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Info,
                //IconColor = ,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#dc3545"
            });
        }

        public void ShowWarningAlertWithImageInformative(ShowErrorAlertWithImageInformativeclass showErrorAlertWithImageclass)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = showErrorAlertWithImageclass.Title,
                Text = showErrorAlertWithImageclass.Mensaje,
                ImageUrl = showErrorAlertWithImageclass.ImageUrl,
                ImageHeight = showErrorAlertWithImageclass.ImageHeight,
                ImageWidth = showErrorAlertWithImageclass.ImageWidth,
                ShowCancelButton = false,
                ConfirmButtonText = showErrorAlertWithImageclass.ConfirmButtonText,
                ConfirmButtonColor = showErrorAlertWithImageclass.ConfirmButtonColor
            });

        }

        public  void ShowLoading()
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "",
                //Color = "#FFFFFF",
                ShowCancelButton = false,
                ShowConfirmButton = false,
                AllowOutsideClick = false,
                Background = "rgba(0, 0, 0, 0)", // Configura el fondo transparente aquí
                ImageHeight = 200,
                ImageUrl = "dist/Img/loadingSamo.gif",
            });
        }

        public void ShowLoadingClose()
        {
            _sweetAlertService.CloseAsync();
        }
    }
}
