using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZone.DAL.Models
{
    public class Service

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String ImgeName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
