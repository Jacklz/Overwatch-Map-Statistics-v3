namespace Overwatch_Map_Statistics_v3
{
    partial class Generic_Stats_Viewer : Form
    {
        private readonly GenericStat stat;

        public Generic_Stats_Viewer(GenericStat stat, string info)
        {
            InitializeComponent();
            this.stat = stat;
            Text = $"{info}";
        }

        private void Generic_Stats_Viewer_Load(object sender, EventArgs e)
        {
            PopulateGrids();
        }

        public void PopulateGrids()
        {
            misc_outcomes_grid.Rows.Clear();
            foreach (var entry in stat.miscoutcomes)
            {
                misc_outcomes_grid.Rows.Add(entry.Key, entry.Value.count);
            }
            notes_grid.Rows.Clear();
            foreach (var entry in stat.notes)
            {
                notes_grid.Rows.Add(entry.Key, entry.Value.count);
            }
        }
    }
}
