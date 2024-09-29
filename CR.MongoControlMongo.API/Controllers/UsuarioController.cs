using CR.MongoControlMongo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CR.MongoControlMongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public UsuarioController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListarTodos(){
            return Ok(await _mongoDBService.GetAsync());
        }
    }
}
