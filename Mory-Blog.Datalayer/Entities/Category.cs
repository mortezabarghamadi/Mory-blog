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
    public class Category : BaseEntity
    {
        
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
                


        #region relatiion

        public ICollection<Post> Posts { get; set; }
    }

    public class CategoryConfigurations : BaseEntityConfigurations<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
        }
    }
}

#endregion
