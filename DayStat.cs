namespace Overwatch_Map_Statistics_v3
{
    internal class DayStat : GenericStat
    {
        public readonly DayOfWeek day;

        public DayStat(DayOfWeek day)
        {
            this.day = day;
        }
    }
}
