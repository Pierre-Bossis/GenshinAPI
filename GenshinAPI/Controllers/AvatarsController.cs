using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Personnages.Avatars;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Authorize("connectedPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private readonly IAvatarsBLLService _AvatarService;

        public AvatarsController(IAvatarsBLLService avatarsService)
        {
            _AvatarService = avatarsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<AvatarsDTO> avatars = _AvatarService.GetAll().Select(a => a.ToDto());
            return Ok(avatars);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AvatarsDTO avatar = _AvatarService.GetById(id).ToDto();
            if (avatar is not null) return Ok(avatar);
            return BadRequest("Aucun Avatar trouvé");
        }

        [HttpPatch]
        public IActionResult ChangeAvatar([FromBody] AvatarChangeDTO dto)
        {
            _AvatarService.AvatarChange(dto.AvatarId, dto.UserId);
            return Ok();
        }
    }
}
