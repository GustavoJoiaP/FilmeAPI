using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.GerenteDTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class GerenteController : ControllerBase
    {
        public AppDbContext _context;
        public IMapper _mapper;
        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarGerentePorID), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> BuscarGerentes()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarGerentePorID(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente != null)
            {
                ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                return Ok(gerenteDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente([FromBody]UpdateGerenteDTO gerenteDTO, int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return NotFound();
            }
            _mapper.Map(gerenteDTO, gerente);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return NotFound();
            }
            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
