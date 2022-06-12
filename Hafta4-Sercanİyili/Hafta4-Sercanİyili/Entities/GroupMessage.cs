using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta4_Sercanİyili.Entities
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public ContentType Type { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        [ForeignKey("Sender")]
        public AppUser GroupMember { get; set; }

        [ForeignKey("Reciever")]
        public Group Group { get; set; }
    }
}
