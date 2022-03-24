using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  // it is up to our level now
        //{

        public DbSet<Room_Type> Room_Type { get; set; }
        public DbSet<Client> Clients { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;Database=THE WEB PROJECT Final  ;Trusted_connection=true");

            base.OnConfiguring(optionsBuilder);
        }
       

        public DbSet<WebApplication1.Models.payment> payment { get; set; }



    }
}
