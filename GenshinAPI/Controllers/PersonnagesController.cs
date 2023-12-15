using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Personnages;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Personnages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnagesController : ControllerBase
    {
        private readonly IPersonnagesBLLService _personnagesBLLService;

        public PersonnagesController(IPersonnagesBLLService personnagesBLLService)
        {
            _personnagesBLLService = personnagesBLLService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PersonnagesDTO> personnages = _personnagesBLLService.GetAll().Select(perso => perso.ToDto());
            return Ok(personnages);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            PersonnagesDTO personnage = _personnagesBLLService.GetByName(name).ToDto();

            if (personnage is not null) return Ok(personnage);
            return BadRequest("Rien trouvé");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            PersonnagesFormDTO dto = new PersonnagesFormDTO()
            {
                Nom = form["Nom"][0],
                OeilDivin = form["OeilDivin"][0],
                TypeArme = form["TypeArme"][0],
                Lore = form["Lore"][0],
                Nationalite = form["Nationalite"][0],
                TrailerYT = form["TrailerYT"][0],
                DateSortie = DateTime.Parse(form["DateSortie"][0]),
                Rarete = int.Parse(form["Rarete"][0]),
                Arme_Id = int.Parse(form["Arme_Id"][0]),
                MateriauxAmeliorationPersonnage_Id = int.Parse(form["MateriauxAmeliorationPersonnage_Id"]),
                Produit_Id = int.Parse(form["Produit_Id"])
            };

            dto.Portrait = ImageConverter.ImgConverter(Request.Form.Files[0]);
            dto.SplashArt = ImageConverter.ImgConverter(Request.Form.Files[1]);

            _personnagesBLLService.Create(dto.ToBLL());

            return Ok();

        }
    }
}
