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

namespace UnitTestWordWrap
{
    [TestClass]
    public class Test_Textumbruch
    {
        readonly string _lineSeparator=WordWrap.LineSeparator;

        [TestMethod]
        public void Textumbruch_abc_ergibt_abc()
        {
            //Arrange
            string text = "a\nb\nc";
            text = text.Replace(@"\n", _lineSeparator);
            string wunschergebnis = "a\nb\nc";
            wunschergebnis = wunschergebnis.Replace(@"\n", _lineSeparator);
            int maxZeilenLänge = 1;
            //Act
            var ergebnisText = WordWrap.Umbrechen(text, maxZeilenLänge);
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

        [TestMethod]
        public void In_Wordlist_a_b_c__ab_fitsInLine_with_maxLength_3()
        {
            //Arrange
            String[] wortliste = new[] { "a", "b", "c" };
            int maxLength = 3;
            String[] expectedLines = new[] { "a b" , "c" };

            //Act
            String[] resultLinesArray = WordWrap.BildeZeilenAusWortgruppenImmutable(wortliste, maxLength);

            //Assert
            CollectionAssert.AreEqual(expectedLines, resultLinesArray);

        }

        [TestMethod]
        public void In_Wordlist_a_b_c__resultsIn_3_single_lines_with_maxLength_3()
        {
            //Arrange
            String[] wortliste = new[] { "a", "b", "c" };
            int maxLength = 1;
            String[] expectedLines = new[] { "a", "b", "c" };

            //Act
            String[] resultLinesArray = WordWrap.BildeZeilenAusWortgruppenImmutable(wortliste, maxLength);

            //Assert
            CollectionAssert.AreEqual(expectedLines, resultLinesArray);

        }

    }
}
