using System.Text;

namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer : Form
    {
        private readonly List<SessionRecordEntry> stats = [];
        private readonly Dictionary<string, MapStat> mapstats = [];
        private readonly Dictionary<string, ModeStat> modestats = [];
        private readonly Dictionary<string, DayStat> daystats = [];
        private readonly Dictionary<string, Dictionary<string, MapStat>> popstats = [];
        private readonly Dictionary<string, ComboStat> combostat = [];
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
            SortedSet<string> roles = [];
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
            for (int a = 0; a < role_checkedlistbox.Items.Count; a++)
            {
                role_checkedlistbox.SetItemChecked(a, true);
            }
        }

        private void LoadProfiles()
        {
            SortedSet<string> profiles = [];
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
            if (stats.Count == 0) return;
            var list = stats.OrderBy(entry => entry.date).ToList();
            start_date.Value = list[0].date;
            end_date.Value = list[^1].date;
            orgstart = list[0].date;
            orgend = list[^1].date;
        }

        private void LoadStats()
        {
            filteredentries.Clear();
            GenericStat notesoutcomes = new();
            foreach (SessionRecordEntry entry in stats)
            {
                if (!checkedprofiles.Contains(entry.profilename)) continue;
                if (entry.date > end_date.Value || entry.date < start_date.Value) continue;
                string dayofweek = entry.date.DayOfWeek.ToString();
                filteredentries.Add(entry);
                //data entries grid doesnt respect selected roles
                data_entries_grid.Rows.Add(entry.date, entry.GetNetWins(), entry.GetWins(), entry.GetLosses(), entry.GetDraws(), entry.GetTotal(), "...", entry);
                foreach (var data in entry.mapdata)
                {
                    if (!checkedroles.Contains(data.role)) continue;
                    if (!mapstats.TryGetValue(data.mapname, out var mapstat))
                    {
                        mapstat = new(data.mapname, data.mode);
                        mapstats[data.mapname] = mapstat;
                    }
                    mapstat.HandleOutcome(data.outcome);
                    mapstat.AddNote([.. data.notes]);
                    if (!modestats.TryGetValue(data.mode, out var modestat))
                    {
                        modestat = new(data.mode);
                        modestats[data.mode] = modestat;
                    }
                    modestat.HandleOutcome(data.outcome);
                    modestat.AddNote([.. data.notes]);
                    if (!daystats.TryGetValue(dayofweek, out var daystat))
                    {
                        daystat = new(entry.date.DayOfWeek);
                        daystats[dayofweek] = daystat;
                    }
                    daystat.HandleOutcome(data.outcome);
                    daystat.AddNote([.. data.notes]);
                    notesoutcomes.AddNote([.. data.notes]);
                    notesoutcomes.HandleOutcome(data.outcome);
                    if (!popstats.TryGetValue(dayofweek, out var value))
                    {
                        value = [];
                        popstats[dayofweek] = value;
                    }
                    if (!value.TryGetValue(data.mapname, out var mapvalue))
                    {
                        mapvalue = new(data.mapname, data.mode);
                        popstats[dayofweek][data.mapname] = mapvalue;
                    }
                    mapvalue.HandleOutcome(data.outcome);
                    mapvalue.AddNote([.. data.notes]);
                }
                if (!combostat.TryGetValue(dayofweek, out var combo))
                {
                    combo = new();
                    combostat[dayofweek] = combo;
                }
                combo.AddData(entry);
            }
            UpdateDataEntriesCount();
            foreach (var entry in mapstats.Values.OrderBy(stat => stat.map.mapname))
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                map_stats_grid.Rows.Add(entry.map.mapname, entry.map.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
            }
            int totalmisc = 0;
            int totalwins = 0;
            int totallosses = 0;
            int totaldraws = 0;
            foreach (var entry in modestats.Values)
            {
                int misc = entry.GetNoteCount() + entry.GetMiscCount();
                mode_stats_grid.Rows.Add(entry.mode, entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, misc, entry);
                totalwins += entry.wins;
                totallosses += entry.losses;
                totaldraws += entry.draws;
                totalmisc += misc;
            }
            int totalgames = totalwins + totallosses + totaldraws;
            double winrate = Math.Round(totalwins / (double)(totalwins + totallosses), 4) * 100;
            totals_grid.Rows.Add(totalwins, totallosses, totaldraws, totalgames, winrate, totalmisc, notesoutcomes);
            foreach (var entry in daystats.Values.OrderBy(day => day.day))
            {
                day_stats_grid.Rows.Add(entry.day.ToString(), entry.wins, entry.losses, entry.draws, entry.total, entry.winrate, entry.GetNoteCount() + entry.GetMiscCount(), entry);
            }
            foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            {
                string dayname = day.ToString();
                if (combostat.TryGetValue(dayname, out var dict))
                {
                    var map = dict.GetMostPopularMap(dayname);
                    if (map != default)
                    {
                        popular_grid.Rows.Add(dayname, map.map.mapname, map.winrate, map.total, "...", dict);
                        continue;
                    }
                }
                popular_grid.Rows.Add(dayname, "NA", 0, 0, "...");

                //if (popstats.TryGetValue(day.ToString(), out var dict))
                //{
                //    var map = dict.Values.OrderBy(entry => entry.total).LastOrDefault();
                //    if (map != default)
                //    {
                //        popular_grid.Rows.Add(day.ToString(), map.map.mapname, map.winrate, map.total, "...", dict);
                //        continue;
                //    }
                //}
                //popular_grid.Rows.Add(day.ToString(), "NA", 0, 0, "...");
            }
        }

        private void ResetStatGrids()
        {
            if (!allowupdate) return;
            map_stats_grid.Rows.Clear();
            mode_stats_grid.Rows.Clear();
            day_stats_grid.Rows.Clear();
            data_entries_grid.Rows.Clear();
            popular_grid.Rows.Clear();
            //UpdateDataEntriesCount();
            totals_grid.Rows.Clear();
            mapstats.Clear();
            modestats.Clear();
            daystats.Clear();
            combostat.Clear();
            popstats.Clear();
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
            GenericStat? stat = (GenericStat?)totals_grid.Rows[0].Cells[6].Value;
            Generic_Stats_Viewer viewer = new(stat, "Misc");
            viewer.PopulateGrids();
            data_entries_grid.Sort(data_entries_grid.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            ExportStatsToCSV(map_stats_grid, totals_grid, mode_stats_grid, day_stats_grid, data_entries_grid, viewer.notes_grid, viewer.misc_outcomes_grid);
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

        //grids are exported with the column count -2 to account for
        //the last 2 columns to not be exported
        private static void ExportCsv(DataGridView grid, string path)
        {
            //var lines = new List<string>
            //{
            //    string.Join(",", grid.Columns.Cast<DataGridViewColumn>().Select(c => Escape(c.HeaderText)))
            //};
            //lines.AddRange(grid.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).Select(r => string.Join(",", r.Cells.Cast<DataGridViewCell>().Select(c => Escape(c.Value?.ToString() ?? "")))));
            //File.WriteAllLines(path, lines, Encoding.UTF8);
            List<string> lines = [];
            List<string> headers = [];
            for (int i = 0; i < grid.Columns.Count - 2; i++)
            {
                if (!grid.Columns[i].Visible) continue;
                headers.Add(Escape(grid.Columns[i].HeaderText));
            }
            lines.Add(string.Join(",", headers));
            for (int r = 0; r < grid.Rows.Count; r++)
            {
                DataGridViewRow row = grid.Rows[r];
                if (row.IsNewRow) continue;
                List<string> cells = [];
                for (int c = 0; c < row.Cells.Count - 2; c++)
                {
                    if (!grid.Columns[c].Visible) continue;
                    DataGridViewCell cell = row.Cells[c];
                    object? cellobject = cell.Value;
                    string? cellvalue = "";
                    if (cellobject is DateTime time) cellvalue = time.ToShortDateString();
                    else cellvalue = cell.Value == null ? "" : cell.Value.ToString();
                    //string? value = cell.Value == null ? "" : cell.Value.ToString();
                    cells.Add(Escape(cellvalue));
                }
                lines.Add(string.Join(",", cells));
            }
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
            var data = (SessionRecordEntry?)data_entries_grid.Rows[e.RowIndex].Cells[7].Value;
            if (data == null) return;
            switch (e.ColumnIndex)
            {
                case 6:
                    Session_Viewer session_Viewer = new(data);
                    session_Viewer.Show();
                    break;
            }
        }

        private void map_search_textbox_TextChanged(object sender, EventArgs e)
        {
            data_entries_grid.Rows.Clear();
            string text = map_search_textbox.Text;
            foreach (var entry in filteredentries)
            {
                bool map = entry.mapdata.Where(data =>
                {
                    bool name = data.mapname.Contains(text, StringComparison.OrdinalIgnoreCase);
                    bool outcome = data.outcome.Contains(text, StringComparison.OrdinalIgnoreCase);
                    return name || outcome;
                }).Any();
                if (!map) continue;
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

        private void map_stats_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGenStatWindow(map_stats_grid, e, 8, 7);
        }

        private void mode_stats_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGenStatWindow(mode_stats_grid, e, 7, 6);
        }

        private void day_stats_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGenStatWindow(day_stats_grid, e, 7, 6);
        }

        private static void OpenGenStatWindow(DataGridView grid, DataGridViewCellEventArgs e, int infocol, int clickcol)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != clickcol) return;
            var entry = grid.Rows[e.RowIndex].Cells[infocol].Value;
            if (entry == null) return;
            string title = entry switch
            {
                MapStat m => m.map.mapname,
                ModeStat m => m.mode,
                DayStat d => d.day.ToString(),
                _ => "Misc"
            };
            Generic_Stats_Viewer gsview = new((GenericStat)entry, title);
            gsview.Show();
        }

        private void totals_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGenStatWindow(totals_grid, e, 6, 5);
        }

        private void popular_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != 4) return;
            var entry = (ComboStat?)popular_grid.Rows[e.RowIndex].Cells[5].Value;
            string? day = popular_grid.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (entry == null || day == null) return;
            Popular_Details_Viewer pop = new(entry, day);
            pop.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new(filteredentries);
            aboutBox1.Show();
        }
    }
}
