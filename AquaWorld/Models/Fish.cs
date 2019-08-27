using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string FishImage { get; set; }

       
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category category { get; set; }

    }
}