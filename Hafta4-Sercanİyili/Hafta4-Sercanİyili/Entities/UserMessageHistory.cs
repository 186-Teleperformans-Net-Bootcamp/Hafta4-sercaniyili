namespace Hafta4_Sercanİyili.Entities
{
    public class UserMessageHistory
    {
        public int Id { get; set; }
        public int UserMessageId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
