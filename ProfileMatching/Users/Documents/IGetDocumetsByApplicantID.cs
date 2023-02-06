using ProfileMatching.Models;

namespace ProfileMatching.Users.Documents
{
    public interface IGetDocumetsByApplicantID
    {
        List<Document> GetDocumentsByApplicantId(string id);
    }
}
