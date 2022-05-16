using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.CinemaDTO;
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
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO readDTO = _cinemaService.AdicionarCinema(cinemaDTO);
            return CreatedAtAction(nameof(BuscarCinemaPorID), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult BuscarCinema([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDTO> readDTO = _cinemaService.BuscarCinema(nomeDoFilme);
            if(readDTO == null)
            {
                return NotFound();
            }
            return Ok(readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarCinemaPorID(int id)
        {
            ReadCinemaDTO readDTO = _cinemaService.BuscarCinemaPorID(id);
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Result resultadoAtualizarCinema = _cinemaService.AtulizarCinema(id, cinemaDTO);
            if(resultadoAtualizarCinema.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result resultadoDeletarCinema = _cinemaService.DeletarCinema(id);
            if (resultadoDeletarCinema.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
    
}
