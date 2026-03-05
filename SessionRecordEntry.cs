using Newtonsoft.Json;

namespace Overwatch_Map_Statistics_v3
{
    internal class SessionRecordEntry
    {
        public string profilename;
        public string statprofilename;
        public DateTime date;
        public List<MapResult> mapdata = [];

        [JsonConstructor]
        public SessionRecordEntry(string profilename, string statprofilename, DateTime date)
        {
            this.profilename = profilename;
            this.statprofilename = statprofilename;
            this.date = date;
        }

        public SessionRecordEntry(LegacyRecordStat stat)
        {
            profilename = stat.profilename;
            statprofilename = "legacy";
            date = stat.date;
            foreach (var entry in stat.entries)
            {
                for (int a = 0; a < entry.wins; a++)
                {
                    MapResult result = new(entry.mapname, entry.maptype, entry.role, "Win", []);
                    mapdata.Add(result);
                }
                for (int a = 0; a < entry.losses; a++)
                {
                    MapResult result = new(entry.mapname, entry.maptype, entry.role, "Loss", []);
                    mapdata.Add(result);
                }
                for (int a = 0; a < entry.draws; a++)
                {
                    MapResult result = new(entry.mapname, entry.maptype, entry.role, "Draw", []);
                    mapdata.Add(result);
                }
            }
        }

        public void AddMapResult(MapResult mapdata)
        {
            this.mapdata.Add(mapdata);
        }

        public SessionRecordEntry Clone()
        {
            SessionRecordEntry copy = new(profilename, statprofilename, date);
            mapdata.ForEach(entry => copy.AddMapResult(entry.Clone()));
            return copy;
        }
    }
}
