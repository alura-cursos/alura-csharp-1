using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private List<Filme> filmes = new List<Filme>();
        private int id = 1;

        public void AdicionaFilme(Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        public List<Filme> GetTodosOsFilmes()
        {
            return filmes;
        }

        public Filme GetFilmePorId(int id, out Filme filme)
        {
            filme = filmes.FirstOrDefault(f => f.Id == id);
            return filme;
        }



    }
}