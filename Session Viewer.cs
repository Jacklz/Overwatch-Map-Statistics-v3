namespace Overwatch_Map_Statistics_v3
{
    partial class Session_Viewer : Form
    {
        private readonly SessionRecordEntry entry;
        private static bool consolidate;
        private static bool canupdate = false;

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
            if (consolidate) PopulateGrid(entry.Consolidate());
            else PopulateGrid(entry.Summarize());
            session_entries_count_label.Text = $"{session_grid.Rows.Count} Entries";
        }

        private void PopulateGrid(List<MapStat> stats)
        {
            foreach (var stat in stats)
            {
                session_grid.Rows.Add(stat.map.mapname, stat.wins - stat.losses, stat.wins, stat.losses, stat.draws, stat.GetMiscCount(), stat.total, stat.winrate);
            }
        }

        private void consolidate_session_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            consolidate = consolidate_session_checkbox.Checked;
            LoadStats();
        }
    }
}
