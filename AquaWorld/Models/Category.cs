using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class Category
    {
        
        [Key]
        public int CategoryId { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }

        public List<Fish> fishes { get; set; }
   
    }
}