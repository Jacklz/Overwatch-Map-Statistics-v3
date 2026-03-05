namespace Overwatch_Map_Statistics_v3
{
    partial class Session_Viewer : Form
    {
        private readonly SessionRecordEntry entry;

        public Session_Viewer(SessionRecordEntry entry)
        {
            InitializeComponent();
            this.entry = entry;
        }

        private void Session_Viewer_Load(object sender, EventArgs e)
        {
            foreach (var stat in entry.Consolidate().mapstats.Values)
            {
                session_grid.Rows.Add(stat.map.mapname, stat.wins - stat.losses, stat.wins, stat.losses, stat.draws, stat.miscoutcomes.Count, stat.total, stat.winrate);
            }
        }
    }
}
