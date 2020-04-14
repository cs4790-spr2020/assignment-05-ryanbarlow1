using BlabberApp.Domain;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BlabberApp.Client
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _service;

        public RegisterModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var email = Request.Form["emailaddress"];
            try
            {
                var user = new User { Email = email };
                _service.AddUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}