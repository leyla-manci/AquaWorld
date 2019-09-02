using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AquaWorld.Identity
{
    public class IdentityDataContext: IdentityDbContext<IdentityUser>
    {
        public IdentityDataContext():base("identityConnection")
        {
            Database.SetInitializer(new IdentityInitializer());

        }
    }
}