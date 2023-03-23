using Bloodonor.Interface;

namespace Bloodonor.Helpers
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _env;

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
        }


        public bool FileExist(string fileUrl)
        {
            if ((File.Exists(fileUrl)))
                return true;

            return false;
        }

        public void DeleteFile(string fileUrl)
        {
            if (File.Exists(_env.WebRootPath + $"/uploads/{fileUrl}"))
            {
                File.Delete(_env.WebRootPath + $"/uploads/{fileUrl}");
            }
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            bool exist = Directory.Exists(uploads);
            if (!exist)
                Directory.CreateDirectory(uploads);

            var fileName = file.FileName;

            if (fileName.EndsWith(".docx") || fileName.EndsWith(".doc"))
            {
                if (file == null || file.Length == 0)
                    return "null, Please select a file to upload";

                if (Path.GetExtension(file.FileName) != ".doc" && Path.GetExtension(file.FileName) != ".docx")
                    return "null, Invalid file format. Only Word documents are allowed.";

                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();

                    var filePath = Path.Combine(uploads, file.FileName);
                    File.WriteAllBytes(filePath, fileBytes);

                }
            }
            else
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }
            return "/uploads/" + fileName;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "projects");
            bool exist = Directory.Exists(uploads);
            if (!exist)
                Directory.CreateDirectory(uploads);

            var fileName = file.FileName;

            if (fileName.EndsWith(".docx") || fileName.EndsWith(".doc"))
            {
                if (file == null || file.Length == 0)
                    return "null, Please select a file to upload";

                if (Path.GetExtension(file.FileName) != ".doc" && Path.GetExtension(file.FileName) != ".docx")
                    return "null, Invalid file format. Only Word documents are allowed.";

                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                var filePath = Path.Combine(uploads, file.FileName);
                File.WriteAllBytes(filePath, fileBytes);
            }
            else
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }
            return "/projects/" + fileName;
        }
    }
}