using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects.GerenteDTO
{
    public class ReadGerenteDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo Nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
