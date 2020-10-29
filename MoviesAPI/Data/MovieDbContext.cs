using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Data
{
    
        public class MovieDbContext : DbContext
        {

            public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
            {
            }
            public DbSet<Movie> Movies { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Movie>().HasData(new Movie[]
                {
                  new Movie( 1, "Die Another Day","Lee Tamahori", new DateTime(2002, 11, 22),"","Action","" ),
                  new Movie( 2, "Top Gun","Tony Scott", new DateTime(1986, 05, 12),"","Action","" ),
                  new Movie( 3, "Jurassic Park","Steven Spielberg", new DateTime(1993, 06, 11),"","Action","" ),
                  new Movie( 4, "Transformers","Michael Bay", new DateTime(2007, 07, 03),"","Action","" ),
                  new Movie( 5, "Independence Day","Roland Emmerich", new DateTime(1996, 07, 03),"","Action","" )
                });
            }


        }
    }

