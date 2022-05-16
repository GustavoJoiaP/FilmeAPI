using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects;
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
    public class FilmeContoller : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeContoller(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }


        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            ReadFilmeDTO readDTO = _filmeService.AdicionarFilme(filmeDTO);  
            return CreatedAtAction(nameof(BuscarFilmePorID), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult BuscarFilme([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDTO> readDTO = _filmeService.BuscarFilme(classificacaoEtaria);
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return Ok(readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorID(int id)
        {
            ReadFilmeDTO readDTO = _filmeService.BuscarFilmePorId(id);
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Result resultadoAtualizarFilme = _filmeService.AtualizarFilme(id, filmeDTO);
            if(resultadoAtualizarFilme.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resutladoDeletarFilme = _filmeService.DeletarFilme(id);
            if(resutladoDeletarFilme.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
