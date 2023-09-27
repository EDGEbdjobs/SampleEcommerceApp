namespace Ecommerce.WebApp.Models.Account
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
