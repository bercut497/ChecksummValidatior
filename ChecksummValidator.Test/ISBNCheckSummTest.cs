using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class ISBNCheckSummTest
    {
        [Fact]
        public void TestUdenfined()
        {
            Assert.Throws<ArgumentException>(() => ISBNCheckSumm.IsValid(null, ISBNTypeEnum.Undefined));
        }

        #region ISSN

        [Theory]
        [InlineData(TestData.VALIDISSN_LONG)]
        [InlineData(TestData.VALIDISSN_STRING)]
        public void TestValidIssn(object Value)
        {
            var msg = $"{Value} is valid value for ISSN";
            Assert.True(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISSN), msg);
        }

        [Theory]
        //[InlineData(TestData.VALIDISSN_LONG)]
        //[InlineData(TestData.VALIDISSN_STRING)]
        [InlineData(TestData.INVALIDISSN_LONG)]
        [InlineData(TestData.INVALIDISSN_STRING)]
        [InlineData(TestData.VALIDISBN10_LONG)]
        [InlineData(TestData.VALIDISBN10_STRING)]
        [InlineData(TestData.INVALIDISBN10_LONG)]
        [InlineData(TestData.INVALIDISBN10_STRING)]
        [InlineData(TestData.VALIDISBN13_LONG)]
        [InlineData(TestData.VALIDISBN13_STRING)]
        [InlineData(TestData.INVALIDISBN13_LONG)]
        [InlineData(TestData.INVALIDISBN13_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidIssn(object Value)
        {
            var msg = $"{Value} is invalid value for ISSN";
            Assert.False(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISSN), msg);
        }

        #endregion ISSN

        #region ISBN10

        [Theory]
        [InlineData(TestData.VALIDISBN10_LONG)]
        [InlineData(TestData.VALIDISBN10_STRING)]
        public void TestValidIsbn10(object Value)
        {
            var msg = $"{Value} is valid value for ISBN10";
            Assert.True(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISBN10), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDISSN_LONG)]
        [InlineData(TestData.VALIDISSN_STRING)]
        [InlineData(TestData.INVALIDISSN_LONG)]
        [InlineData(TestData.INVALIDISSN_STRING)]
        //[InlineData(TestData.VALIDISBN10_LONG)]
        //[InlineData(TestData.VALIDISBN10_STRING)]
        [InlineData(TestData.INVALIDISBN10_LONG)]
        [InlineData(TestData.INVALIDISBN10_STRING)]
        [InlineData(TestData.VALIDISBN13_LONG)]
        [InlineData(TestData.VALIDISBN13_STRING)]
        [InlineData(TestData.INVALIDISBN13_LONG)]
        [InlineData(TestData.INVALIDISBN13_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        //min int is valid value
        //[InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidIsbn10(object Value)
        {
            var msg = $"{Value} is invalid value for ISBN10";
            Assert.False(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISBN10), msg);
        }

        #endregion ISBN10

        #region ISBN13

        [Theory]
        [InlineData(TestData.VALIDISBN13_LONG)]
        [InlineData(TestData.VALIDISBN13_STRING)]
        public void TestValidIsbn13(object Value)
        {
            var msg = $"{Value} is valid value for ISBN13";
            Assert.True(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISBN13), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDISSN_LONG)]
        [InlineData(TestData.VALIDISSN_STRING)]
        [InlineData(TestData.INVALIDISSN_LONG)]
        [InlineData(TestData.INVALIDISSN_STRING)]
        [InlineData(TestData.VALIDISBN10_LONG)]
        [InlineData(TestData.VALIDISBN10_STRING)]
        [InlineData(TestData.INVALIDISBN10_LONG)]
        [InlineData(TestData.INVALIDISBN10_STRING)]
        //[InlineData(TestData.VALIDISBN13_LONG)]
        //[InlineData(TestData.VALIDISBN13_STRING)]
        [InlineData(TestData.INVALIDISBN13_LONG)]
        [InlineData(TestData.INVALIDISBN13_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidIsbn13(object Value)
        {
            var msg = $"{Value} is invalid value for ISBN13";
            Assert.False(ISBNCheckSumm.IsValid(Value, ISBNTypeEnum.ISBN13), msg);
        }

        #endregion ISBN13
    }
}