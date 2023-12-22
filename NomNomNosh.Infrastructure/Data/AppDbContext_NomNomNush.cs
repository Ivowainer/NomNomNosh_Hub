using Microsoft.EntityFrameworkCore;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Infrastructure.Data
{
    public class AppDbContext_NomNomNush : DbContext
    {
        public AppDbContext_NomNomNush(DbContextOptions options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<RecipeComment> RecipeComments { get; set; }
        public DbSet<RecipeRate> RecipeRates { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<RecipeSaved> RecipeSaved { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(ms =>
            {
                // PK
                ms.HasKey(m => m.Member_Id);

                ms.Property(m => m.Username).IsRequired();
                ms.Property(m => m.First_Name).IsRequired();
                ms.Property(m => m.Last_Name).IsRequired();
                ms.Property(m => m.Password).IsRequired();
                ms.Property(m => m.Email).IsRequired();
            });

            modelBuilder.Entity<Recipe>(rs =>
            {
                rs.HasKey(r => r.Recipe_Id);

                rs.Property(r => r.Title).IsRequired();
                rs.Property(r => r.Description).IsRequired();
                rs.Property(r => r.Main_Image).IsRequired();
                rs.Property(r => r.Member_Id).IsRequired();

                rs.HasOne(r => r.Member)
                    .WithMany(m => m.Recipes)
                    .HasForeignKey(r => r.Member_Id);
            });

        }


    }
}