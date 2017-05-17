using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Program;
using static System.Environment;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTextumbruch
    {
        [TestMethod]
        public void Textumbruch_Akzeptanztest_Advent_Zeilenlänge_9()
        {
            //Arrange
            string beispiel= $"Es blaut die Nacht,{NewLine} die Sternlein blinken,{NewLine} Schneeflöcklein leis hernieder sinken.";
            string wunschergebnis= $"Es blaut{NewLine}die{NewLine}Nacht,{NewLine}die{NewLine}Sternlein{NewLine}blinken,Schneeflö{NewLine}cklein{NewLine}leis{NewLine}hernieder{NewLine}sinken.";
            int zeilenLänge = 9;
            var ergebnisText = Umbrechen(beispiel, zeilenLänge);
            //Act
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

     

        [TestMethod]
        public void Textumbruch_abc_ergibt_abc()
        {
            //Arrange
            string beispiel = $"a{NewLine}b{NewLine}c{NewLine}";
            string wunschergebnis = $"a{NewLine}b{NewLine}c";
            int zeilenLänge = 1;
            //Act
            var ergebnisText = Umbrechen(beispiel, zeilenLänge);
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

        [TestMethod]
        public void Textumbruch_Es_blaut_die_Nacht_9_Direkte_Einzelworte()
        {
            //Arrange
            string beispiel = $"Es blaut die Nacht,";
            string wunschergebnis = $"Es blaut{NewLine}die{NewLine}Nacht,";
            int zeilenLänge = 9;
            //Act
            var ergebnisText = Umbrechen(beispiel, zeilenLänge);
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

        


        private string Umbrechen(string text, int maxZeilenlänge)
        {
            var worte = text.Split(' ','\n','\r');
            StringBuilder textErgebnis = new StringBuilder(string.Empty);
            int cursor = 0;
            for (int i = 0; i < worte.Count(); i++)
            //foreach (var wort in worte)
            {
                string wort = worte[i];

                if (String.IsNullOrEmpty(wort))
                    continue;
                int anzufügendeLänge = i > 0 ? 1 : 0;
                if (cursor + wort.Length+ anzufügendeLänge <= maxZeilenlänge)
                {
                    if (anzufügendeLänge > 0)
                    {
                        textErgebnis.Append(' ');
                        cursor += anzufügendeLänge;
                    }
                    textErgebnis.Append(wort);
                    cursor += wort.Length;
                }
                else if (wort.Length <= maxZeilenlänge)
                {
                    textErgebnis.Append(NewLine).Append(wort);
                    cursor = wort.Length;
                }
                else
                {
                    textErgebnis.Append(wort.LeftChars(maxZeilenlänge)).Append(NewLine);
                    var newPart = wort.Substring(maxZeilenlänge);
                    textErgebnis.Append(newPart);
                    cursor = newPart.Length;
                }

            }
            return textErgebnis.ToString();

        }
    }
}
