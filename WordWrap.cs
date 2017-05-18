using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Program
{
    public static class WordWrap

    {
        public static string LineSeparator { get; } = "\n";

        public static string Umbrechen(string text, int maxZeilenlänge)
        {
            var wörter = WörterUmbrechen(text);
            return AusgabetextAufbereiten(wörter);
        }

        public static string[] WörterUmbrechen(string wortString)
        {
            wortString = Regex.Replace(wortString, @"\s", " "); // Remove also not explicitly-treated whitespace characters
            var wörter = wortString.Split(new char[] {' ','\t','\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
            return wörter;
        }

        public static String[] WorteDerZeileBestimmen(List<String> wortliste, int maxLength)
        {
            const int wordSeparatorLength = 1;
            var wortgruppe = new List<String>();
            int currentLineLength = 0;
            while (wortliste.Count >0)
            {
                String currentWord = wortliste[0];

                int newLineLength = currentLineLength + currentWord.Length;
                bool inTheMiddleOfTheLine = currentLineLength > 0;
                if (inTheMiddleOfTheLine)
                {
                    newLineLength += wordSeparatorLength;
                }

                bool lineCompleted = newLineLength > maxLength;
                if (lineCompleted)
                {
                    break;
                }

                wortgruppe.Add(currentWord);
                wortliste.RemoveAt(0);
                currentLineLength = newLineLength;
            }
            return wortgruppe.ToArray();
        }

        public static string[][] WorteZusammenfassenProZeile(string[] wörter, int maxLength)
        {
            List<String> wortliste=wörter.ToList();
            var zeilenCollection= new List<string[]>();
            while (wortliste.Count > 0)
            {
                zeilenCollection.Add( WorteDerZeileBestimmen(wortliste, maxLength));
            }

            return zeilenCollection.ToArray();
        }

        public static String[] WortGruppenBestimmen(string[] wortliste, int wortSuchBeginnIndex, int maxLength)
        {
            const int wordSeparatorLength = 1;
            var wortgruppe = new List<String>();
            int currentLineLength = 0;
            int iWordCursor = wortSuchBeginnIndex;
            while (iWordCursor < wortliste.Count())
            {
                String currentWord = wortliste[iWordCursor];

                int lineLongerCountForCurrentWord = currentLineLength + currentWord.Length;
                bool zeilenAnfang = currentLineLength == 0;
                if (false == zeilenAnfang)
                {
                    lineLongerCountForCurrentWord += wordSeparatorLength;
                }

                bool lineCompletedSoDoNotIncludeCurrentWord = lineLongerCountForCurrentWord > maxLength;
                if (lineCompletedSoDoNotIncludeCurrentWord)
                {
                    break;
                }

                wortgruppe.Add(currentWord);
                currentLineLength += lineLongerCountForCurrentWord;
                iWordCursor++;
            }
            return wortgruppe.ToArray();
        }

        public static string AusgabetextAufbereiten(string[] eingabe)
        {
            var ausgabeString = String.Join(LineSeparator, eingabe);
            return ausgabeString;
        }

        public static string Wrap(this string text, int maxZeilenlänge)
        {
            return Umbrechen(text, maxZeilenlänge);
        }

        #region Phils Code
        //public class Zeile
        //{
        //    const string WordSeparator = " ";

        //    public Zeile(string[] zeilenteile)
        //    {
        //        ZeilenText= String.Join(WordSeparator, zeilenteile);
        //    }

        //    public Zeile(string zeilenText)
        //    {
        //        ZeilenText = zeilenText;
        //    }

        //    public string ZeilenText { get; }
        //}
        //public static string[] BildeZeilenAusWortgruppenImmutable(string[] wörter, int maxLength)
        //{
        //    var zeilenCollection = new List<string>();
        //    int wortSuchBeginnIndex = 0;

        //    while (wortSuchBeginnIndex < wörter.Count())
        //    {
        //        string[] wortgruppe = WortGruppenBestimmen(wörter, wortSuchBeginnIndex, maxLength);
        //        int anzahlWörterInWortGruppe = wortgruppe.Count();
        //        wortSuchBeginnIndex += anzahlWörterInWortGruppe;

        //        var zeile = new Zeile(wortgruppe);

        //        Debug.Assert(anzahlWörterInWortGruppe > 0);
        //    }

        //    return zeilenCollection.ToArray();
        //}

        //public static Zeile[] ZeilenBildenAusWortgruppen(string[] wörter, int maxLength)
        //{
        //    List<String> eingangsWortliste = wörter.ToList();
        //    var zeilenCollection = new List<Zeile>();
        //    while (eingangsWortliste.Count > 0)
        //    {
        //        var wortgruppe = WorteDerZeileBestimmen(eingangsWortliste, maxLength);
        //        var zeile = new Zeile(wortgruppe);
        //        zeilenCollection.Add(zeile);
        //    }

        //    return zeilenCollection.ToArray();
        //}

        //[TestMethod]
        //public void In_Wordlist_a_b_c__ab_fitsInLine_with_maxLength_3()
        //{
        //    //Arrange
        //    String[] wortliste = new[] { "a", "b", "c" };
        //    int maxLength = 3;
        //    String[] expectedLines = new[] { "a b", "c" };

        //    //Act
        //    String[] resultLinesArray = WordWrap.BildeZeilenAusWortgruppenImmutable(wortliste, maxLength);

        //    //Assert
        //    CollectionAssert.AreEqual(expectedLines, resultLinesArray);

        //}

        //[TestMethod]
        //public void In_Wordlist_a_b_c__resultsIn_3_single_lines_with_maxLength_3()
        //{
        //    //Arrange
        //    String[] wortliste = new[] { "a", "b", "c" };
        //    int maxLength = 1;
        //    String[] expectedLines = new[] { "a", "b", "c" };

        //    //Act
        //    String[] resultLinesArray = WordWrap.BildeZeilenAusWortgruppenImmutable(wortliste, maxLength);

        //    //Assert
        //    CollectionAssert.AreEqual(expectedLines, resultLinesArray);

        //}

        #endregion Phils Code

    }
}