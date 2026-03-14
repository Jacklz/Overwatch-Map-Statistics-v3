namespace Overwatch_Map_Statistics_v3
{
    internal class GenericStat
    {
        public int wins;
        public int losses;
        public int draws;
        public int total;
        public double winrate;
        public readonly Dictionary<string, MiscStat> miscoutcomes = [];
        public readonly Dictionary<string, MiscStat> notes = [];

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

        public void AddNote(params string[] notes)
        {
            foreach (var note in notes)
            {
                if (this.notes.TryGetValue(note, out var value)) value.Add(1);
                else this.notes[note] = new(note, 1);
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

        public int GetMiscCount()
        {
            return miscoutcomes.Values.Select(entry => entry.count).Sum();
        }

        public int GetNoteCount()
        {
            return notes.Values.Select(entry => entry.count).Sum();
        }

        private void AddMiscOutcome(string outcome, int count)
        {
            if (miscoutcomes.TryGetValue(outcome, out MiscStat? value)) value.Add(count);
            else miscoutcomes[outcome] = new(outcome, count);
        }

        //only called when a win or loss is added
        //no need for div by 0 protection
        private void CalculateWinrate()
        {
            winrate = Math.Round(((double)wins / (double)(wins + losses)) * 100, 2);
        }

        public class MiscStat
        {
            public string description;
            public int count;

            public MiscStat(string description, int count)
            {
                this.description = description;
                this.count = count;
            }

            public void Add(int amount)
            {
                count += amount;
            }
        }
    }
}
