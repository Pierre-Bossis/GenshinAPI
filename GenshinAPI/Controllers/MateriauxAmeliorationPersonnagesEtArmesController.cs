using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.MatsAmelioPersosArmes;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxAmeliorationPersonnagesEtArmesController : ControllerBase
    {
        private readonly IMateriauxAmeliorationPersonnagesEtArmesBLLService _serv;

        public MateriauxAmeliorationPersonnagesEtArmesController(IMateriauxAmeliorationPersonnagesEtArmesBLLService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> mats = _serv.GetAll().Select(mat => mat.ToDto());
            return Ok(mats);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            MateriauxAmeliorationPersonnagesEtArmesDTO mat = _serv.GetByName(name).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            MateriauxAmeliorationPersonnagesEtArmesDTO mat = _serv.GetById(id).ToDto();

            if (mat is not null) return Ok(mat);
            return BadRequest("Rien trouvé");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            MateriauxAmeliorationPersonnagesEtArmesFormDTO dto = new MateriauxAmeliorationPersonnagesEtArmesFormDTO()
            {
                Nom = form["Nom"][0],
                Source = form["Source"][0],
                Rarete = int.Parse(form["Rarete"][0])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _serv.Create(dto.ToBLL());
            return Ok();

        }
    }
}
