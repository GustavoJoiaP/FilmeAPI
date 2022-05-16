using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public ReadFilmeDTO AdicionarFilme(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDTO>(filme);
        }

        public List<ReadFilmeDTO> BuscarFilme(int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filmes => filmes.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDTO> readDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return readDTO;
            }
            return null;

        }

        public ReadFilmeDTO BuscarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return null;
            }
            ReadFilmeDTO readDTO = _mapper.Map<ReadFilmeDTO>(filme);
            return readDTO;
        }

        public Result AtualizarFilme(int id, UpdateFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return Result.Fail("Filme nao encontrado para atualizar");
            }
            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return Result.Fail("Filme nao encontrado para deletar");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
