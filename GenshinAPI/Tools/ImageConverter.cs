namespace GenshinAPI.Tools
{
    public static class ImageConverter
    {
        public static byte[] ImgConverter(IFormFile file)
        {
            using (MemoryStream memoryStream1 = new MemoryStream())
            {
                file.CopyTo(memoryStream1);
                return memoryStream1.ToArray();
            }
        }
    }
}
