using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    //Factory pattern
    public class DocumentFactory
    {
        private static Dictionary<string, Document> docs =
            new Dictionary<string, Document>()
            {
                { "application/pdf", new Certificate() },
                { "application/png", new Certificate() },
                { "application/msword", new Word()},
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new Word()},
            };

        public Document Create(string docType)
        {
            //Replace if with polymorfism
            return docs[docType];
        }

    }
}
