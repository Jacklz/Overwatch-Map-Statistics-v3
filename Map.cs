using Newtonsoft.Json;

namespace Overwatch_Map_Statistics_v3
{
    public class Map
    {
        public readonly string mapname;

        [JsonIgnore]
        public string mode;

        [JsonIgnore]
        public string fullname;

        public Map(string mapname, string mode)
        {
            this.mapname = mapname;
            this.mode = mode;
            fullname = $"{mapname} - {mode}";
        }

        public static List<string> GetAllModes()
        {
            return
            [
                "Flashpoint",
                "Koth",
                "Hybrid",
                "Escort",
                "Push",
                "Clash",
            ];
        }

        public static List<Map> GetAllMaps()
        {
            return
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
        }
    }
}
