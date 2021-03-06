﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SzereloCegApp.Models;

namespace SzereloCegApp.DAL
{
    public class SzereloCegEntities : DbContext
    {
        public SzereloCegEntities() : base("SzereloCegEntities")
        {
        }
        public DbSet<Szerelo> Szerelok { get; set; }
        public DbSet<Ugyfel> Ugyfelek { get; set; }
        public DbSet<Diagnosztika> Diagnosztikák { get; set; }
        public DbSet<GepJarmu> GepJarmuvek { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 0));            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}