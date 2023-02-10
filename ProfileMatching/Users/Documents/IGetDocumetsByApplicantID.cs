using ProfileMatching.Models;

namespace ProfileMatching.Users.Documents
{
    public interface IGetDocumetsByApplicantID
    {
        Task<List<Document>> GetDocumentsByApplicantId(string id);
    }
}
