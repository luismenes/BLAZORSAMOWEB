namespace BlazorServer.Common.Helpers.SweetAlert
{
    public class SweetAlertClasses
    {
        public class ShowErrorAlertWithImageclass
        {
            public string Title { get; set; }
            public string Mensaje { get; set; }
            public string ImageUrl { get; set; }
            public int ImageHeight { get; set; }
            public int ImageWidth { get; set; }
            public bool ShowCancelButton { get; set; }
            public string ConfirmButtonText { get; set; }
            public string ConfirmButtonColor { get; set; }
        }
        public class ShowWarningAlertWithIcon
        {
            public string Title { get; set; }
            public string Mensaje { get; set; }
            public string IconColor { get; set; }
            public string ConfirmButtonText { get; set; }
            public string ConfirmButtonColor { get; set; }
            public bool ShowCancelButton { get; set; }
        }

        public class ShowSuccessWithIcon
        {
            public string Title { get; set; }
            public string Mensaje { get; set; }
            public string IconColor { get; set; }
            public string ConfirmButtonText { get; set; }
            public string ConfirmButtonColor { get; set; }
        }

        public class ShowInfoWithIcon
        {
            public string Title { get; set; }
            public string Mensaje { get; set; }
            public string IconColor { get; set; }
            public string ConfirmButtonText { get; set; }
            public string ConfirmButtonColor { get; set; }
        }

        public class ShowErrorAlertWithImageInformativeclass
        {
            public string Title { get; set; }
            public string Mensaje { get; set; }
            public string ImageUrl { get; set; }
            public int ImageHeight { get; set; }
            public int ImageWidth { get; set; }
            public string ConfirmButtonText { get; set; }
            public string ConfirmButtonColor { get; set; }
        }
    }
}
