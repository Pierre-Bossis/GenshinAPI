using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxAmeliorationPersonnagesController : ControllerBase
    {
        private readonly IMateriauxAmeliorationPersonnagesBLLService _materiauxAmeliorationPersonnagesService;

        public MateriauxAmeliorationPersonnagesController(IMateriauxAmeliorationPersonnagesBLLService materiauxAmeliorationPersonnagesService)
        {
            _materiauxAmeliorationPersonnagesService = materiauxAmeliorationPersonnagesService;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            MateriauxAmeliorationPersonnagesFormDTO dto = new MateriauxAmeliorationPersonnagesFormDTO()
            {
                Nom = form["Nom"][0],
                Source = form["Source"][0],
                Rarete = int.Parse(form["Rarete"][0])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _materiauxAmeliorationPersonnagesService.Create(dto.ToBLL());
            return Ok();

        }
    }
}
