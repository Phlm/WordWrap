using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Program;
using static System.Environment;
// ReSharper disable All

namespace UnitTestProject1
{
    [TestClass]
    public class Test_Subroutines_TextUmbruch
    {
        readonly Program.TextUmbruch _textumbruch;

        public Test_Subroutines_TextUmbruch()
        {
            _textumbruch = new Program.TextUmbruch();
        }

        [TestMethod]
        public void Mixtest_WörterUmbrechen()
        {
            //Arrange
            string eingabeString = $"a\nb \nc {NewLine}d,\n";
            string[] wunschergebnis = new string[] {"a","b","c","d,"};
            //Act
            var ergebnisText = _textumbruch.WörterUmbrechen(eingabeString);
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
            var ergebnisText = _textumbruch.WörterUmbrechen(eingabeString);
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
            var ergebnisText = _textumbruch.WörterUmbrechen(eingabeString);
            //Assert
            CollectionAssert.AreEqual(wunschergebnis, ergebnisText);
        }
    }
}
