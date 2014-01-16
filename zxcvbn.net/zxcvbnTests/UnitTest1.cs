using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zxcvbn.net;

namespace zxcvbnTests
{
    [TestClass]
    public class UnitTest1
    {
        String lamePassword = "Passw0rd1!";

        [TestMethod]
        public void HelloCode()
        {
            Assert.IsTrue(true,"Hello world unit test");
        }


        [TestMethod]
        public void CanSetAndGetGlobalVariable()
        {
            String lameString = "Passw0rd1!";
            Zxcvbn zxcvbn = new Zxcvbn();

            int zero = 0;
            dynamic actual = zxcvbn.Test(lamePassword);
            Assert.AreEqual(lameString, actual.ToString(), "Hello world unit test");
        }

        [TestMethod]
        public void ScoreIsZeroWithLamePassword()
        {
            String lamePassword = "Passw0rd1!";
           Zxcvbn zxcvbn = new Zxcvbn();

            int zero = 0;
            int expected = zxcvbn.Score(lamePassword);
            Assert.AreEqual(zero, expected, "Hello world unit test");
        }

    }
}
