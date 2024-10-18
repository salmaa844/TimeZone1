using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeZone.PL.Areas.Dashboard.ViewModels
{
    public class ItemFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int ? portfolioId { get; set; }

        public SelectList? Portfolios { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgeName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
