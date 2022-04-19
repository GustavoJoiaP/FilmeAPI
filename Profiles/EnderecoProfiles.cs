using AutoMapper;
using FilmesAPI.Data.DataTransferObjects.EnderecoDTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfiles : Profile
    {
        public EnderecoProfiles()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
        }
    }
}
