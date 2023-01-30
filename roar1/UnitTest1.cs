using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using pr4;
using static pr4.Form1;

namespace roar1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "true", b="false";
            string ex = "true";
            yu y = new yu();
            string itog = y.prover(a,b);
            Assert.AreEqual(ex,itog);
        }
    }
}
