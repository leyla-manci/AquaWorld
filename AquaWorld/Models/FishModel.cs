using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class FishModel
    {
        public int FishId { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string FishImage { get; set; }
        public int CategoryId { get; set; }
        //public String CategoryName { get; set; }
        public string LongDesc { get; set; }
    }
}