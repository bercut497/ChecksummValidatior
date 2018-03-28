using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class BarCodeChecksummTest
    {
        [Fact]
        public void TestUdenfined()
        {
            Assert.Throws<ArgumentException>(() => BarCodeCheckSumm.IsValid(null, BarcodeTypeEnum.Undefined));
        }

        #region EAN8

        [Theory]
        [InlineData(TestData.VALIDEAN8_LONG)]
        [InlineData(TestData.VALIDEAN8_STRING)]
        public void TestValidEan8(object Value)
        {
            var msg = $"{Value} is valid value for EAN8";
            Assert.True(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.EAN8), msg);
        }

        [Theory]
        //[InlineData(TestData.VALIDEAN8_LONG)]
        //[InlineData(TestData.VALIDEAN8_STRING)]
        [InlineData(TestData.INVALIDEAN8_LONG)]
        [InlineData(TestData.INVALIDEAN8_STRING)]
        [InlineData(TestData.VALIDEAN13_LONG)]
        [InlineData(TestData.VALIDEAN13_STRING)]
        [InlineData(TestData.INVALIDEAN13_LONG)]
        [InlineData(TestData.INVALIDEAN13_STRING)]
        [InlineData(TestData.VALIDUPC12_LONG)]
        [InlineData(TestData.VALIDUPC12_STRING)]
        [InlineData(TestData.INVALIDUPC12_LONG)]
        [InlineData(TestData.INVALIDUPC12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidEan8(object Value)
        {
            var msg = $"{Value} is invalid value for EAN8";
            Assert.False(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.EAN8), msg);
        }

        #endregion EAN8

        #region EAN13

        [Theory]
        [InlineData(TestData.VALIDEAN13_LONG)]
        [InlineData(TestData.VALIDEAN13_STRING)]
        public void TestValidEan13(object Value)
        {
            var msg = $"{Value} is valid value for EAN13";
            Assert.True(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.EAN13), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDEAN8_LONG)]
        [InlineData(TestData.VALIDEAN8_STRING)]
        [InlineData(TestData.INVALIDEAN8_LONG)]
        [InlineData(TestData.INVALIDEAN8_STRING)]
        //[InlineData(TestData.VALIDEAN13_LONG)]
        //[InlineData(TestData.VALIDEAN13_STRING)]
        [InlineData(TestData.INVALIDEAN13_LONG)]
        [InlineData(TestData.INVALIDEAN13_STRING)]
        [InlineData(TestData.VALIDUPC12_LONG)]
        [InlineData(TestData.VALIDUPC12_STRING)]
        [InlineData(TestData.INVALIDUPC12_LONG)]
        [InlineData(TestData.INVALIDUPC12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidEan13(object Value)
        {
            var msg = $"{Value} is invalid value for EAN13";
            Assert.False(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.EAN13), msg);
        }

        #endregion EAN13

        #region UPC12

        [Theory]
        [InlineData(TestData.VALIDUPC12_LONG)]
        [InlineData(TestData.VALIDUPC12_STRING)]
        public void TestValidUPC12(object Value)
        {
            var msg = $"{Value} is valid value for UPC12";
            Assert.True(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.UPC12), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDEAN8_LONG)]
        [InlineData(TestData.VALIDEAN8_STRING)]
        [InlineData(TestData.INVALIDEAN8_LONG)]
        [InlineData(TestData.INVALIDEAN8_STRING)]
        [InlineData(TestData.VALIDEAN13_LONG)]
        [InlineData(TestData.VALIDEAN13_STRING)]
        [InlineData(TestData.INVALIDEAN13_LONG)]
        [InlineData(TestData.INVALIDEAN13_STRING)]
        //[InlineData(TestData.VALIDUPC12_LONG)]
        //[InlineData(TestData.VALIDUPC12_STRING)]
        [InlineData(TestData.INVALIDUPC12_LONG)]
        [InlineData(TestData.INVALIDUPC12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidUPC12(object Value)
        {
            var msg = $"{Value} is invalid value for UPC12";
            Assert.False(BarCodeCheckSumm.IsValid(Value, BarcodeTypeEnum.UPC12), msg);
        }

        #endregion UPC12
    }
}