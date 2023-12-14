using Genshin.BLL.Interfaces;
using GenshinAPI.Models;
using GenshinAPI.Tools.Mappers.Armes;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxElevationArmesController : ControllerBase
    {
        private readonly IMateriauxElevationArmesBLLService _materiauxElevationArmesService;

        public MateriauxElevationArmesController(IMateriauxElevationArmesBLLService MateriauxElevationArmesService)
        {
            _materiauxElevationArmesService = MateriauxElevationArmesService;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            MateriauxElevationArmesFormDTO dto = new MateriauxElevationArmesFormDTO()
            {
                Nom = form["Nom"][0],
                Source = form["Source"][0],
                Rarete = int.Parse(form["Rarete"][0])
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormFile file = Request.Form.Files[0];
                file.CopyTo(memoryStream);
                dto.Icone = memoryStream.ToArray();
            }
            _materiauxElevationArmesService.Create(dto.ToBLL());
            return Ok();

        }

    }
}
