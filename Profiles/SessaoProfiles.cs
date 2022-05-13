using AutoMapper;
using FilmesAPI.Data.DataTransferObjects.SessaoDTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfiles:Profile
    {
        public SessaoProfiles()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
            CreateMap<UpdateSessaoDTO, Sessao>();
        }
        
    }
}
