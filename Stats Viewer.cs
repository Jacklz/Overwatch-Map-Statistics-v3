namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer : Form
    {
        private readonly List<SessionRecordEntry> stats = [];

        public Stats_Viewer(List<SessionRecordEntry> entries)
        {
            InitializeComponent();
            stats.AddRange(entries);
        }

        private void Stats_Viewer_Load(object sender, EventArgs e)
        {

        }
    }
}
