using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.MatsAmelioPersosArmes;
using GenshinAPI.Models.Personnages;
using GenshinAPI.Models.Personnages.Aptitudes;
using GenshinAPI.Models.Personnages.Constellations;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Models.Personnages.MateriauxElevationPersonnages;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes;
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
        private readonly IPersonnages_MateriauxElevationPersonnagesBLLService _getMatsElevationService;
        private readonly IPersonnages_MatsAmelioPersosArmesBLLService _getMatsAmelioPersosArmesService;
        private readonly IConstellationsBLLService _constellationsService;
        private readonly IAptitudesBLLService _aptitudesService;

        public PersonnagesController(IPersonnagesBLLService personnagesBLLService, IPersonnages_LivresAptitudeBLLService getLivresService,
                                     IPersonnages_MateriauxElevationPersonnagesBLLService getMatsElevationService,
                                     IPersonnages_MatsAmelioPersosArmesBLLService getMatsAmelioPersosArmesService,
                                     IConstellationsBLLService constellationsService,
                                     IAptitudesBLLService aptitudesService)
        {
            _personnagesBLLService = personnagesBLLService;
            _getLivresService = getLivresService;
            _getMatsElevationService = getMatsElevationService;
            _getMatsAmelioPersosArmesService = getMatsAmelioPersosArmesService;
            _constellationsService = constellationsService;
            _aptitudesService = aptitudesService;
        }
        #region Personnages
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
            IEnumerable<LivresAptitudeDTO?> livres = GetLivresAptitude(personnage.Id);
            IEnumerable<MateriauxElevationPersonnagesDTO> matsElevation = GetMateriauxElevationPersos(personnage.Id);
            IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> matsAmelioPersosArmes = GetMateriauxAmeliorationPersosArmes(personnage.Id);

            if (personnage is not null) return Ok(new { personnage, livres, matsElevation, matsAmelioPersosArmes });
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            PersonnagesDTO personnage = _personnagesBLLService.GetById(id).ToDto();
            IEnumerable<LivresAptitudeDTO?> livres = GetLivresAptitude(personnage.Id);
            IEnumerable<MateriauxElevationPersonnagesDTO> matsElevation = GetMateriauxElevationPersos(personnage.Id);
            IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> matsAmelioPersosArmes = GetMateriauxAmeliorationPersosArmes(personnage.Id);

            if (personnage is not null) return Ok(new { personnage, livres, matsElevation, matsAmelioPersosArmes });
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

            //gérer la reception de la liste d'id des livres d'aptitude
            var selectedLivres = form["SelectedLivres[]"];
            List<int> selectedLivresList = selectedLivres.Select(int.Parse).ToList();

            //gérer la reception de la liste d'id des materiaux elevation personnages
            var selectedMatsElevationPersonnages = form["SelectedMatsElevation[]"];
            List<int> selectedMatsElevPersosListe = selectedMatsElevationPersonnages.Select(int.Parse).ToList();

            //gérer la reception de la liste d'id des materiaux amelioration personnages et armes
            var selectedMatsAmelio = form["SelectedMatsAmelioPersosArmes[]"];
            List<int> selectedMatsAmelioListe = selectedMatsAmelio.Select(int.Parse).ToList();


            _personnagesBLLService.Create(dto.ToBLL(), selectedLivresList, selectedMatsElevPersosListe, selectedMatsAmelioListe);

            return Ok();

        }

        #region Private Methods
        //Méthode privée appel liste livres d'aptitude
        private IEnumerable<LivresAptitudeDTO> GetLivresAptitude(int personnageId)
        {
            return _getLivresService.GetLivres(personnageId).Select(livre => livre.ToDto()) ?? Enumerable.Empty<LivresAptitudeDTO>(); ;
        }
        //Méthode privée appel liste materiaux elevation
        private IEnumerable<MateriauxElevationPersonnagesDTO> GetMateriauxElevationPersos(int personnageId)
        {
            return _getMatsElevationService.GetMateriauxElevation(personnageId).Select(mat => mat.ToDto()) ?? Enumerable.Empty<MateriauxElevationPersonnagesDTO>(); ;
        }
        //Méthode privée appel liste materiaux amelioration personnages/armes
        private IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> GetMateriauxAmeliorationPersosArmes(int personnageId)
        {
            return _getMatsAmelioPersosArmesService.GetMateriauxAmelioration(personnageId).Select(mat => mat.ToDto()) ?? Enumerable.Empty<MateriauxAmeliorationPersonnagesEtArmesDTO>();
        }
        #endregion

        #endregion

        #region Constellations

        [HttpGet("{id:int}/constellations")]
        public IActionResult GetConstellations(int id)
        {
            IEnumerable<ConstellationsDTO?> constellations = _constellationsService.GetAll(id).Select(c => c.ToDto());

            return Ok(constellations);
        }

        [HttpPost("create/constellation")]
        public async Task<IActionResult> CreateConstellation()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            ConstellationsFormDTO dto = new ConstellationsFormDTO()
            {
                Nom = form["Nom"][0],
                Description = form["Description"][0],
                Personnage_Id = int.Parse(form["Personnage_Id"])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _constellationsService.Create(dto.ToBLL());

            return Ok();
        }

        #endregion

        #region Aptitudes
        [HttpGet("{id:int}/aptitudes")]
        public IActionResult GetAptitudes(int id)
        {
            IEnumerable<AptitudesDTO?> aptitudes = _aptitudesService.GetAll(id).Select(c => c.ToDto());

            return Ok(aptitudes);
        }

        [HttpPost("create/aptitude")]
        public async Task<IActionResult> CreateAptitude()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            AptitudesFormDTO dto = new AptitudesFormDTO()
            {
                Nom = form["Nom"][0],
                Description = form["Description"][0],
                IsAptitudeCombat = bool.Parse(form["IsAptitudeCombat"][0]),
                Personnage_Id = int.Parse(form["Personnage_Id"])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _aptitudesService.Create(dto.ToBLL());

            return Ok();
        }
        #endregion
    }
}