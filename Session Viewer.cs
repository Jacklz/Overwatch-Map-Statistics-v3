namespace Overwatch_Map_Statistics_v3
{
    partial class Session_Viewer : Form
    {
        private readonly SessionRecordEntry entry;
        private static bool consolidate = true;
        private bool canupdate = false;

        public Session_Viewer(SessionRecordEntry entry)
        {
            InitializeComponent();
            this.entry = entry;
            Text = $"Viewing session: {entry.date.ToShortDateString()}";
        }

        private void Session_Viewer_Load(object sender, EventArgs e)
        {
            canupdate = false;
            consolidate_session_checkbox.Checked = consolidate;
            canupdate = true;
            LoadStats();
        }

        private void LoadStats()
        {
            if (!canupdate) return;
            session_grid.Rows.Clear();
            PopulateGrid(consolidate == true ? entry.Consolidate() : entry.Summarize());
            session_entries_count_label.Text = $"{session_grid.Rows.Count} Entries";
        }

        private void PopulateGrid(List<MapStat> stats)
        {
            foreach (var stat in stats)
            {
                session_grid.Rows.Add(stat.map.mapname, stat.wins - stat.losses, stat.wins, stat.losses, stat.draws, stat.total, stat.winrate, stat.GetMiscCount() + stat.GetNoteCount(), stat);
            }
        }

        private void consolidate_session_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            consolidate = consolidate_session_checkbox.Checked;
            LoadStats();
        }

        private void session_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var entry = (MapStat?)session_grid.Rows[e.RowIndex].Cells[8].Value;
            if (entry == null) return;
            switch (e.ColumnIndex)
            {
                case 7:
                    Generic_Stats_Viewer gsview = new(entry, entry.map.mapname);
                    gsview.Show();
                    break;
            }
        }
    }
}
