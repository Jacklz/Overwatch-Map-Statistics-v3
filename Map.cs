using System.Text.Json.Serialization;

namespace Overwatch_Map_Statistics_v3
{
    public class Map
    {
        public readonly string mapname;
        public readonly string mode;

        [JsonIgnore]
        public string fullname;

        public Map(string mapname, string mode)
        {
            this.mapname = mapname;
            this.mode = mode;
            fullname = $"{mapname} - {mode}";
        }
    }
}
