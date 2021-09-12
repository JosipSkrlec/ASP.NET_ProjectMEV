using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Vjezba.Model;

namespace Vjezba.Web.Controllers
{
    public class BaseController : Controller
    {
        public String UserId { get; }        
        public BaseController(UserManager<AppUser> userManager)
        {
            try
            {
                UserId = userManager.GetUserId(User);
            }
            catch (Exception e)
            {
                UserId = null;
            }            
        }
    }
}
