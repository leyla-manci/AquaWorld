using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class CategoryFishModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int FishCount { get; set; }
    }
}