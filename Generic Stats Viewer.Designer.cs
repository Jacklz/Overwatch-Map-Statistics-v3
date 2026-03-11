namespace Overwatch_Map_Statistics_v3
{
    partial class Generic_Stats_Viewer
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
            misc_outcomes_grid = new DataGridView();
            outcome_column = new DataGridViewTextBoxColumn();
            count_column = new DataGridViewTextBoxColumn();
            notes_grid = new DataGridView();
            notes_column = new DataGridViewTextBoxColumn();
            notecount_column = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)misc_outcomes_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)notes_grid).BeginInit();
            SuspendLayout();
            // 
            // misc_outcomes_grid
            // 
            misc_outcomes_grid.AllowUserToAddRows = false;
            misc_outcomes_grid.AllowUserToDeleteRows = false;
            misc_outcomes_grid.AllowUserToResizeColumns = false;
            misc_outcomes_grid.AllowUserToResizeRows = false;
            misc_outcomes_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            misc_outcomes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            misc_outcomes_grid.Columns.AddRange(new DataGridViewColumn[] { outcome_column, count_column });
            misc_outcomes_grid.Location = new Point(0, 0);
            misc_outcomes_grid.Name = "misc_outcomes_grid";
            misc_outcomes_grid.ReadOnly = true;
            misc_outcomes_grid.Size = new Size(347, 75);
            misc_outcomes_grid.TabIndex = 0;
            // 
            // outcome_column
            // 
            outcome_column.HeaderText = "Outcome";
            outcome_column.Name = "outcome_column";
            outcome_column.ReadOnly = true;
            // 
            // count_column
            // 
            count_column.HeaderText = "Count";
            count_column.Name = "count_column";
            count_column.ReadOnly = true;
            // 
            // notes_grid
            // 
            notes_grid.AllowUserToAddRows = false;
            notes_grid.AllowUserToDeleteRows = false;
            notes_grid.AllowUserToResizeColumns = false;
            notes_grid.AllowUserToResizeRows = false;
            notes_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            notes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            notes_grid.Columns.AddRange(new DataGridViewColumn[] { notes_column, notecount_column });
            notes_grid.Location = new Point(0, 81);
            notes_grid.Name = "notes_grid";
            notes_grid.ReadOnly = true;
            notes_grid.Size = new Size(347, 204);
            notes_grid.TabIndex = 1;
            // 
            // notes_column
            // 
            notes_column.HeaderText = "Note";
            notes_column.Name = "notes_column";
            notes_column.ReadOnly = true;
            // 
            // notecount_column
            // 
            notecount_column.HeaderText = "Count";
            notecount_column.Name = "notecount_column";
            notecount_column.ReadOnly = true;
            // 
            // Generic_Stats_Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 285);
            Controls.Add(notes_grid);
            Controls.Add(misc_outcomes_grid);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Generic_Stats_Viewer";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generic Stats Viewer";
            TopMost = true;
            Load += Generic_Stats_Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)misc_outcomes_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)notes_grid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView misc_outcomes_grid;
        private DataGridViewTextBoxColumn outcome_column;
        private DataGridViewTextBoxColumn count_column;
        private DataGridView notes_grid;
        private DataGridViewTextBoxColumn notes_column;
        private DataGridViewTextBoxColumn notecount_column;
    }
}
