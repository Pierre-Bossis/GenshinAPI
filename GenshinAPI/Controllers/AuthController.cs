using Genshin.BLL.Interfaces;
using GenshinAPI.Models.User;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Users;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBLLService _userService;
        private readonly JwtGenerator _jwtGenerator;

        public AuthController(IUserBLLService userService, JwtGenerator jwtGenerator)
        {
            _userService = userService;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterFormDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.Register(dto.Username, dto.MotDePasse, dto.Email);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginFormDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ConnectedUserDTO connectedUser = _userService.Login(dto.Email, dto.MotDePasse).ToDto();
                string token = _jwtGenerator.Generate(connectedUser);
                return Ok(token);
            }
            catch
            {
                return BadRequest("Email ou mot de passe incorrect.");
            }
        }
    }
}
