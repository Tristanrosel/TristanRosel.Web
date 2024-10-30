using TristanRosel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TristanRosel.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Library> libraries = new List<Library>
            {
                new Library
                {
                    LibraryId = Guid.NewGuid(),
                    Name = "Central Library",
                    Location = "Downtown",
                    EstablishedYear = 1950
                },
                new Library
                {
                    LibraryId = Guid.NewGuid(),
                    Name = "Community Library",
                    Location = "Suburbs",
                    EstablishedYear = 1980
                }
            };

            
            List<Book> books = new List<Book>
            {
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "C# Programming",
                    Author = "John Doe",
                    ISBN = "123-4567890123",
                    LibraryId = libraries[0].LibraryId
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Introduction to Algorithms",
                    Author = "Thomas H. Cormen",
                    ISBN = "456-7890123456",
                    LibraryId = libraries[1].LibraryId
                }
            };

            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId);

            
            modelBuilder.Entity<Library>().HasData(libraries);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
