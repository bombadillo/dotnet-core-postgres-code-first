namespace dotnet_core_postgres_code_first
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EFContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;User Id=test;Password=C.mum1873;Database=test;Integrated Security=true;Pooling=true");
        }
    }
}