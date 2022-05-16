using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.GerenteDTO;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public ReadGerenteDTO AdicionarGerente(CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public List<ReadGerenteDTO> BuscarGerente()
        {
            List<Gerente> gerente = _context.Gerentes.ToList();
            if(gerente == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadGerenteDTO>>(gerente);
        }

        public ReadGerenteDTO BuscarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return null;
            }
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public Result AtualizarGerente(int id, UpdateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return Result.Fail("Gerente não encontrado para atualizar");
            }
            _mapper.Map(gerenteDTO, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return Result.Fail("Gerente não encontrado para deletar");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
