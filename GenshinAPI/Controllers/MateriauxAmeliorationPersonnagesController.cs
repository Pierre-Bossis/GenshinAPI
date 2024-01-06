using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxAmeliorationPersonnagesController : ControllerBase
    {
        private readonly IMateriauxAmeliorationPersonnagesBLLService _materiauxAmeliorationPersonnagesService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MateriauxAmeliorationPersonnagesController(IMateriauxAmeliorationPersonnagesBLLService materiauxAmeliorationPersonnagesService, IWebHostEnvironment hostingEnvironment)
        {
            _materiauxAmeliorationPersonnagesService = materiauxAmeliorationPersonnagesService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MateriauxAmeliorationPersonnagesDTO> mats = _materiauxAmeliorationPersonnagesService.GetAll().Select(mat => mat.ToDto());
            return Ok(mats);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            MateriauxAmeliorationPersonnagesDTO mat = _materiauxAmeliorationPersonnagesService.GetByName(name).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            MateriauxAmeliorationPersonnagesDTO mat = _materiauxAmeliorationPersonnagesService.GetById(id).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] MateriauxAmeliorationPersonnagesFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "MateriauxAmeliorationPersonnages", _hostingEnvironment);

            _materiauxAmeliorationPersonnagesService.Create(dto.ToBLL(relativePath));
            return Ok();

        }
    }
}
