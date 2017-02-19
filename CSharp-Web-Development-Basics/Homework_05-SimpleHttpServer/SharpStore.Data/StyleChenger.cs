using System.IO;
using System.Text;

namespace SharpStore.Data
{
    public class StyleChenger
    {
        public static string InsertStyle(string htmlPath, string stylePath)
        {
            StringBuilder htmlPage = new StringBuilder(File.ReadAllText(htmlPath));
            int headClosingIndex = htmlPage.ToString().IndexOf("</head>");
            htmlPage.Insert(headClosingIndex, $"<link href=\"{stylePath}\" rel=\"stylesheet\">");

            return htmlPage.ToString();
        }
    }
}
