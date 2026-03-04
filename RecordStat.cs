namespace Overwatch_Map_Statistics_v3
{
    internal class RecordStat
    {
        public readonly DayStat DayStat;
        public readonly MapStat MapStat;
        public readonly ModeStat ModeStat;

        public RecordStat(string map, string mode, DayOfWeek day)
        {
            DayStat = new(day);
            MapStat = new(map, mode);
            ModeStat = new(mode);
        }

        public void HandleOutcome(string outcome)
        {
            switch (outcome)
            {
                case "Win": AddWin(1); break;
                case "Loss": AddLoss(1); break;
                case "Draw": AddDraw(1); break;
                default: AddMiscOutcome(outcome, 1); break;
            }
        }

        private void AddDraw(int count)
        {
            DayStat.AddDraw(count);
            MapStat.AddDraw(count);
            ModeStat.AddDraw(count);
        }

        private void AddLoss(int count)
        {
            DayStat.AddLoss(count);
            MapStat.AddLoss(count);
            ModeStat.AddLoss(count);
        }

        private void AddWin(int count)
        {
            DayStat.AddWin(count);
            MapStat.AddWin(count);
            ModeStat.AddWin(count);
        }

        private void AddMiscOutcome(string outcome, int count)
        {
            DayStat.AddMiscOutcome(outcome, count);
            MapStat.AddMiscOutcome(outcome, count);
            ModeStat.AddMiscOutcome(outcome, count);
        }
    }
}
