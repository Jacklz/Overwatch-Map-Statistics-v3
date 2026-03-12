namespace Overwatch_Map_Statistics_v3
{
    partial class AboutBox1 : Form
    {
        private readonly List<SessionRecordEntry> entries;

        public AboutBox1(List<SessionRecordEntry> entries)
        {
            InitializeComponent();
            this.entries = entries;
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            var grid = GridCreator.CreateDataEntriesGrid(700, 400);
            grid.Location = new(0, 0);
            this.Controls.Add(grid);
            grid.PopulateDataEntries(entries);
        }
    }
}
