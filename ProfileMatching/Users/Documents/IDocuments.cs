using ProfileMatching.Models;

namespace ProfileMatching.Users.Documents
{
    public interface IDocuments
    {
        Task<string> SaveDocumentsAsync(List<IFormFile> file, string id);
        Task<List<Document>> GetAllDocuments();
    }
}
