namespace Overwatch_Map_Statistics_v3
{
    internal static class EntriesManager
    {
        private static readonly string dir = "Text data";

        public static SortedSet<string> allroles = [];
        public static SortedSet<string> allmodes = [];
        public static SortedSet<string> alloutcomes = [];
        public static SortedSet<string> allnotes = [];
        public static SortedSet<string> allprofiles = [];
        public static List<Map> allmaps = [];

        public static void CreateAllFiles()
        {
            Directory.CreateDirectory(dir);
            CreateModes();
            CreateMaps();
            CreateOutcomes();
            CreateNotes();
            CreateRoles();
            CreateProfiles();
        }

        public static void ModifyMaps(Map map, bool remove)
        {
            if (remove) allmaps.RemoveAll(entry => entry.fullname == map.fullname);
            else allmaps.Add(map);
            UpdateFile("maps", [.. allmaps.Select(entry => entry.fullname)]);
        }

        public static void RemoveMap(Predicate<Map> map)
        {
            allmaps.RemoveAll(map);
            UpdateFile("maps", [.. allmaps.Select(entry => entry.fullname)]);
        }

        public enum EntryType { role, mode, outcome, note, profile }
        public static void ModifyEntry(EntryType entrytype, string entry, bool remove)
        {
            SortedSet<string> list = [];
            string filename = "";
            switch (entrytype)
            {
                case EntryType.role: filename = "roles"; list = allroles; break;
                case EntryType.mode: filename = "modes"; list = allmodes; break;
                case EntryType.outcome: filename = "outcomes"; list = alloutcomes; break;
                case EntryType.note: filename = "notes"; list = allnotes; break;
                case EntryType.profile: filename = "profiles"; list = allprofiles; break;
            }
            if (remove) list.Remove(entry);
            else list.Add(entry);
            UpdateFile(filename, list);
        }

        private static void UpdateFile(string filename, SortedSet<string> entries)
        {
            string path = Path.Combine(dir, $"{filename}.txt");
            File.WriteAllLines(path, entries);
        }

        private static SortedSet<string> CheckOrCreateFile(string filename, SortedSet<string> entries)
        {
            string path = Path.Combine(dir, $"{filename}.txt");
            if (File.Exists(path))
            {
                if (filename == "maps") return [.. File.ReadAllLines(path)];
                return [.. File.ReadAllLines(path).Select(entry => entry.Replace("-", ""))];
            }
            else File.WriteAllLines(path, entries);
            return entries;
        }

        private static void CreateProfiles()
        {
            allprofiles = CheckOrCreateFile("profiles", []);
        }

        private static void CreateRoles()
        {
            SortedSet<string> roles = ["Open Queue", "DPS", "Tank", "Support"];
            allroles = CheckOrCreateFile("roles", roles);
        }

        private static void CreateModes()
        {
            SortedSet<string> modes = ["Flashpoint", "Koth", "Hybrid", "Escort", "Push"];
            allmodes = CheckOrCreateFile("modes", modes);
        }

        private static void CreateOutcomes()
        {
            SortedSet<string> outcomes = ["Win", "Loss", "Draw", "Canceled", "Server Closed"];
            alloutcomes = CheckOrCreateFile("outcomes", outcomes);
        }

        private static void CreateNotes()
        {
            SortedSet<string> notes =
            [
                "Leaver compensation",
                "Cheater",
                "Friendly AFK",
                "Friendly DC",
                "Friendly cheater",
                "Friendly thrower",
                "Enemy AFK",
                "Enemy DC",
                "Enemy cheater",
                "Enemy thrower",
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
