using Microsoft.EntityFrameworkCore;

namespace Mission07_crofth.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<Movie> Movies { get; set;}
        public DbSet<Category> Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS"}
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId= 1,
                    Title= "WALL-E",
                    CategoryId= 4,
                    Year= 2008,
                    Director= "Andrew Stanton",
                    Rating= "G"
                },
                new Movie
                {
                    MovieId= 2,
                    Title= "Knives Out",
                    CategoryId= 3,
                    Year= 2019,
                    Director= "Rian Johnson",
                    Rating= "PG-13"
                },
                new Movie
                {
                    MovieId= 3,
                    Title= "La La Land",
                    CategoryId= 3,
                    Year= 2016,
                    Director= "Damien Chazelle",
                    Rating= "PG-13"
                }
            );
        }
    }
}
