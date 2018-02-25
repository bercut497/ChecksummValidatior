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
        #endregion
    }
}