namespace MauiApp1.Helpers
{
    public class DbHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return FileSystem.AppDataDirectory + fileName;
        }
    }
}
