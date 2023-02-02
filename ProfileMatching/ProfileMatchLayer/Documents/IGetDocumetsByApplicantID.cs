using ProfileMatching.Models;
using System.Net;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    public interface IGetDocumetsByApplicantID
    {
        List<Document> GetDocumentsByApplicantId(int id);
    }
}
