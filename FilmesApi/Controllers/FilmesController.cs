using FilmesAPI.Models;
using FilmesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {

        private IFilmesRepository _filmesRepository;

        public FilmesController(IFilmesRepository filmesRepository)
        {
            _filmesRepository = filmesRepository;
        }


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _filmesRepository.AdicionaFilme(filme);
            return CreatedAtAction(nameof(GetMovie), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            IEnumerable<Filme> filmes = _filmesRepository.GetTodosOsFilmes();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            if (_filmesRepository.GetFilmePorId(id, out Filme filme) == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }
    }
}
