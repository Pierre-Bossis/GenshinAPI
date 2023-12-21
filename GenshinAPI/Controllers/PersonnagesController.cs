using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.Personnages;
using GenshinAPI.Models.Personnages.LivresAptitude;
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
        private readonly IPersonnages_LivresAptitudeBLLService _getLivresService;

        public PersonnagesController(IPersonnagesBLLService personnagesBLLService, IPersonnages_LivresAptitudeBLLService getLivresService)
        {
            _personnagesBLLService = personnagesBLLService;
            _getLivresService = getLivresService;
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
            IEnumerable<LivresAptitudeDTO?> livres = GetMateriauxElevationArmes(personnage.Id);

            if (personnage is not null && livres is not null) return Ok(new {personnage,livres});
            return BadRequest("Rien trouvé");
        }

        [HttpGet("nationalite/{nationalite}")]
        public IActionResult GetByNationalite(string nationalite)
        {
            IEnumerable<PersonnagesDTO> personnages = _personnagesBLLService.GetByNationalite(nationalite).Select(perso => perso.ToDto());

            if (personnages is not null) return Ok(personnages);
            return BadRequest("rien trouvé");
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
                MateriauxAmeliorationPersonnage_Id = int.Parse(form["MateriauxAmeliorationPersonnage_Id"]),
                Produit_Id = int.Parse(form["Produit_Id"])
            };

            //gérer le cas ou le personnage n'a pas d'arme signature
            int parsedArmeId = 0;
            if (int.TryParse(form["Arme_Id"][0], out parsedArmeId))
            {
                dto.Arme_Id = parsedArmeId;
            }

            dto.Portrait = ImageConverter.ImgConverter(Request.Form.Files[0]);
            dto.SplashArt = ImageConverter.ImgConverter(Request.Form.Files[1]);

            //gérer la reception de la liste d'id des materiaux elevation d'armes
            var selectedLivres = form["SelectedLivres[]"];
            List<int> selectedLivresList = selectedLivres.Select(int.Parse).ToList();

            _personnagesBLLService.Create(dto.ToBLL(), selectedLivresList);

            return Ok();

        }

        //Méthode privée appel liste materiaux elevation arme (GetByName et GetById)
        private IEnumerable<LivresAptitudeDTO> GetMateriauxElevationArmes(int personnageId)
        {
            return _getLivresService.GetLivres(personnageId).Select(livre => livre.ToDto()) ?? Enumerable.Empty<LivresAptitudeDTO>(); ;
        }
    }
}
