using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mory_Blog.Datalayer.Context
{
    internal class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
    }
}

namespace Mory_Blog.Datalayer
{
    public class BlogContext
    {
    }
}