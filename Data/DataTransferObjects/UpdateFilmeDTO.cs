﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DataTransferObjects
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatorio")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Genero do filme nao pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 300, ErrorMessage = "A duração do filme tem que ter no minimo 1 e no max 300 minutos")]
        public int Duracao { get; set; }
    }
}
