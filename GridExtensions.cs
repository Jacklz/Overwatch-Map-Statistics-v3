namespace Overwatch_Map_Statistics_v3
{
    internal static class GridExtensions
    {
        public static void PopulateDataEntries(this DataGridView grid, List<SessionRecordEntry> entries)
        {
            grid.Rows.Clear();
            foreach (var entry in entries)
            {
                grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetTotal(), "...", entry);
            }         
        }

        public static void PopulateMapStats(this DataGridView grid, IOrderedEnumerable<MapStat> entries)
        {
            grid.Rows.Clear();
            foreach (var entry in entries)
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
            }
        }

        public static void PopulateDayStats(this DataGridView grid, IOrderedEnumerable<DayStat> entries)
        {
            grid.Rows.Clear();
            foreach (var entry in entries)
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                grid.Rows.Add(entry.day.ToString(), entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
            }
        }
    }
}
