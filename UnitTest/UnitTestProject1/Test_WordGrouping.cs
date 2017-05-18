using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Program;
// ReSharper disable All

namespace UnitTestWordWrap
{
    [TestClass]
    public class Test_WordGrouping
    {
        [TestMethod]
        public void lastWordConstitutesLine()
        {
            List<String> wortliste = new List<String>();
            wortliste.Add("c");
            int maxLength = 3;

            String[] expectedWortgruppe = new String[] { "c" };
            String[] expectedRemainingWortliste = new String[] { };

            String[] wortgruppe = WordWrap.WorteDerZeileBestimmen(wortliste, maxLength);

            CollectionAssert.AreEqual(wortliste.ToArray(), expectedRemainingWortliste);
            CollectionAssert.AreEqual(wortgruppe, expectedWortgruppe);
        }

        [TestMethod]
        public void wordgroupFitsExactlyInLine()
        {
            List<String> wortliste = new List<String>();
            wortliste.AddRange(new List<string> { "a", "b", "c" });
            int maxLength = 3;

            String[] expectedWortgruppe = new String[] { "a", "b" };
            String[] expectedRemainingWortliste = new String[] { "c" };

            String[] wortgruppe = WordWrap.WorteDerZeileBestimmen(wortliste, maxLength);

            CollectionAssert.AreEqual(wortliste.ToArray(), expectedRemainingWortliste);
            CollectionAssert.AreEqual(wortgruppe, expectedWortgruppe);
        }

        [TestMethod]
        public void wordlist_a_b_c_results_to_ab_fitInLine_with_maxLength_3()
        {
            //Arrange
            String[] wortliste = new[] { "a", "b", "c" };
            int maxLength = 3;
            String[][] expectedWortgruppen = new[] { new[] { "a", "b" }, new[] { "c" } };

            //Act
            String[][] wortgruppen = WordWrap.WorteZusammenfassenProZeile(wortliste, maxLength);

            //Assert
            CollectionAssert.AreEqual(wortgruppen[0], expectedWortgruppen[0]);
            CollectionAssert.AreEqual(wortgruppen[1], expectedWortgruppen[1]);
            Assert.AreEqual(2, wortgruppen.Length);

        }
        [TestMethod]
        public void wordlist_a_b_c_eachWordOneLine_with_maxLength_1()
        {
            //Arrange
            String[] wortliste = new[] { "a", "b", "c" };
            int maxLength = 1;
            String[][] expectedWortgruppen = new[] { new[] { "a" }, new[] { "b" }, new[] { "c" } };

            //Act
            String[][] wortgruppen = WordWrap.WorteZusammenfassenProZeile(wortliste, maxLength);

            //Assert
            CollectionAssert.AreEqual(wortgruppen[0], expectedWortgruppen[0]);
            CollectionAssert.AreEqual(wortgruppen[1], expectedWortgruppen[1]);
            CollectionAssert.AreEqual(wortgruppen[2], expectedWortgruppen[2]);
            Assert.AreEqual(3, wortgruppen.Length);

        }


    }
}
