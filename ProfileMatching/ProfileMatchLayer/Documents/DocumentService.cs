using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.ProfileMatchLayer.Documents.Helpers;
using System.IO;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    public class DocumentService : IDocuments
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment _env;
        private FileSaver fileSaver;

        public DocumentService(ApplicationDbContext context, IWebHostEnvironment _env) {
            this.context=context;
            this._env = _env;
            fileSaver = new FileSaver(_env);
        }
        public async Task<string> SaveDocumentsAsync(List<IFormFile> files, int id)
        {
            try
            {
                foreach (IFormFile file in files)
                {
                    DocumentFactory d = new DocumentFactory();
                    Document document = d.Create(file.ContentType);
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    document.Name = fileName;
                    document.Extension = file.ContentType;
                    document.SavedPath = "assests / documents";
                    document.ApplicantId = id;
                    document.Size = (int)file.Length;
                    document.Update();

                    await fileSaver.FileSaveDocsAsync(file, "assests/documents", fileName);
                    context.Documents.Add(document);
                    await context.SaveChangesAsync();
                }
                return "Done!";
            }catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        public async Task<List<Document>> GetAllDocuments()
        {
            return await context.Documents.ToListAsync();
        }

        
    }
}
