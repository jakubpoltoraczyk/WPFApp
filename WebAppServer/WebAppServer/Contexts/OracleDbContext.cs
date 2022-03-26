using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.Contexts
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public DbSet<UserCategory> UserCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\_Keys\oracle_db_ConnectionString.txt";

            optionsBuilder.UseOracle(File.ReadAllText(path));
        }
    }
}