using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Repositories
{
    public interface IFilmesRepository
    {
        void AdicionaFilme(Filme filme);
        List<Filme> GetTodosOsFilmes();
        Filme GetFilmePorId(int id, out Filme filme);
    }
}