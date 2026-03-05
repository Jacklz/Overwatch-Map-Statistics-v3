using Newtonsoft.Json;

namespace Overwatch_Map_Statistics_v3
{
    public partial class Main : Form
    {
        public static List<string> allmodes = [];
        public static List<Map> allmaps = [];
        public static List<string> allnotes = [];
        public static List<string> alloutcomes = [];
        public static List<string> profiles = [];
        public static List<string> statprofiles = [];
        public static Dictionary<string, string> maptomode = [];
        public static List<string> roles = ["Open Queue", "DPS", "Tank", "Support"];
        public static bool showconfirmationdialogs = true;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();
            session_date_picker.Value = DateTime.Today;
            CheckAndCreateFiles();
        }

        private void CheckAndCreateFiles()
        {
            LoadMapModes();
            LoadMaps();
            LoadProfiles();
            LoadNotes();
            LoadOutcomes();
            LoadStatProfiles();
            LoadRoles();
            CheckRecordsForExtraProfiles();
        }

        private void LoadRoles()
        {
            roles.ForEach(role => { role_combobox.Items.Add(role); });
            role_combobox.SelectedIndex = 0;
        }

        private void CheckRecordsForExtraProfiles()
        {
            if (File.Exists("records.json"))
            {
                int newprofiles = 0;
                int newstats = 0;
                foreach (string line in File.ReadAllLines("records.json"))
                {
                    SessionRecordEntry? entry = JsonConvert.DeserializeObject<SessionRecordEntry>(line);
                    if (entry == null) continue;
                    if (!profiles.Contains(entry.profilename))
                    {
                        profiles.Add(entry.profilename);
                        newprofiles++;
                    }
                    if (!statprofiles.Contains(entry.statprofilename))
                    {
                        statprofiles.Add(entry.statprofilename);
                        newstats++;
                    }
                }
                if (newprofiles > 0)
                {
                    UpdateProfileDisplayLists();
                }
                if (newstats > 0)
                {
                    UpdateStatDisplayLists();
                }
            }
        }

        private void LoadStatProfiles()
        {
            if (File.Exists("statprofiles.txt"))
            {
                statprofiles.AddRange(File.ReadAllLines("statprofiles.txt"));
            }
            else File.Create("statprofiles.txt");
            UpdateStatDisplayLists();
        }

        public void UpdateStatDisplayLists()
        {
            statprofiles_checkedlistbox.Items.Clear();
            save_statprofile_combobox.Items.Clear();
            statprofiles.Sort();
            statprofiles.ForEach(profile =>
            {
                statprofiles_checkedlistbox.Items.Add(profile);
                save_statprofile_combobox.Items.Add(profile);
            });
        }

        private void LoadOutcomes()
        {
            if (File.Exists("outcomes.txt"))
            {
                alloutcomes.AddRange(File.ReadAllLines("outcomes.txt"));
            }
            else
            {
                List<string> outcomes =
                [
                    "Win",
                    "Loss",
                    "Draw",
                    "Canceled",
                    "Server Closed",
                ];
                File.WriteAllLines("outcomes.txt", outcomes);
                alloutcomes.AddRange(outcomes);
            }
            UpdateOutcomesDisplayLists();
        }

        private void UpdateOutcomesDisplayLists()
        {
            outcomes_listbox.Items.Clear();
            outcome_combobox.Items.Clear();
            alloutcomes.Sort();
            alloutcomes.ForEach(outcome =>
            {
                outcomes_listbox.Items.Add(outcome);
                outcome_combobox.Items.Add(outcome);
            });
        }

        private void LoadNotes()
        {
            if (File.Exists("notes.txt"))
            {
                allnotes.AddRange(File.ReadAllLines("notes.txt"));
            }
            else
            {
                List<string> notes =
                [
                    "Friendly DC",
                    "Friendly Cheater",
                    "Enemy DC",
                    "Enemy Cheater",
                    "Lopsided",
                ];
                File.WriteAllLines("notes.txt", notes);
                allnotes.AddRange(notes);
            }
            UpdateNotesDisplayLists();
        }

        private void UpdateNotesDisplayLists()
        {
            notes_listbox.Items.Clear();
            notes_checkedlistbox.Items.Clear();
            allnotes.Sort();
            allnotes.ForEach(note =>
            {
                notes_listbox.Items.Add(note);
                notes_checkedlistbox.Items.Add(note);
            });
        }

