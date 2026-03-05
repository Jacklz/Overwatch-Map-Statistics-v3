namespace Overwatch_Map_Statistics_v3
{
    internal class LegacyRecordStat(string profilename, DateTime date)
    {
        public DateTime date = date;
        public string profilename = profilename;
        public List<MapDataEntry> entries = [];

        public void AddMapEntry(MapDataEntry entry)
        {
            entries.Add(entry);
        }

        public void AddMapEntries(List<MapDataEntry> entries)
        {
            this.entries.AddRange(entries);
        }

        public int GetModeTotals(string modename = "allmodes", string role = "All roles")
        {
            int total = 0;
            if (modename == "allmodes") entries.ForEach(x => total += x.GetTotal(role));
            else entries.Where(x => x.maptype.ToLower() == modename.ToLower()).ToList().ForEach(x => total += x.GetTotal(role));
            return total;
        }

        public int GetModeDraws(string modename = "allmodes", string role = "All roles")
        {
            int draws = 0;
            if (modename == "allmodes") entries.ForEach(x => draws += x.GetDraws(role));
            else entries.Where(x => x.maptype.ToLower() == modename.ToLower()).ToList().ForEach(x => draws += x.GetDraws(role));
            return draws;
        }

        public int GetModeLosses(string modename = "allmodes", string role = "All roles")
        {
            int losses = 0;
            if (modename == "allmodes") entries.ForEach(x => losses += x.GetLosses(role));
            else entries.Where(x => x.maptype.ToLower() == modename.ToLower()).ToList().ForEach(x => losses += x.GetLosses(role));
            return losses;
        }

        public int GetModeWins(string modename = "allmodes", string role = "All roles")
        {
            int wins = 0;
            if (modename == "allmodes") entries.ForEach(x => wins += x.GetWins(role));
            else entries.Where(x => x.maptype.ToLower() == modename.ToLower()).ToList().ForEach(x => wins += x.GetWins(role));
            return wins;
        }

        public int GetTotals(string mapname = "allmaps", string role = "All roles")
        {
            int total = 0;
            if (mapname == "allmaps") entries.ForEach(x => total += x.GetTotal(role));
            else entries.Where(x => x.mapname.ToLower() == mapname.ToLower()).ToList().ForEach(x => total += x.GetTotal(role));
            return total;
        }

        public int GetDraws(string mapname = "allmaps", string role = "All roles")
        {
            int draws = 0;
            if (mapname == "allmaps") entries.ForEach(x => draws += x.GetDraws(role));
            else entries.Where(x => x.mapname.ToLower() == mapname.ToLower()).ToList().ForEach(x => draws += x.GetDraws(role));
            return draws;
        }

        public int GetLosses(string mapname = "allmaps", string role = "All roles")
        {
            int losses = 0;
            if (mapname == "allmaps") entries.ForEach(x => losses += x.GetLosses(role));
            else entries.Where(x => x.mapname.ToLower() == mapname.ToLower()).ToList().ForEach(x => losses += x.GetLosses(role));
            return losses;
        }

        public int GetWins(string mapname = "allmaps", string role = "All roles")
        {
            int wins = 0;
            if (mapname == "allmaps") entries.ForEach(x => wins += x.GetWins(role));
            else entries.Where(x => x.mapname.ToLower() == mapname.ToLower()).ToList().ForEach(x => wins += x.GetWins(role));
            return wins;
        }

        internal class MapDataEntry(string mapname, string maptype, int wins, int losses, int draws, string role)
        {
            public string mapname = mapname;
            public string maptype = maptype;
            public int wins = wins;
            public int losses = losses;
            public int draws = draws;
            public string role = role;

            public int GetTotal(string role)
            {
                if (this.role != role && role != "All roles") return 0;
                return wins + losses + draws;
            }

            public int GetWins(string role)
            {
                if (this.role != role && role != "All roles") return 0;
                return wins;
            }

            public int GetLosses(string role)
            {
                if (this.role != role && role != "All roles") return 0;
                return losses;
            }

            public int GetDraws(string role)
            {
                if (this.role != role && role != "All roles") return 0;
                return draws;
            }

            public double GetWinPercent()
            {
                if (wins + losses == 0) return 0;
                return Math.Round((double)wins / (wins + losses) * 100, 2);
            }
        }
    }
}
