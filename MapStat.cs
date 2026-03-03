namespace Overwatch_Map_Statistics_v3
{
    internal class MapStat : Map
    {
        public int wins;
        public int draws;
        public int losses;
        public int total;
        public double winrate;

        public MapStat(string mapname, string mode) : base(mapname, mode)
        {
        }

        public void AddWin(int wins)
        {
            this.wins += wins;
            total += wins;
            CalculateWinrate();
        }

        public void AddDraw(int draws)
        {
            this.draws += draws;
            total += draws;
        }

        public void AddLoss(int loss)
        {
            this.losses += loss;
            total += loss;
            CalculateWinrate();
        }

        private void CalculateWinrate()
        {
            winrate = Math.Round(((double)wins / (double)(wins + losses)) * 100, 2);
        }

        public double GetWinrate()
        {
            CalculateWinrate();
            return winrate;
        }
    }
}
