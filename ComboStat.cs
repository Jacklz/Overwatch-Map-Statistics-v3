namespace Overwatch_Map_Statistics_v3
{
    internal class ComboStat
    {
        public readonly List<SessionRecordEntry> records = [];
        public readonly Dictionary<string, Dictionary<string, MapStat>> mapstats = [];
        public readonly Dictionary<string, Dictionary<string, ModeStat>> modestats = [];

        public void AddData(SessionRecordEntry record)
        {
            records.Add(record);
            string dayofweek = record.date.DayOfWeek.ToString();
            foreach (var data in record.mapdata)
            {
                if (!mapstats.TryGetValue(dayofweek, out var mapdict))
                {
                    mapdict = [];
                    mapstats[dayofweek] = mapdict;
                }
                if (!mapdict.TryGetValue(data.mapname, out var mapvalue))
                {
                    mapvalue = new(data.mapname, data.mode);
                    mapstats[dayofweek][data.mapname] = mapvalue;
                }
                mapvalue.HandleOutcome(data.outcome);
                mapvalue.AddNote([.. data.notes]);

                if (!modestats.TryGetValue(dayofweek, out var modedict))
                {
                    modedict = [];
                    modestats[dayofweek] = modedict;
                }
                if (!modedict.TryGetValue(data.mode, out var modevalue))
                {
                    modevalue = new(data.mode);
                    modestats[dayofweek][data.mode] = modevalue;
                }
                modevalue.HandleOutcome(data.outcome);
                modevalue.AddNote([..data.notes]);
            }
        }

        public MapStat? GetMostPopularMap(string day)
        {
            return mapstats[day].Values.OrderBy(entry => entry.total).LastOrDefault();
        }
    }
}
