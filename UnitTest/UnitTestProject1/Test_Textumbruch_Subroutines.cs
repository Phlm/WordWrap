using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using static Program.WordWrap;
using static System.Environment;
// ReSharper disable All

namespace UnitTestWordWrap
{
    [TestClass]
    public class Test_TextUmbruch_Subroutines
    {

        [TestMethod]
        public void Mixtest_WörterUmbrechen()
        {
            //Arrange
            string eingabeString = $"a\nb \nc {NewLine}d,\n";
            string[] wunschergebnis = new string[] {"a","b","c","d,"};
            //Act
            var ergebnisText = WörterUmbrechen(eingabeString);
            //Assert
            CollectionAssert.AreEqual(wunschergebnis, ergebnisText);
        }

        [TestMethod]
        public void MehrereLeerzeichen_WörterUmbrechen()
        {
            //Arrange
            string eingabeString = " a  bb   cc d  ";
            string[] wunschergebnis = new string[] { "a", "bb", "cc", "d" };
            //Act
            var ergebnisText = WörterUmbrechen(eingabeString);
            //Assert
            CollectionAssert.AreEqual(wunschergebnis, ergebnisText);
        }

        [TestMethod]
        public void Kommata_WörterUmbrechen()
        {
            //Arrange
            string eingabeString = "a  ,b c,  , d,  ";
            string[] wunschergebnis = new string[] { "a", ",b", "c,", "," , "d," };
            //Act
            var ergebnisText = WörterUmbrechen(eingabeString);
            //Assert
            CollectionAssert.AreEqual(wunschergebnis, ergebnisText);
        }


        [TestMethod]
        public void Textumbruch_abc_mit_mehereren_Leerzeichen_ergibt_abc_Zeilen()
        {
            // Arrange
            string beispiel = "a  b  c  ";
            var zeilenArray = new string[] { "a", "b", "c" };
            // Act
            var ergebnis = WörterUmbrechen(beispiel);
            // Assert
            CollectionAssert.AreEqual(zeilenArray, ergebnis);
        }
    }
}
