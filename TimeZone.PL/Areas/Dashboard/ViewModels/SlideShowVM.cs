namespace TimeZone.PL.Areas.Dashboard.ViewModels
{
    public class SlideShowVM
    {
       
        
        public bool status { get; set; }
        
        public int Id { get; set; }
        
        public IFormFile Image { get; set; }
        public string? ImgeName { get; set; }
      
    }
}
