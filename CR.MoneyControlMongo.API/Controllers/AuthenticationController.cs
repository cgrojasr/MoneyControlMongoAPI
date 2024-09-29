using CR.MoneyControlMongo.API.Models;
using CR.MoneyControlMongo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CR.MoneyControlMongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private IConfiguration _configuration;

        public AuthenticationController(UsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] AuthenticatorModel authenticatorModel)
        {
            var usuarioModel = await _usuarioService.Autenticar(authenticatorModel);
            var token = TokenGenerator(usuarioModel);
            return Ok(token);
        }

        private string TokenGenerator(UsuarioModel usuarioModel)
        {
            try
            {
                var claims = new[] {
                new Claim(ClaimTypes.Name, $"{usuarioModel.nombre} {usuarioModel.apellido}"),
                new Claim(ClaimTypes.Email, usuarioModel.correo)
                };

                var bytes = Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value, []);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials
                );

                string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
