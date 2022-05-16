using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DataTransferObjects.EnderecoDTO;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDTO AdicionarEndereco(CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public List<ReadEnderecoDTO> BuscarEndereco()
        {
            List<Endereco> endereco = _context.Enderecos.ToList();
            if(endereco == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadEnderecoDTO>>(endereco);
        }

        public ReadEnderecoDTO BuscarEndercoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return null;
            }
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
