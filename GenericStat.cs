namespace Overwatch_Map_Statistics_v3
{
    internal class GenericStat
    {
        public int wins;
        public int losses;
        public int draws;
        public int total;
        public double winrate;
        public Dictionary<string, MiscOutcomes> miscoutcomes = [];

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

        public void AddLoss(int losses)
        {
            this.losses += losses;
            total += losses;
            CalculateWinrate();
        }

        public void AddMiscOutcome(string outcome, int count)
        {
            if (miscoutcomes.TryGetValue(outcome, out MiscOutcomes value)) value.Add(count);
            else miscoutcomes[outcome] = new(outcome, count);
        }

        private void CalculateWinrate()
        {
            winrate = Math.Round(((double)wins / (double)(wins + losses)) * 100, 4);
        }

        public struct MiscOutcomes
        {
            public string outcome;
            public int count;

            public MiscOutcomes(string outcome, int count)
            {
                this.outcome = outcome;
                this.count = count;
            }

            public void Add(int amount)
            {
                count += amount;
            }
        }
    }
}
