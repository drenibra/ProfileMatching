using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    public class DocumentService : IDocuments
    {
        private ApplicationDbContext context;
        public DocumentService(ApplicationDbContext context) {
            this.context=context;
        }
        public async Task<string> SaveDocumentsAsync(List<IFormFile> files, int id)
        {
            foreach(IFormFile file in files)
            {
                DocumentFactory d = new DocumentFactory();
                Document document = d.Create(file.ContentType);
                document.Name = file.FileName;
                document.Extension = file.ContentType;
                document.SavedPath = file.Headers.ToString();
                document.ApplicantId = id;
                document.Size =(int) file.Length;
                document.Update();
                
                context.Documents.Add(document);
                await context.SaveChangesAsync();
            }
            return "Done!";
        }


        public async Task<List<Document>> GetAllDocuments()
        {
            return await context.Documents.ToListAsync();
        }
    }
}
