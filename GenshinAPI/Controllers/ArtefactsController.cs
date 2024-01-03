using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Artefacts;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Tools.Mappers.Artefacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtefactsController : ControllerBase
    {
        private readonly IArtefactsBLLService _artefactsService;

        public ArtefactsController(IArtefactsBLLService artefactsService)
        {
            _artefactsService = artefactsService;
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
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            Guid newName = Guid.NewGuid();
            string fileName = newName.ToString() + form.Files[0].FileName;

            //Creer le dossier de réception si inéxistant
            if (!Directory.Exists("Artefacts")) Directory.CreateDirectory("Artefacts");

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Artefacts/", fileName);

            string path = Directory.GetCurrentDirectory() + "Artefacts/" + fileName;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(fs);
                //return this.StatusCode(200, "https://localhost:44375/upload/" + fileName);
            }
            ArtefactsFormDTO dto = new ArtefactsFormDTO()
            {
                Nom = form["Nom"][0],
                NomSet = form["NomSet"][0],
                Type = form["Type"][0],
                Bonus2Pieces = form["Bonus2Pieces"][0],
                Bonus4Pieces = form["Bonus4Pieces"][0],
                ImagePath = filePath,
                Source = form["Source"][0]
            };


            _artefactsService.create(dto.ToBLL());
            return Ok();
        }
    }
}
