using Genshin.BLL.Interfaces;
using GenshinAPI.Tools.Mappers.Armes;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using GenshinAPI.Tools;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using Microsoft.AspNetCore.Authorization;
using Genshin.DAL.DataAccess;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxElevationArmesController : ControllerBase
    {
        private readonly IMateriauxElevationArmesBLLService _materiauxElevationArmesService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MateriauxElevationArmesController(IMateriauxElevationArmesBLLService MateriauxElevationArmesService, IWebHostEnvironment hostingEnvironment)
        {
            _materiauxElevationArmesService = MateriauxElevationArmesService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MateriauxElevationArmesDTO> mats = _materiauxElevationArmesService.GetAll().Select(mat => mat.ToDto());
            return Ok(mats);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
           MateriauxElevationArmesDTO mat = _materiauxElevationArmesService.GetByName(name).ToDto();

           if(mat is not null) return Ok(mat);
           return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] MateriauxElevationArmesFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "MateriauxElevationArmes", _hostingEnvironment);

            _materiauxElevationArmesService.Create(dto.ToBLL(relativePath));
            return Ok();

        }

    }
}
