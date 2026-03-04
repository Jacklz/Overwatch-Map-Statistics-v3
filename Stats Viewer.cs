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
            LoadRoles();
            LoadProfiles();
            SetDates();
            LoadStats();            
        }

        private void LoadRoles()
        {
            Main.roles.ForEach(role => { role_checkedlistbox.Items.Add(role); });
            role_checkedlistbox.SetItemChecked(0, true);
        }

        private void LoadProfiles()
        {
            Main.profiles.ForEach(profile => { profile_checkedlistbox.Items.Add(profile); });
        }

        private void SetDates()
        {
            var list = stats.OrderBy(entry => entry.date).ToList();
            start_date.Value = list[0].date;
            end_date.Value = list[^1].date;
        }

        private void LoadStats()
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
            foreach (var entry in mapstats.Values.OrderBy(x => x.mapname))
            {
                map_stats_grid.Rows.Add(entry.mapname, entry.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate);
            }
        }
    }
}
