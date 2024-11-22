using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using CodeYad_Blog.CoreLayer.DTOs.Users;
//using CodeYad_Blog.CoreLayer.Sevices.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mory_Blog.CoreLayeer.DTOs.Users;
using Mory_Blog.CoreLayeer.Sevices;

namespace CodeYad_Blog.Web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly IUserServices _userService;

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        #endregion

        public RegisterModel(IUserServices userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.RigesterUser(new UserRegisterDTOs()
            {
                UserName = UserName,
                Password = Password,
                FullName = FullName
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
