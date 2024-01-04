using Genshin.BLL.Interfaces;
using GenshinAPI.Models.Artefacts;
using GenshinAPI.Models.Personnages.LivresAptitude;
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
        public async Task<IActionResult> Create()
        {
            HttpRequest req = HttpContext.Request;
            var form = await Request.ReadFormAsync();

            Guid newName = Guid.NewGuid();
            string fileName = newName.ToString() + form.Files[0].FileName;

            string uploadsFolder = "Assets/Artefacts";
            string relativeUploadsPath = Path.Combine(uploadsFolder, fileName);

            string absoluteUploadsPath = Path.Combine(_hostingEnvironment.ContentRootPath, relativeUploadsPath);

            if (!Directory.Exists(Path.GetDirectoryName(absoluteUploadsPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(absoluteUploadsPath));
            }

            using (FileStream fs = new FileStream(absoluteUploadsPath, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(fs);
            }

            // Obtention du chemin relatif à partir du chemin absolu
            string relativePath = Path.Combine("", relativeUploadsPath).Replace('\\', '/'); // Chemin relatif avec des slashs

            ArtefactsFormDTO dto = new ArtefactsFormDTO()
            {
                Nom = form["Nom"][0],
                NomSet = form["NomSet"][0],
                Type = form["Type"][0],
                Bonus2Pieces = form["Bonus2Pieces"][0],
                Bonus4Pieces = form["Bonus4Pieces"][0],
                ImagePath = relativePath, // Utilisation du chemin relatif
                Source = form["Source"][0]
            };

            _artefactsService.create(dto.ToBLL());
            return Ok();
        }
    }
}
