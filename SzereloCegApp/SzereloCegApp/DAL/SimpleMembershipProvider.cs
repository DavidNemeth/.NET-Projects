using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SzereloCegApp.DAL
{
    public class SimpleMembershipProvider : DbContext
    {
        public SimpleMembershipProvider() : base("SimpleMembershipProvider")
        {
        }        
        public static SimpleMembershipProvider Create()
        {
            return new SimpleMembershipProvider();
        }
    }
}