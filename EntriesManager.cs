namespace Overwatch_Map_Statistics_v3
{
    internal static class EntriesManager
    {
        private static readonly string dir = "Text data";

        public static List<string> allroles = [];
        public static List<string> allmodes = [];
        public static List<string> alloutcomes = [];
        public static List<string> allnotes = [];
        public static List<string> allprofiles = [];
        public static List<Map> allmaps = [];

        public static void CreateAllFiles()
        {
            CreateModes();
            CreateMaps();
            CreateOutcomes();
            CreateNotes();
            CreateRoles();
            CreateProfiles();
        }

        private static List<string> CheckOrCreateFile(string filename, List<string> entries)
        {
            string path = Path.Combine(dir, $"{filename}.txt");
            if (File.Exists(path)) return [.. File.ReadAllLines(path)];
            else File.WriteAllLines(path, entries);
            return entries;
        }

        private static void CreateProfiles()
        {
            allprofiles = CheckOrCreateFile("profiles", []);
        }

        private static void CreateRoles()
        {
            List<string> roles = ["Open Queue", "DPS", "Tank", "Support"];
            allroles = CheckOrCreateFile("roles", roles);
        }

        private static void CreateModes()
        {
            List<string> modes = ["Flashpoint", "Koth", "Hybrid", "Escort", "Push"];
            allmodes = CheckOrCreateFile("modes", modes);
        }

        private static void CreateOutcomes()
        {
            List<string> outcomes = ["Win", "Loss", "Draw", "Canceled", "Server Closed"];
            alloutcomes = CheckOrCreateFile("outcomes", outcomes);
        }

        private static void CreateNotes()
        {
            List<string> notes =
            [
                "Friendly DC",
                "Friendly cheater",
                "Enemy DC",
                "Enemy cheater",
                "Lopsided",
                "Expected",
                "Reversal",
                "Uphill battle",
                "Consolation",
                "Losing trend",
                "Winning trend"
            ];
            allnotes = CheckOrCreateFile("notes", notes);
        }

        private static void CreateMaps()
        {
            List<Map> maps =
            [
                new("Aatlis", "Flashpoint"),
                new("Antarctic Peninsula", "Koth"),
                new("Blizzard World", "Hybrid"),
                new("Busan", "Koth"),
                new("Circuit Royal", "Escort"),
                new("Colosseo", "Push"),
                new("Dorado", "Escort"),
                new("Eichenwalde", "Hybrid"),
                new("Esperanca", "Push"),
                new("Havana", "Escort"),
                new("Hollywood", "Hybrid"),
                new("Ilios", "Koth"),
                new("Junkertown", "Escort"),
                new("King's Row", "Hybrid"),
                new("Lijiang Tower", "Koth"),
                new("Midtown", "Hybrid"),
                new("Nepal", "Koth"),
                new("New Junk City", "Flashpoint"),
                new("New Queen Street", "Push"),
                new("Numbani", "Hybrid"),
                new("Oasis", "Koth"),
                new("Paraiso", "Hybrid"),
                new("Rialto", "Escort"),
                new("Route 66", "Escort"),
                new("Runasapi", "Push"),
                new("Samoa", "Koth"),
                new("Shambali Monastary", "Escort"),
                new("Suravasa", "Flashpoint"),
                new("Watchpoint: Gibraltar", "Escort"),
            ];
            var tmp = CheckOrCreateFile("maps", [.. maps.Select(entry => entry.fullname)]);
            allmaps = tmp.Select(entry =>
            {
                int index = entry.IndexOf('-');
                string name = entry.Substring(0, index).Trim();
                string mode = entry.Substring(index + 1).Trim();
                return new Map(name, mode);
            }).ToList();
        }
    }
}
