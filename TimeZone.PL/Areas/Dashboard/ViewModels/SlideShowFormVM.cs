namespace TimeZone.PL.Areas.Dashboard.ViewModels
{
    public class SlideShowFormVM
    {
        public int Id { get; set; }
       
        public bool status { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgeName { get; set; }

    }
}
