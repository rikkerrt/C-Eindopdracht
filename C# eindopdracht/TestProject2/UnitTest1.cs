using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientWinForm;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        Form1 winform = new ClientWinForm.Form1();
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Dikke kanker");
        }
    }
}