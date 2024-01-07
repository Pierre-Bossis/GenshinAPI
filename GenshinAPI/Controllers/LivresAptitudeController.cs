using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
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
        private readonly IWebHostEnvironment _hostingEnvironment;

        public LivresAptitudeController(ILivresAptitudeBLLService service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create([FromForm] LivresAptitudeFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "LivresAptitude", _hostingEnvironment);

            _service.Create(dto.ToBLL(relativePath));
            return Ok();
        }
    }
}
