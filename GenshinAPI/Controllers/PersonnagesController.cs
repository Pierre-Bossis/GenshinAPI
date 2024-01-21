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
using Microsoft.AspNetCore.Authorization;
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
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PersonnagesController(IPersonnagesBLLService personnagesBLLService, IPersonnages_LivresAptitudeBLLService getLivresService,
                                     IPersonnages_MateriauxElevationPersonnagesBLLService getMatsElevationService,
                                     IPersonnages_MatsAmelioPersosArmesBLLService getMatsAmelioPersosArmesService,
                                     IConstellationsBLLService constellationsService, IWebHostEnvironment hostingEnvironment,
                                     IAptitudesBLLService aptitudesService)
        {
            _personnagesBLLService = personnagesBLLService;
            _getLivresService = getLivresService;
            _getMatsElevationService = getMatsElevationService;
            _getMatsAmelioPersosArmesService = getMatsAmelioPersosArmesService;
            _constellationsService = constellationsService;
            _aptitudesService = aptitudesService;
            _hostingEnvironment = hostingEnvironment;
        }
        #region Personnages
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PersonnagesListDTO> personnages = _personnagesBLLService.GetAll().Select(perso => perso.ToDtoList());
            return Ok(personnages);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            PersonnagesDTO personnage = _personnagesBLLService.GetByName(name).ToDto();
            if (personnage is not null)
            {
                IEnumerable<LivresAptitudeDTO?> livres = GetLivresAptitude(personnage.Id);
                IEnumerable<MateriauxElevationPersonnagesDTO> matsElevation = GetMateriauxElevationPersos(personnage.Id);
                IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> matsAmelioPersosArmes = GetMateriauxAmeliorationPersosArmes(personnage.Id);

                return Ok(new { personnage, livres, matsElevation, matsAmelioPersosArmes });
            }
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

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] PersonnagesFormDTO dto)
        {
            string relativePathPortrait = await ImageConverter.SaveIcone(dto.Icone, "Personnages/"+dto.Nom, _hostingEnvironment);
            string relativePathSplashArt = await ImageConverter.SaveIcone(dto.Image, "Personnages/" + dto.Nom, _hostingEnvironment);

            //gérer le cas ou le personnage n'a pas d'arme signature
            //int parsedArmeId = 0;
            //if (int.TryParse(form["Arme_Id"][0], out parsedArmeId))
            //{
            //    dto.Arme_Id = parsedArmeId;
            //}


            _personnagesBLLService.Create(dto.ToBLL(relativePathPortrait,relativePathSplashArt), dto.SelectedLivres, dto.SelectedMatsElevation, dto.SelectedMatsAmelioPersosArmes);

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

        [Authorize("adminPolicy")]
        [HttpPost("create/constellation")]
        public async Task<IActionResult> CreateConstellation([FromForm] ConstellationsFormDTO dto)
        {
            PersonnagesDTO perso = _personnagesBLLService.GetById(dto.Personnage_Id).ToDto();

            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "Personnages/"+perso.Nom+"/Constellations", _hostingEnvironment);

            _constellationsService.Create(dto.ToBLL(relativePath));
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

        [Authorize("adminPolicy")]
        [HttpPost("create/aptitude")]
        public async Task<IActionResult> CreateAptitude([FromForm] AptitudesFormDTO dto)
        {
            PersonnagesDTO perso = _personnagesBLLService.GetById(dto.Personnage_Id).ToDto();

            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "Personnages/" + perso.Nom + "/Aptitudes", _hostingEnvironment);

            _aptitudesService.Create(dto.ToBLL(relativePath));
            return Ok();
        }
        #endregion
    }
}