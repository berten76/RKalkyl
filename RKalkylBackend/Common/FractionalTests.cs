using System;
using System.Collections.Generic;
using System.Text;
using Math;
using NUnit.Framework;

namespace MathTests
{
    [TestFixture]
    public class FractionalTests
    {
        [TestCase("1/4", 0.25)]
        [TestCase("5 1/4", 5.25)]
        public void FractionalTest(string fractional, double expected)
        {
            double deciaml = Fractional.ToDecimal(fractional);

            Assert.AreEqual(expected, deciaml);
        }
    }
}
