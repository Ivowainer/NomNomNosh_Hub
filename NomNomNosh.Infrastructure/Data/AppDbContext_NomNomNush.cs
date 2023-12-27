using Microsoft.EntityFrameworkCore;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Infrastructure.Data
{
    public class AppDbContext_NomNomNosh : DbContext
    {
        public AppDbContext_NomNomNosh(DbContextOptions options) : base(options) { }

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

            // Member
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

            // Recipe
            modelBuilder.Entity<Recipe>(rs =>
            {
                // PK
                rs.HasKey(r => r.Recipe_Id);

                rs.Property(r => r.Title).IsRequired();
                rs.Property(r => r.Description).IsRequired();
                rs.Property(r => r.Main_Image).IsRequired();
                rs.Property(r => r.Member_Id).IsRequired();

                // Relationships
                rs.HasOne(r => r.Member)
                    .WithMany(m => m.Recipes)
                    .HasForeignKey(r => r.Member_Id);
            });

            // RecipeComment
            modelBuilder.Entity<RecipeComment>(rcs =>
            {
                rcs.HasKey(rc => rc.RecipeComment_Id);

                rcs.Property(rc => rc.RecipeComment_Content).IsRequired();
                rcs.Property(rc => rc.Member_Id).IsRequired();
                rcs.Property(rc => rc.Recipe_Id).IsRequired();

                // Relationships
                rcs.HasOne(rc => rc.Member)
                    .WithMany(m => m.RecipeComments)
                    .HasForeignKey(rc => rc.Member_Id);

                rcs.HasOne(rc => rc.Recipe)
                    .WithMany(r => r.RecipeComments)
                    .HasForeignKey(rc => rc.Recipe_Id);
            });

            // RecipeRate
            modelBuilder.Entity<RecipeRate>(rrs =>
            {
                // PK
                rrs.HasKey(rr => rr.RecipeRate_Id);

                rrs.Property(rr => rr.Recipe_Id).IsRequired();
                rrs.Property(rr => rr.Member_Id).IsRequired();
                rrs.Property(rr => rr.Rating_Value).IsRequired();

                // Relationships
                rrs.HasOne(rr => rr.Member)
                    .WithMany(m => m.RecipeRates)
                    .HasForeignKey(rr => rr.Member_Id);

                rrs.HasOne(rr => rr.Recipe)
                    .WithMany(r => r.RecipeRates)
                    .HasForeignKey(rr => rr.Recipe_Id);

            });

            // RecipeImage
            modelBuilder.Entity<RecipeImage>(ris =>
            {
                //PK
                ris.HasKey(ri => ri.RecipeImage_Id);

                ris.Property(ri => ri.Recipe_Id).IsRequired();
                ris.Property(ri => ri.Url).IsRequired();

                // Relationships
                ris.HasOne(ri => ri.Recipe)
                    .WithMany(r => r.RecipeImages)
                    .HasForeignKey(ri => ri.Recipe_Id);
            });

            // RecipeStep
            modelBuilder.Entity<RecipeStep>(rss =>
            {
                // PK
                rss.HasKey(rs => rs.RecipeStep_Id);

                rss.Property(rs => rs.Title).IsRequired();
                rss.Property(rs => rs.Description).IsRequired();
                rss.Property(rs => rs.Recipe_Id).IsRequired();

                // Relationships
                rss.HasOne(rs => rs.Recipe)
                    .WithMany(r => r.RecipeSteps)
                    .HasForeignKey(rs => rs.Recipe_Id);
            });

            // RecipeSaved
            modelBuilder.Entity<RecipeSaved>(rss =>
            {
                // PK
                rss.HasKey(rs => rs.RecipeSaved_Id);

                rss.Property(rs => rs.Member_Id).IsRequired();
                rss.Property(rs => rs.Recipe_Id).IsRequired();

                // Relationships
                rss.HasOne(rs => rs.Member)
                    .WithMany(m => m.RecipesSaved)
                    .HasForeignKey(rs => rs.Member_Id);

                rss.HasOne(rs => rs.Recipe)
                    .WithMany(r => r.RecipesSaved)
                    .HasForeignKey(rs => rs.Recipe_Id);

            });
        }
    }
}