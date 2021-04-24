using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Repositories
{
    public interface IFilmesRepository
    {
        void AddMovie(Filme filme);
        List<Filme> FindAllMovies();
        Filme FindMovieById(int id, out Filme filme);
    }
}