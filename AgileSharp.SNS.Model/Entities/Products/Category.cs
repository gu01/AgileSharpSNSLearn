﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        public int ParentId { get; set; }
        public int ViewCount { get; set; }
        public bool IsDeleted { get; set; }
        public long ProductCount { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Binary Version { get; set; }
    }
}
