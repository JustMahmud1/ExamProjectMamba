namespace ProjectMambaExam.Extensions
{
    public static class CreateFileExt
    {
        public static string CreateFile(this IFormFile file , string environment , string path)
        {
            string imagename = Guid.NewGuid() + file.FileName;
            string fullPath = Path.Combine(environment, path , imagename);
            using (FileStream fileStream = new FileStream(fullPath,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return imagename;
        }
    }
}
