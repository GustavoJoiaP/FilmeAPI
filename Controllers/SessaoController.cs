using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.SessaoDTO;
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
    
    public class SessaoController: ControllerBase
    {
        public AppDbContext _context;
        public IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarSessaoPorId), new { Id = sessao.Id }, sessao);

        }

        [HttpGet]
        public IEnumerable<Sessao> BuscarSessoes()
        {
            return _context.Sessoes;
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if(sessao != null)
            {
                ReadSessaoDTO sessaoDTO = _mapper.Map < ReadSessaoDTO> (sessao);
                return Ok(sessaoDTO);
                
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarSessao([FromBody] UpdateSessaoDTO sessaoDTO, int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if(sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDTO, sessao);
            _context.SaveChanges();
            return Ok();

        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if( sessao == null)
            {
                return NotFound();
            }
            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
