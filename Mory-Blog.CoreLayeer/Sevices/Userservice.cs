using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Entities;
using Mory_Blog.CoreLayeer.DTOs.Users;
using Mory_Blog.Datalayer.Context;

namespace Mory_Blog.CoreLayeer.Sevices
{
    public class Userservice:IUserServices    

    {
        #region readonly BlogContext

        private readonly BlogContext _context;

        public Userservice(BlogContext context)
        {
            _context = context;
        }

        #endregion
        public OperationResult RigesterUser(UserRegisterDTOs registerDtOs)
        {
            var IsFullname = _context.Users.Any(u => u.UserName == registerDtOs.UserName);
            if (IsFullname)
            {
                OperationResult.Error("نام کاربری قبلا وارد شده");
            }

            var passwordhash = registerDtOs.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDtOs.FullName,
                UserName = registerDtOs.UserName,
                isdeleted = false,
                creatdate = DateTime.Now,
                Password = passwordhash
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult LoginUser(LoginUserDtos loginDtos)
        {
            var passwordhash=loginDtos.Password.EncodeToMd5();
            var IsUserExist = _context.Users.Any(u => u.UserName == loginDtos.UserName&& u.Password==passwordhash);
            if (IsUserExist = false)
            {
                return OperationResult.NotFound();
            }
            return OperationResult.Success();

        }
    }
}
