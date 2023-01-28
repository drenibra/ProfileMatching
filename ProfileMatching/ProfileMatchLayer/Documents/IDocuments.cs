﻿using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Documents
{
    public interface IDocuments
    {
        Task<string> SaveDocumentsAsync(List<IFormFile> file, int id);
        Task<List<Document>> GetAllDocuments();
    }
}
