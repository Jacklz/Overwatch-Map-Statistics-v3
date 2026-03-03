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
            map_stats_grid = new DataGridView();
            map_column = new DataGridViewTextBoxColumn();
            mode_column = new DataGridViewTextBoxColumn();
            wins_column = new DataGridViewTextBoxColumn();
            loss_column = new DataGridViewTextBoxColumn();
            draw_column = new DataGridViewTextBoxColumn();
            totals_column = new DataGridViewTextBoxColumn();
            winrate_column = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)map_stats_grid).BeginInit();
            SuspendLayout();
            // 
            // map_stats_grid
            // 
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            map_stats_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            map_stats_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            map_stats_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            map_stats_grid.Columns.AddRange(new DataGridViewColumn[] { map_column, mode_column, wins_column, loss_column, draw_column, totals_column, winrate_column });
            map_stats_grid.Location = new Point(13, 76);
            map_stats_grid.Name = "map_stats_grid";
            map_stats_grid.ReadOnly = true;
            map_stats_grid.Size = new Size(625, 300);
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            wins_column.DefaultCellStyle = dataGridViewCellStyle2;
            wins_column.HeaderText = "Wins";
            wins_column.Name = "wins_column";
            wins_column.ReadOnly = true;
            // 
            // loss_column
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            loss_column.DefaultCellStyle = dataGridViewCellStyle3;
            loss_column.HeaderText = "Losses";
            loss_column.Name = "loss_column";
            loss_column.ReadOnly = true;
            // 
            // draw_column
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            draw_column.DefaultCellStyle = dataGridViewCellStyle4;
            draw_column.HeaderText = "Draws";
            draw_column.Name = "draw_column";
            draw_column.ReadOnly = true;
            // 
            // totals_column
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totals_column.DefaultCellStyle = dataGridViewCellStyle5;
            totals_column.HeaderText = "Total";
            totals_column.Name = "totals_column";
            totals_column.ReadOnly = true;
            // 
            // winrate_column
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            winrate_column.DefaultCellStyle = dataGridViewCellStyle6;
            winrate_column.HeaderText = "Win %";
            winrate_column.Name = "winrate_column";
            winrate_column.ReadOnly = true;
            // 
            // Stats_Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 384);
            Controls.Add(map_stats_grid);
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
    }
}
