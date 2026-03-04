namespace Overwatch_Map_Statistics_v3
{
    partial class Stats_Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            map_stats_grid = new DataGridView();
            map_column = new DataGridViewTextBoxColumn();
            mode_column = new DataGridViewTextBoxColumn();
            wins_column = new DataGridViewTextBoxColumn();
            loss_column = new DataGridViewTextBoxColumn();
            draw_column = new DataGridViewTextBoxColumn();
            totals_column = new DataGridViewTextBoxColumn();
            winrate_column = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            map_stats_page = new TabPage();
            map_totals_page = new TabPage();
            day_stats_page = new TabPage();
            data_entries_page = new TabPage();
            data_selection_page = new TabPage();
            reset_dates_button = new Button();
            uncheck_all_roles_button = new Button();
            check_all_roles_button = new Button();
            button1 = new Button();
            uncheck_all_profiles_button = new Button();
            check_all_profiles_button = new Button();
            end_date = new DateTimePicker();
            label2 = new Label();
            start_date = new DateTimePicker();
            label1 = new Label();
            label4 = new Label();
            role_checkedlistbox = new CheckedListBox();
            label3 = new Label();
            profile_checkedlistbox = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)map_stats_grid).BeginInit();
            tabControl1.SuspendLayout();
            map_stats_page.SuspendLayout();
            data_selection_page.SuspendLayout();
            SuspendLayout();
            // 
            // map_stats_grid
            // 
            map_stats_grid.AllowUserToAddRows = false;
            map_stats_grid.AllowUserToDeleteRows = false;
            map_stats_grid.AllowUserToResizeColumns = false;
            map_stats_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            map_stats_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            map_stats_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            map_stats_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            map_stats_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            map_stats_grid.Columns.AddRange(new DataGridViewColumn[] { map_column, mode_column, wins_column, loss_column, draw_column, totals_column, winrate_column });
            map_stats_grid.Location = new Point(6, 6);
            map_stats_grid.Name = "map_stats_grid";
            map_stats_grid.ReadOnly = true;
            map_stats_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            map_stats_grid.Size = new Size(704, 470);
            map_stats_grid.TabIndex = 0;
            // 
            // map_column
            // 
            map_column.FillWeight = 200F;
            map_column.HeaderText = "Map";
            map_column.Name = "map_column";
            map_column.ReadOnly = true;
            // 
            // mode_column
            // 
            mode_column.HeaderText = "Mode";
            mode_column.Name = "mode_column";
            mode_column.ReadOnly = true;
            // 
            // wins_column
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            wins_column.DefaultCellStyle = dataGridViewCellStyle3;
            wins_column.HeaderText = "Wins";
            wins_column.Name = "wins_column";
            wins_column.ReadOnly = true;
            // 
            // loss_column
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loss_column.DefaultCellStyle = dataGridViewCellStyle4;
            loss_column.HeaderText = "Losses";
            loss_column.Name = "loss_column";
            loss_column.ReadOnly = true;
            // 
            // draw_column
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            draw_column.DefaultCellStyle = dataGridViewCellStyle5;
            draw_column.HeaderText = "Draws";
            draw_column.Name = "draw_column";
            draw_column.ReadOnly = true;
            // 
            // totals_column
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totals_column.DefaultCellStyle = dataGridViewCellStyle6;
            totals_column.HeaderText = "Total";
            totals_column.Name = "totals_column";
            totals_column.ReadOnly = true;
            // 
            // winrate_column
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            winrate_column.DefaultCellStyle = dataGridViewCellStyle7;
            winrate_column.HeaderText = "Win %";
            winrate_column.Name = "winrate_column";
            winrate_column.ReadOnly = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(map_stats_page);
            tabControl1.Controls.Add(map_totals_page);
            tabControl1.Controls.Add(day_stats_page);
            tabControl1.Controls.Add(data_entries_page);
            tabControl1.Controls.Add(data_selection_page);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(721, 507);
            tabControl1.TabIndex = 1;
            // 
            // map_stats_page
            // 
            map_stats_page.Controls.Add(map_stats_grid);
            map_stats_page.Location = new Point(4, 24);
            map_stats_page.Name = "map_stats_page";
            map_stats_page.Padding = new Padding(3);
            map_stats_page.Size = new Size(713, 479);
            map_stats_page.TabIndex = 0;
            map_stats_page.Text = "Map Stats";
            map_stats_page.UseVisualStyleBackColor = true;
            // 
            // map_totals_page
            // 
            map_totals_page.Location = new Point(4, 24);
            map_totals_page.Name = "map_totals_page";
            map_totals_page.Padding = new Padding(3);
            map_totals_page.Size = new Size(713, 479);
            map_totals_page.TabIndex = 1;
            map_totals_page.Text = "Map Totals";
            map_totals_page.UseVisualStyleBackColor = true;
            // 
            // day_stats_page
            // 
            day_stats_page.Location = new Point(4, 24);
            day_stats_page.Name = "day_stats_page";
            day_stats_page.Size = new Size(713, 479);
            day_stats_page.TabIndex = 2;
            day_stats_page.Text = "Day Stats";
            day_stats_page.UseVisualStyleBackColor = true;
            // 
            // data_entries_page
            // 
            data_entries_page.Location = new Point(4, 24);
            data_entries_page.Name = "data_entries_page";
            data_entries_page.Size = new Size(713, 479);
            data_entries_page.TabIndex = 3;
            data_entries_page.Text = "Data Entries";
            data_entries_page.UseVisualStyleBackColor = true;
            // 
            // data_selection_page
            // 
            data_selection_page.Controls.Add(reset_dates_button);
            data_selection_page.Controls.Add(uncheck_all_roles_button);
            data_selection_page.Controls.Add(check_all_roles_button);
            data_selection_page.Controls.Add(button1);
            data_selection_page.Controls.Add(uncheck_all_profiles_button);
            data_selection_page.Controls.Add(check_all_profiles_button);
            data_selection_page.Controls.Add(end_date);
            data_selection_page.Controls.Add(label2);
            data_selection_page.Controls.Add(start_date);
            data_selection_page.Controls.Add(label1);
            data_selection_page.Controls.Add(label4);
            data_selection_page.Controls.Add(role_checkedlistbox);
            data_selection_page.Controls.Add(label3);
            data_selection_page.Controls.Add(profile_checkedlistbox);
            data_selection_page.Location = new Point(4, 24);
            data_selection_page.Name = "data_selection_page";
            data_selection_page.Size = new Size(713, 479);
            data_selection_page.TabIndex = 4;
            data_selection_page.Text = "Data Selection";
            data_selection_page.UseVisualStyleBackColor = true;
            // 
            // reset_dates_button
            // 
            reset_dates_button.Location = new Point(226, 30);
            reset_dates_button.Name = "reset_dates_button";
            reset_dates_button.Size = new Size(84, 23);
            reset_dates_button.TabIndex = 14;
            reset_dates_button.Text = "Reset dates";
            reset_dates_button.UseVisualStyleBackColor = true;
            // 
            // uncheck_all_roles_button
            // 
            uncheck_all_roles_button.Location = new Point(226, 391);
            uncheck_all_roles_button.Name = "uncheck_all_roles_button";
            uncheck_all_roles_button.Size = new Size(84, 23);
            uncheck_all_roles_button.TabIndex = 13;
            uncheck_all_roles_button.Text = "Uncheck all";
            uncheck_all_roles_button.UseVisualStyleBackColor = true;
            // 
            // check_all_roles_button
            // 
            check_all_roles_button.Location = new Point(226, 362);
            check_all_roles_button.Name = "check_all_roles_button";
            check_all_roles_button.Size = new Size(84, 23);
            check_all_roles_button.TabIndex = 12;
            check_all_roles_button.Text = "Check all";
            check_all_roles_button.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(9, 451);
            button1.Name = "button1";
            button1.Size = new Size(211, 23);
            button1.TabIndex = 11;
            button1.Text = "Export stats to xlsx";
            button1.UseVisualStyleBackColor = true;
            // 
            // uncheck_all_profiles_button
            // 
            uncheck_all_profiles_button.Location = new Point(226, 154);
            uncheck_all_profiles_button.Name = "uncheck_all_profiles_button";
            uncheck_all_profiles_button.Size = new Size(84, 23);
            uncheck_all_profiles_button.TabIndex = 10;
            uncheck_all_profiles_button.Text = "Uncheck all";
            uncheck_all_profiles_button.UseVisualStyleBackColor = true;
            // 
            // check_all_profiles_button
            // 
            check_all_profiles_button.Location = new Point(226, 125);
            check_all_profiles_button.Name = "check_all_profiles_button";
            check_all_profiles_button.Size = new Size(84, 23);
            check_all_profiles_button.TabIndex = 9;
            check_all_profiles_button.Text = "Check all";
            check_all_profiles_button.UseVisualStyleBackColor = true;
            // 
            // end_date
            // 
            end_date.Location = new Point(9, 74);
            end_date.Name = "end_date";
            end_date.Size = new Size(200, 23);
            end_date.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 56);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "And:";
            // 
            // start_date
            // 
            start_date.Location = new Point(9, 30);
            start_date.Name = "start_date";
            start_date.Size = new Size(200, 23);
            start_date.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 5;
            label1.Text = "View stats between:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 344);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 3;
            label4.Text = "Select role:";
            // 
            // role_checkedlistbox
            // 
            role_checkedlistbox.FormattingEnabled = true;
            role_checkedlistbox.Location = new Point(9, 362);
            role_checkedlistbox.Name = "role_checkedlistbox";
            role_checkedlistbox.Size = new Size(211, 76);
            role_checkedlistbox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 107);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 1;
            label3.Text = "Select profile:";
            // 
            // profile_checkedlistbox
            // 
            profile_checkedlistbox.FormattingEnabled = true;
            profile_checkedlistbox.Location = new Point(9, 125);
            profile_checkedlistbox.Name = "profile_checkedlistbox";
            profile_checkedlistbox.Size = new Size(211, 202);
            profile_checkedlistbox.TabIndex = 0;
            // 
            // Stats_Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 511);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Stats_Viewer";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stats Viewer";
            Load += Stats_Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)map_stats_grid).EndInit();
            tabControl1.ResumeLayout(false);
            map_stats_page.ResumeLayout(false);
            data_selection_page.ResumeLayout(false);
            data_selection_page.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView map_stats_grid;
        private DataGridViewTextBoxColumn map_column;
        private DataGridViewTextBoxColumn mode_column;
        private DataGridViewTextBoxColumn wins_column;
        private DataGridViewTextBoxColumn loss_column;
        private DataGridViewTextBoxColumn draw_column;
        private DataGridViewTextBoxColumn totals_column;
        private DataGridViewTextBoxColumn winrate_column;
        private TabControl tabControl1;
        private TabPage map_stats_page;
        private TabPage map_totals_page;
        private TabPage day_stats_page;
        private TabPage data_entries_page;
        private TabPage data_selection_page;
        private Label label3;
        private CheckedListBox profile_checkedlistbox;
        private Label label4;
        private CheckedListBox role_checkedlistbox;
        private Button button1;
        private Button uncheck_all_profiles_button;
        private Button check_all_profiles_button;
        private DateTimePicker end_date;
        private Label label2;
        private DateTimePicker start_date;
        private Label label1;
        private Button uncheck_all_roles_button;
        private Button check_all_roles_button;
        private Button reset_dates_button;
    }
}
