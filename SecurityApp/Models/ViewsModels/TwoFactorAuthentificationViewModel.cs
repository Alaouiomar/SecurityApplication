namespace SecurityApp.Models.ViewsModels
{
    public class TwoFactorAuthentificationViewModel
    {
        public string? Code { get; set; }
        public string? Token { get; set; }
        public string QRCodeUrl { get; internal set; }
    }
}
