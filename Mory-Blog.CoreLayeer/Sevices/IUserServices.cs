using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Entities;
using Mory_Blog.CoreLayeer.DTOs.Users;

namespace Mory_Blog.CoreLayeer.Sevices
{
    public interface IUserServices
    {
        OperationResult RigesterUser(UserRegisterDTOs userRegisterDtOs);
        OperationResult LoginUser(LoginUserDtos loginDtos);
    }
}
