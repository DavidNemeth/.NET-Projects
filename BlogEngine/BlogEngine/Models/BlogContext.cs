using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(): base("BlogConnection")
        {
        }
        public static BlogContext Create()
        {
            return new BlogContext();
        }

        //dataszettek TODO: reply? like? video? pic?
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //többesszám
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       
    }    
}