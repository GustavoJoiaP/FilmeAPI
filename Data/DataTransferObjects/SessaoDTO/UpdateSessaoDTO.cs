using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects.SessaoDTO
{
    public class UpdateSessaoDTO
    {
        public string Cinema { get; set; }
        public string Filme { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
    }
}
