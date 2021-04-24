using FilmesAPI.Models;
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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(GetMovie), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            if (filmes.ToArray().Length == 0)
            {
                return NoContent();
            }
            return Ok(filmes.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            Filme filme = filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }
    }
}
