namespace Ecommerce.WebApp.Models.Account
{
    public class AssignRoleViewModel
    {
        public string UserName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
