namespace Ecommerce.WebApp.Models.Account
{
    public class RoleCreateViewModel
    {
        public string Role { get; set; }

        public ICollection<string>? Roles { get; set; }


    }
}
