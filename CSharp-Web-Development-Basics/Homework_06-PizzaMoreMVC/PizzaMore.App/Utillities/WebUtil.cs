using System.IO;

namespace PizzaMore.App.Utillities
{
    public static class WebUtil
    {
        public static string RetrieveFileContent(string path)
        {
            string content = File.ReadAllText(path);

            return content;
        }
    }
}
