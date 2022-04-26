using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects.GerenteDTO
{
    public class CreateGerenteDTO
    {
        [Required(ErrorMessage ="Obrigatorio inserir o nome para o Gerente")]
        public string Nome { get; set; }
    }
}
