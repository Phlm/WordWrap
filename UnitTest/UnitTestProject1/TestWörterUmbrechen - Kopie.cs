using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    public class TestWörterUmbrechen
    {
        TestTextumbruch _testTextumbruch;

        public TestWörterUmbrechen(TestTextumbruch testTextumbruch)
        {
            _testTextumbruch = testTextumbruch;
        }

        //[TestMethod]
        //public void Textumbruch_abc_mit_mehereren_Leerzeichen_ergibt_abc_Zeilen()
        //{
        //    //Arrange
        //    string beispiel = $"a  b  c  ";
        //    var zeilenArray = new string[] { "a", "b", "c" };
        //    //Act
        //    string[] ergebnis = _testTextumbruch._textUmbruch.WörterUmbrechen(beispiel);
        //    //Assert
        //    CollectionAssert.AreEqual(zeilenArray, ergebnis);
        //}
    }
}