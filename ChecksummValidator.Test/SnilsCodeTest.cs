using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class SnilsCodeTest
    {
        [Theory]
        [InlineData(TestData.VALIDSNILS_LONG)]
        [InlineData(TestData.VALIDSNILS_STRING)]
        public void TestValidSNILS(object Value)
        {
            var msg = $"{Value} is valid value for SNILS";
            Assert.True(SnilsCheckSumm.IsValid(Value), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDOKPO_LONG)]
        [InlineData(TestData.VALIDOKPO_STRING)]
        [InlineData(TestData.INVALIDSNILS_LONG)]
        [InlineData(TestData.INVALIDSNILS_STRING)]
        [InlineData(TestData.INVALIDOKPO_LONG)]
        [InlineData(TestData.INVALIDOKPO_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidSNILS(object Value)
        {
            var msg = $"{Value} is invalid value for SNILS";
            Assert.False(SnilsCheckSumm.IsValid(Value), msg);
        }
        
    }
}