namespace Overwatch_Map_Statistics_v3
{
    internal static class GridCreator
    {
        public static DataGridView CreateDayStatsGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Day", "Wins", "Losses", "Draws", "Total", "Winrate", "Misc");
            grid.CellContentClick += (o, e) =>
            {

            };
            return grid;
        }

        public static DataGridView CreateDataEntriesGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Date", "Net Wins", "Wins", "Losses", "Draws", "Total", "Details");
            grid.CellContentClick += (o, e) =>
            {
                SessionRecordEntry? entry = GetCellData<SessionRecordEntry>(grid, e);
                if (entry != null)
                {
                    Session_Viewer session_Viewer = new(entry);
                    session_Viewer.Show();
                }
            };
            return grid;
        }

        public static DataGridView CreateTotalsGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Total Wins", "Total Losses", "Total Draws", "Total Games", "Winrate", "Misc");
            grid.CellContentClick += (o, e) =>
            {
                GenericStat? stat = GetCellData<GenericStat>(grid, e);
                if (stat != null)
                {
                    
                }
            };
            return grid;
        }

        public static DataGridView CreateModeStatsGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Map Type", "Wins", "Losses", "Draws", "Total", "Winrate", "Misc");
            return grid;
        }

        public static DataGridView CreateMapStatsGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Map", "Mode", "Wins", "Losses", "Draws", "Total", "Winrate", "Misc");
            grid.CellContentClick += (o, e) =>
            {

            };
            return grid;
        }

        public static DataGridView CreateNotesGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Note", "Count");
            return grid;
        }

        public static DataGridView CreateOutcomesGrid(int width, int height)
        {
            DataGridView grid = CreateGrid(width, height);
            AddColumnsToGrid(grid, "Outcome", "Count");
            return grid;
        }

        private static DataGridView CreateGrid(int width, int height)
        {
            DataGridView grid = new();
            SetCommonOptions(grid, width, height);
            return grid;
        }

        private static T? GetCellData<T>(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return default;
            DataGridViewColumn? data = grid.Columns["data_colhidden"];
            if (data == null) return default;
            T? value = (T?)grid.Rows[e.RowIndex].Cells[data.Index].Value;
            if (value != null) return value;
            return default;
        }

        private static void AddColumnsToGrid(DataGridView grid, params string[] columns)
        {
            foreach (var entry in columns)
            {
                grid.Columns.Add($"{entry.ToLower().Replace(" ","")}_col", entry);
            }
            AddHiddenColumn(grid, "Data");
        }

        private static void AddHiddenColumn(DataGridView grid, params string[] columns)
        {
            foreach (var entry in columns)
            {
                DataGridViewColumn col = new();
                col.HeaderText = entry;
                col.CellTemplate = new DataGridViewTextBoxCell();
                col.Name = $"{entry.ToLower().Replace(" ", "")}_colhidden";
                col.Visible = false;
                grid.Columns.Add(col);
            }            
        }

        private static void SetCommonOptions(DataGridView grid, int width, int height)
        {
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.Size = new(width, height);
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grid.CellContentClick += Grid_CellContentClick;
        }

        private static void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var grid = (DataGridView?)sender;
            
        }

        //private static void CreateNotesOutcomesGrid(out DataGridView notes, out DataGridView outcomes)
        //{
        //    notes = CreateNotesGrid();
        //    outcomes = CreateOutcomesGrid();
        //}
    }
}
