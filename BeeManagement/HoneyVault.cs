namespace BeeManagement
{
    public static class HoneyVault
    {
        private const float NECTAR_CONVERSION_RATIO = .19f; 
        private const float LOW_LEVEL_WARNING  = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport
        {
            get
            {
                var status =  $"Raport o stanie skarbca\n" +
                        $"Jednostki miodu: {honey:0.0}\n" +
                        $"Jednostki nektaru: {nectar:0.0}\n\n";
                var warnings = "";
                if (honey < LOW_LEVEL_WARNING) { warnings += "MAŁO MIODU - DODAJ PRODUCENTÓW MIODU!"; }
                if (nectar < LOW_LEVEL_WARNING) { warnings += "MAŁO NEKTARU - DODAJ ZBIERACZY NEKTARU!"; }

                return status + warnings ;
            }
        }

        public static void CollectNectar(float amount) {
            nectar += amount > 0f ? amount : 0;
        }
        public static void ConvertNectarToHoney(float amount) {
            if(amount > nectar) amount = nectar;

            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }
        public static bool ConsumeHoney(float amount) {
            if (amount > honey)
                return false;

            honey -= amount;
            return true;
        }
    }
}
