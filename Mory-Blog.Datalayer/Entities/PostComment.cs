using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mory_Blog.Datalayer.Entities.BaseEntity;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class PostComment : BaseEntity
    {
        
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }

        
        public Post Post { get; set; }

        
        public User User { get; set; }
    }

    #region relation

    public class PostCommentConfigurations : BaseEntityConfigurations<PostComment>
    {
        public override void Configure(EntityTypeBuilder<PostComment> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostComments)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PostComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    #endregion

}
