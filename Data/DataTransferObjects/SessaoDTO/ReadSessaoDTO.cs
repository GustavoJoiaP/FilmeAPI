using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects.SessaoDTO
{
    public class ReadSessaoDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }

    }
}
