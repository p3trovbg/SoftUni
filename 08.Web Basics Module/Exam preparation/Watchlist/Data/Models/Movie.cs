
namespace Watchlist.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public ICollection<UserMovie> UsersMovies { get; set; }
    }
}
