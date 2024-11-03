using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mory_Blog.Datalayer.Entities
{
    internal class Post
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string visit { get; set; }
        [Required]
        public string slug { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<PostComment> PostComments { get; set; }
        }
}
