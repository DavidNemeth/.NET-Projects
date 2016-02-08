using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SzereloCegApp.DAL
{
    public class RoleProvider : DbContext
    {
        public RoleProvider() : base("RoleProvider")
        {
        }
        public static RoleProvider Create()
        {
            return new RoleProvider();
        }
    }
}