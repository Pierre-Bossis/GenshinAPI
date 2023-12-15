using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Produits;
using GenshinAPI.Tools;
using GenshinAPI.Tools.Mappers.Armes;
using GenshinAPI.Tools.Mappers.Produits;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IProduitsBLLService _produitsService;

        public ProduitsController(IProduitsBLLService produitsService)
        {
            _produitsService = produitsService;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            ProduitsFormDTO dto = new ProduitsFormDTO()
            {
                Nom = form["Nom"][0],
                Source = form["Source"][0],
                Rarete = int.Parse(form["Rarete"][0])
            };

            dto.Icone = ImageConverter.ImgConverter(Request.Form.Files[0]);

            _produitsService.Create(dto.ToBLL());
            return Ok();

        }
    }
}
