using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class BankContext : DbContext
    {
        public BankContext() : base("MyConnection")
        {
            Database.SetInitializer<BankContext>(new CreateDatabaseIfNotExists<BankContext>());
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<ClientCheck> Checks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .Property(e => e.PassportNumber)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            modelBuilder.Entity<ClientCheck>()
               .HasRequired(c => c.Owner)
               .WithMany()
               .HasForeignKey(c => c.ClientID);
        }

        public void DeleteOwner(int id)
        {
            var parameter = new SqlParameter("@ownerId", id);
             Database.ExecuteSqlCommand("exec DeleteOwner @ownerId", parameter);
        }

    }
}
