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
        readonly Program.TextUmbruch _textumbruch;

        public TestTextumbruch()
        {
            _textumbruch = new Program.TextUmbruch();
        }

        [TestMethod]
        public void Textumbruch_abc_ergibt_abc()
        {
            //Arrange
            string beispiel = "a\nb\nc";
            string wunschergebnis = "a\nb\nc";
            int zeilenLänge = 1;
            //Act
            var ergebnisText = _textumbruch.Umbrechen(beispiel, zeilenLänge);
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

        [TestMethod]
        public void Textumbruch2_abc_ergibt_abc()
        {
            //Arrange
            string beispiel = "a\nb\nc";
            string wunschergebnis = "a\nb\nc";
            int zeilenLänge = 1;
            //Act
            var ergebnisText = _textumbruch.Umbrechen(beispiel, zeilenLänge);
            //Assert
            Assert.AreEqual<string>(wunschergebnis, ergebnisText);
        }

    }
}
