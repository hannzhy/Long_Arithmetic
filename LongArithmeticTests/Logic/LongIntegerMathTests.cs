﻿using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class LongIntegerMathTests
    {
        [TestMethod]
        public void Equals_Zero_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("0"), LongInteger.Parse("0")));
        }

        [TestMethod]
        public void Equals_Int_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("5"), LongInteger.Parse("5")));
        }

        [TestMethod]
        public void Equals_NegativeInt_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-8"), LongInteger.Parse("-8")));
        }

        [TestMethod]
        public void Equals_LongInt_IsTrue()
        {
            var str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse(str), LongInteger.Parse(str)));
        }

        [TestMethod]
        public void Equals_NegativeLongInt_IsTrue()
        {
            var str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-" + str), LongInteger.Parse("-" + str)));
        }

        [TestMethod]
        public void Equals_AnyNumberIsEqualToItself_IsTrue()
        {
            var number = LongInteger.Parse("15977");
            Assert.IsTrue(LongIntegerMath.Equals(number, number));
        }

        [TestMethod]
        public void Equals_StartWithZero_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("0128"), LongInteger.Parse("128")));
        }

        [TestMethod]
        public void Compare_DifferentSign()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-8567"), LongInteger.Parse("8567"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_Negatives_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-78895"), LongInteger.Parse("-85557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_Negatives_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85157"), LongInteger.Parse("-78557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_Positive_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("98895"), LongInteger.Parse("85557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_Positive_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85157"), LongInteger.Parse("88557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_NegativeDifferentLength_FirstLarger()
        {
            LongIntegerMath.Compare(LongInteger.Parse("225"), LongInteger.Parse("856"));
            var result = LongIntegerMath.Compare(LongInteger.Parse("-98895"), LongInteger.Parse("-85595455488432574564857"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_NegativeDifferentLength_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-988852945965292398595"), LongInteger.Parse("-8557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_PositiveDifferentLength_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("859529395263915725"), LongInteger.Parse("88557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_PositiveDifferentCount_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("851"), LongInteger.Parse("85649679898888648557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_NegativeEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85122228767945"), LongInteger.Parse("-85122228767456"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_PositiveEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85122228767945"), LongInteger.Parse("85122228767456"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_PositiveEquals()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("8512222876"), LongInteger.Parse("8512222876"));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_NegativeEquals()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-8512222876"), LongInteger.Parse("-8512222876"));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SummLongInteger_Positives()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("28076"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("86754358512250952"), result));
        }

        [TestMethod]
        public void SummLongInteger_Negatives()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-28076"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-86754358512250952"), result));
        }

        [TestMethod]
        public void SummLongInteger_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("-8675435851876"), LongInteger.Parse("28076"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-8675435823800"), result));
        }

        [TestMethod]
        public void SummLongInteger_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("8675435851876"), LongInteger.Parse("-28076"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("8675435823800"), result));
        }

        [TestMethod]
        public void SummLongInteger_EqualValues()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("28076"), LongInteger.Parse("28076"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("56152"), result));
        }

        [TestMethod]
        public void SummLongInteger_IncreasesSignificantBit()
        {
            var result = LongIntegerMath.SummLongInteger(LongInteger.Parse("9999999999999999999999"), LongInteger.Parse("1"));
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("10000000000000000000000"), result));
        }

        [TestMethod]
        public void SummLongInteger_ShouldNotChangeArguments()
        {
            var v1 = LongInteger.Parse("1");
            var v2 = LongInteger.Parse("200000000000000");
            var v3 = LongIntegerMath.SummLongInteger(v1, v2);

            Assert.AreEqual(v1.ToString(), "1");
            Assert.AreEqual(v2.ToString(), "200000000000000");
            Assert.AreEqual(v3.ToString(), "200000000000001");
        }
    }
}
