using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mory_Blog.Datalayer.Entities.BaseEntity;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class User : BaseEntity
    {
        
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }

    #region relation

    public class UserConfigurations : BaseEntityConfigurations<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
        }
    }

    #endregion
}
