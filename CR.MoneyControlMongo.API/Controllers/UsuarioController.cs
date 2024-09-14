using System.Runtime.CompilerServices;
using CR.MoneyControlMongo.API.Models;
using CR.MoneyControlMongo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CR.MoneyControlMongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar(){
            return Ok(await _usuarioService.GetAsync());
        }
        }
}
