using System.Linq;

namespace SimpleMVC.App.MVC.Extensions
{
    public static class StringExtentions
    {
        public static string ToUpperFirst(this string str)
        {
            if (str != null)
            {
                str = str.First().ToString().ToUpper() + str.Substring(1);
            }

            return str;
        }
    }
}
