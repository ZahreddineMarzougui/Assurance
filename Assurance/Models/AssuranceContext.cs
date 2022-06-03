using Assurance.Models.EF;
using Assurance.Models.Extend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.Models
{
    public partial class AssuranceContext : DbContext
    {
        public AssuranceContext(DbContextOptions options) : base(options) { }
        //public AssuranceContext(string ConnectionString) : base(new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options)
        //{

        //}

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contrat> Contrat { get; set; }
        public virtual DbSet<Branche> Branche { get; set; }
        public virtual DbSet<Garantie> Garantie { get; set; }
        public virtual DbSet<TypeGarantie> TypeGarantie { get; set; }
        
        public virtual DbSet<NbrContratParClient> NbrContratParClient { get; set; }
        public virtual DbSet<ListContratByClient> ListContratByClient { get; set; }
        public virtual DbSet<ListGarantieByContrat> ListGarantieByContrat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.seed();
            modelBuilder.Entity<NbrContratParClient>().HasNoKey();
            modelBuilder.Entity<ListContratByClient>().HasNoKey();
            modelBuilder.Entity<ListGarantieByContrat>().HasNoKey();
            
        }
    }
}
