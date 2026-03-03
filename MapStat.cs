namespace Overwatch_Map_Statistics_v3
{
    internal class MapStat : Map
    {
        public int wins;
        public int draws;
        public int losses;
        public double winrate;

        public MapStat(string mapname, string mode) : base(mapname, mode)
        {
        }

        public void AddWin(int wins)
        {
            this.wins += wins;
            CalculateWinrate();
        }

        public void AddDraw(int draws)
        {
            this.draws += draws;
        }

        public void AddLoss(int loss)
        {
            this.losses += loss;
            CalculateWinrate();
        }

        private void CalculateWinrate()
        {
            winrate = wins / (wins + losses);
        }

        public double GetWinrate()
        {
            CalculateWinrate();
            return winrate;
        }
    }
}
