namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer : Form
    {
        private readonly List<SessionRecordEntry> stats = [];
        private readonly Dictionary<string, MapStat> mapstats = [];

        public Stats_Viewer(List<SessionRecordEntry> entries)
        {
            InitializeComponent();
            stats.AddRange(entries);
        }

        private void Stats_Viewer_Load(object sender, EventArgs e)
        {
            foreach (var entry in stats)
            {
                foreach (var data in entry.mapdata)
                {
                    if (!mapstats.ContainsKey(data.mapname)) mapstats[data.mapname] = new(data.mapname, data.mode);
                    switch (data.outcome)
                    {
                        case "Win": mapstats[data.mapname].AddWin(1); break;
                        case "Loss": mapstats[data.mapname].AddLoss(1); break;
                        case "Draw": mapstats[data.mapname].AddDraw(1); break;
                        default: break;
                    }
                }
            }
        }
    }
}
