using Xunit;

namespace ChecksummValidator.Test
{
    public class InnChecksummTest
    {
        #region LegalEntity

        [Theory]
        [InlineData(TestData.VALIDINN10_LONG)]
        [InlineData(TestData.VALIDINN10_STRING)]
        public void TestValidLegalEntity(object Value)
        {
            var msg = $"{Value} is valid value for LegalEntity";
            Assert.True(InnCheckSumm.isValid(Value, ValidationPersonEnum.LegalEntity), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDINN12_LONG)]
        [InlineData(TestData.VALIDINN12_STRING)]
        [InlineData(TestData.INVALIDINN10_LONG)]
        [InlineData(TestData.INVALIDINN10_STRING)]
        [InlineData(TestData.INVALIDINN12_LONG)]
        [InlineData(TestData.INVALIDINN12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidLegalEntity(object Value)
        {
            var msg = $"{Value} is invalid value for LegalEntity";
            Assert.False(InnCheckSumm.isValid(Value, ValidationPersonEnum.LegalEntity), msg);
        }

        #endregion LegalEntity

        #region NaturalPerson

        [Theory]
        [InlineData(TestData.VALIDINN12_LONG)]
        [InlineData(TestData.VALIDINN12_STRING)]
        public void TestValidNaturalPerson(object Value)
        {
            var msg = $"{Value} is valid value for NaturalPerson";
            Assert.True(InnCheckSumm.isValid(Value, ValidationPersonEnum.NaturalPerson), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDINN10_LONG)]
        [InlineData(TestData.VALIDINN10_STRING)]
        [InlineData(TestData.INVALIDINN10_LONG)]
        [InlineData(TestData.INVALIDINN10_STRING)]
        [InlineData(TestData.INVALIDINN12_LONG)]
        [InlineData(TestData.INVALIDINN12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidNaturalPerson(object Value)
        {
            var msg = $"{Value} is invalid value for NaturalPerson";
            Assert.False(InnCheckSumm.isValid(Value, ValidationPersonEnum.NaturalPerson), msg);
        }

        #endregion NaturalPerson

        #region SelfEmployed

        [Theory]
        [InlineData(TestData.VALIDINN12_LONG)]
        [InlineData(TestData.VALIDINN12_STRING)]
        public void TestValidSelfEmployed(object Value)
        {
            var msg = $"{Value} is valid value for NaturalPerson";
            Assert.True(InnCheckSumm.isValid(Value, ValidationPersonEnum.SelfEmployed), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDINN10_LONG)]
        [InlineData(TestData.VALIDINN10_STRING)]
        [InlineData(TestData.INVALIDINN10_LONG)]
        [InlineData(TestData.INVALIDINN10_STRING)]
        [InlineData(TestData.INVALIDINN12_LONG)]
        [InlineData(TestData.INVALIDINN12_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidSelfEmployed(object Value)
        {
            var msg = $"{Value} is invalid value for NaturalPerson";
            Assert.False(InnCheckSumm.isValid(Value, ValidationPersonEnum.SelfEmployed), msg);
        }

        #endregion SelfEmployed
    }
}