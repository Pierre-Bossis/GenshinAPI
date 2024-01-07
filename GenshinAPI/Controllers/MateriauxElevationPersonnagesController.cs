using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.Personnages.MateriauxElevationPersonnages;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxElevationPersonnagesController : ControllerBase
    {
        private readonly IMateriauxElevationPersonnagesBLLService _service;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MateriauxElevationPersonnagesController(IMateriauxElevationPersonnagesBLLService service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MateriauxElevationPersonnagesDTO> mats = _service.GetAll().Select(mat => mat.ToDto());
            return Ok(mats);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            MateriauxElevationPersonnagesDTO mat = _service.GetByName(name).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            MateriauxElevationPersonnagesDTO mat = _service.GetById(id).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] MateriauxElevationPersonnagesFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "MateriauxElevationPersonnages", _hostingEnvironment);

            _service.Create(dto.ToBLL(relativePath));
            return Ok();    

        }
    }
}
