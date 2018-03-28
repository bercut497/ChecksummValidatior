using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class ClassificationCodeTest
    {
        [Fact]
        public void TestClassificationCodeType()
        {
            Assert.Throws<ArgumentException>(() => ClassificationCode.IsValid(null, ClassificationCodeType.Undefined));
        }

        #region OKATO

        [Theory]
        [InlineData(TestData.VALIDOKATO_LONG)]
        [InlineData(TestData.VALIDOKATO_STRING)]
        [InlineData(TestData.VALIDOKATO3_LONG)]
        [InlineData(TestData.VALIDOKATO3_STRING)]
        public void TestValidOkato(object Value)
        {
            var msg = $"{Value} is valid value for OKATO";
            Assert.True(ClassificationCode.IsValid(Value, ClassificationCodeType.okato), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDOKPO_LONG)]
        [InlineData(TestData.VALIDOKPO_STRING)]
        [InlineData(TestData.INVALIDOKATO_LONG)]
        [InlineData(TestData.INVALIDOKATO_STRING)]
        [InlineData(TestData.INVALIDOKPO_LONG)]
        [InlineData(TestData.INVALIDOKPO_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidOkato(object Value)
        {
            var msg = $"{Value} is invalid value for OKATO";
            Assert.False(ClassificationCode.IsValid(Value, ClassificationCodeType.okato), msg);
        }

        #endregion OKATO

        #region OKPO

        [Theory]
        [InlineData(TestData.VALIDOKPO_LONG)]
        [InlineData(TestData.VALIDOKPO_STRING)]
        public void TestValidOkpo(object Value)
        {
            var msg = $"{Value} is valid value for OKPO";
            Assert.True(ClassificationCode.IsValid(Value, ClassificationCodeType.okpo), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDOKATO_LONG)]
        [InlineData(TestData.VALIDOKATO_STRING)]
        [InlineData(TestData.INVALIDOKATO_LONG)]
        [InlineData(TestData.INVALIDOKATO_STRING)]
        [InlineData(TestData.INVALIDOKPO_LONG)]
        [InlineData(TestData.INVALIDOKPO_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidOkpo(object Value)
        {
            var msg = $"{Value} is invalid value for OKPO";
            Assert.False(ClassificationCode.IsValid(Value, ClassificationCodeType.okpo), msg);
        }

        #endregion OKPO
    }
}