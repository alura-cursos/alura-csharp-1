using FilmesApi.Data;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly FilmeContext _context;

        public FilmesRepository(FilmeContext context)
        {
            _context = context;
        }

        public void AdicionaFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }

        public IEnumerable<Filme> GetTodosOsFilmes()
        {
            return _context.Filmes;
        }

        public Filme GetFilmePorId(int id, out Filme filme)
        {
            filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            return filme;
        }



    }
}