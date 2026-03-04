using ClosedXML.Excel;

namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer : Form
    {
        private readonly List<SessionRecordEntry> stats = [];
        private readonly Dictionary<string, RecordStat> mapstats = [];
        private readonly Dictionary<string, RecordStat> modestats = [];
        private readonly Dictionary<string, RecordStat> daystats = [];
        private DateTime orgstart;
        private DateTime orgend;
        private bool allowupdate = false;
        private readonly HashSet<string> checkedprofiles = [];
        private readonly HashSet<string> checkedroles = [];

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
            allowupdate = true;
        }

        private void LoadRoles()
        {
            Main.roles.ForEach(role => { role_checkedlistbox.Items.Add(role); });
            role_checkedlistbox.SetItemChecked(0, true);
        }

        private void LoadProfiles()
        {
            Main.profiles.ForEach(profile => { profile_checkedlistbox.Items.Add(profile); });
            for (int a = 0; a < profile_checkedlistbox.Items.Count; a++)
            {
                profile_checkedlistbox.SetItemChecked(a, true);
            }
        }

        private void SetDates()
        {
            var list = stats.OrderBy(entry => entry.date).ToList();
            start_date.Value = list[0].date;
            end_date.Value = list[^1].date;
            orgstart = list[0].date;
            orgend = list[^1].date;
        }

        private void LoadStats()
        {
            foreach (var entry in stats)
            {
                if (!checkedprofiles.Contains(entry.profilename)) continue;
                if (entry.date > end_date.Value || entry.date < start_date.Value) continue;
                foreach (var data in entry.mapdata)
                {
                    if (!checkedroles.Contains(data.role)) continue;
                    if (!mapstats.TryGetValue(data.mapname, out var mapstat))
                    {
                        mapstat = new(data.mapname, data.mode, entry.date.DayOfWeek);
                        mapstats[data.mapname] = mapstat;
                    }
                    mapstat.HandleOutcome(data.outcome);
                    if (!modestats.TryGetValue(data.mode, out var modestat))
                    {
                        modestat = new(data.mapname, data.mode, entry.date.DayOfWeek);
                        modestats[data.mode] = modestat;
                    }
                    modestat.HandleOutcome(data.outcome);
                    if (!daystats.TryGetValue(entry.date.DayOfWeek.ToString(), out var daystat))
                    {
                        daystat = new(data.mapname, data.mode, entry.date.DayOfWeek);
                        daystats[entry.date.DayOfWeek.ToString()] = daystat;
                    }
                    daystat.HandleOutcome(data.outcome);
                }
            }
            foreach (var entry in mapstats.Values.OrderBy(stat => stat.MapStat.map.mapname).Select(stat => stat.MapStat))
            {
                map_stats_grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.miscoutcomes.Count, entry.total, entry.winrate);
            }
            foreach (var entry in modestats.Values.Select(stat => stat.ModeStat))
            {
                mode_stats_grid.Rows.Add(entry.mode, entry.wins, entry.losses, entry.draws, entry.miscoutcomes.Count, entry.total, entry.winrate);
            }
            foreach (var entry in daystats.Values.Select(stat => stat.DayStat))
            {
                day_stats_grid.Rows.Add(entry.day.ToString(), entry.wins, entry.losses, entry.draws, entry.miscoutcomes.Count, entry.total, entry.winrate);
            }
        }

        private void ResetStatGrids()
        {
            if (!allowupdate) return;
            map_stats_grid.Rows.Clear();
            mode_stats_grid.Rows.Clear();
            day_stats_grid.Rows.Clear();
            mapstats.Clear();
            modestats.Clear();
            daystats.Clear();
            LoadStats();
        }

        private void reset_dates_button_Click(object sender, EventArgs e)
        {
            start_date.Value = orgstart;
            end_date.Value = orgend;
            ResetStatGrids();
        }

        private void profile_checkedlistbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? profile = profile_checkedlistbox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked) checkedprofiles.Add(profile);
            else checkedprofiles.Remove(profile);
            ResetStatGrids();
        }

        private void role_checkedlistbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? role = role_checkedlistbox.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked) checkedroles.Add(role);
            else checkedroles.Remove(role);
            ResetStatGrids();
        }

        private void AlterCheckState(CheckedListBox box, bool ischecked)
        {
            allowupdate = false;
            for (int a = 0; a < box.Items.Count; a++)
            {
                box.SetItemChecked(a, ischecked);
            }
            allowupdate = true;
            ResetStatGrids();
        }

        private void check_all_profiles_button_Click(object sender, EventArgs e)
        {
            AlterCheckState(profile_checkedlistbox, true);
        }

        private void uncheck_all_profiles_button_Click(object sender, EventArgs e)
        {
            AlterCheckState(profile_checkedlistbox, false);
        }

        private void check_all_roles_button_Click(object sender, EventArgs e)
        {
            AlterCheckState(role_checkedlistbox, true);
        }

        private void uncheck_all_roles_button_Click(object sender, EventArgs e)
        {
            AlterCheckState(role_checkedlistbox, false);
        }

        private void export_stats_button_Click(object sender, EventArgs e)
        {
            Dictionary<string, DataGridView> stats = [];
            stats.Add("Map Stats", map_stats_grid);
            ExportToExcel(stats, "recordsheet.xlsx");
            MessageBox.Show("Successfully exported current state of grids to file 'recordsheet.xlsx'");
        }

        public static void ExportToExcel(Dictionary<string, DataGridView> dataGrids, string filePath)
        {
            using var workbook = new XLWorkbook();
            foreach (var kvp in dataGrids)
            {
                string sheetName = kvp.Key;
                DataGridView dgv = kvp.Value;
                var ws = workbook.Worksheets.Add(sheetName);
                // Headers
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    ws.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
                }
                // Rows
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    if (dgv.Rows[row].IsNewRow) continue;
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        ws.Cell(row + 2, col + 1).Value = dgv.Rows[row].Cells[col].Value?.ToString() ?? "";
                    }
                }
                ws.Columns().AdjustToContents();
            }
            workbook.SaveAs(filePath);
        }
    }
}
