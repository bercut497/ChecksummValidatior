namespace ChecksummValidator.Test
{
    public static class TestData{
        public const object NULLOBJECT = null;
        public const string EMPTYSTRING = "";
        public const string SOMESTRING = "S0me57r1ngV41u3";
        public const int    MAXINT    = int.MaxValue;
        public const int    MININT    = int.MinValue;
        public const int    ZEROINT    = 0;    
        ///
        public const long VALIDINN12_LONG = 500100732259;
        public const string VALIDINN12_STRING = "500100732259";
        public const long INVALIDINN12_LONG = 500100732250;
        public const string INVALIDINN12_STRING = "500100732250";
        
        public const long VALIDINN10_LONG = 7830002293;
        public const string VALIDINN10_STRING = "7830002293";
        public const long INVALIDINN10_LONG = 7830002291;
        public const string INVALIDINN10_STRING = "7830002291";
    }
}