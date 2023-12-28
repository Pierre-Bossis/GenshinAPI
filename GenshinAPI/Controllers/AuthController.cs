using Genshin.BLL.Interfaces;
using Genshin.DAL.Entities;
using GenshinAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBLLService _userService;

        public AuthController(IUserBLLService userService)
        {
            _userService = userService;
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
                UserEntity connectedUser = _userService.Login(dto.Email, dto.MotDePasse);
                //string token = _jwtGenerator.Generate(connectedUser);
                return Ok(connectedUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
