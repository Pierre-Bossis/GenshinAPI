using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresAptitudeController : ControllerBase
    {
        private readonly ILivresAptitudeBLLService _service;

        public LivresAptitudeController(ILivresAptitudeBLLService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LivresAptitudeDTO> livres = _service.GetAll().Select(livre => livre.ToDto());
            return Ok(livres);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            LivresAptitudeDTO livre = _service.GetByName(name).ToDto();

            if (livre is not null) return Ok(livre);
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            LivresAptitudeDTO livre = _service.GetById(id).ToDto();

            if (livre is not null) return Ok(livre);
            return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            LivresAptitudeFormDTO dto = new LivresAptitudeFormDTO()
            {
                Nom = form["Nom"][0],
                Source = form["Source"][0],
                Rarete = int.Parse(form["Rarete"][0])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _service.Create(dto.ToBLL());
            return Ok();

        }
    }
}