        private void LoadMapModes()
        {
            if (File.Exists("modes.txt"))
            {
                var modes = File.ReadAllLines("modes.txt");
                allmodes.AddRange(modes);
            }
            else
            {
                var modes = Map.GetAllModes();
                File.WriteAllLines("modes.txt", modes);
                allmodes.AddRange(modes);
            }
            UpdateModesDisplayLists();
        }

        private void UpdateModesDisplayLists()
        {
            map_type_combo.Items.Clear();
            modelist_box.Items.Clear();
            allmodes.Sort();
            allmodes.ForEach(mode =>
            {
                map_type_combo.Items.Add(mode);
                modelist_box.Items.Add(mode);
            });
        }

        private void LoadMaps()
        {
            if (File.Exists("maps.txt"))
            {
                var maps = File.ReadLines("maps.txt");
                foreach (var map in maps)
                {
                    string mapname = map[..map.IndexOf('-')].Trim();
                    string maptype = map[(map.IndexOf('-') + 1)..].Trim();
                    allmaps.Add(new(mapname, maptype));
                    maptomode[mapname] = maptype;
                }
            }
            else
            {
                var maps = Map.GetAllMaps();
                File.WriteAllLines("maps.txt", maps.Select(map => map.fullname));
                allmaps.AddRange(maps);
                maps.ForEach(map => { maptomode[map.mapname] = map.mode; });
            }
            UpdateMapsDisplayLists();
        }

        private void UpdateMapsDisplayLists()
        {
            maplist_combobox.Items.Clear();
            maplist_box.Items.Clear();
            allmaps.Sort((m1, m2) =>
            {
                return m1.mapname.CompareTo(m2.mapname);
            });
            allmaps.ForEach(map =>
            {
                maplist_combobox.Items.Add(map.mapname);
                maplist_box.Items.Add(map.fullname);
            });
        }

        private void LoadProfiles()
        {
            if (File.Exists("profiles.txt"))
            {
                profiles.AddRange(File.ReadAllLines("profiles.txt"));
            }
            else File.Create("profiles.txt");
            UpdateProfileDisplayLists();
        }

