namespace TimeZone.PL.Areas.Dashboard.ViewModels
{
    public class ProductFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgeName { get; set; }
        public string Description { get; set; }

    }
}
