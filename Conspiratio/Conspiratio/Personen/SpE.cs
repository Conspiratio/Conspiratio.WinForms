namespace Conspiratio
{
    // TODO: Diese Klasse am besten komplett entfernen und stattdessen mit Rückgabewerten arbeiten (z.B. DialogResult)

    static class SpE //Spielereinstellungen
    {
        //public static bool host;
        //public static bool networkgame;
        //public int spnr;

        static string StringKurzSpeicher; //Temp
        static int IntKurzSpeicher; //Temp
        static bool BoolKurzSpeicher; //Temp
        static int anschwaerzID;

        static SpE()
        {
        }

        public static bool getBoolKurzSpeicher()
        {
            return BoolKurzSpeicher;
        }

        public static void setBoolKurzSpeicher(bool torf)
        {
            BoolKurzSpeicher = torf;
        }

        public static void setAnschwaerzID(int aid)
        {
            anschwaerzID = aid;
        }

        public static int getAnschwaerzID()
        {
            return anschwaerzID;
        }

        public static void setIntKurzSpeicher(int x)
        {
            IntKurzSpeicher = x;
        }

        public static int getIntKurzSpeicher()
        {
            return IntKurzSpeicher;
        }

        public static void setStringKurzSpeicher(string s)
        {
            StringKurzSpeicher = s;
        }

        public static string getStringKurzSpeicher()
        {
            return StringKurzSpeicher;
        }
    }
}
