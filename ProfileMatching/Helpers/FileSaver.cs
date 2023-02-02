namespace ProfileMatching.Helpers
{
    public class FileSaver
    {
        IWebHostEnvironment _env;

        public FileSaver(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task FileSaveDocsAsync(IFormFile file, string filePath, string fileName)
        {
            string route = Path.Combine(_env.WebRootPath, filePath);

            //nese directory nuk ekziston, e shton nja te re
            if (!Directory.Exists(route))
            {
                Directory.CreateDirectory(route);
            }

            string fileRoute = Path.Combine(route, fileName);
            // ruhet nje kopje e file ne wwwroot
            using (FileStream fs = File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fs);
            }

        }
    }
}
