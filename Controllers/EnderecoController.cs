using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.EnderecoDTO;
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
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarEnderecoPorID), new { Id = endereco.Id }, endereco);

        }

        [HttpGet]
        public IEnumerable<Endereco> BuscarEndereco()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEnderecoPorID(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
                return Ok(endereco);
            }
            return NotFound();
        }

        [HttpPut("{id}")]

        public IActionResult AtualizarEndereco(int id, [FromBody]UpdateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if(endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return NoContent();
           
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
