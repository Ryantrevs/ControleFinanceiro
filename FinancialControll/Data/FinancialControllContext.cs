using Microsoft.EntityFrameworkCore;
using FinancialControll.Models;
using Microsoft.AspNetCore.Identity;
using static FinancialControll.Models.Profile;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FinancialControll.Data
{
    public class FinancialControllContext : IdentityDbContext<Profile>
    {
        public FinancialControllContext(DbContextOptions<FinancialControllContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Organization>(org => { org.ToTable("Organizations"); org.HasKey(x => x.Id); org.HasMany<Profile>().WithOne().HasForeignKey(x => x.OrgId).IsRequired(false); });
        }

        public DbSet<Debt> Debt { get; set; }
        public DbSet<InstallmentDebt> InstallmentDebt { get; set; }
        public DbSet<Planning> Planning { get; set; }
        public DbSet<Card> Card { get; set; }

    }
}
