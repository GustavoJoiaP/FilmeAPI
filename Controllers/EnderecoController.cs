using FilmesAPI.Data;
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

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] Endereco endereco)
        {
            
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
                return Ok(endereco);
            }
            return NotFound();
        }

        [HttpPut("{id}")]

        public IActionResult AtualizarEndereco(int id, [FromBody]Endereco enderecoNovo)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if(endereco == null)
            {
                return NotFound();
            }
            endereco.Bairro = enderecoNovo.Bairro;
            endereco.Rua = enderecoNovo.Rua;
            endereco.Numero = enderecoNovo.Numero;
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
