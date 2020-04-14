using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Client
{
    public class UsersModel : PageModel
    {
        private readonly IUserService _service;

        public UsersModel(IUserService service)
        {
            _service = service;
        }
        
        public void OnGet()
        {
        }
    }
}