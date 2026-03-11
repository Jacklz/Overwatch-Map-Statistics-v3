namespace Overwatch_Map_Statistics_v3
{
    internal class RecordStat
    {
        //public readonly DayStat DayStat;
        public readonly Dictionary<string, MapStat> mapstats = [];
        //public readonly Dictionary<string, ModeStat> modestats = [];

        public RecordStat(DateTime date, List<MapResult> results)
        {
            //DayStat = new(date.DayOfWeek);
            foreach (var data in results)
            {
                if (!mapstats.TryGetValue(data.mapname, out var mapstat))
                {
                    mapstat = new(data.mapname, data.mode);
                    mapstats[data.mapname] = mapstat;
                }
                mapstat.HandleOutcome(data.outcome);
                mapstat.AddNote([.. data.notes]);
                //if (!modestats.TryGetValue(data.mode, out var modestat))
                //{
                //    modestat = new(data.mode);
                //    modestats[data.mode] = modestat;
                //}
                //modestat.HandleOutcome(data.outcome);
                //DayStat.HandleOutcome(data.outcome);
            }
        }

        public void Combine(RecordStat stat)
        {
            foreach (var entry in stat.mapstats)
            {
                mapstats[entry.Key].Combine(entry.Value);
            }
        }
    }
}
