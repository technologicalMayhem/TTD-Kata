using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TTD_Kata;

namespace Tests
{
    public class StringCalculatorTests
    {
        [Test]
        public void TestEmpty()
        {
            var i = StringCalculator.Add(string.Empty);
            Assert.AreEqual(0, i);
        }

        [Test]
        public void TestOne()
        {
            var i = StringCalculator.Add("1");
            Assert.AreEqual(1, i);
        }

        [Test]
        public void TestOneTwo()
        {
            var i = StringCalculator.Add("1,2");
            Assert.AreEqual(3, i);
        }

        [Test]
        public void TestRandomNumbers()
        {
            var r = new Random();
            var list = new List<int>();
            for (var j = 0; j < r.Next(10); j++)
            {
                list.Add(r.Next(1000));
            }

            var i = StringCalculator.Add(string.Join(',', list));
            Assert.AreEqual(list.Sum(), i);
        }

        [Test]
        public void TestCommaAndNewlineSeparators()
        {
            var i = StringCalculator.Add("1\n2,3");
            Assert.AreEqual(6, i);
        }

        [Test]
        public void TestCustomNumberDelimiter()
        {
            var i = StringCalculator.Add(@"//;\n1;2");
            Assert.AreEqual(3, i);
        }

        [Test]
        public void TestNegativeNumberException()
        {
            try
            {
                StringCalculator.Add("1,-5,2,-6");
            }
            catch (InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void IgnoreGreaterThan1000()
        {
            var i = StringCalculator.Add("2,1001");
            Assert.AreEqual(2, i);
        }

        [Test]
        public void TestCustomNumberDelimiterArray()
        {
            var i = StringCalculator.Add(@"//[***]\n1***2***3");
            Assert.AreEqual(6,i);
        }

        [Test]
        public void TestCustomNumberDelimiterArrayWithMultiple()
        {
            var i = StringCalculator.Add(@"//[*][%]\n1*2%3");
            Assert.AreEqual(6, i);
        }
        
        [Test]
        public void TestCustomNumberDelimiterArrayWithMultipleMoreThanOneChar()
        {
            var i = StringCalculator.Add(@"//[**][%/]\n1**2%/3");
            Assert.AreEqual(6, i);
        }
    }
}