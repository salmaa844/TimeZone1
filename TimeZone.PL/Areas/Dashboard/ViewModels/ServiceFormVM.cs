﻿namespace TimeZone.PL.Areas.Dashboard.ViewModels
{
    public class ServiceFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? ImgeName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
