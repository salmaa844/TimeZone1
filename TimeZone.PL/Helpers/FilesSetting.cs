namespace TimeZone.PL.Helpers
{
    public class FilesSetting
    {
        public static string UploadeFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);

            var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;

        }
        public static void Delete(string  fileName,string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);
            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
            }

        }
    }
}
