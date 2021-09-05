using System.Threading.Tasks;
using Dotnet_Rpg.Data;
using Dotnet_Rpg.Dtos.User;
using Dotnet_Rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authrepo;
        public AuthController(IAuthRepository authrepo)
        {
            _authrepo = authrepo;
        }
    [HttpPost("Register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request) 
    {
      var response = await _authrepo.Register(new User { Username = request.Username }, request.Password);
      if(!response.Success)
        return BadRequest(response);
      return Ok(response);
    }
    [HttpPost("Login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request) 
    {
      var response = await _authrepo.Login(request.Username, request.Password);
      if(!response.Success)
        return BadRequest(response);
      return Ok(response);
    }

  }
}