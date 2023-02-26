namespace _.UniveraHiringChallengeWebUI.Models
{
    public class ListAllShoppingDTO
    {
        public Guid shoppingId { get; set; }
        public string shoppingName { get; set; }
        public string shoppingDescription { get; set; }
        public DateTime shoppingDate { get; set; }
        public string fullName { get; set; }
        public bool iscomplated { get; set; }
        public DateTime ? complatedDate { get; set; }
    }
}
