namespace FocusRandomGenerator.DataEntities
{
    using Microsoft.EntityFrameworkCore;
    using System;
    public class RandomNumberDbContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="RandomNumberDbContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public RandomNumberDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the GeneratedRandonNumbers.
        /// </summary>
        /// <value>The DB Set of <see cref="RandonNumber"/>.</value>
        public DbSet<RandomNumber> RandomNumbers { get; set; }


        /// <summary>
        /// Gets or sets the GeneratedRandonNumbers.
        /// </summary>
        /// <value>The DB Set of <see cref="RandonNumber"/>.</value>
        public DbSet<NumberInfo> NumberInfo { get; set; }

        /// <summary>
        /// Gets or sets the GeneratedRandonNumbers.
        /// </summary>
        /// <value>The DB Set of <see cref="RandonNumber"/>.</value>
        public DbSet<ColorCoding> ColorCoding { get; set; }


        /// <summary>
        /// Create the model with relationships/keys
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Validate arguments
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }


            modelBuilder.Entity<RandomNumber>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GeneratorDateTime).HasColumnName("GeneratorDateTime");
            });
               
            modelBuilder.Entity<ColorCoding>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<NumberInfo>()
                .HasKey(e => e.Id);

            //modelBuilder.Seed();
            // Call base
            base.OnModelCreating(modelBuilder);
        }
    }
}
