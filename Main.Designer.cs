namespace Overwatch_Map_Statistics_v3
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            maplist_combobox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            outcome_combobox = new ComboBox();
            notes_checkedlistbox = new CheckedListBox();
            label3 = new Label();
            add_entry_button = new Button();
            reset_session_button = new Button();
            save_button = new Button();
            tabControl1 = new TabControl();
            session_page = new TabPage();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            role_combobox = new ComboBox();
            label11 = new Label();
            current_record_label = new Label();
            save_statprofile_combobox = new ComboBox();
            session_date_picker = new DateTimePicker();
            save_profile_combobox = new ComboBox();
            remove_sel_entry_button = new Button();
            session_entries_listbox = new ListBox();
            maps_page = new TabPage();
            remove_map_button = new Button();
            add_map_button = new Button();
            map_type_combo = new ComboBox();
            label5 = new Label();
            map_name_textbox = new TextBox();
            label4 = new Label();
            maplist_box = new ListBox();
            modes_page = new TabPage();
            remove_mode_button = new Button();
            add_mode_button = new Button();
            mode_name_textbox = new TextBox();
            label7 = new Label();
            modelist_box = new ListBox();
            outcomes_page = new TabPage();
            remove_outcome_button = new Button();
            add_outcome_button = new Button();
            outcome_textbox = new TextBox();
            label6 = new Label();
            outcomes_listbox = new ListBox();
            notes_page = new TabPage();
            remove_note_button = new Button();
            add_note_button = new Button();
            note_textbox = new TextBox();
            label8 = new Label();
            notes_listbox = new ListBox();
            profiles_page = new TabPage();
            remove_profile_button = new Button();
            add_profile_button = new Button();
            profilename_textbox = new TextBox();
            label9 = new Label();
            profiles_listbox = new ListBox();
            stats_page = new TabPage();
            view_legacy_stats = new Button();
            check_all_statprofiles_button = new Button();
            uncheck_all_statprofiles_button = new Button();
            view_stats_button = new Button();
            remove_statprofile_button = new Button();
            add_statprofile_button = new Button();
            label10 = new Label();
            statprofile_textbox = new TextBox();
            statprofiles_checkedlistbox = new CheckedListBox();
            tabControl1.SuspendLayout();
            session_page.SuspendLayout();
            maps_page.SuspendLayout();
            modes_page.SuspendLayout();
            outcomes_page.SuspendLayout();
            notes_page.SuspendLayout();
            profiles_page.SuspendLayout();
            stats_page.SuspendLayout();
            SuspendLayout();
            // 
            // maplist_combobox
            // 
            maplist_combobox.FormattingEnabled = true;
            maplist_combobox.Location = new Point(6, 26);
            maplist_combobox.Name = "maplist_combobox";
            maplist_combobox.Size = new Size(154, 23);
            maplist_combobox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Select Map:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 3);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Outcome:";
            // 
            // outcome_combobox
            // 
            outcome_combobox.FormattingEnabled = true;
            outcome_combobox.Location = new Point(294, 26);
            outcome_combobox.Name = "outcome_combobox";
            outcome_combobox.Size = new Size(105, 23);
            outcome_combobox.TabIndex = 3;
            // 
            // notes_checkedlistbox
            // 
            notes_checkedlistbox.FormattingEnabled = true;
            notes_checkedlistbox.HorizontalScrollbar = true;
            notes_checkedlistbox.Location = new Point(408, 26);
            notes_checkedlistbox.Name = "notes_checkedlistbox";
            notes_checkedlistbox.Size = new Size(123, 184);
            notes_checkedlistbox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 3);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Notes:";
            // 
            // add_entry_button
            // 
            add_entry_button.Location = new Point(6, 218);
            add_entry_button.Name = "add_entry_button";
            add_entry_button.Size = new Size(105, 23);
            add_entry_button.TabIndex = 6;
            add_entry_button.Text = "Add Entry";
            add_entry_button.UseVisualStyleBackColor = true;
            add_entry_button.Click += add_entry_button_Click;
            // 
            // reset_session_button
            // 
            reset_session_button.Location = new Point(6, 247);
            reset_session_button.Name = "reset_session_button";
            reset_session_button.Size = new Size(105, 23);
            reset_session_button.TabIndex = 7;
            reset_session_button.Text = "Reset Session";
            reset_session_button.UseVisualStyleBackColor = true;
            reset_session_button.Click += reset_entry_button_Click;
            // 
            // save_button
            // 
            save_button.Location = new Point(408, 275);
            save_button.Name = "save_button";
            save_button.Size = new Size(123, 23);
            save_button.TabIndex = 9;
            save_button.Text = "Save";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += exit_button_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(session_page);
            tabControl1.Controls.Add(maps_page);
            tabControl1.Controls.Add(modes_page);
            tabControl1.Controls.Add(outcomes_page);
            tabControl1.Controls.Add(notes_page);
            tabControl1.Controls.Add(profiles_page);
            tabControl1.Controls.Add(stats_page);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(548, 335);
            tabControl1.TabIndex = 10;
            // 
            // session_page
            // 
            session_page.Controls.Add(label15);
            session_page.Controls.Add(label14);
            session_page.Controls.Add(label13);
            session_page.Controls.Add(label12);
            session_page.Controls.Add(role_combobox);
            session_page.Controls.Add(label11);
            session_page.Controls.Add(current_record_label);
            session_page.Controls.Add(save_statprofile_combobox);
            session_page.Controls.Add(session_date_picker);
            session_page.Controls.Add(save_profile_combobox);
            session_page.Controls.Add(remove_sel_entry_button);
            session_page.Controls.Add(session_entries_listbox);
            session_page.Controls.Add(label1);
            session_page.Controls.Add(save_button);
            session_page.Controls.Add(maplist_combobox);
            session_page.Controls.Add(label2);
            session_page.Controls.Add(reset_session_button);
            session_page.Controls.Add(outcome_combobox);
            session_page.Controls.Add(add_entry_button);
            session_page.Controls.Add(notes_checkedlistbox);
            session_page.Controls.Add(label3);
            session_page.Location = new Point(4, 24);
            session_page.Name = "session_page";
            session_page.Padding = new Padding(3);
            session_page.Size = new Size(540, 307);
            session_page.TabIndex = 0;
            session_page.Text = "Session";
            session_page.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(335, 250);
            label15.Name = "label15";
            label15.Size = new Size(67, 15);
            label15.TabIndex = 22;
            label15.Text = "Stat profile:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(355, 221);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 21;
            label14.Text = "Profile:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(117, 250);
            label13.Name = "label13";
            label13.Size = new Size(86, 15);
            label13.TabIndex = 20;
            label13.Text = "Session record:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 279);
            label12.Name = "label12";
            label12.Size = new Size(75, 15);
            label12.TabIndex = 19;
            label12.Text = "Session date:";
            // 
            // role_combobox
            // 
            role_combobox.FormattingEnabled = true;
            role_combobox.Location = new Point(166, 26);
            role_combobox.Name = "role_combobox";
            role_combobox.Size = new Size(122, 23);
            role_combobox.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(166, 3);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 17;
            label11.Text = "Role:";
            // 
            // current_record_label
            // 
            current_record_label.AutoSize = true;
            current_record_label.Location = new Point(209, 250);
            current_record_label.Name = "current_record_label";
            current_record_label.Size = new Size(76, 15);
            current_record_label.TabIndex = 16;
            current_record_label.Text = "W/L/D: 0-0-0";
            // 
            // save_statprofile_combobox
            // 
            save_statprofile_combobox.FormattingEnabled = true;
            save_statprofile_combobox.Location = new Point(408, 247);
            save_statprofile_combobox.Name = "save_statprofile_combobox";
            save_statprofile_combobox.Size = new Size(123, 23);
            save_statprofile_combobox.TabIndex = 15;
            // 
            // session_date_picker
            // 
            session_date_picker.Location = new Point(87, 275);
            session_date_picker.Name = "session_date_picker";
            session_date_picker.Size = new Size(312, 23);
            session_date_picker.TabIndex = 14;
            // 
            // save_profile_combobox
            // 
            save_profile_combobox.FormattingEnabled = true;
            save_profile_combobox.Location = new Point(408, 218);
            save_profile_combobox.Name = "save_profile_combobox";
            save_profile_combobox.Size = new Size(123, 23);
            save_profile_combobox.TabIndex = 12;
            // 
            // remove_sel_entry_button
            // 
            remove_sel_entry_button.Location = new Point(117, 218);
            remove_sel_entry_button.Name = "remove_sel_entry_button";
            remove_sel_entry_button.Size = new Size(171, 23);
            remove_sel_entry_button.TabIndex = 11;
            remove_sel_entry_button.Text = "Remove Selected Entry";
            remove_sel_entry_button.UseVisualStyleBackColor = true;
            remove_sel_entry_button.Click += remove_sel_entry_button_Click;
            // 
            // session_entries_listbox
            // 
            session_entries_listbox.FormattingEnabled = true;
            session_entries_listbox.HorizontalScrollbar = true;
            session_entries_listbox.Location = new Point(6, 55);
            session_entries_listbox.Name = "session_entries_listbox";
            session_entries_listbox.Size = new Size(393, 154);
            session_entries_listbox.TabIndex = 10;
            // 
            // maps_page
            // 
            maps_page.Controls.Add(remove_map_button);
            maps_page.Controls.Add(add_map_button);
            maps_page.Controls.Add(map_type_combo);
            maps_page.Controls.Add(label5);
            maps_page.Controls.Add(map_name_textbox);
            maps_page.Controls.Add(label4);
            maps_page.Controls.Add(maplist_box);
            maps_page.Location = new Point(4, 24);
            maps_page.Name = "maps_page";
            maps_page.Padding = new Padding(3);
            maps_page.Size = new Size(540, 307);
            maps_page.TabIndex = 1;
            maps_page.Text = "Maps";
            maps_page.UseVisualStyleBackColor = true;
            // 
            // remove_map_button
            // 
            remove_map_button.Location = new Point(234, 143);
            remove_map_button.Name = "remove_map_button";
            remove_map_button.Size = new Size(75, 23);
            remove_map_button.TabIndex = 6;
            remove_map_button.Text = "Remove";
            remove_map_button.UseVisualStyleBackColor = true;
            remove_map_button.Click += remove_map_button_Click;
            // 
            // add_map_button
            // 
            add_map_button.Location = new Point(234, 114);
            add_map_button.Name = "add_map_button";
            add_map_button.Size = new Size(75, 23);
            add_map_button.TabIndex = 5;
            add_map_button.Text = "Add";
            add_map_button.UseVisualStyleBackColor = true;
            add_map_button.Click += add_map_button_Click;
            // 
            // map_type_combo
            // 
            map_type_combo.FormattingEnabled = true;
            map_type_combo.Location = new Point(234, 85);
            map_type_combo.Name = "map_type_combo";
            map_type_combo.Size = new Size(135, 23);
            map_type_combo.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(234, 67);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 3;
            label5.Text = "Map type";
            // 
            // map_name_textbox
            // 
            map_name_textbox.Location = new Point(234, 41);
            map_name_textbox.Name = "map_name_textbox";
            map_name_textbox.Size = new Size(135, 23);
            map_name_textbox.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(234, 23);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 1;
            label4.Text = "Map name";
            // 
            // maplist_box
            // 
            maplist_box.FormattingEnabled = true;
            maplist_box.Location = new Point(8, 6);
            maplist_box.Name = "maplist_box";
            maplist_box.Size = new Size(220, 289);
            maplist_box.TabIndex = 0;
            // 
            // modes_page
            // 
            modes_page.Controls.Add(remove_mode_button);
            modes_page.Controls.Add(add_mode_button);
            modes_page.Controls.Add(mode_name_textbox);
            modes_page.Controls.Add(label7);
            modes_page.Controls.Add(modelist_box);
            modes_page.Location = new Point(4, 24);
            modes_page.Name = "modes_page";
            modes_page.Size = new Size(540, 307);
            modes_page.TabIndex = 2;
            modes_page.Text = "Modes";
            modes_page.UseVisualStyleBackColor = true;
            // 
            // remove_mode_button
            // 
            remove_mode_button.Location = new Point(234, 99);
            remove_mode_button.Name = "remove_mode_button";
            remove_mode_button.Size = new Size(75, 23);
            remove_mode_button.TabIndex = 13;
            remove_mode_button.Text = "Remove";
            remove_mode_button.UseVisualStyleBackColor = true;
            remove_mode_button.Click += remove_mode_button_Click;
            // 
            // add_mode_button
            // 
            add_mode_button.Location = new Point(234, 70);
            add_mode_button.Name = "add_mode_button";
            add_mode_button.Size = new Size(75, 23);
            add_mode_button.TabIndex = 12;
            add_mode_button.Text = "Add";
            add_mode_button.UseVisualStyleBackColor = true;
            add_mode_button.Click += add_mode_button_Click;
            // 
            // mode_name_textbox
            // 
            mode_name_textbox.Location = new Point(234, 41);
            mode_name_textbox.Name = "mode_name_textbox";
            mode_name_textbox.Size = new Size(135, 23);
            mode_name_textbox.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(234, 23);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 8;
            label7.Text = "Mode name";
            // 
            // modelist_box
            // 
            modelist_box.FormattingEnabled = true;
            modelist_box.Location = new Point(8, 6);
            modelist_box.Name = "modelist_box";
            modelist_box.Size = new Size(220, 289);
            modelist_box.TabIndex = 7;
            // 
            // outcomes_page
            // 
            outcomes_page.Controls.Add(remove_outcome_button);
            outcomes_page.Controls.Add(add_outcome_button);
            outcomes_page.Controls.Add(outcome_textbox);
            outcomes_page.Controls.Add(label6);
            outcomes_page.Controls.Add(outcomes_listbox);
            outcomes_page.Location = new Point(4, 24);
            outcomes_page.Name = "outcomes_page";
            outcomes_page.Size = new Size(540, 307);
            outcomes_page.TabIndex = 4;
            outcomes_page.Text = "Outcomes";
            outcomes_page.UseVisualStyleBackColor = true;
            // 
            // remove_outcome_button
            // 
            remove_outcome_button.Location = new Point(234, 99);
            remove_outcome_button.Name = "remove_outcome_button";
            remove_outcome_button.Size = new Size(75, 23);
            remove_outcome_button.TabIndex = 18;
            remove_outcome_button.Text = "Remove";
            remove_outcome_button.UseVisualStyleBackColor = true;
            remove_outcome_button.Click += remove_outcome_button_Click;
            // 
            // add_outcome_button
            // 
            add_outcome_button.Location = new Point(234, 70);
            add_outcome_button.Name = "add_outcome_button";
            add_outcome_button.Size = new Size(75, 23);
            add_outcome_button.TabIndex = 17;
            add_outcome_button.Text = "Add";
            add_outcome_button.UseVisualStyleBackColor = true;
            add_outcome_button.Click += add_outcome_button_Click;
            // 
            // outcome_textbox
            // 
            outcome_textbox.Location = new Point(234, 41);
            outcome_textbox.Name = "outcome_textbox";
            outcome_textbox.Size = new Size(135, 23);
            outcome_textbox.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(234, 23);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 15;
            label6.Text = "Outcome name";
            // 
            // outcomes_listbox
            // 
            outcomes_listbox.FormattingEnabled = true;
            outcomes_listbox.Location = new Point(8, 6);
            outcomes_listbox.Name = "outcomes_listbox";
            outcomes_listbox.Size = new Size(220, 289);
            outcomes_listbox.TabIndex = 14;
            // 
            // notes_page
            // 
            notes_page.Controls.Add(remove_note_button);
            notes_page.Controls.Add(add_note_button);
            notes_page.Controls.Add(note_textbox);
            notes_page.Controls.Add(label8);
            notes_page.Controls.Add(notes_listbox);
            notes_page.Location = new Point(4, 24);
            notes_page.Name = "notes_page";
            notes_page.Size = new Size(540, 307);
            notes_page.TabIndex = 5;
            notes_page.Text = "Notes";
            notes_page.UseVisualStyleBackColor = true;
            // 
            // remove_note_button
            // 
            remove_note_button.Location = new Point(234, 99);
            remove_note_button.Name = "remove_note_button";
            remove_note_button.Size = new Size(75, 23);
            remove_note_button.TabIndex = 18;
            remove_note_button.Text = "Remove";
            remove_note_button.UseVisualStyleBackColor = true;
            remove_note_button.Click += remove_note_button_Click;
            // 
            // add_note_button
            // 
            add_note_button.Location = new Point(234, 70);
            add_note_button.Name = "add_note_button";
            add_note_button.Size = new Size(75, 23);
            add_note_button.TabIndex = 17;
            add_note_button.Text = "Add";
            add_note_button.UseVisualStyleBackColor = true;
            add_note_button.Click += add_note_button_Click;
            // 
            // note_textbox
            // 
            note_textbox.Location = new Point(234, 41);
            note_textbox.Name = "note_textbox";
            note_textbox.Size = new Size(135, 23);
            note_textbox.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(234, 23);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 15;
            label8.Text = "Note name";
            // 
            // notes_listbox
            // 
            notes_listbox.FormattingEnabled = true;
            notes_listbox.HorizontalScrollbar = true;
            notes_listbox.Location = new Point(8, 6);
            notes_listbox.Name = "notes_listbox";
            notes_listbox.Size = new Size(220, 289);
            notes_listbox.TabIndex = 14;
            // 
            // profiles_page
            // 
            profiles_page.Controls.Add(remove_profile_button);
            profiles_page.Controls.Add(add_profile_button);
            profiles_page.Controls.Add(profilename_textbox);
            profiles_page.Controls.Add(label9);
            profiles_page.Controls.Add(profiles_listbox);
            profiles_page.Location = new Point(4, 24);
            profiles_page.Name = "profiles_page";
            profiles_page.Size = new Size(540, 307);
            profiles_page.TabIndex = 3;
            profiles_page.Text = "Profiles";
            profiles_page.UseVisualStyleBackColor = true;
            // 
            // remove_profile_button
            // 
            remove_profile_button.Location = new Point(234, 99);
            remove_profile_button.Name = "remove_profile_button";
            remove_profile_button.Size = new Size(75, 23);
            remove_profile_button.TabIndex = 18;
            remove_profile_button.Text = "Remove";
            remove_profile_button.UseVisualStyleBackColor = true;
            remove_profile_button.Click += remove_profile_button_Click;
            // 
            // add_profile_button
            // 
            add_profile_button.Location = new Point(234, 70);
            add_profile_button.Name = "add_profile_button";
            add_profile_button.Size = new Size(75, 23);
            add_profile_button.TabIndex = 17;
            add_profile_button.Text = "Add";
            add_profile_button.UseVisualStyleBackColor = true;
            add_profile_button.Click += add_profile_button_Click;
            // 
            // profilename_textbox
            // 
            profilename_textbox.Location = new Point(234, 41);
            profilename_textbox.Name = "profilename_textbox";
            profilename_textbox.Size = new Size(135, 23);
            profilename_textbox.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(234, 23);
            label9.Name = "label9";
            label9.Size = new Size(74, 15);
            label9.TabIndex = 15;
            label9.Text = "Profile name";
            // 
            // profiles_listbox
            // 
            profiles_listbox.FormattingEnabled = true;
            profiles_listbox.Location = new Point(8, 6);
            profiles_listbox.Name = "profiles_listbox";
            profiles_listbox.Size = new Size(220, 289);
            profiles_listbox.TabIndex = 14;
            // 
            // stats_page
            // 
            stats_page.Controls.Add(view_legacy_stats);
            stats_page.Controls.Add(check_all_statprofiles_button);
            stats_page.Controls.Add(uncheck_all_statprofiles_button);
            stats_page.Controls.Add(view_stats_button);
            stats_page.Controls.Add(remove_statprofile_button);
            stats_page.Controls.Add(add_statprofile_button);
            stats_page.Controls.Add(label10);
            stats_page.Controls.Add(statprofile_textbox);
            stats_page.Controls.Add(statprofiles_checkedlistbox);
            stats_page.Location = new Point(4, 24);
            stats_page.Name = "stats_page";
            stats_page.Size = new Size(540, 307);
            stats_page.TabIndex = 6;
            stats_page.Text = "Stat Profiles";
            stats_page.UseVisualStyleBackColor = true;
            // 
            // view_legacy_stats
            // 
            view_legacy_stats.Location = new Point(234, 246);
            view_legacy_stats.Name = "view_legacy_stats";
            view_legacy_stats.Size = new Size(202, 23);
            view_legacy_stats.TabIndex = 8;
            view_legacy_stats.Text = "Convert Legacy Stats";
            view_legacy_stats.UseVisualStyleBackColor = true;
            view_legacy_stats.Click += view_legacy_stats_Click;
            // 
            // check_all_statprofiles_button
            // 
            check_all_statprofiles_button.Location = new Point(234, 128);
            check_all_statprofiles_button.Name = "check_all_statprofiles_button";
            check_all_statprofiles_button.Size = new Size(88, 23);
            check_all_statprofiles_button.TabIndex = 7;
            check_all_statprofiles_button.Text = "Check All";
            check_all_statprofiles_button.UseVisualStyleBackColor = true;
            check_all_statprofiles_button.Click += check_all_statprofiles_button_Click;
            // 
            // uncheck_all_statprofiles_button
            // 
            uncheck_all_statprofiles_button.Location = new Point(234, 157);
            uncheck_all_statprofiles_button.Name = "uncheck_all_statprofiles_button";
            uncheck_all_statprofiles_button.Size = new Size(88, 23);
            uncheck_all_statprofiles_button.TabIndex = 6;
            uncheck_all_statprofiles_button.Text = "Uncheck All";
            uncheck_all_statprofiles_button.UseVisualStyleBackColor = true;
            uncheck_all_statprofiles_button.Click += uncheck_all_statprofiles_button_Click;
            // 
            // view_stats_button
            // 
            view_stats_button.Location = new Point(234, 275);
            view_stats_button.Name = "view_stats_button";
            view_stats_button.Size = new Size(88, 23);
            view_stats_button.TabIndex = 5;
            view_stats_button.Text = "View Stats";
            view_stats_button.UseVisualStyleBackColor = true;
            view_stats_button.Click += view_stats_button_Click;
            // 
            // remove_statprofile_button
            // 
            remove_statprofile_button.Location = new Point(234, 99);
            remove_statprofile_button.Name = "remove_statprofile_button";
            remove_statprofile_button.Size = new Size(88, 23);
            remove_statprofile_button.TabIndex = 4;
            remove_statprofile_button.Text = "Remove";
            remove_statprofile_button.UseVisualStyleBackColor = true;
            remove_statprofile_button.Click += remove_statprofile_button_Click;
            // 
            // add_statprofile_button
            // 
            add_statprofile_button.Location = new Point(234, 70);
            add_statprofile_button.Name = "add_statprofile_button";
            add_statprofile_button.Size = new Size(88, 23);
            add_statprofile_button.TabIndex = 3;
            add_statprofile_button.Text = "Add";
            add_statprofile_button.UseVisualStyleBackColor = true;
            add_statprofile_button.Click += add_statprofile_button_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(234, 23);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 2;
            label10.Text = "Stat name";
            // 
            // statprofile_textbox
            // 
            statprofile_textbox.Location = new Point(234, 41);
            statprofile_textbox.Name = "statprofile_textbox";
            statprofile_textbox.Size = new Size(148, 23);
            statprofile_textbox.TabIndex = 1;
            // 
            // statprofiles_checkedlistbox
            // 
            statprofiles_checkedlistbox.FormattingEnabled = true;
            statprofiles_checkedlistbox.Location = new Point(8, 6);
            statprofiles_checkedlistbox.Name = "statprofiles_checkedlistbox";
            statprofiles_checkedlistbox.Size = new Size(220, 292);
            statprofiles_checkedlistbox.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 338);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Overwatch Map Statistics v3.0 By Jacklz";
            Load += Main_Load;
            tabControl1.ResumeLayout(false);
            session_page.ResumeLayout(false);
            session_page.PerformLayout();
            maps_page.ResumeLayout(false);
            maps_page.PerformLayout();
            modes_page.ResumeLayout(false);
            modes_page.PerformLayout();
            outcomes_page.ResumeLayout(false);
            outcomes_page.PerformLayout();
            notes_page.ResumeLayout(false);
            notes_page.PerformLayout();
            profiles_page.ResumeLayout(false);
            profiles_page.PerformLayout();
            stats_page.ResumeLayout(false);
            stats_page.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox maplist_combobox;
        private Label label1;
        private Label label2;
        private ComboBox outcome_combobox;
        private CheckedListBox notes_checkedlistbox;
        private Label label3;
        private Button add_entry_button;
        private Button reset_session_button;
        private Button view_session_entries_button;
        private Button save_button;
        private TabControl tabControl1;
        private TabPage session_page;
        private TabPage maps_page;
        private TabPage modes_page;
        private TabPage profiles_page;
        private ListBox maplist_box;
        private Button remove_map_button;
        private Button add_map_button;
        private ComboBox map_type_combo;
        private Label label5;
        private TextBox map_name_textbox;
        private Label label4;
        private Button remove_mode_button;
        private Button add_mode_button;
        private TextBox mode_name_textbox;
        private Label label7;
        private ListBox modelist_box;
        private ListBox session_entries_listbox;
        private Button remove_sel_entry_button;
        private TabPage outcomes_page;
        private Button remove_outcome_button;
        private Button add_outcome_button;
        private TextBox outcome_textbox;
        private Label label6;
        private ListBox outcomes_listbox;
        private TabPage notes_page;
        private Button remove_note_button;
        private Button add_note_button;
        private TextBox note_textbox;
        private Label label8;
        private ListBox notes_listbox;
        private Button remove_profile_button;
        private Button add_profile_button;
        private TextBox profilename_textbox;
        private Label label9;
        private ListBox profiles_listbox;
        private TabPage stats_page;
        private Button remove_statprofile_button;
        private Button add_statprofile_button;
        private Label label10;
        private TextBox statprofile_textbox;
        private CheckedListBox statprofiles_checkedlistbox;
        private Button view_stats_button;
        private ComboBox comboBox2;
        private ComboBox save_profile_combobox;
        private DateTimePicker session_date_picker;
        private ComboBox save_statprofile_combobox;
        private Button check_all_statprofiles_button;
        private Button uncheck_all_statprofiles_button;
        private Label current_record_label;
        private Label label11;
        private ComboBox role_combobox;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label label14;
        private Button view_legacy_stats;
    }
}
