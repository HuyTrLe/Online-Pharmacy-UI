using pj3_ui.Models;

namespace pj3_ui.Service.Home
{
    public interface IHomeService
    {
        IEnumerable<Movie> GetMovies();
    }
}
