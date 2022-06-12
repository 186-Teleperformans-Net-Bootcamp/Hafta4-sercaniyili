using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4_Sercanİyili.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentType Type { get; set; }
        public DateTime SendDate { get; set; }

        [ForeignKey("Sender")]
        public AppUser User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
