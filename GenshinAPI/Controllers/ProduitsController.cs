using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Produits;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Armes;
using GenshinAPI.Tools.Mappers.Produits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IProduitsBLLService _produitsService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProduitsController(IProduitsBLLService produitsService, IWebHostEnvironment hostingEnvironment)
        {
            _produitsService = produitsService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ProduitsDTO> produits = _produitsService.GetAll().Select(prod => prod.ToDto());
            return Ok(produits);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            ProduitsDTO produit = _produitsService.GetByName(name).ToDto();

            if (produit is not null) return Ok(produit);
            return BadRequest("Rien trouvé");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ProduitsDTO produit = _produitsService.GetById(id).ToDto();

            if (produit is not null) return Ok(produit);
            return BadRequest("Rien trouvé");
        }

        [Authorize("adminPolicy")]
        [Consumes("multipart/form-data")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProduitsFormDTO dto)
        {
            string relativePath = await ImageConverter.SaveIcone(dto.Icone,"Produits",_hostingEnvironment);

            _produitsService.Create(dto.ToBLL(relativePath));
            return Ok();

        }
    }
}
