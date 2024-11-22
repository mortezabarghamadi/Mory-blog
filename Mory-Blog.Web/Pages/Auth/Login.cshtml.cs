using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mory_Blog.CoreLayeer.DTOs.Users;
using Mory_Blog.CoreLayeer.Sevices;

namespace CodeYad_Blog.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public readonly IUserServices _userServices;
        public LoginModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public string Username { get; set; }
        
        public string Password { get; set; }

        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userServices.LoginUser(new LoginUserDtos() { Password = Password, UserName = Username });
            if (result.Status == OperationResultStatus.NotFound )
            {
                ModelState.AddModelError("UserName","کاربری یافت نشد");
                return Page();
            }
            return RedirectToPage("../Index");
        }

        
    }
}
