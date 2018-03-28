namespace ChecksummValidator.Test
{
    public static class TestData
    {
        public const object NULLOBJECT = null;
        public const string EMPTYSTRING = "";
        public const string SOMESTRING = "S0me57r1ngV41u3";
        public const int MAXINT = int.MaxValue;
        public const int MININT = int.MinValue;
        public const int ZEROINT = 0;

        #region inn data

        public const long VALIDINN12_LONG = 500100732259;
        public const string VALIDINN12_STRING = "500100732259";
        public const long INVALIDINN12_LONG = 500100732250;
        public const string INVALIDINN12_STRING = "500100732250";

        public const long VALIDINN10_LONG = 7830002293;
        public const string VALIDINN10_STRING = "7830002293";
        public const long INVALIDINN10_LONG = 7830002291;
        public const string INVALIDINN10_STRING = "7830002291";

        #endregion inn data

        #region Bar code data

        public const long VALIDUPC12_LONG = 241689300498;
        public const string VALIDUPC12_STRING = "241689300498";
        public const long INVALIDUPC12_LONG = 241689300490;
        public const string INVALIDUPC12_STRING = "241689300490";

        public const long VALIDEAN8_LONG = 46009333;
        public const string VALIDEAN8_STRING = "46009333";
        public const long INVALIDEAN8_LONG = 46009330;
        public const string INVALIDEAN8_STRING = "46009330";

        public const long VALIDEAN13_LONG = 4600051000057;
        public const string VALIDEAN13_STRING = "4600051000057";
        public const long INVALIDEAN13_LONG = 4600051000050;
        public const string INVALIDEAN13_STRING = "4600051000050";

        #endregion Bar code data

        #region ogrn data

        public const long VALIDOGRN_LONG = 1037739010891;
        public const string VALIDOGRN_STRING = "1037739010891";
        public const long INVALIDOGRN_LONG = 1037739010890;
        public const string INVALIDOGRN_STRING = "1037739010890";

        public const long VALIDOGRNIP_LONG = 304500116000157;
        public const string VALIDOGRNIP_STRING = "304500116000157";
        public const long INVALIDOGRNIP_LONG = 304500116000150;
        public const string INVALIDOGRNIP_STRING = "304500116000150";

        #endregion ogrn data

        #region ISBN

        public const long VALIDISSN_LONG = 20493630;
        public const string VALIDISSN_STRING = "0033-765X";
        public const long INVALIDISSN_LONG = 20493631;
        public const string INVALIDISSN_STRING = "0033-765Z";

        public const long VALIDISBN10_LONG = 5932860057;
        public const string VALIDISBN10_STRING = "0-446-52087-X";
        public const long INVALIDISBN10_LONG = 5932860050;
        public const string INVALIDISBN10_STRING = "0-446-52087-D";

        public const long VALIDISBN13_LONG = 9785916782950;
        public const string VALIDISBN13_STRING = "978-5-91678-295-0";
        public const long INVALIDISBN13_LONG = 9785916782951;
        public const string INVALIDISBN13_STRING = "978-5-91678-295-1";

        #endregion ISBN

        #region ClassificationCode
        public const long VALIDOKPO_LONG = 47296611;
        public const string VALIDOKPO_STRING = "47296611";
        public const long INVALIDOKPO_LONG = 47296612;
        public const string INVALIDOKPO_STRING = "47296612";

        public const string VALIDOKATO3_STRING = "624";
        public const string VALIDOKATO3_LONG = "816";

        public const long VALIDOKATO_LONG = 654800005;
        public const string VALIDOKATO_STRING = "654800005";
        public const long INVALIDOKATO_LONG = 654800000;
        public const string INVALIDOKATO_STRING = "654800001";

        #endregion ClassificationCode

        #region SNILS

        public const long VALIDSNILS_LONG = 11223344595;
        public const string VALIDSNILS_STRING = "087-654-302 00";
        public const long INVALIDSNILS_LONG = 11223344596;
        public const string INVALIDSNILS_STRING = "087-654-302 10";

        #endregion SNILS 

        #region Bank Number
        public const string VALID_PAYMENTACCOUNT = "40702810638050013199";
        public const string VALID_CORRESPONDENTACCOUNT = "30101810400000000225";
        public const string VALID_BIK_STRING = "044525225";
        public const int VALID_BIK_INT = 044525225;

        public const string INVALID_PAYMENTACCOUNT = "40702810638050013190";
        public const string INVALID_CORRESPONDENTACCOUNT = "30101810400000000220";
        public const string INVALID_BIK_STRING = "944527225";
        public const int INVALID_BIK_INT = 944527225;
        #endregion
    }
}