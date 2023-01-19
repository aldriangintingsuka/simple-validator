using System;
using SimpleValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleValidator.Tests
{
    [TestClass]
    public class Validator_Date_Tests
    {
        [TestMethod]
        public void Test_IsGreaterThan()
        {
            Validator validator = new Validator();

            DateTime now = DateTime.Now;
            validator.IsGreaterThan(now, now.AddSeconds(-5));
            validator.IsGreaterThan(now, now.AddMinutes(-5));
            validator.IsGreaterThan(now.Date, now.AddDays(-1));
            validator.IsGreaterThan(now, now.AddSeconds(1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsGreaterThanOrEqualTo()
        {
            Validator validator = new Validator();

            DateTime now = DateTime.Now;
            validator.IsGreaterThanOrEqualTo(now, now.AddSeconds(-5));
            validator.IsGreaterThanOrEqualTo(now, now.AddMinutes(-5));
            validator.IsGreaterThanOrEqualTo(now.Date, now.AddDays(-1));
            validator.IsGreaterThanOrEqualTo(now, now);
            validator.IsGreaterThanOrEqualTo(now.Date, now.AddDays(-1).Date);
            validator.IsGreaterThanOrEqualTo(now.Date, now.Date);
            validator.IsGreaterThan(now, now.AddSeconds(1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsLessThan()
        {
            Validator validator = new Validator();

            DateTime now = DateTime.Now;
            validator.IsLessThan(now, now.AddSeconds(5));
            validator.IsLessThan(now, now.AddMinutes(5));
            validator.IsLessThan(now.Date, now.AddDays(1));
            validator.IsLessThan(now, now.AddSeconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsLessThanOrEqualTo()
        {
            Validator validator = new Validator();

            DateTime now = DateTime.Now;
            validator.IsLessThanOrEqualTo(now, now.AddSeconds(5));
            validator.IsLessThanOrEqualTo(now, now.AddMinutes(5));
            validator.IsLessThanOrEqualTo(now.Date, now.AddDays(1));
            validator.IsLessThanOrEqualTo(now, now);
            validator.IsLessThanOrEqualTo(now.Date, now.AddDays(1).Date);
            validator.IsLessThanOrEqualTo(now.Date, now.Date);
            validator.IsLessThanOrEqualTo(now, now.AddSeconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 1);
        }

        [TestMethod]
        public void Test_IsEqualTo()
        {
            Validator validator = new Validator();

            DateTime now = DateTime.Now;
            validator.IsEqualTo(now, now.AddSeconds(5));  // fail
            validator.IsEqualTo(now, now);
            validator.IsEqualTo(now.Date, now.Date);
            validator.IsEqualTo(now, now.AddMilliseconds(-1)); // fail

            Assert.IsTrue(validator.Errors.Count == 2);
        }

        [TestMethod]
        public void Test_IsBetweenInclusive()
        {
            Validator validator = new Validator();

            validator.IsBetweenInclusive(new DateTime(2016, 1, 10), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 8), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 6), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenInclusive(new DateTime(2016, 1, 12), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenInclusive(new DateTime(2016, 1, 14), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail

            Assert.IsTrue(validator.Errors.Count == 2);
        }

        [TestMethod]
        public void Test_IsBetweenExclusive()
        {
            Validator validator = new Validator();

            validator.IsBetweenExclusive(new DateTime(2016, 1, 10), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12));
            validator.IsBetweenExclusive(new DateTime(2016, 1, 8), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 6), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 12), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail
            validator.IsBetweenExclusive(new DateTime(2016, 1, 14), new DateTime(2016, 1, 8), new DateTime(2016, 1, 12)); // fail

            Assert.IsTrue(validator.Errors.Count == 4);
        }


    }
}
