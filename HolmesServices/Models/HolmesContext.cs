using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HolmesServices.Models
{
    public class HolmesContext : DbContext
    {
        public HolmesContext(DbContextOptions<HolmesContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Decking> Deckings { get; set; }
        public DbSet<Railing> Railings { get; set; }
        public DbSet<Design> Designs { get; set; } 
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // set Customer table primary key
            model.Entity<Customer>().HasKey(c => c.Id);

            model.Entity<Decking>().HasKey(d => d.Id);

            model.Entity<Railing>().HasKey(r => r.Id);

            model.Entity<Design>().HasKey(d => d.Id);
            // set foreign key


            model.Entity<Job>().HasKey(j => j.Id);
            
        }
    }
}
