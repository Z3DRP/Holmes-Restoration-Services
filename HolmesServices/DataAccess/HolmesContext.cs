using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolmesServices.Models;
using HolmesServices.Models.DomainModels;

namespace HolmesServices.DataAccess
{
    public class HolmesContext : DbContext
    {
        public HolmesContext(DbContextOptions<HolmesContext> options)
            : base(options) { }

        public DbSet<Deck_Type> Deck_Types { get; set; }
        public DbSet<Rail_Type> Rail_Types { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Price_Groups> Price_Groups { get; set; }
        public DbSet<Decking> Deckings { get; set; }
        public DbSet<Railing> Railings { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<Job> Jobs { get; set; }

        

        protected override void OnModelCreating(ModelBuilder model)
        {
            // set primary keys and foreign keys for tables

            // customers
            model.Entity<Customer>().HasKey(c => new { c.Id });
            //deck types 
            model.Entity<Deck_Type>().HasKey(d => new { d.Id });
            model.Entity<Deck_Type>().HasMany(d => d.Deckings)
                .WithOne(dk => dk.Type).HasForeignKey(dt => dt.Type_Id);
            //rail types
            model.Entity<Rail_Type>().HasKey(r => new { r.Id });
            model.Entity<Rail_Type>().HasMany(r => r.Railings)
                .WithOne(r => r.Type).HasForeignKey(rt => rt.Type_Id);
            // price groups
            model.Entity<Price_Groups>().HasKey(g => new { g.Id });
            model.Entity<Price_Groups>().HasMany(g => g.Decks)
                .WithOne(d => d.Group).HasForeignKey(g => g.Group_Id);
            model.Entity<Price_Groups>().HasMany(g => g.Rails)
                .WithOne(r => r.Group).HasForeignKey(g => g.Group_Id);
            //deckings
            model.Entity<Decking>().HasKey(d => new { d.Id });
            model.Entity<Decking>().HasOne(t => t.Type)
               .WithMany(dt => dt.Deckings).HasForeignKey(d => d.Type_Id);
            //railings 
            model.Entity<Railing>().HasKey(r => new { r.Id });
            model.Entity<Railing>().HasOne(r => r.Type)
                .WithMany(rt => rt.Railings).HasForeignKey(r => r.Type_Id);
            //designs
            model.Entity<Design>().HasKey(d => new { d.Id });
            model.Entity<Design>().HasOne(c => c.Customer)
                .WithMany(d => d.Designs).HasForeignKey(d => d.Customer_Id);
            model.Entity<Design>().HasOne(d => d.Deck)
                .WithMany(d => d.Designs).HasForeignKey(d => d.Decking_Id);
            model.Entity<Design>().HasOne(r => r.Rail)
                .WithMany(r => r.Designs).HasForeignKey(r => r.Railing_Id);
            //jobs
            model.Entity<Job>().HasKey(j => new { j.Id });
            model.Entity<Job>().HasOne(d => d.Design)
                .WithMany(dj => dj.Jobs).HasForeignKey(dj => dj.Design_Id);
            model.Entity<Job>().HasOne(c => c.Customer)
                .WithMany(c => c.Jobs).HasForeignKey(cj => cj.Customer_Id);
            
        }

    }
}
