using Genshin.BLL.Interfaces;
using GenshinAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_materiauxElevationArmesService.GetAll());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] MateriauxElevationArmesFormDTO form)
        {
            if (!ModelState.IsValid) return BadRequest(form);
            //traitement pour create
            return Ok();
        }
    }
}
