using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServantSoftware.Toolkit;

namespace Tests.ServantSoftwareToolkit
{
    [TestClass]
    public class DateRangeFixture
    {
        [TestMethod]
        public void Test_Standard_Constructor()
        {
            DateTime start = new DateTime(2013, 6, 28);
            DateTime end = new DateTime(2013, 6, 30);

            var x = new DateRange(start, end);

            Assert.AreEqual(start, x.Start);
            Assert.AreEqual(end, x.End);
        }

        [TestMethod]
        public void Test_Days_Constructor()
        {
            DateTime start = new DateTime(2013, 6, 28);
            int days = 7;

            var x = new DateRange(start, days);

            Assert.AreEqual(start.AddDays(7), x.End);
        }

        [TestMethod]
        public void Test_End_Days_Constructor()
        {
            DateTime end = new DateTime(2013, 6, 28);
            int days = -7;

            var x = new DateRange(days, end);

            Assert.AreEqual(end.AddDays(days), x.Start);
        }

        [TestMethod]
        public void Test_DaysBetweenStartAndEnd()
        {
            DateTime start = new DateTime(2013, 6, 28);
            DateTime end = new DateTime(2013, 6, 30);

            var x = new DateRange(start, end);

            Assert.AreEqual((end - start).TotalDays, x.DaysBetweenStartAndEnd);
        }

        [TestMethod]
        public void Test_DaysBetweenStart()
        {
            DateTime start = new DateTime(2013, 6, 28);
            DateTime end = new DateTime(2013, 6, 30);
            DateTime test = new DateTime(2013, 6, 29);

            var x = new DateRange(start, end);

            Assert.AreEqual(1, x.DaysBetweenStart(test));
        }

        [TestMethod]
        public void Test_DaysBetween_End()
        {
            DateTime start = new DateTime(2013, 6, 28);
            DateTime end = new DateTime(2013, 6, 30);
            DateTime test = new DateTime(2013, 7, 5);

            var x = new DateRange(start, end);

            Assert.AreEqual(5, x.DaysBetweenEnd(test));
        }

        [TestMethod]
        public void Test_ChangeEndDate()
        {
            DateTime start = new DateTime(2013, 6, 28,0,0,0);
            DateTime end = new DateTime(2013, 6, 30);

            var x = new DateRange(start, end);

            x.ChangeEndDate(5);


            Assert.AreEqual(new DateTime(2013, 7, 5, 0, 0, 0), x.End);
        }

        [TestMethod]
        public void Test_ChangeStartDate()
        {
            DateTime start = new DateTime(2013, 6, 28, 0, 0, 0);
            DateTime end = new DateTime(2013, 6, 30);

            var x = new DateRange(start, end);

            x.ChangeStartDate(5);


            Assert.AreEqual(new DateTime(2013, 7, 3, 0, 0, 0), x.Start);
        }

        [TestMethod]
        public void Test_ParseFromYYYYMMDD()
        {
            string start = "20130701";
            string end = "20130801";

            var x = DateRange.ParseFromYYYMMDD(start, end);

            Assert.AreEqual(new DateTime(2013, 07, 01, 0, 0, 0), x.Start);
            Assert.AreEqual(new DateTime(2013, 08, 01, 0, 0, 0), x.End);
        }
    }
}
