using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.DataTransferObject.UsuarioDTO;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController: ControllerBase
    {
        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] CreateUsuarioDTO usuarioDTO)
        {
            return Ok();
        }
    }
}
