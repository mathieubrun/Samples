using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.CodeContracts.Tests
{
    [TestClass]
    public class RationalTest
    {
        [TestMethod]
        public void Working_Constructor()
        {
            var r = new Rational(10, 10);

            Assert.AreEqual(r.Numerator / r.Denominator, 1);
        }

        [Ignore]
        public void Failing_Constructor()
        {
            var r = new Rational(10, 0);
        }

        [Ignore]
        public void Failing_Invariant()
        {
            var r = new Rational(10, 10) { Denominator = 0 };
        }
    }

    public class Rational
    {
        public Rational(int numerator, int denominator)
        {
            Contract.Requires(denominator != 0);

            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator { get; set; }

        public int Denominator { get; set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Denominator != 0);
        }
    }
}