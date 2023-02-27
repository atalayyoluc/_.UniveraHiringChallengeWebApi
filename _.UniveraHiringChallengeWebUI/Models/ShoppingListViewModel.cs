namespace _.UniveraHiringChallengeWebUI.Models
{
    public class ShoppingListViewModel
    {
        public Guid shoppingId { get; set; }
        public string shoppingName { get; set;}
        public string shoppingDescription { get; set;}
        public DateTime shoppingDate { get; set; }
        public DateTime? complatedDate { get; set; }
        public bool iscomplated { get; set; }
        public string fullName { get; set; }

    }
}
