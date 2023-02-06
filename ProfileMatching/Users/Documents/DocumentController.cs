using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProfileMatching.Users.Documents
{
    //[EnableCors("appcors")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DocumentController : Controller
    {
        private IWebHostEnvironment _env;
        //private FileSaver fileSaver;
        private readonly IDocuments contract;
        public DocumentController(IDocuments contract, IWebHostEnvironment _env)
        {
            this.contract = contract;
            this._env = _env;

        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            return Ok(await contract.GetAllDocuments());
        }

        [HttpPost]
        public async Task<JsonResult> SaveDocuments(List<IFormFile> file, string id)
        {
            await contract.SaveDocumentsAsync(file, id);
            return new JsonResult("Saved!");
        }
        /*
        [HttpGet("Files")]
        public IActionResult GetFiles()
        {
            Document document= new Document();
            var displayImg = Path.Combine(_env.WebRootPath, "assests/documents");
            DirectoryInfo directoryInfo= new DirectoryInfo(displayImg);
            FileInfo[] files = directoryInfo.GetFiles();

            return View(files);
        }*/
    }
}
