using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class OgrnCheckSummTest
    {
        [Theory]
        [InlineData(ValidationPersonEnum.Undefined)]
        [InlineData(ValidationPersonEnum.NaturalPerson)]
        public void TestValidationPersonEnum(ValidationPersonEnum person)
        {
            Assert.Throws<ArgumentException>(() => OgrnCheckSumm.IsValid(null, person));
        }

        #region LegalEntity

        [Theory]
        [InlineData(TestData.VALIDOGRN_LONG)]
        [InlineData(TestData.VALIDOGRN_STRING)]
        public void TestValidLegalEntity(object Value)
        {
            var msg = $"{Value} is valid value for OGRN";
            Assert.True(OgrnCheckSumm.IsValid(Value, ValidationPersonEnum.LegalEntity), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDOGRNIP_LONG)]
        [InlineData(TestData.VALIDOGRNIP_STRING)]
        [InlineData(TestData.INVALIDOGRN_LONG)]
        [InlineData(TestData.INVALIDOGRN_STRING)]
        [InlineData(TestData.INVALIDOGRNIP_LONG)]
        [InlineData(TestData.INVALIDOGRNIP_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidLegalEntity(object Value)
        {
            var msg = $"{Value} is invalid value for LegalEntity";
            Assert.False(OgrnCheckSumm.IsValid(Value, ValidationPersonEnum.LegalEntity), msg);
        }

        #endregion LegalEntity

        #region SelfEmployed

        [Theory]
        [InlineData(TestData.VALIDOGRNIP_LONG)]
        [InlineData(TestData.VALIDOGRNIP_STRING)]
        public void TestValidSelfEmployed(object Value)
        {
            var msg = $"{Value} is valid value for SelfEmployed";
            Assert.True(OgrnCheckSumm.IsValid(Value, ValidationPersonEnum.SelfEmployed), msg);
        }

        [Theory]
        [InlineData(TestData.VALIDOGRN_LONG)]
        [InlineData(TestData.VALIDOGRN_STRING)]
        [InlineData(TestData.INVALIDOGRN_LONG)]
        [InlineData(TestData.INVALIDOGRN_STRING)]
        [InlineData(TestData.INVALIDOGRNIP_LONG)]
        [InlineData(TestData.INVALIDOGRNIP_STRING)]
        [InlineData(TestData.EMPTYSTRING)]
        [InlineData(TestData.SOMESTRING)]
        [InlineData(TestData.MAXINT)]
        [InlineData(TestData.MININT)]
        [InlineData(TestData.NULLOBJECT)]
        [InlineData(TestData.ZEROINT)]
        public void TestInvalidSelfEmployed(object Value)
        {
            var msg = $"{Value} is invalid value for SelfEmployed";
            Assert.False(OgrnCheckSumm.IsValid(Value, ValidationPersonEnum.SelfEmployed), msg);
        }

        #endregion SelfEmployed
    }
}