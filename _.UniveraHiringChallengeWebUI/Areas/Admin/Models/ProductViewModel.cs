namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public Guid productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productImgUrl { get; set; }
        public List<CategoryViewModel> categories { get; set; }





    }
}
