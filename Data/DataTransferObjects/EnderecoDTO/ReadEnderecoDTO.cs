using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects.EnderecoDTO
{
    public class ReadEnderecoDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatorio")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatorio")]
        public string Bairro { get; set; }
        [Range(1, 9999, ErrorMessage = "A numeração do endereço tem que ter no minimo 1 e no max 9999 minutos")]
        public int Numero { get; set; }
    }
}
