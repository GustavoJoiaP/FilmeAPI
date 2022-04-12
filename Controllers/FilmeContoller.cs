using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects;
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
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeContoller(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
             
        }


        [HttpPost]

        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();   
            return CreatedAtAction(nameof(BuscarFilmePorID), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> BuscarFilme()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorID(int id)
        {
            Filme filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                return Ok(filmeDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
