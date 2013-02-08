using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ServantSoftware.Toolkit;

namespace Tests.ServantSoftwareToolkit
{
    [TestClass]
    public class EmailAddressValidatorFixture
    {
        [TestMethod]
        public void TestCanValidateAValidAddress()
        {
            IEmailAddressValidator obj = new EmailAddressValidator();

            Assert.IsTrue(obj.IsValid("test@test.com"));
        }

        [TestMethod]
        public void TestCanFailToValidateAInvalidAddress()
        {
            IEmailAddressValidator obj = new EmailAddressValidator();

            Assert.IsFalse(obj.IsValid("test@test.com."));
        }

        [TestMethod]
        public void TestCanFindInvalidAddress()
        {
            IEmailAddressValidator obj = new EmailAddressValidator();

            string[] results = obj.FindInvalidEmailAddress("test@test.com.;test@test.com;");

            Assert.IsTrue(results.Length == 1);
        }

        [TestMethod]
        public void TestCanFindCorrectInvalidAddress()
        {
            IEmailAddressValidator obj = new EmailAddressValidator();

            string[] results = obj.FindInvalidEmailAddress("test@test.com.;test@test.com;");

            Assert.IsTrue(results[0] == "test@test.com.");
        }
    }
}
