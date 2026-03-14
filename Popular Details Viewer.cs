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
                pop_map_stats_grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, entry.GetMiscCount() + entry.GetNoteCount(), entry);
            }
            pop_mode_stats_grid.Rows.Clear();
            int totalmisc = 0;
            int totalwins = 0;
            int totallosses = 0;
            int totaldraws = 0;
            GenericStat notesoutcomes = new();
            foreach (var entry in stat.modestats[day].Values)
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                pop_mode_stats_grid.Rows.Add(entry.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
                totalwins += entry.wins;
                totallosses += entry.losses;
                totaldraws += entry.draws;
                totalmisc += misc;
                foreach (var data in entry.notes)
                {
                    for (int a = 0; a < data.Value.count; a++)
                    {
                        notesoutcomes.AddNote(data.Key);
                    }
                }
                foreach (var data in entry.miscoutcomes)
                {
                    for (int a = 0; a < data.Value.count; a++)
                    {
                        notesoutcomes.HandleOutcome(data.Key);
                    }
                }
            }
            int totalgames = totalwins + totallosses + totaldraws;
            double winrate = Math.Round(totalwins / (double)(totalwins + totallosses), 4) * 100;
            pop_totals_grid.Rows.Clear();
            pop_totals_grid.Rows.Add(totalwins, totallosses, totaldraws, totalgames, winrate, totalmisc, notesoutcomes);
            foreach (var entry in stat.records)
            {
                pop_data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetTotal(), "...", entry);
            }
            pop_data_entries_grid.Sort(pop_data_entries_grid.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            UpdateDataEntriesCount();
        }

        private void data_entries_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var data = (SessionRecordEntry?)pop_data_entries_grid.Rows[e.RowIndex].Cells[7].Value;
            if (data == null) return;
            switch (e.ColumnIndex)
            {
                case 6:
                    Session_Viewer session_Viewer = new(data);
                    session_Viewer.Show();
                    break;
            }
        }

        private void pop_map_stats_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Stats_Viewer.OpenGenStatWindow(pop_map_stats_grid, e, 8, 7);
        }

        private void totals_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Stats_Viewer.OpenGenStatWindow(pop_totals_grid, e, 6, 5);
        }

        private void mode_stats_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Stats_Viewer.OpenGenStatWindow(pop_mode_stats_grid, e, 7, 6);
        }

        private void export_day_button_Click(object sender, EventArgs e)
        {
            Stats_Viewer.ExportStatsToCSV(day, pop_map_stats_grid, pop_totals_grid, pop_mode_stats_grid, pop_data_entries_grid);
            MessageBox.Show($"Successfully exported '{day}' stats");
        }

        private void map_search_textbox_TextChanged(object sender, EventArgs e)
        {
            pop_data_entries_grid.Rows.Clear();
            string text = map_search_textbox.Text;
            foreach (var entry in stat.records)
            {
                bool map = entry.mapdata.Where(data =>
                {
                    bool name = data.mapname.Contains(text, StringComparison.OrdinalIgnoreCase);
                    bool outcome = data.outcome.Contains(text, StringComparison.OrdinalIgnoreCase);
                    bool note = data.notes.Where(item => item.Contains(text, StringComparison.OrdinalIgnoreCase)).Any();
                    return name || outcome || note;
                }).Any();
                if (!map) continue;
                pop_data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetTotal(), "...", entry);
            }
            pop_data_entries_grid.Sort(pop_data_entries_grid.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            UpdateDataEntriesCount();
        }

        private void UpdateDataEntriesCount()
        {
            entries_count_label.Text = $"Entries: {pop_data_entries_grid.Rows.Count}";
        }
    }
}
