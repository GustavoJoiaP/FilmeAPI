using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.CinemaDTO;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDTO AdicionarCinema(CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDTO>(cinema);
        }

        public List<ReadCinemaDTO> BuscarCinema(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }
            ;
            return _mapper.Map<List<ReadCinemaDTO>>(cinemas);
        }

        public ReadCinemaDTO BuscarCinemaPorID(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return null;
            }
             
            return _mapper.Map<ReadCinemaDTO>(cinema); ;
        }

        public Result AtulizarCinema(int id, UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return Result.Fail("Cinema não encontrado para atualizar");
            }
            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return Result.Fail("Cinema não encontrado para deletar");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
