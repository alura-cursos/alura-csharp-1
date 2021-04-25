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
        public IActionResult AddMovie([FromBody] Filme filme)
        {
            _filmesRepository.AddMovie(filme);
            return CreatedAtAction(nameof(GetMovie), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            List<Filme> filmes = _filmesRepository.FindAllMovies();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            if (_filmesRepository.FindMovieById(id, out Filme filme) == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }
    }
}
