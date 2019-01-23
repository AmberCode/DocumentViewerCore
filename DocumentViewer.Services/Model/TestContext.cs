
using Microsoft.EntityFrameworkCore;

namespace DocumentViewer.Services.Model
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documents> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasIndex(e => e.DocumentNumber)
                    .HasName("UQ__Document__68993918FE0C3605")
                    .IsUnique();
            });
        }
    }
}
