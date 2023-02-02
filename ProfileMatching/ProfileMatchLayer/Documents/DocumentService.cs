using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Helpers;
using ProfileMatching.Models;
using System.IO;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    public class DocumentService : IDocuments, IGetDocumetsByApplicantID
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment env;
        private FileSaver fileSaver;

        public DocumentService(ApplicationDbContext context, IWebHostEnvironment env) {
            this.context=context;
            this.env = env;
            fileSaver = new FileSaver(this.env);
        }

        public DocumentService(ApplicationDbContext context)
        {
            this.context=context;
        }
        public async Task<string> SaveDocumentsAsync(List<IFormFile> files, string id)
        {
            string path = "assests/documents";
            try
            {
                foreach (IFormFile file in files)
                {
                    DocumentFactory d = new DocumentFactory();
                    Document document = d.Create(file.ContentType);
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    document.Name = fileName;
                    document.Extension = file.ContentType;
                    document.SavedPath = path;
                    document.ApplicantId = id;
                    document.Size = (int)file.Length;
                    document.Update();

                    //ruan te dhenat per file ne databaze
                    context.Documents.Add(document);
                    await context.SaveChangesAsync();
                    //ruan file ne folderin wwwroot
                    await fileSaver.FileSaveDocsAsync(file, path, fileName);
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

        public List<Document> GetDocumentsByApplicantId(string id)
        {
            List<Document> documents = new List<Document>();
            foreach(Document d in context.Documents)
            {
                if(d.ApplicantId.Equals(id))
                {
                    documents.Add(d);
                }
            }
            return documents;
        }
    }
}
