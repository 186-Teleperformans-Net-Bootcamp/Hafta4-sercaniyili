namespace Hafta4_Sercanİyili.Entities
{
    public class GroupMembership
    {
        public int Id { get; set; }

        public AppUser GroupMember { get; set; }
        public int GroupMemberId { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }


    }
}
