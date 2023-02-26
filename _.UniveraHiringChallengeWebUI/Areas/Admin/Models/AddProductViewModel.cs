
namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productImgUrl { get; set; }
        public Guid category1Id { get; set; }
        public Guid category2Id { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
    }
}


//{
//  "productName": "Deneme",
//  "productDescripton": "TEST",
//  "productImgUrl": "string",
//  "category1Id": "7e9e99c9-48ca-44ab-bd88-a50ffb838e68",
//  "category2Id": "df843704-0228-4bdf-9f7e-6b586c5ed3b4"
//}