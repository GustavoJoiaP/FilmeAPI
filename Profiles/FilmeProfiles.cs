using AutoMapper;
using FilmesAPI.Data.DataTransferObjects;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfiles : Profile
    {
        public FilmeProfiles()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
        }
    }
}
