namespace Overwatch_Map_Statistics_v3
{
    internal class SessionRecordEntry
    {
        public string profilename;
        public string statprofilename;
        public DateTime date;
        public List<MapResult> mapdata = [];
        
        public SessionRecordEntry(string profilename, string statprofilename, DateTime date)
        {
            this.profilename = profilename;
            this.statprofilename = statprofilename;
            this.date = date;
        }

        public void AddMapResult(MapResult mapdata)
        {
            this.mapdata.Add(mapdata);
        }
    }
}
