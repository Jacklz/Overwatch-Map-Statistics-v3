namespace Overwatch_Map_Statistics_v3
{
    partial class Popular_Details_Viewer : Form
    {
        private readonly Dictionary<string, MapStat> dict;

        public Popular_Details_Viewer(Dictionary<string, MapStat> dict, string day)
        {
            InitializeComponent();
            this.dict = dict;
            Text = $"Map stats for '{day}'";
        }

        private void Popular_Details_Viewer_Load(object sender, EventArgs e)
        {

        }
    }
}
