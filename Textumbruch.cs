using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Program
{
    public class TextUmbruch
    {
        public string Umbrechen(string text, int maxZeilenlänge)
        {
            var wörter = WörterUmbrechen(text);
            return AusgabetextAufbereiten(wörter);
        }

        public string[] WörterUmbrechen(string beispiel)
        {
            //var bereinigt = Regex.Replace(beispiel, "\\s", " ");
            var wörter = beispiel.Split(new char[] {' ','\t','\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
            return wörter;
        }

        public string AusgabetextAufbereiten(string[] eingabe)
        {
            StringBuilder ausgabeString = new StringBuilder("");
            foreach (var wort in eingabe)
            {
                ausgabeString.Append(wort).Append('\n');
            }

            return ausgabeString.ToString().TrimEnd();
        }

    }
}