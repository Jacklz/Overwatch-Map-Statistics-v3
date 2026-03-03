using Newtonsoft.Json;

namespace Overwatch_Map_Statistics_v3
{
    internal class MapResult : Map
    {
        public readonly string outcome;
        public List<string> notes = [];

        public MapResult(string mapname, string mode, string outcome, List<string> notes) : base(mapname, mode)
        {
            this.outcome = outcome;
            this.notes = notes;
        }

        [JsonConstructor]
        public MapResult(string mapname, string outcome, List<string> notes) : base(mapname, Main.maptomode[mapname])
        {
            this.outcome = outcome;
            this.notes = notes;
        }
    }
}
