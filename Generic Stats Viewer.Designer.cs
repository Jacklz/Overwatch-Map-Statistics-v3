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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            misc_outcomes_grid = new DataGridView();
            outcome_column = new DataGridViewTextBoxColumn();
            count_column = new DataGridViewTextBoxColumn();
            test_col1 = new DataGridViewTextBoxColumn();
            test_col2 = new DataGridViewTextBoxColumn();
            notes_grid = new DataGridView();
            notes_column = new DataGridViewTextBoxColumn();
            notecount_column = new DataGridViewTextBoxColumn();
            test_col3 = new DataGridViewTextBoxColumn();
            test_col4 = new DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            misc_outcomes_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            misc_outcomes_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            misc_outcomes_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            misc_outcomes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            misc_outcomes_grid.Columns.AddRange(new DataGridViewColumn[] { outcome_column, count_column, test_col1, test_col2 });
            misc_outcomes_grid.Location = new Point(0, 0);
            misc_outcomes_grid.Name = "misc_outcomes_grid";
            misc_outcomes_grid.ReadOnly = true;
            misc_outcomes_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            count_column.DefaultCellStyle = dataGridViewCellStyle3;
            count_column.HeaderText = "Count";
            count_column.Name = "count_column";
            count_column.ReadOnly = true;
            // 
            // test_col1
            // 
            test_col1.HeaderText = "Column1";
            test_col1.Name = "test_col1";
            test_col1.ReadOnly = true;
            test_col1.Visible = false;
            // 
            // test_col2
            // 
            test_col2.HeaderText = "Column1";
            test_col2.Name = "test_col2";
            test_col2.ReadOnly = true;
            test_col2.Visible = false;
            // 
            // notes_grid
            // 
            notes_grid.AllowUserToAddRows = false;
            notes_grid.AllowUserToDeleteRows = false;
            notes_grid.AllowUserToResizeColumns = false;
            notes_grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            notes_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            notes_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            notes_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            notes_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            notes_grid.Columns.AddRange(new DataGridViewColumn[] { notes_column, notecount_column, test_col3, test_col4 });
            notes_grid.Location = new Point(0, 81);
            notes_grid.Name = "notes_grid";
            notes_grid.ReadOnly = true;
            notes_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            notes_grid.Size = new Size(347, 200);
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
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            notecount_column.DefaultCellStyle = dataGridViewCellStyle6;
            notecount_column.HeaderText = "Count";
            notecount_column.Name = "notecount_column";
            notecount_column.ReadOnly = true;
            // 
            // test_col3
            // 
            test_col3.HeaderText = "Column1";
            test_col3.Name = "test_col3";
            test_col3.ReadOnly = true;
            test_col3.Visible = false;
            // 
            // test_col4
            // 
            test_col4.HeaderText = "Column1";
            test_col4.Name = "test_col4";
            test_col4.ReadOnly = true;
            test_col4.Visible = false;
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
        internal DataGridView misc_outcomes_grid;
        internal DataGridView notes_grid;
        private DataGridViewTextBoxColumn outcome_column;
        private DataGridViewTextBoxColumn count_column;
        private DataGridViewTextBoxColumn test_col1;
        private DataGridViewTextBoxColumn test_col2;
        private DataGridViewTextBoxColumn notes_column;
        private DataGridViewTextBoxColumn notecount_column;
        private DataGridViewTextBoxColumn test_col3;
        private DataGridViewTextBoxColumn test_col4;
    }
}
