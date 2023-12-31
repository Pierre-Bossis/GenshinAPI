﻿using Genshin.BLL.Interfaces;
using Genshin.DAL.DataAccess;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;
using GenshinAPI.Models.MatsAmelioPersosArmes;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriauxAmeliorationPersonnagesEtArmesController : ControllerBase
    {
        private readonly IMateriauxAmeliorationPersonnagesEtArmesBLLService _serv;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MateriauxAmeliorationPersonnagesEtArmesController(IMateriauxAmeliorationPersonnagesEtArmesBLLService serv, IWebHostEnvironment hostingEnvironment)
        {
            _serv = serv;
            _hostingEnvironment = hostingEnvironment;
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

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] MateriauxAmeliorationPersonnagesEtArmesFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "MateriauxAmeliorationPersonnagesEtArmes", _hostingEnvironment);

            _serv.Create(dto.ToBLL(relativePath));
            return Ok();

        }
    }
}
