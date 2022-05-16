using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.EnderecoDTO;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
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
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO readDTO = _enderecoService.AdicionarEndereco(enderecoDTO);
            return CreatedAtAction(nameof(BuscarEnderecoPorID), new { Id = readDTO.Id }, readDTO);

        }

        [HttpGet]
        public IActionResult BuscarEndereco()
        {
            List<ReadEnderecoDTO> readDTO = _enderecoService.BuscarEndereco();
            if (readDTO == null)
            {
                return NotFound();
            }
            return Ok(readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEnderecoPorID(int id)
        {
            ReadEnderecoDTO readDTO = _enderecoService.BuscarEndercoPorId(id);
            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]

        public IActionResult AtualizarEndereco(int id, [FromBody]UpdateEnderecoDTO enderecoDTO)
        {
            Result resultadoAtualizarEndereco = _enderecoService.AtualizarEndereco(id, enderecoDTO);

            if (resultadoAtualizarEndereco == null)
            {
                return NotFound();
            }

            return NoContent();
           
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultadoDeletarEndereco = _enderecoService.DeletarEndereco(id);
            if (resultadoDeletarEndereco == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
