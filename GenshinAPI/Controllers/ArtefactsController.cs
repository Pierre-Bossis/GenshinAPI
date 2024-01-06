using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Artefacts;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Models.Produits;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Artefacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtefactsController : ControllerBase
    {
        private readonly IArtefactsBLLService _artefactsService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArtefactsController(IArtefactsBLLService artefactsService, IWebHostEnvironment hostingEnvironment)
        {
            _artefactsService = artefactsService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<ArtefactsDTO> artefacts = _artefactsService.GetAll().Select(a => a.ToDto());
            return Ok(artefacts);
        }

        [HttpGet("{nomSet}")]
        public IActionResult GetBySet(string nomSet)
        {
            IEnumerable<ArtefactsDTO> artefacts = _artefactsService.GetBySet(nomSet).Select(a => a.ToDto());
            return Ok(artefacts);
        }

        [Authorize("adminPolicy")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ArtefactsFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone, "Artefacts", _hostingEnvironment);

            _artefactsService.create(dto.ToBLL(relativePath));
            return Ok();
        }
    }
}
