using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Entities;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Armes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmesController : ControllerBase
    {
        private readonly IArmesBLLService _armesService;
        private readonly IArmes_MateriauxElevationArmesBLLService _serv;

        public ArmesController(IArmesBLLService armesService, IArmes_MateriauxElevationArmesBLLService serv)
        {
            _armesService = armesService;
            _serv = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ArmesDTO> armes = _armesService.GetAll().Select(arme => arme.ToDto());
            return Ok(armes);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            ArmesDTO? arme = _armesService.GetByName(name).ToDto();
            IEnumerable<MateriauxElevationArmesDTO?> matsElevationArmes = GetMateriauxElevationArmes(arme.Id);

            if (arme is not null && matsElevationArmes is not null) return Ok(new {arme, matsElevationArmes });
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ArmesDTO arme = _armesService.GetById(id).ToDto();
            IEnumerable<MateriauxElevationArmesDTO?> matsElevationArmes = GetMateriauxElevationArmes(arme.Id);

            if (arme is not null && matsElevationArmes is not null) return Ok(new { arme, matsElevationArmes });
            return BadRequest("Rien trouvé");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            //remplir DTO
            ArmesFormDTO dto = new ArmesFormDTO()
            {
                Nom = form["Nom"][0],
                TypeArme = form["TypeArme"][0],
                Description = form["Description"][0],
                NomStatPrincipale = form["NomStatPrincipale"][0],
                EffetPassif = form["EffetPassif"][0],
                ATQBase = int.Parse(form["ATQBase"][0]),
                Rarete = int.Parse(form["Rarete"][0]),
            };

            //gérer la reception de la valeur décimale
            dto.ValeurStatPrincipale = DecimalConverter.DecimalConvert(form["ValeurStatPrincipale"][0]);

            //gérer la conversion des images en byte[]
            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);
            dto.Image = ImageConverter.ImgConverter(Request.Form.Files[1]);

            //envoyer le DTO finalisé
            _armesService.Create(dto.ToBLL());

            return Ok();

        }



        //Méthode privée appel liste materiaux elevation arme (GetByName et GetById)
        private IEnumerable<MateriauxElevationArmesDTO> GetMateriauxElevationArmes(int armeid)
        {
           return _serv.GetMateriaux(armeid).Select(mat => mat.ToDto()) ?? Enumerable.Empty<MateriauxElevationArmesDTO>(); ;
        }

    }
}
