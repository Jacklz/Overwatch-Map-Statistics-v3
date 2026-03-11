using System.Text.Json.Serialization;

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

        public List<MapStat> Summarize()
        {
            List<MapStat> mapstats = [];
            foreach (var entry in mapdata)
            {
                MapStat stat = new(entry.mapname, entry.mode);
                stat.HandleOutcome(entry.outcome);
                stat.AddNote([.. entry.notes]);
                mapstats.Add(stat);
            }
            return mapstats;
        }

        public List<MapStat> Consolidate()
        {
            Dictionary<string, MapStat> records = [];
            foreach (var entry in mapdata)
            {
                if (!records.TryGetValue(entry.mapname, out var value))
                {
                    value = new(entry.mapname, entry.mode);
                    records[entry.mapname] = value;
                }
                value.HandleOutcome(entry.outcome);
                value.AddNote([.. entry.notes]);
            }
            return [..records.Values];
        }

        public int GetTotal()
        {
            return GetWins() + GetLosses() + GetDraws();
        }

        public int GetNetWins()
        {
            return GetWins() - GetLosses();
        }

        public int GetWins()
        {
            return GetOutcomeCount("Win");
        }

        public int GetLosses()
        {
            return GetOutcomeCount("Loss");
        }

        public int GetDraws()
        {
            return GetOutcomeCount("Draw");
        }

        public int GetMiscOutcomes()
        {
            return mapdata.Where(entry => entry.outcome != "Win" && entry.outcome != "Loss" && entry.outcome != "Draw").Count();
        }

        private int GetOutcomeCount(string outcome)
        {
            return mapdata.Where(entry => entry.outcome == outcome).Count();
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
