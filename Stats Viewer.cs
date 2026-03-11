using System.Text;

namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer : Form
    {
        private readonly List<SessionRecordEntry> stats = [];
        private readonly Dictionary<string, MapStat> mapstats = [];
        private readonly Dictionary<string, ModeStat> modestats = [];
        private readonly Dictionary<string, DayStat> daystats = [];
        private readonly Dictionary<string, int> notestats = [];
        private DateTime orgstart;
        private DateTime orgend;
        private bool allowupdate = false;
        private readonly HashSet<string> checkedprofiles = [];
        private readonly HashSet<string> checkedroles = [];
        private readonly List<SessionRecordEntry> filteredentries = [];
        private readonly Main instance;

        public Stats_Viewer(List<SessionRecordEntry> entries, Main instance, List<string> statprofiles)
        {
            InitializeComponent();
            stats.AddRange(entries);
            this.instance = instance;
            string plural = "";
            if (statprofiles.Count > 1) plural = "s";
            Text = $"Stat profile{plural}: {string.Join(",", statprofiles)}";
        }

        //need to account for an empty stats list
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
            HashSet<string> roles = [];
            foreach (var entry in stats)
            {
                foreach (var element in entry.mapdata)
                {
                    roles.Add(element.role);
                }
            }
            foreach (var entry in roles)
            {
                role_checkedlistbox.Items.Add(entry);
            }
            role_checkedlistbox.SetItemChecked(0, true);
        }

        private void LoadProfiles()
        {
            HashSet<string> profiles = [];
            foreach (var entry in stats)
            {
                profiles.Add(entry.profilename);
            }
            foreach (var entry in profiles)
            {
                profile_checkedlistbox.Items.Add(entry);
            }
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
            filteredentries.Clear();
            foreach (SessionRecordEntry entry in stats)
            {
                if (!checkedprofiles.Contains(entry.profilename)) continue;
                if (entry.date > end_date.Value || entry.date < start_date.Value) continue;
                filteredentries.Add(entry);
                //data entries grid doesnt respect selected roles
                data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetMiscOutcomes(), entry.GetTotal(), "...", entry);
                //need to also handle notes
                foreach (var data in entry.mapdata)
                {
                    if (!checkedroles.Contains(data.role)) continue;
                    if (!mapstats.TryGetValue(data.mapname, out var mapstat))
                    {
                        mapstat = new(data.mapname, data.mode);
                        mapstats[data.mapname] = mapstat;
                    }
                    mapstat.HandleOutcome(data.outcome);
                    mapstat.AddNote([..data.notes]);
                    if (!modestats.TryGetValue(data.mode, out var modestat))
                    {
                        modestat = new(data.mode);
                        modestats[data.mode] = modestat;
                    }
                    modestat.HandleOutcome(data.outcome);
                    modestat.AddNote([.. data.notes]);
                    if (!daystats.TryGetValue(entry.date.DayOfWeek.ToString(), out var daystat))
                    {
                        daystat = new(entry.date.DayOfWeek);
                        daystats[entry.date.DayOfWeek.ToString()] = daystat;
                    }
                    daystat.HandleOutcome(data.outcome);
                    daystat.AddNote([.. data.notes]);
                    foreach (var note in data.notes)
                    {
                        if (!notestats.TryGetValue(note, out int value)) notestats[note] = 1;
                        else notestats[note] = value + 1;
                    }
                }
            }
            UpdateDataEntriesCount();
            foreach (var entry in mapstats.Values.OrderBy(stat => stat.map.mapname))
            {
                map_stats_grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.GetMiscCount(), entry.total, entry.winrate);
            }
            int totalwins = 0;
            int totallosses = 0;
            int totaldraws = 0;
            int totalmisc = 0;
            foreach (var entry in modestats.Values)
            {
                mode_stats_grid.Rows.Add(entry.mode, entry.wins, entry.losses, entry.draws, entry.GetMiscCount(), entry.total, entry.winrate);
                totalwins += entry.wins;
                totallosses += entry.losses;
                totaldraws += entry.draws;
                totalmisc += entry.GetMiscCount();
            }
            int totalgames = totalwins + totallosses + totaldraws;
            double winrate = Math.Round((double)totalwins / (double)(totalwins + totallosses), 4) * 100;
            totals_grid.Rows.Add(totalwins, totallosses, totaldraws, totalmisc, totalgames, winrate);
            foreach (var entry in daystats.Values.OrderBy(day => day.day))
            {
                day_stats_grid.Rows.Add(entry.day.ToString(), entry.wins, entry.losses, entry.draws, entry.GetMiscCount(), entry.total, entry.winrate);
            }
            foreach (var entry in notestats)
            {
                notes_grid.Rows.Add(entry.Key, entry.Value);
            }
        }

        private void ResetStatGrids()
        {
            if (!allowupdate) return;
            map_stats_grid.Rows.Clear();
            mode_stats_grid.Rows.Clear();
            day_stats_grid.Rows.Clear();
            UpdateDataEntriesCount();
            data_entries_grid.Rows.Clear();
            totals_grid.Rows.Clear();
            mapstats.Clear();
            modestats.Clear();
            daystats.Clear();
            notestats.Clear();
            filteredentries.Clear();
            LoadStats();
        }

        private void reset_dates_button_Click(object sender, EventArgs e)
        {
            allowupdate = false;
            start_date.Value = orgstart;
            end_date.Value = orgend;
            allowupdate = true;
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
            ExportStatsToCSV(map_stats_grid, totals_grid, mode_stats_grid, day_stats_grid);
            MessageBox.Show("Successfully exported the current state of grids");
        }

        private static void ExportStatsToCSV(params DataGridView[] grids)
        {
            Directory.CreateDirectory("Exported stats");
            string time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string export = Path.Combine("Exported stats", time);
            Directory.CreateDirectory(export);
            foreach (var grid in grids)
            {
                string path = Path.Combine("Exported stats", time, $"{grid.Name}.csv");
                ExportCsv(grid, path);
            }
        }

        private static void ExportCsv(DataGridView grid, string path)
        {
            var lines = new List<string>
            {
                string.Join(",", grid.Columns.Cast<DataGridViewColumn>().Select(c => Escape(c.HeaderText)))
            };
            lines.AddRange(grid.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).Select(r => string.Join(",", r.Cells.Cast<DataGridViewCell>().Select(c => Escape(c.Value?.ToString() ?? "")))));
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        private static string Escape(string s)
        {
            if (s.Contains('"')) s = s.Replace("\"", "\"\"");
            if (s.Contains(',') || s.Contains('"') || s.Contains('\n')) s = $"\"{s}\"";
            return s;
        }

        //public static void ExportToExcel(Dictionary<string, DataGridView> grids, string file)
        //{
        //    using var workbook = new XLWorkbook();
        //    foreach (var kvp in grids)
        //    {
        //        string sheetName = kvp.Key;
        //        DataGridView dgv = kvp.Value;
        //        var ws = workbook.Worksheets.Add(sheetName);
        //        // Headers
        //        for (int col = 0; col < dgv.Columns.Count; col++)
        //        {
        //            ws.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
        //        }
        //        // Rows
        //        for (int row = 0; row < dgv.Rows.Count; row++)
        //        {
        //            if (dgv.Rows[row].IsNewRow) continue;
        //            for (int col = 0; col < dgv.Columns.Count; col++)
        //            {
        //                ws.Cell(row + 2, col + 1).Value = dgv.Rows[row].Cells[col].Value?.ToString() ?? "";
        //            }
        //        }
        //        ws.Columns().AdjustToContents();
        //    }
        //    workbook.SaveAs(file);
        //}

        private void save_selection_Click(object sender, EventArgs e)
        {
            string newname = newstat_profilename_textbox.Text;
            if (newname.Length == 0)
            {
                MessageBox.Show("Enter a name!");
                return;
            }
            List<SessionRecordEntry> newentries = [.. filteredentries.Select(entry => entry.Clone())];
            StatProfileManager.SaveStatProfileData(newname, false, [.. newentries]);
            instance.UpdateStatDisplayLists();
            MessageBox.Show("Successfully saved selected data to new stat profile");
        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {
            ResetStatGrids();
        }

        private void end_date_ValueChanged(object sender, EventArgs e)
        {
            ResetStatGrids();
        }

        private void data_entries_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var data = (SessionRecordEntry?)data_entries_grid.Rows[e.RowIndex].Cells[8].Value;
            if (data == null) return;
            switch (e.ColumnIndex)
            {
                case 5:

                    break;
                case 7:
                    Session_Viewer session_Viewer = new(data);
                    session_Viewer.Show();
                    break;
            }
        }

        private void map_search_textbox_TextChanged(object sender, EventArgs e)
        {
            data_entries_grid.Rows.Clear();
            foreach (var entry in filteredentries)
            {
                if (!entry.mapdata.Where(data => data.mapname.Contains(map_search_textbox.Text, StringComparison.OrdinalIgnoreCase)).Any()) continue;
                data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetMiscOutcomes(), entry.GetTotal(), "...", entry);
            }
            UpdateDataEntriesCount();
        }

        private void UpdateDataEntriesCount()
        {
            entries_count_label.Text = $"Entries: {data_entries_grid.Rows.Count}";
        }

        private void Stats_Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.statwindows.Remove(this);
        }
    }
}
