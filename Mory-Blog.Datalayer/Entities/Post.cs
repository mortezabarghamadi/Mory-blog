using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mory_Blog.Datalayer.Entities.BaseEntity;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class Post : BaseEntity
    {
        
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        
        public string Title { get; set; }
        
        public string Slug { get; set; }
        
        public string Description { get; set; }
        public int Visit { get; set; }


        public User User { get; set; }

        public Category Category { get; set; }

        public ICollection<PostComment> PostComments { get; set; }
    }

    #region relation

    public class PostConfigurations : BaseEntityConfigurations<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId);

        }
    }

    #endregion
}