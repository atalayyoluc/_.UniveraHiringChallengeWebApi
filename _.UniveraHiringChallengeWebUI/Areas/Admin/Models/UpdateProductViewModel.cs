namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Models
{
    public class UpdateProductViewModel
    {
        public Guid productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productImgUrl { get; set; }
        public Guid category1Id { get; set; }
        public Guid category2Id { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
    }
}
