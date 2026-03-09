namespace Overwatch_Map_Statistics_v3
{
    partial class Session_Viewer
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
            session_grid = new DataGridView();
            session_map = new DataGridViewTextBoxColumn();
            session_netwins = new DataGridViewTextBoxColumn();
            session_wins = new DataGridViewTextBoxColumn();
            session_losses = new DataGridViewTextBoxColumn();
            session_draws = new DataGridViewTextBoxColumn();
            session_misc = new DataGridViewButtonColumn();
            session_total = new DataGridViewTextBoxColumn();
            session_winrate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)session_grid).BeginInit();
            SuspendLayout();
            // 
            // session_grid
            // 
            session_grid.AllowUserToAddRows = false;
            session_grid.AllowUserToDeleteRows = false;
            session_grid.AllowUserToResizeColumns = false;
            session_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            session_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            session_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            session_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            session_grid.Columns.AddRange(new DataGridViewColumn[] { session_map, session_netwins, session_wins, session_losses, session_draws, session_misc, session_total, session_winrate });
            session_grid.Location = new Point(2, 3);
            session_grid.Name = "session_grid";
            session_grid.ReadOnly = true;
            session_grid.Size = new Size(699, 333);
            session_grid.TabIndex = 0;
            // 
            // session_map
            // 
            session_map.FillWeight = 170F;
            session_map.HeaderText = "Map";
            session_map.Name = "session_map";
            session_map.ReadOnly = true;
            // 
            // session_netwins
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            session_netwins.DefaultCellStyle = dataGridViewCellStyle2;
            session_netwins.FillWeight = 120F;
            session_netwins.HeaderText = "Net Wins";
            session_netwins.Name = "session_netwins";
            session_netwins.ReadOnly = true;
            // 
            // session_wins
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            session_wins.DefaultCellStyle = dataGridViewCellStyle3;
            session_wins.HeaderText = "Wins";
            session_wins.Name = "session_wins";
            session_wins.ReadOnly = true;
            // 
            // session_losses
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            session_losses.DefaultCellStyle = dataGridViewCellStyle4;
            session_losses.HeaderText = "Losses";
            session_losses.Name = "session_losses";
            session_losses.ReadOnly = true;
            // 
            // session_draws
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            session_draws.DefaultCellStyle = dataGridViewCellStyle5;
            session_draws.HeaderText = "Draws";
            session_draws.Name = "session_draws";
            session_draws.ReadOnly = true;
            // 
            // session_misc
            // 
            session_misc.HeaderText = "Misc";
            session_misc.Name = "session_misc";
            session_misc.ReadOnly = true;
            session_misc.Resizable = DataGridViewTriState.True;
            session_misc.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // session_total
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            session_total.DefaultCellStyle = dataGridViewCellStyle6;
            session_total.HeaderText = "Total";
            session_total.Name = "session_total";
            session_total.ReadOnly = true;
            // 
            // session_winrate
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            session_winrate.DefaultCellStyle = dataGridViewCellStyle7;
            session_winrate.HeaderText = "Win %";
            session_winrate.Name = "session_winrate";
            session_winrate.ReadOnly = true;
            // 
            // Session_Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 339);
            Controls.Add(session_grid);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Session_Viewer";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Session Viewer";
            TopMost = true;
            Load += Session_Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)session_grid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView session_grid;
        private DataGridViewTextBoxColumn session_map;
        private DataGridViewTextBoxColumn session_netwins;
        private DataGridViewTextBoxColumn session_wins;
        private DataGridViewTextBoxColumn session_losses;
        private DataGridViewTextBoxColumn session_draws;
        private DataGridViewButtonColumn session_misc;
        private DataGridViewTextBoxColumn session_total;
        private DataGridViewTextBoxColumn session_winrate;
    }
}
