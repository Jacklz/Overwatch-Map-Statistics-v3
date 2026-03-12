namespace Overwatch_Map_Statistics_v3
{
    partial class Popular_Details_Viewer : Form
    {
        private readonly ComboStat stat;
        private readonly string day;

        public Popular_Details_Viewer(ComboStat stat, string day)
        {
            InitializeComponent();
            this.stat = stat;
            this.day = day;
            Text = $"Map stats for '{day}'";
        }

        private void Popular_Details_Viewer_Load(object sender, EventArgs e)
        {
            pop_map_stats_grid.Rows.Clear();
            foreach (var entry in stat.mapstats[day].Values.OrderBy(map => map.map.mapname))
            {
                pop_map_stats_grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate);
            }
            mode_stats_grid.Rows.Clear();
            int totalmisc = 0;
            int totalwins = 0;
            int totallosses = 0;
            int totaldraws = 0;
            foreach (var entry in stat.modestats[day].Values)
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                mode_stats_grid.Rows.Add(entry.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
                totalwins += entry.wins;
                totallosses += entry.losses;
                totaldraws += entry.draws;
                totalmisc += misc;
            }
            int totalgames = totalwins + totallosses + totaldraws;
            double winrate = Math.Round(totalwins / (double)(totalwins + totallosses), 4) * 100;
            totals_grid.Rows.Clear();
            totals_grid.Rows.Add(totalwins, totallosses, totaldraws, totalgames, winrate, totalmisc, "");

            foreach (var entry in stat.records)
            {
                data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetTotal(), "...", entry);
            }
        }
    }
}
