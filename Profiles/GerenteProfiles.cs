using AutoMapper;
using FilmesAPI.Data.DataTransferObjects.GerenteDTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfiles: Profile
    {
        public GerenteProfiles()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>();
            CreateMap<UpdateGerenteDTO, Gerente>();

        }
    }
}
