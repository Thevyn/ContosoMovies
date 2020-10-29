using System;

namespace assignment
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public Movie(int id, string name, string director, DateTime releaseDate, string cast, string genre, string description)
        {
            Id = id;
            Name = name;
            Director = director;
            ReleaseDate = releaseDate;
            Cast = cast;
            Genre = genre;
            Description = description;
        }

        public Movie()
        {
        }
    }
    
}