        private void add_entry_button_Click(object sender, EventArgs e)
        {
            try
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
                foreach (var note in notes_checkedlistbox.CheckedItems)
                {
                    notes.Add(note.ToString());
                }
                string entry = $"{mapname} - {role} - {outcome}";
                if (notes.Count > 0) entry += $" - {string.Join(" | ", notes)}";
                session_entries_listbox.Items.Add(entry);
                ResetCurrentEntry();
                UpdateRecordLabel();
            }
            catch
            {
                MessageBox.Show("An unknown error occurred when attempting to add an entry to the session list");
            }
        }

        private bool RequestConfirmation(string message, string title = "")
        {
            if (showconfirmationdialogs)
            {
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return false;
            }
            return true;
        }

        private void remove_sel_entry_button_Click(object sender, EventArgs e)
        {
            int index = session_entries_listbox.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected entry?")) return;
            session_entries_listbox.Items.RemoveAt(index);
            UpdateRecordLabel();
        }

        private void reset_entry_button_Click(object sender, EventArgs e)
        {
            if (!RequestConfirmation("Are you sure you want to reset the session?")) return;
            session_entries_listbox.Items.Clear();
            session_date_picker.Value = DateTime.Today;
            UpdateRecordLabel();
            ResetCurrentEntry();
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
            allmodes.Add(mode);
            UpdateModesDisplayLists();
            File.WriteAllLines("modes.txt", allmodes);
            mode_name_textbox.Clear();
        }

        private void remove_mode_button_Click(object sender, EventArgs e)
        {
            int index = modelist_box.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected mode?")) return;
            string? mode = modelist_box.Items[index]?.ToString();
            modelist_box.Items.RemoveAt(index);
            allmodes.RemoveAll(entry => entry == mode);
            UpdateModesDisplayLists();
            File.WriteAllLines("modes.txt", allmodes);
        }

        private void add_map_button_Click(object sender, EventArgs e)
        {
            string mapname = map_name_textbox.Text;
            int index = map_type_combo.SelectedIndex;
            if (index == -1 || mapname.Length == 0)
            {
                MessageBox.Show("Could not add map! Make sure both the map name field and map type are defined");
                return;
            }
            string? maptype = map_type_combo.Items[index]?.ToString();
            allmaps.Add(new(mapname, maptype));
            UpdateMapsDisplayLists();
            File.WriteAllLines("maps.txt", allmaps.Select(entry => entry.fullname));
            map_name_textbox.Clear();
            map_type_combo.SelectedIndex = -1;
        }

        private void remove_map_button_Click(object sender, EventArgs e)
        {
            int index = maplist_box.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected map?")) return;
            string? mapname = maplist_box.Items[index].ToString();
            allmaps.RemoveAll(entry => entry.fullname == mapname);
            UpdateMapsDisplayLists();
            File.WriteAllLines("maps.txt", allmaps.Select(entry => entry.fullname));
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
            alloutcomes.Add(name);
            UpdateOutcomesDisplayLists();
            File.WriteAllLines("outcomes.txt", alloutcomes);
            outcome_textbox.Clear();
        }

        private void remove_outcome_button_Click(object sender, EventArgs e)
        {
            int index = outcomes_listbox.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected outcome?")) return;
            string? name = outcomes_listbox.Items[index]?.ToString();
            alloutcomes.RemoveAll(entry => entry == name);
            UpdateOutcomesDisplayLists();
            File.WriteAllLines("outcomes.txt", alloutcomes);
            outcomes_listbox.SelectedIndex = -1;
        }

        private void add_note_button_Click(object sender, EventArgs e)
        {
            string name = note_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the note");
                return;
            }
            allnotes.Add(name);
            UpdateNotesDisplayLists();
            File.WriteAllLines("notes.txt", allnotes);
            note_textbox.Clear();
        }

        private void remove_note_button_Click(object sender, EventArgs e)
        {
            int index = notes_listbox.SelectedIndex;
            if (index == -1) return;
            if (!RequestConfirmation("Are you sure you want to delete the selected note?")) return;
            string? name = notes_listbox.Items[index]?.ToString();
            allnotes.RemoveAll(entry => entry == name);
            UpdateNotesDisplayLists();
            File.WriteAllLines("notes.txt", allnotes);
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
            if (profiles.Contains(name))
            {
                MessageBox.Show("This profile already exists!");
                return;
            }
            profiles.Add(name);
            UpdateProfileDisplayLists();
            File.WriteAllLines("profiles.txt", profiles);
            profilename_textbox.Clear();
        }

        private void remove_profile_button_Click(object sender, EventArgs e)
        {
            int index = profiles_listbox.SelectedIndex;
            if (index == -1) return;
            string? name = profiles_listbox.Items[index]?.ToString();
            var result = MessageBox.Show("Removing this profile will also delete all stat profiles associated with it. Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                profiles.RemoveAll(entry => entry == name);
                UpdateProfileDisplayLists();
                File.WriteAllLines("profiles.txt", profiles);
                profiles_listbox.SelectedIndex = -1;
                DeleteProfileData(name, false);
            }
        }

        private void UpdateProfileDisplayLists()
        {
            profiles_listbox.Items.Clear();
            save_profile_combobox.Items.Clear();
            profiles.Sort();
            profiles.ForEach(entry =>
            {
                profiles_listbox.Items.Add(entry);
                save_profile_combobox.Items.Add(entry);
            });
        }

        private void add_statprofile_button_Click(object sender, EventArgs e)
        {
            string name = statprofile_textbox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Enter a name for the stat profile");
                return;
            }
            if (statprofiles.Contains(name))
            {
                MessageBox.Show("This stat profile already exists!");
                return;
            }
            statprofiles.Add(name);
            UpdateStatDisplayLists();
            File.WriteAllLines("statprofiles.txt", statprofiles);
            statprofile_textbox.Clear();
        }

        private void remove_statprofile_button_Click(object sender, EventArgs e)
        {
            int index = statprofiles_checkedlistbox.SelectedIndex;
            if (index == -1) return;
            string? name = statprofiles_checkedlistbox.Items[index]?.ToString();
            var result = MessageBox.Show("Removing this stat profile will also delete the stats associated with it. Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                statprofiles.RemoveAll(entry => entry == name);
                UpdateStatDisplayLists();
                File.WriteAllLines("statprofiles.txt", statprofiles);
                statprofiles_checkedlistbox.SelectedIndex = -1;
                DeleteProfileData(name, true);
            }
        }

        private static void DeleteProfileData(string profilename, bool statprofile)
        {
            if (!File.Exists("records.json"))
            {
                MessageBox.Show("Could not delete profile data, records.json file was not found");
                return;
            }
            List<SessionRecordEntry> records = [];
            foreach (string line in File.ReadAllLines("records.json"))
            {
                SessionRecordEntry? entry = JsonConvert.DeserializeObject<SessionRecordEntry>(line);
                if (entry == null) continue;
                if (statprofile)
                {
                    if (entry.statprofilename != profilename) records.Add(entry);
                }
                else
                {
                    if (entry.profilename != profilename) records.Add(entry);
                }
            }
            List<string> serializedrecords = [];
            records.ForEach(record => serializedrecords.Add(JsonConvert.SerializeObject(record)));
            File.WriteAllLines("records.json", serializedrecords);
        }

        private void UpdateRecordLabel()
        {
            int wins = 0;
            int losses = 0;
            int draws = 0;
            foreach (string entry in session_entries_listbox.Items)
            {
                string line = entry.ToString();
                if (line.Contains("Win")) wins++;
                if (line.Contains("Loss")) losses++;
                if (line.Contains("Draw")) draws++;
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
            foreach (var entry in statprofiles_checkedlistbox.CheckedItems)
            {
                statprofiles.Add(entry.ToString());
            }
            if (statprofiles.Count == 0)
            {
                MessageBox.Show("Select a stat profile!");
                return;
            }
            if (!File.Exists("records.json"))
            {
                MessageBox.Show("Could not open stats as no records.json file was found");
                return;
            }
            List<SessionRecordEntry> entries = [];
            foreach (var line in File.ReadAllLines("records.json"))
            {
                SessionRecordEntry? record = JsonConvert.DeserializeObject<SessionRecordEntry>(line);
                if (record == null) continue;
                if (statprofiles.Contains(record.statprofilename))
                {
                    entries.Add(record);
                }
            }
            Stats_Viewer stats_Viewer = new(entries, this, statprofiles);
            stats_Viewer.Show();
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
            string serializeddata = JsonConvert.SerializeObject(session);
            WriteSessionToFile(serializeddata);
            var result = MessageBox.Show("Successfully saved stats. Close program?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) CloseProgram();
        }

        private void CloseProgram()
        {
            Close();
        }

        public static void WriteSessionToFile(params string[] serializeddata)
        {
            using StreamWriter writer = new("records.json", true);
            foreach (var entry in serializeddata)
            {
                writer.WriteLine(entry);
            }
        }

        private void view_legacy_stats_Click(object sender, EventArgs e)
        {
            List<SessionRecordEntry> entries = [];
            if (File.Exists("maprecords.json"))
            {
                foreach (string line in File.ReadAllLines("maprecords.json"))
                {
                    LegacyRecordStat? entry = JsonConvert.DeserializeObject<LegacyRecordStat>(line);
                    if (entry != null) entries.Add(new(entry));
                }
            }
            List<string> serialized = [];
            foreach (var entry in entries)
            {
                serialized.Add(JsonConvert.SerializeObject(entry));
            }
            WriteSessionToFile([.. serialized]);
            MessageBox.Show("Converted legacy stats");
        }

        private void confirm_dialogs_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            showconfirmationdialogs = confirm_dialogs_checkbox.Checked;
        }

        private void SaveSettings()
        {
            Dictionary<string, bool> settings = [];
            settings.Add("dialogs", showconfirmationdialogs);
            File.WriteAllText("settings.json", JsonConvert.SerializeObject(settings));
        }

        private void LoadSettings()
        {
            if (!File.Exists("settings.json")) return;
            string file = File.ReadAllText("settings.json");
            Dictionary<string, bool>? settings = JsonConvert.DeserializeObject<Dictionary<string, bool>>(file);
            if (settings == null) return;
            showconfirmationdialogs = settings["dialogs"];
            confirm_dialogs_checkbox.Checked = showconfirmationdialogs;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
