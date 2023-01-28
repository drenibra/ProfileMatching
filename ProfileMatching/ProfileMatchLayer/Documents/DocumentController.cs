using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController:Controller
    {
        private readonly IDocuments contract;
        public DocumentController(IDocuments contract) { 
            this.contract = contract;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            return Ok(await contract.GetAllDocuments());
        }

        [HttpPost]
        public async Task<JsonResult> SaveDocuments(List<IFormFile> file, int id)
        {
           await contract.SaveDocumentsAsync(file, id);
            return new JsonResult("Saved!");
        }
    }
}
