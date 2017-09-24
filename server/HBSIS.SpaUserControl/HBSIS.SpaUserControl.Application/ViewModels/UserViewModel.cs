namespace HBSIS.SpaUserControl.Application.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName => Email;
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public bool Active { get; set; }
    }
}
