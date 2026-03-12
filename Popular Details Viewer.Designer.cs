namespace Overwatch_Map_Statistics_v3
{
    partial class Popular_Details_Viewer
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            pop_map_stats_grid = new DataGridView();
            pop_map = new DataGridViewTextBoxColumn();
            pop_mode = new DataGridViewTextBoxColumn();
            pop_win = new DataGridViewTextBoxColumn();
            pop_loss = new DataGridViewTextBoxColumn();
            pop_draws = new DataGridViewTextBoxColumn();
            pop_total = new DataGridViewTextBoxColumn();
            pop_winrate = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            map_stats_page = new TabPage();
            map_totals_page = new TabPage();
            totals_grid = new DataGridView();
            total_wins_column = new DataGridViewTextBoxColumn();
            total_losses_column = new DataGridViewTextBoxColumn();
            total_draws_column = new DataGridViewTextBoxColumn();
            total_games_column = new DataGridViewTextBoxColumn();
            winrate_totals_column = new DataGridViewTextBoxColumn();
            total_details_column = new DataGridViewButtonColumn();
            misc_entry = new DataGridViewTextBoxColumn();
            mode_stats_grid = new DataGridView();
            map_type_column = new DataGridViewTextBoxColumn();
            mode_wins_column = new DataGridViewTextBoxColumn();
            mode_losses_column = new DataGridViewTextBoxColumn();
            mode_draws_column = new DataGridViewTextBoxColumn();
            mode_total = new DataGridViewTextBoxColumn();
            mode_winrate = new DataGridViewTextBoxColumn();
            mode_details_column = new DataGridViewButtonColumn();
            mode_entry_column = new DataGridViewTextBoxColumn();
            entries_page = new TabPage();
            data_entries_grid = new DataGridView();
            entries_date = new DataGridViewTextBoxColumn();
            entries_netwins = new DataGridViewTextBoxColumn();
            entries_wins = new DataGridViewTextBoxColumn();
            entries_losses = new DataGridViewTextBoxColumn();
            entries_draws = new DataGridViewTextBoxColumn();
            entries_total = new DataGridViewTextBoxColumn();
            entries_details = new DataGridViewButtonColumn();
            entries_data = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pop_map_stats_grid).BeginInit();
            tabControl1.SuspendLayout();
            map_stats_page.SuspendLayout();
            map_totals_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)totals_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mode_stats_grid).BeginInit();
            entries_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)data_entries_grid).BeginInit();
            SuspendLayout();
            // 
            // pop_map_stats_grid
            // 
            pop_map_stats_grid.AllowUserToAddRows = false;
            pop_map_stats_grid.AllowUserToDeleteRows = false;
            pop_map_stats_grid.AllowUserToResizeColumns = false;
            pop_map_stats_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            pop_map_stats_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            pop_map_stats_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            pop_map_stats_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            pop_map_stats_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pop_map_stats_grid.Columns.AddRange(new DataGridViewColumn[] { pop_map, pop_mode, pop_win, pop_loss, pop_draws, pop_total, pop_winrate });
            pop_map_stats_grid.Location = new Point(3, 3);
            pop_map_stats_grid.Name = "pop_map_stats_grid";
            pop_map_stats_grid.ReadOnly = true;
            pop_map_stats_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            pop_map_stats_grid.Size = new Size(694, 300);
            pop_map_stats_grid.TabIndex = 0;
            // 
            // pop_map
            // 
            pop_map.FillWeight = 150F;
            pop_map.HeaderText = "Map";
            pop_map.Name = "pop_map";
            pop_map.ReadOnly = true;
            // 
            // pop_mode
            // 
            pop_mode.HeaderText = "Mode";
            pop_mode.Name = "pop_mode";
            pop_mode.ReadOnly = true;
            // 
            // pop_win
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pop_win.DefaultCellStyle = dataGridViewCellStyle3;
            pop_win.HeaderText = "Wins";
            pop_win.Name = "pop_win";
            pop_win.ReadOnly = true;
            // 
            // pop_loss
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pop_loss.DefaultCellStyle = dataGridViewCellStyle4;
            pop_loss.HeaderText = "Losses";
            pop_loss.Name = "pop_loss";
            pop_loss.ReadOnly = true;
            // 
            // pop_draws
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pop_draws.DefaultCellStyle = dataGridViewCellStyle5;
            pop_draws.HeaderText = "Draws";
            pop_draws.Name = "pop_draws";
            pop_draws.ReadOnly = true;
            // 
            // pop_total
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pop_total.DefaultCellStyle = dataGridViewCellStyle6;
            pop_total.HeaderText = "Total";
            pop_total.Name = "pop_total";
            pop_total.ReadOnly = true;
            // 
            // pop_winrate
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pop_winrate.DefaultCellStyle = dataGridViewCellStyle7;
            pop_winrate.HeaderText = "Win %";
            pop_winrate.Name = "pop_winrate";
            pop_winrate.ReadOnly = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(map_stats_page);
            tabControl1.Controls.Add(map_totals_page);
            tabControl1.Controls.Add(entries_page);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(709, 337);
            tabControl1.TabIndex = 1;
            // 
            // map_stats_page
            // 
            map_stats_page.Controls.Add(pop_map_stats_grid);
            map_stats_page.Location = new Point(4, 24);
            map_stats_page.Name = "map_stats_page";
            map_stats_page.Padding = new Padding(3);
            map_stats_page.Size = new Size(701, 309);
            map_stats_page.TabIndex = 0;
            map_stats_page.Text = "Map Stats";
            map_stats_page.UseVisualStyleBackColor = true;
            // 
            // map_totals_page
            // 
            map_totals_page.Controls.Add(totals_grid);
            map_totals_page.Controls.Add(mode_stats_grid);
            map_totals_page.Location = new Point(4, 24);
            map_totals_page.Name = "map_totals_page";
            map_totals_page.Padding = new Padding(3);
            map_totals_page.Size = new Size(705, 305);
            map_totals_page.TabIndex = 1;
            map_totals_page.Text = "Map Totals";
            map_totals_page.UseVisualStyleBackColor = true;
            // 
            // totals_grid
            // 
            totals_grid.AllowUserToAddRows = false;
            totals_grid.AllowUserToDeleteRows = false;
            totals_grid.AllowUserToResizeColumns = false;
            totals_grid.AllowUserToResizeRows = false;
            totals_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            totals_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            totals_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            totals_grid.Columns.AddRange(new DataGridViewColumn[] { total_wins_column, total_losses_column, total_draws_column, total_games_column, winrate_totals_column, total_details_column, misc_entry });
            totals_grid.Location = new Point(3, 21);
            totals_grid.Name = "totals_grid";
            totals_grid.ReadOnly = true;
            totals_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            totals_grid.Size = new Size(696, 50);
            totals_grid.TabIndex = 3;
            // 
            // total_wins_column
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            total_wins_column.DefaultCellStyle = dataGridViewCellStyle9;
            total_wins_column.HeaderText = "Total Wins";
            total_wins_column.Name = "total_wins_column";
            total_wins_column.ReadOnly = true;
            // 
            // total_losses_column
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            total_losses_column.DefaultCellStyle = dataGridViewCellStyle10;
            total_losses_column.HeaderText = "Total Losses";
            total_losses_column.Name = "total_losses_column";
            total_losses_column.ReadOnly = true;
            // 
            // total_draws_column
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            total_draws_column.DefaultCellStyle = dataGridViewCellStyle11;
            total_draws_column.HeaderText = "Total Draws";
            total_draws_column.Name = "total_draws_column";
            total_draws_column.ReadOnly = true;
            // 
            // total_games_column
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            total_games_column.DefaultCellStyle = dataGridViewCellStyle12;
            total_games_column.HeaderText = "Total Games";
            total_games_column.Name = "total_games_column";
            total_games_column.ReadOnly = true;
            // 
            // winrate_totals_column
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            winrate_totals_column.DefaultCellStyle = dataGridViewCellStyle13;
            winrate_totals_column.HeaderText = "Win %";
            winrate_totals_column.Name = "winrate_totals_column";
            winrate_totals_column.ReadOnly = true;
            // 
            // total_details_column
            // 
            total_details_column.FillWeight = 110F;
            total_details_column.HeaderText = "Misc";
            total_details_column.Name = "total_details_column";
            total_details_column.ReadOnly = true;
            total_details_column.Resizable = DataGridViewTriState.True;
            total_details_column.SortMode = DataGridViewColumnSortMode.Automatic;
            total_details_column.Text = "";
            // 
            // misc_entry
            // 
            misc_entry.HeaderText = "misc_entry";
            misc_entry.Name = "misc_entry";
            misc_entry.ReadOnly = true;
            misc_entry.Visible = false;
            // 
            // mode_stats_grid
            // 
            mode_stats_grid.AllowUserToAddRows = false;
            mode_stats_grid.AllowUserToDeleteRows = false;
            mode_stats_grid.AllowUserToResizeColumns = false;
            mode_stats_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = Color.LightGray;
            mode_stats_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            mode_stats_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            mode_stats_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            mode_stats_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mode_stats_grid.Columns.AddRange(new DataGridViewColumn[] { map_type_column, mode_wins_column, mode_losses_column, mode_draws_column, mode_total, mode_winrate, mode_details_column, mode_entry_column });
            mode_stats_grid.Location = new Point(3, 149);
            mode_stats_grid.Name = "mode_stats_grid";
            mode_stats_grid.ReadOnly = true;
            mode_stats_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            mode_stats_grid.Size = new Size(696, 150);
            mode_stats_grid.TabIndex = 2;
            // 
            // map_type_column
            // 
            map_type_column.HeaderText = "Map Type";
            map_type_column.Name = "map_type_column";
            map_type_column.ReadOnly = true;
            // 
            // mode_wins_column
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mode_wins_column.DefaultCellStyle = dataGridViewCellStyle16;
            mode_wins_column.HeaderText = "Wins";
            mode_wins_column.Name = "mode_wins_column";
            mode_wins_column.ReadOnly = true;
            // 
            // mode_losses_column
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mode_losses_column.DefaultCellStyle = dataGridViewCellStyle17;
            mode_losses_column.HeaderText = "Losses";
            mode_losses_column.Name = "mode_losses_column";
            mode_losses_column.ReadOnly = true;
            // 
            // mode_draws_column
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mode_draws_column.DefaultCellStyle = dataGridViewCellStyle18;
            mode_draws_column.HeaderText = "Draws";
            mode_draws_column.Name = "mode_draws_column";
            mode_draws_column.ReadOnly = true;
            // 
            // mode_total
            // 
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mode_total.DefaultCellStyle = dataGridViewCellStyle19;
            mode_total.HeaderText = "Total";
            mode_total.Name = "mode_total";
            mode_total.ReadOnly = true;
            // 
            // mode_winrate
            // 
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            mode_winrate.DefaultCellStyle = dataGridViewCellStyle20;
            mode_winrate.HeaderText = "Win %";
            mode_winrate.Name = "mode_winrate";
            mode_winrate.ReadOnly = true;
            // 
            // mode_details_column
            // 
            mode_details_column.HeaderText = "Misc";
            mode_details_column.Name = "mode_details_column";
            mode_details_column.ReadOnly = true;
            mode_details_column.Resizable = DataGridViewTriState.True;
            mode_details_column.SortMode = DataGridViewColumnSortMode.Automatic;
            mode_details_column.Text = "";
            // 
            // mode_entry_column
            // 
            mode_entry_column.HeaderText = "mode_entry_column";
            mode_entry_column.Name = "mode_entry_column";
            mode_entry_column.ReadOnly = true;
            mode_entry_column.Visible = false;
            // 
            // entries_page
            // 
            entries_page.Controls.Add(data_entries_grid);
            entries_page.Location = new Point(4, 24);
            entries_page.Name = "entries_page";
            entries_page.Size = new Size(701, 309);
            entries_page.TabIndex = 2;
            entries_page.Text = "Data Entries";
            entries_page.UseVisualStyleBackColor = true;
            // 
            // data_entries_grid
            // 
            data_entries_grid.AllowUserToAddRows = false;
            data_entries_grid.AllowUserToDeleteRows = false;
            data_entries_grid.AllowUserToResizeColumns = false;
            data_entries_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = Color.LightGray;
            data_entries_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            data_entries_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = SystemColors.Control;
            dataGridViewCellStyle22.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle22.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
            data_entries_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            data_entries_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_entries_grid.Columns.AddRange(new DataGridViewColumn[] { entries_date, entries_netwins, entries_wins, entries_losses, entries_draws, entries_total, entries_details, entries_data });
            data_entries_grid.Location = new Point(3, 3);
            data_entries_grid.Name = "data_entries_grid";
            data_entries_grid.ReadOnly = true;
            data_entries_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            data_entries_grid.Size = new Size(693, 300);
            data_entries_grid.TabIndex = 1;
            // 
            // entries_date
            // 
            dataGridViewCellStyle23.Format = "d";
            dataGridViewCellStyle23.NullValue = null;
            entries_date.DefaultCellStyle = dataGridViewCellStyle23;
            entries_date.HeaderText = "Date";
            entries_date.Name = "entries_date";
            entries_date.ReadOnly = true;
            // 
            // entries_netwins
            // 
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleCenter;
            entries_netwins.DefaultCellStyle = dataGridViewCellStyle24;
            entries_netwins.HeaderText = "Net Wins";
            entries_netwins.Name = "entries_netwins";
            entries_netwins.ReadOnly = true;
            // 
            // entries_wins
            // 
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            entries_wins.DefaultCellStyle = dataGridViewCellStyle25;
            entries_wins.HeaderText = "Wins";
            entries_wins.Name = "entries_wins";
            entries_wins.ReadOnly = true;
            // 
            // entries_losses
            // 
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleCenter;
            entries_losses.DefaultCellStyle = dataGridViewCellStyle26;
            entries_losses.HeaderText = "Losses";
            entries_losses.Name = "entries_losses";
            entries_losses.ReadOnly = true;
            // 
            // entries_draws
            // 
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
            entries_draws.DefaultCellStyle = dataGridViewCellStyle27;
            entries_draws.HeaderText = "Draws";
            entries_draws.Name = "entries_draws";
            entries_draws.ReadOnly = true;
            // 
            // entries_total
            // 
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            entries_total.DefaultCellStyle = dataGridViewCellStyle28;
            entries_total.HeaderText = "Total";
            entries_total.Name = "entries_total";
            entries_total.ReadOnly = true;
            // 
            // entries_details
            // 
            entries_details.HeaderText = "Details";
            entries_details.Name = "entries_details";
            entries_details.ReadOnly = true;
            // 
            // entries_data
            // 
            entries_data.HeaderText = "data_entry";
            entries_data.Name = "entries_data";
            entries_data.ReadOnly = true;
            entries_data.Visible = false;
            // 
            // Popular_Details_Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 336);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Popular_Details_Viewer";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popular Details Viewer";
            TopMost = true;
            Load += Popular_Details_Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)pop_map_stats_grid).EndInit();
            tabControl1.ResumeLayout(false);
            map_stats_page.ResumeLayout(false);
            map_totals_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)totals_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)mode_stats_grid).EndInit();
            entries_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)data_entries_grid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView pop_map_stats_grid;
        private DataGridViewTextBoxColumn pop_map;
        private DataGridViewTextBoxColumn pop_mode;
        private DataGridViewTextBoxColumn pop_win;
        private DataGridViewTextBoxColumn pop_loss;
        private DataGridViewTextBoxColumn pop_draws;
        private DataGridViewTextBoxColumn pop_total;
        private DataGridViewTextBoxColumn pop_winrate;
        private TabControl tabControl1;
        private TabPage map_stats_page;
        private TabPage map_totals_page;
        private TabPage entries_page;
        private DataGridView data_entries_grid;
        private DataGridViewTextBoxColumn entries_date;
        private DataGridViewTextBoxColumn entries_netwins;
        private DataGridViewTextBoxColumn entries_wins;
        private DataGridViewTextBoxColumn entries_losses;
        private DataGridViewTextBoxColumn entries_draws;
        private DataGridViewTextBoxColumn entries_total;
        private DataGridViewButtonColumn entries_details;
        private DataGridViewTextBoxColumn entries_data;
        private DataGridView mode_stats_grid;
        private DataGridViewTextBoxColumn map_type_column;
        private DataGridViewTextBoxColumn mode_wins_column;
        private DataGridViewTextBoxColumn mode_losses_column;
        private DataGridViewTextBoxColumn mode_draws_column;
        private DataGridViewTextBoxColumn mode_total;
        private DataGridViewTextBoxColumn mode_winrate;
        private DataGridViewButtonColumn mode_details_column;
        private DataGridViewTextBoxColumn mode_entry_column;
        private DataGridView totals_grid;
        private DataGridViewTextBoxColumn total_wins_column;
        private DataGridViewTextBoxColumn total_losses_column;
        private DataGridViewTextBoxColumn total_draws_column;
        private DataGridViewTextBoxColumn total_games_column;
        private DataGridViewTextBoxColumn winrate_totals_column;
        private DataGridViewButtonColumn total_details_column;
        private DataGridViewTextBoxColumn misc_entry;
    }
}
