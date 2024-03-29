﻿using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Entities;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.MatsAmelioPersosArmes;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Armes;
using GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Globalization;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmesController : ControllerBase
    {
        private readonly IArmesBLLService _armesService;
        private readonly IArmes_MateriauxElevationArmesBLLService _matsElevationService;
        private readonly IArmes_MatsAmelioPersosArmesBLLService _matsAmelioService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArmesController(IArmesBLLService armesService, IArmes_MateriauxElevationArmesBLLService matsElevationService, IArmes_MatsAmelioPersosArmesBLLService matsAmelioService,
                               IWebHostEnvironment hostingEnvironment)
        {
            _armesService = armesService;
            _matsElevationService = matsElevationService;
            _matsAmelioService = matsAmelioService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ArmesListDTO> armes = _armesService.GetAll().Select(arme => arme.ToDtoList());
            return Ok(armes);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            ArmesDTO? arme = _armesService.GetByName(name).ToDto();
            if (arme is not null)
            {
                IEnumerable<MateriauxElevationArmesDTO?> matsElevationArmes = GetMateriauxElevationArmes(arme.Id);
                IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> matsAmelioPersosArmes = GetMateriauxAmeliorationsArmes(arme.Id);

                return Ok(new { arme, matsElevationArmes, matsAmelioPersosArmes });
            }
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ArmesDTO arme = _armesService.GetById(id).ToDto();
            IEnumerable<MateriauxElevationArmesDTO> matsElevationArmes = GetMateriauxElevationArmes(arme.Id);
            IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> matsAmelioPersosArmes = GetMateriauxAmeliorationsArmes(arme.Id);

            if (arme is not null) return Ok(new { arme, matsElevationArmes, matsAmelioPersosArmes });
            return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ArmesFormDTO dto)
        {
            string relativePathIcone = await ImageConverter.SaveIcone(dto.Icone, "Armes/Icones", _hostingEnvironment);
            string relativePathImage = await ImageConverter.SaveIcone(dto.Image, "Armes/Images", _hostingEnvironment);

            //gérer la reception de la valeur décimale
            //dto.ValeurStatPrincipale = DecimalConverter.DecimalConvert(dto.ValeurStatPrincipale);

            //envoyer le DTO finalisé
            _armesService.Create(dto.ToBLL(relativePathIcone, relativePathImage), dto.SelectedMats, dto.selectedMatsAmelio);

            return Ok();

        }


        #region Private Methods
        //Méthode privée appel liste materiaux elevation arme (GetByName et GetById)
        private IEnumerable<MateriauxElevationArmesDTO> GetMateriauxElevationArmes(int armeid)
        {
            return _matsElevationService.GetMateriaux(armeid).Select(mat => mat.ToDto()) ?? Enumerable.Empty<MateriauxElevationArmesDTO>(); ;
        }
        //Méthode privée appel liste materiaux Amelioration Personnages et Armes (GetByName et GetById)
        private IEnumerable<MateriauxAmeliorationPersonnagesEtArmesDTO> GetMateriauxAmeliorationsArmes(int armeid)
        {
            return _matsAmelioService.GetMateriaux(armeid).Select(mat => mat.ToDto()) ?? Enumerable.Empty<MateriauxAmeliorationPersonnagesEtArmesDTO>(); ;
        }
        #endregion

    }
}
