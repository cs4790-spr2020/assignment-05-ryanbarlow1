using BlabberApp.Domain;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BlabberApp.Client
{
    public class FeedModel : PageModel
    {
        private readonly IBlabService _serviceBlab;
        private readonly IUserService _serviceUser;

        public FeedModel(IBlabService serviceBlab, IUserService serviceUser)
        {
            _serviceBlab = serviceBlab;
            _serviceUser = serviceUser;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var email = Request.Form["emailaddress"];
            var message = Request.Form["message"];

            try
            {
                var user = _serviceUser.GetUserByEmail(email);
                var blab = new Blab { Message = message, User = user };
                _serviceBlab.AddBlab(blab);
            }
            catch(Exception ex)
            {
                throw new Exception("FeedModel::OnPost: " + ex.ToString());
            }
        }
    }
}