using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.GerenteDTO;
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
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO readDTO = _gerenteService.AdicionarGerente(gerenteDTO);
            return CreatedAtAction(nameof(BuscarGerentePorID), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult BuscarGerentes()
        {
            List<ReadGerenteDTO> readDTO = _gerenteService.BuscarGerente();
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarGerentePorID(int id)
        {
            ReadGerenteDTO readDTO = _gerenteService.BuscarGerentePorId(id);
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente([FromBody]UpdateGerenteDTO gerenteDTO, int id)
        {
            Result resultadoAtualizarGerente = _gerenteService.AtualizarGerente(id, gerenteDTO);
            if (resultadoAtualizarGerente.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultadoDeletarGerente = _gerenteService.DeletarGerente(id);
            if (resultadoDeletarGerente.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}
