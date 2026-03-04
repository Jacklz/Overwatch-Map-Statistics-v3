namespace Overwatch_Map_Statistics_v3
{
    internal class MapStat : GenericStat
    {
        public readonly Map map;

        public MapStat(Map map)
        {
            this.map = map;
        }

        public MapStat(string name, string mode)
        {
            map = new(name, mode);
        }
    }
}
