using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using Sang5_01_07.Models;

namespace Sang5_01_07.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    
        [DisplayName]
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<ShowDays> ShowDays { get; set; }
        public DbSet<ShowTimes> ShowTimes { get; set; }
        public DbSet<Shows> Shows { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservations>()
                .HasRequired(c => c.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}