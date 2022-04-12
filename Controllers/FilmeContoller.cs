using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeContoller : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);  
            return CreatedAtAction(nameof(BuscarFilmePorID), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> BuscarFilme()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorID(int id)
        {
            Filme filme =  filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
