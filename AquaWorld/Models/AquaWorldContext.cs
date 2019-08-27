using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AquaWorld.Models
{
    public class AquaWorldContext:DbContext
    {

        public AquaWorldContext():base("dbConnectString")
        {
            Database.SetInitializer(new AquaWorldInitializer());
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Fish> fishes { get; set; }
    }
}