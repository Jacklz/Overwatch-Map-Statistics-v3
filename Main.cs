namespace Overwatch_Map_Statistics_v3
{
    public partial class Main : Form
    {
        internal static Dictionary<string, string> maptomode = [];
        internal static List<Stats_Viewer> statwindows = [];
        internal static char[] forbiddencharacters = ['-', ',', '|', '"', '\''];

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();
            session_date_picker.Value = DateTime.Today;
            PrepareDirectory();
            UpdateAllDisplayLists();
            UpdateRecordLabel();
            CreateAllContextMenus();
        }

        private static void PrepareDirectory()
        {
            StatProfileManager.LoadStatProfiles();
            EntriesManager.CreateAllFiles();
        }

        private void UpdateAllDisplayLists()
        {
            UpdateRoleDisplayList();
            UpdateMapsDisplayLists();
            UpdateModesDisplayLists();
            UpdateNotesDisplayLists();
            UpdateOutcomesDisplayLists();
            UpdateProfileDisplayLists();
            UpdateStatDisplayLists();
        }

        public void UpdateStatDisplayLists()
        {
            statprofiles_checkedlistbox.Items.Clear();
            save_statprofile_combobox.Items.Clear();
            foreach (var profile in StatProfileManager.statprofiles)
            {
                statprofiles_checkedlistbox.Items.Add(profile);
                save_statprofile_combobox.Items.Add(profile);
            }
        }

        public void UpdateRoleDisplayList()
        {
            role_combobox.Items.Clear();
            foreach (var role in EntriesManager.allroles)
            {
                role_combobox.Items.Add(role);
            }
        }

        private void UpdateOutcomesDisplayLists()
        {
            outcomes_listbox.Items.Clear();
            outcome_combobox.Items.Clear();
            foreach (var outcome in EntriesManager.alloutcomes)
            {
                outcomes_listbox.Items.Add(outcome);
                outcome_combobox.Items.Add(outcome);
            }
        }

        private void UpdateNotesDisplayLists()
        {
            notes_listbox.Items.Clear();
            notes_checkedlistbox.Items.Clear();
            foreach (var note in EntriesManager.allnotes)
            {
                notes_listbox.Items.Add(note);
                notes_checkedlistbox.Items.Add(note);
            }
        }

        private void UpdateModesDisplayLists()
        {
            map_type_combo.Items.Clear();
            modelist_box.Items.Clear();
            foreach (var mode in EntriesManager.allmodes)
            {
                map_type_combo.Items.Add(mode);
                modelist_box.Items.Add(mode);
            }
        }

        private void UpdateMapsDisplayLists()
        {
            maplist_combobox.Items.Clear();
            maplist_box.Items.Clear();
            maptomode.Clear();
            EntriesManager.allmaps.Sort((m1, m2) =>
            {
                return m1.mapname.CompareTo(m2.mapname);
            });
            foreach (var map in EntriesManager.allmaps)
            {
                maptomode[map.mapname] = map.mode;
                maplist_combobox.Items.Add(map.mapname);
                maplist_box.Items.Add(map.fullname);
            }
        }

        private void add_entry_button_Click(object sender, EventArgs e)
        {
            int map = maplist_combobox.SelectedIndex;
            int selout = outcome_combobox.SelectedIndex;
            int roleindex = role_combobox.SelectedIndex;
            if (map == -1 || selout == -1 || roleindex == -1)
            {
                MessageBox.Show("Error adding entry. Make sure the map, role, and outcome fields are set!");
                return;
            }
            string? mapname = maplist_combobox.Items[map]?.ToString();
            string? role = role_combobox.Items[roleindex]?.ToString();
            string? outcome = outcome_combobox.Items[selout]?.ToString();
            List<string> notes = [];
            foreach (string note in notes_checkedlistbox.CheckedItems)
            {
                notes.Add(note);
            }
            string entry = $"{mapname} - {role} - {outcome}";
            if (notes.Count > 0) entry += $" - {string.Join(" | ", notes)}";
            session_entries_listbox.Items.Add(entry);
            session_entries_listbox.TopIndex = session_entries_listbox.Items.Count - 1;
            ResetCurrentEntry();
            UpdateRecordLabel();
        }

        private static bool RequestConfirmation(string message, string title = "")
        {
            if (Settings.showconfirmdialogs)
            {
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return false;
            }
            return true;
        }

        private void reset_entry_button_Click(object sender, EventArgs e)
        {
            if (!RequestConfirmation("Are you sure you want to reset the session?")) return;
            ResetCurrentSession();
        }

        private void ResetCurrentSession()
        {
            session_entries_listbox.Items.Clear();
            session_date_picker.Value = DateTime.Today;
            UpdateRecordLabel();
            ResetCurrentEntry();
            role_combobox.SelectedIndex = -1;
        }

        private void ResetCurrentEntry()
        {
            maplist_combobox.SelectedIndex = -1;
            outcome_combobox.SelectedIndex = -1;
            notes_checkedlistbox.SelectedIndex = -1;
            for (int a = 0; a < notes_checkedlistbox.Items.Count; a++)
            {
                notes_checkedlistbox.SetItemChecked(a, false);
            }
        }

        private void add_mode_button_Click(object sender, EventArgs e)
        {
            string mode = mode_name_textbox.Text;
            if (mode.Length == 0)
            {
                MessageBox.Show("Enter a mode name!");
                return;
            }
            if (HasIllegalCharacter(mode, out char off))
            {
                MessageBox.Show($"Cannot add a mode with the character '{off}' contained in its name");
                return;
            }
            EntriesManager.ModifyEntry(EntriesManager.EntryType.mode, mode, false);
            UpdateModesDisplayLists();
            mode_name_textbox.Clear();
        }

        private void remove_mode_button_Click(object sender, EventArgs e)
        {
            int index = modelist_box.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected mode?")) return;
            string? mode = modelist_box.Items[index]?.ToString();
            modelist_box.Items.RemoveAt(index);
            EntriesManager.ModifyEntry(EntriesManager.EntryType.mode, mode, true);
            UpdateModesDisplayLists();
        }

        private void add_map_button_Click(object sender, EventArgs e)
        {
            string mapname = map_name_textbox.Text;
            int index = map_type_combo.SelectedIndex;
            if (index == -1 || mapname.Length == 0)
            {
                MessageBox.Show("Could not add map! Make sure both the map name and map type are defined");
                return;
            }
            if (HasIllegalCharacter(mapname, out char off))
            {
                MessageBox.Show($"Cannot add a map with the character '{off}' contained in its name");
                return;
            }
            string? maptype = map_type_combo.Items[index]?.ToString();
            EntriesManager.ModifyMaps(new Map(mapname, maptype), false);
            UpdateMapsDisplayLists();
            map_name_textbox.Clear();
            map_type_combo.SelectedIndex = -1;
        }

        private void remove_map_button_Click(object sender, EventArgs e)
        {
            int index = maplist_box.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected map?")) return;
            string? mapname = maplist_box.Items[index].ToString();
            EntriesManager.RemoveMap(map => map.fullname == mapname);
            UpdateMapsDisplayLists();
            maplist_box.SelectedIndex = -1;
        }

        private void add_outcome_button_Click(object sender, EventArgs e)
        {
            string name = outcome_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the outcome");
                return;
            }
            if (HasIllegalCharacter(name, out char off))
            {
                MessageBox.Show($"Cannot add an outcome with the character '{off}' contained in its name");
                return;
            }
            EntriesManager.ModifyEntry(EntriesManager.EntryType.outcome, name, false);
            UpdateOutcomesDisplayLists();
            outcome_textbox.Clear();
        }

        private void remove_outcome_button_Click(object sender, EventArgs e)
        {
            int index = outcomes_listbox.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected outcome?")) return;
            string? name = outcomes_listbox.Items[index]?.ToString();
            EntriesManager.ModifyEntry(EntriesManager.EntryType.outcome, name, true);
            UpdateOutcomesDisplayLists();
            outcomes_listbox.SelectedIndex = -1;
        }

        internal static bool HasIllegalCharacter(string text, out char offender)
        {
            foreach (char character in forbiddencharacters)
            {
                if (text.Contains(character))
                {
                    offender = character;
                    return true;
                }
            }
            offender = ' ';
            return false;
        }

        internal static string RemoveForbiddenCharacters(string text, params char[] ignore)
        {
            foreach (var ch in forbiddencharacters)
            {
                if (ignore.Contains(ch)) continue;
                text = text.Replace(ch.ToString(), "");
            }
            return text;
        }

        private void add_note_button_Click(object sender, EventArgs e)
        {
            string name = note_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the note");
                return;
            }
            if (HasIllegalCharacter(name, out char off))
            {
                MessageBox.Show($"Cannot add a note with the character '{off}' contained in its name");
                return;
            }
            EntriesManager.ModifyEntry(EntriesManager.EntryType.note, name, false);
            UpdateNotesDisplayLists();
            note_textbox.Clear();
        }

        private void remove_note_button_Click(object sender, EventArgs e)
        {
            int index = notes_listbox.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected note?")) return;
            string? name = notes_listbox.Items[index]?.ToString();
            EntriesManager.ModifyEntry(EntriesManager.EntryType.note, name, true);
            UpdateNotesDisplayLists();
            notes_listbox.SelectedIndex = -1;
        }

        private void add_profile_button_Click(object sender, EventArgs e)
        {
            string name = profilename_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the profile");
                return;
            }
            if (HasIllegalCharacter(name, out char off))
            {
                MessageBox.Show($"Cannot add a profile with the character '{off}' contained in its name");
                return;
            }
            EntriesManager.ModifyEntry(EntriesManager.EntryType.profile, name, false);
            UpdateProfileDisplayLists();
            profilename_textbox.Clear();
        }

        private void remove_profile_button_Click(object sender, EventArgs e)
        {
            int index = profiles_listbox.SelectedIndex;
            if (index == -1) return;
            string? name = profiles_listbox.Items[index]?.ToString();
            var result = MessageBox.Show($"Are you sure you want to delete profile '{name}'", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EntriesManager.ModifyEntry(EntriesManager.EntryType.profile, name, true);
                UpdateProfileDisplayLists();
                profiles_listbox.SelectedIndex = -1;
            }
        }

        private void UpdateProfileDisplayLists()
        {
            profiles_listbox.Items.Clear();
            save_profile_combobox.Items.Clear();
            foreach (var profile in EntriesManager.allprofiles)
            {
                profiles_listbox.Items.Add(profile);
                save_profile_combobox.Items.Add(profile);
            }
        }

        private void add_statprofile_button_Click(object sender, EventArgs e)
        {
            string name = statprofile_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the stat profile");
                return;
            }
            if (HasIllegalCharacter(name, out char off))
            {
                MessageBox.Show($"Cannot add a stat profile with the character '{off}' contained in its name");
                return;
            }
            StatProfileManager.CreateStatProfile(name);
            UpdateStatDisplayLists();
            statprofile_textbox.Clear();
        }

        //private void remove_statprofile_button_Click(object sender, EventArgs e)
        //{
        //    int index = statprofiles_checkedlistbox.SelectedIndex;
        //    if (index == -1) return;
        //    string? name = statprofiles_checkedlistbox.Items[index]?.ToString();
        //    var result = MessageBox.Show($"Removing this stat profile will also delete the stats associated with it. Are you sure you want to delete the '{name}' stat profile?", "Warning", MessageBoxButtons.YesNo);
        //    if (result == DialogResult.Yes)
        //    {
        //        StatProfileManager.RemoveStatProfile(name);
        //        UpdateStatDisplayLists();
        //        statprofiles_checkedlistbox.SelectedIndex = -1;
        //    }
        //}

        private void UpdateRecordLabel()
        {
            int wins = 0;
            int losses = 0;
            int draws = 0;
            foreach (string entry in session_entries_listbox.Items)
            {
                string[] parts = entry.Split("-");
                string outcome = parts[2].Trim();
                switch (outcome)
                {
                    case "Win": wins++; break;
                    case "Loss": losses++; break;
                    case "Draw": draws++; break;
                }
            }
            current_record_label.Text = $"W/L/D: {wins}-{losses}-{draws}";
            File.WriteAllText("today.txt", current_record_label.Text);
        }

        private void check_all_statprofiles_button_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < statprofiles_checkedlistbox.Items.Count; a++)
            {
                statprofiles_checkedlistbox.SetItemChecked(a, true);
            }
        }

        private void uncheck_all_statprofiles_button_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < statprofiles_checkedlistbox.Items.Count; a++)
            {
                statprofiles_checkedlistbox.SetItemChecked(a, false);
            }
        }

        private void view_stats_button_Click(object sender, EventArgs e)
        {
            List<string> statprofiles = [];
            foreach (string entry in statprofiles_checkedlistbox.CheckedItems)
            {
                statprofiles.Add(entry);
            }
            if (statprofiles.Count == 0)
            {
                MessageBox.Show("Select a stat profile!");
                return;
            }
            List<SessionRecordEntry> entries = [];
            foreach (var profile in statprofiles)
            {
                entries.AddRange(StatProfileManager.GetStatsFromStatProfile(profile));
            }
            Stats_Viewer stats_Viewer = new(entries, this, statprofiles);
            stats_Viewer.Show();
            statwindows.Add(stats_Viewer);
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            int profile = save_profile_combobox.SelectedIndex;
            int stat = save_statprofile_combobox.SelectedIndex;
            if (profile == -1)
            {
                MessageBox.Show("Select a profile to save the data to");
                return;
            }
            if (stat == -1)
            {
                MessageBox.Show("Select a stat profile to save the data to");
                return;
            }
            if (session_entries_listbox.Items.Count == 0)
            {
                MessageBox.Show("No data to save!");
                return;
            }
            string? profilename = save_profile_combobox.Items[profile]?.ToString();
            string? statprofile = save_statprofile_combobox.Items[stat]?.ToString();
            SessionRecordEntry session = new(profilename, statprofile, session_date_picker.Value);
            foreach (var entry in session_entries_listbox.Items)
            {
                string? line = entry?.ToString();
                var parts = line.Split('-');
                string mapname = parts[0].Trim();
                string mapmode = maptomode[mapname];
                string role = parts[1].Trim();
                string outcome = parts[2].Trim();
                List<string> notes2 = [];
                if (parts.Length > 3)
                {
                    string notes = parts[3];
                    notes2.AddRange(notes.Split('|').Select(entry => entry.Trim()));
                }
                MapResult mapdata = new(mapname, mapmode, role, outcome, notes2);
                session.AddMapResult(mapdata);
            }
            StatProfileManager.SaveStatProfileData(statprofile, false, session);
            var result = MessageBox.Show("Successfully saved stats. Close program?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Close();
            if (Settings.resetaftersave) ResetCurrentSession();
        }

        private void view_legacy_stats_Click(object sender, EventArgs e)
        {
            //List<SessionRecordEntry> entries = [];
            //if (File.Exists("maprecords.json"))
            //{
            //    foreach (string line in File.ReadAllLines("maprecords.json"))
            //    {
            //        LegacyRecordStat? entry = JsonManager.DeserializeObject<LegacyRecordStat>(line);
            //        if (entry != null) entries.Add(new(entry));
            //    }
            //}
            //List<string> serialized = [];
            //foreach (var entry in entries)
            //{
            //    serialized.Add(JsonManager.SerializeObject(entry));
            //}
            //StatProfileManager.SaveStatProfileData(entries[0].statprofilename, true, [.. entries]);
            //UpdateStatDisplayLists();
            //MessageBox.Show("Converted legacy stats");
        }

        private void confirm_dialogs_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.showconfirmdialogs = confirm_dialogs_checkbox.Checked;
        }

        private static void SaveSettings()
        {
            Dictionary<string, bool> settings = [];
            foreach (var field in Settings.GetSettings())
            {
                settings.Add(field.Name, (bool)field.GetValue(null));
            }
            File.WriteAllText("settings.json", JsonManager.SerializeObject(settings));
        }

        private void LoadSettings()
        {
            if (!File.Exists("settings.json")) return;
            string file = File.ReadAllText("settings.json");
            Dictionary<string, bool>? settings = JsonManager.DeserializeObject<Dictionary<string, bool>>(file);
            if (settings == null) return;
            foreach (var field in Settings.GetSettings())
            {
                if (settings.TryGetValue(field.Name, out bool value))
                {
                    field.SetValue(null, value);
                }
            }
            UpdateCheckboxesToReflectSettings();
        }

        private void UpdateCheckboxesToReflectSettings()
        {
            confirm_dialogs_checkbox.Checked = Settings.showconfirmdialogs;
            reset_after_save_checkbox.Checked = Settings.resetaftersave;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetCurrentSession();
            SaveSettings();
        }

        private void gen_rand_stats_button_Click(object sender, EventArgs e)
        {
            //List<SessionRecordEntry> randomrecords = [];
            //var allmaps = EntriesManager.allmaps;
            //var alloutcomes = EntriesManager.alloutcomes.ToList();
            //var allnotes = EntriesManager.allnotes.ToList();
            //for (int b = 0; b < 200; b++)
            //{
            //    DateTime datebegin = new(2023, 1, 1);
            //    DateTime dateend = new(2026, 1, 1);
            //    int range = (dateend - datebegin).Days;
            //    DateTime randomdate = datebegin.AddDays(Random.Shared.Next(range));
            //    SessionRecordEntry record = new("randomprofile", "random", randomdate);
            //    int gamesperentry = Random.Shared.Next(5, 9);
            //    for (int a = 0; a < gamesperentry; a++)
            //    {
            //        Map map = allmaps[Random.Shared.Next(allmaps.Count)];
            //        string outcome = alloutcomes[Random.Shared.Next(alloutcomes.Count)];
            //        List<string> notes = [];
            //        int notecount = Random.Shared.Next(0, 4);
            //        for (int c = 0; c < notecount; c++)
            //        {
            //            notes.Add(allnotes[Random.Shared.Next(allnotes.Count)]);
            //        }
            //        MapResult result = new(map.mapname, map.mode, "Open Queue", outcome, notes);
            //        record.AddMapResult(result);
            //    }
            //    randomrecords.Add(record);
            //}
            //StatProfileManager.SaveStatProfileData(randomrecords[0].statprofilename, true, [.. randomrecords]);
            //UpdateStatDisplayLists();
            //MessageBox.Show("Generated 200 random stats");
        }

        private void recall_stats_button_Click(object sender, EventArgs e)
        {
            foreach (var entry in statwindows)
            {
                entry.WindowState = FormWindowState.Normal;
                entry.TopMost = true;
                entry.TopMost = false;
            }
        }

        private void reset_after_save_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.resetaftersave = reset_after_save_checkbox.Checked;
        }

        private void refresh_statprofiles_button_Click(object sender, EventArgs e)
        {
            StatProfileManager.LoadStatProfiles();
            UpdateStatDisplayLists();
        }

        private void CreateAllContextMenus()
        {
            CreateSessionContextMenu();
            CreateStatProfileContextMenu();
        }

        private void CreateStatProfileContextMenu()
        {
            MenuItem delete = new("Delete", (o, e) =>
            {
                int index = statprofiles_checkedlistbox.SelectedIndex;
                if (index == -1) return;
                string? name = statprofiles_checkedlistbox.Items[index]?.ToString();
                var result = MessageBox.Show($"Removing this stat profile will also delete the stats associated with it. Are you sure you want to delete the '{name}' stat profile?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StatProfileManager.RemoveStatProfile(name);
                    UpdateStatDisplayLists();
                    statprofiles_checkedlistbox.SelectedIndex = -1;
                }
            });
            CreateContextMenu(statprofiles_checkedlistbox, [.. CreateContextMenuItems(delete)]);
        }

        private void CreateSessionContextMenu()
        {
            MenuItem delete = new("Delete", (o, e) =>
            {
                int i = session_entries_listbox.SelectedIndex;
                if (i == -1) return;
                if (!RequestConfirmation("Are you sure you want to delete the selected entry?")) return;
                session_entries_listbox.Items.RemoveAt(i);
                UpdateRecordLabel();
            });
            MenuItem moveup = new("Move up", (o, e) =>
            {
                int i = session_entries_listbox.SelectedIndex;
                if (i > 0)
                {
                    var item = session_entries_listbox.Items[i];
                    session_entries_listbox.Items.RemoveAt(i);
                    session_entries_listbox.Items.Insert(i - 1, item);
                    session_entries_listbox.SelectedIndex = i - 1;
                }
            });
            MenuItem movedown = new("Move down", (o, e) =>
            {
                int i = session_entries_listbox.SelectedIndex;
                if (i >= 0 && i < session_entries_listbox.Items.Count - 1)
                {
                    var item = session_entries_listbox.Items[i];
                    session_entries_listbox.Items.RemoveAt(i);
                    session_entries_listbox.Items.Insert(i + 1, item);
                    session_entries_listbox.SelectedIndex = i + 1;
                }
            });
            MenuItem redo = new("Redo", (o, e) =>
            {
                int i = session_entries_listbox.SelectedIndex;
                if (i == -1) return;
                var item = session_entries_listbox.Items[i];
                string[] parts = item.ToString().Split("-");
                string map = parts[0].Trim();
                string role = parts[1].Trim();
                string outcome = parts[2].Trim();
                List<string> notelist = [];
                if (parts.Length > 3)
                {
                    string notes = parts[3];
                    notelist.AddRange(notes.Split('|').Select(entry => entry.Trim()));
                }
                maplist_combobox.SelectedIndex = maplist_combobox.Items.IndexOf(map);
                role_combobox.SelectedIndex = role_combobox.Items.IndexOf(role);
                outcome_combobox.SelectedIndex = outcome_combobox.Items.IndexOf(outcome);
                notes_checkedlistbox.ClearSelected();
                for (int a = 0; a < notes_checkedlistbox.Items.Count; a++)
                {
                    notes_checkedlistbox.SetItemChecked(a, false);
                }
                foreach (string note in notelist)
                {
                    int n = notes_checkedlistbox.Items.IndexOf(note);
                    notes_checkedlistbox.SetItemChecked(n, true);
                }
            });
            CreateContextMenu(session_entries_listbox, [.. CreateContextMenuItems(delete, moveup, movedown, redo)]);
        }

        private struct MenuItem
        {
            public string name;
            public Action<object, EventArgs> action;

            public MenuItem(string name, Action<object, EventArgs> action)
            {
                this.name = name;
                this.action = action;
            }
        }

        private static List<ToolStripMenuItem> CreateContextMenuItems(params MenuItem[] items)
        {
            List<ToolStripMenuItem> list = [];
            foreach (var entry in items.OrderBy(i => i.name))
            {
                ToolStripMenuItem item = new(entry.name, null, (o, e) => { entry.action?.Invoke(o, e); });
                list.Add(item);
            }
            list.Add(new("Cancel"));
            return list;
        }

        private static void CreateContextMenu(Control control, params ToolStripMenuItem[] items)
        {
            ContextMenuStrip strip = new();
            strip.Items.AddRange(items);
            strip.Opening += (o, e) =>
            {
                if (strip.SourceControl is ListBox box)
                {
                    Point mousePos = box.PointToClient(Cursor.Position);
                    int index = box.IndexFromPoint(mousePos);
                    if (index == -1) return;
                    box.SelectedIndex = index;
                }
            };
            control.ContextMenuStrip = strip;
        }
    }
}
