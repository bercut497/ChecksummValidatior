using System;
using System.Globalization;
using Xunit;

namespace ChecksummValidator.Test
{
    using ChecksummValidator;
    using ChecksummValidator.Enums;

    public class BankNumberTest
    {
        [Theory]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_INT)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_INT)]

        public void TestValidBankAccounts(object Value, BankNumberTypeEnum numberType, object bik)
        {
            var msg = $"{Value} is valid value for BankAccount";
            Assert.True(BankNumber.IsValid(Value,numberType,bik), msg);
        }

        [Theory]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_INT)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_INT)]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.INVALID_BIK_STRING)]
        [InlineData(TestData.VALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.INVALID_BIK_INT)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.INVALID_BIK_STRING)]
        [InlineData(TestData.VALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.INVALID_BIK_INT)]
        [InlineData(TestData.INVALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.INVALID_PAYMENTACCOUNT, BankNumberTypeEnum.PaymentAccount, TestData.VALID_BIK_INT)]
        [InlineData(TestData.INVALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.INVALID_CORRESPONDENTACCOUNT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_INT)]
        ////
        [InlineData(TestData.EMPTYSTRING, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.SOMESTRING, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.MAXINT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.MININT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.NULLOBJECT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        [InlineData(TestData.ZEROINT, BankNumberTypeEnum.CorrespondentAccount, TestData.VALID_BIK_STRING)]
        public void TestInvalidBankAccounts(object Value, BankNumberTypeEnum numberType, object bik)
        {
            var msg = $"{Value} is invalid value for BankAccount";
            Assert.False(BankNumber.IsValid(Value,numberType,bik), msg);
        }
        
    }
}