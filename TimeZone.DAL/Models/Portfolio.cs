﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZone.DAL.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
