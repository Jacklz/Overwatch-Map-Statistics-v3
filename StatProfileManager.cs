using System.Media;

namespace Overwatch_Map_Statistics_v3
{
    internal static class StatProfileManager
    {
        private static readonly string dir = "Stat profiles";

        public static SortedSet<string> statprofiles = [];

        public static void LoadStatProfiles()
        {
            statprofiles.Clear();
            Directory.CreateDirectory(dir);
            foreach (var entry in Directory.GetFiles(dir, "*.json").Select(file => Path.GetFileNameWithoutExtension(file)))
            {
                statprofiles.Add(entry);
            }
        }

        public static void RemoveStatProfile(string statprofile)
        {
            statprofiles.Remove(statprofile);
            string path = Path.Combine(dir, $"{statprofile}.json");
            File.Delete(path);
        }

        public static void CreateStatProfile(string statprofile)
        {
            if (!statprofiles.Add(statprofile)) return;
            string path = Path.Combine(dir, $"{statprofile}.json");
            File.WriteAllLines(path, []);
        }

        public static void SaveStatProfileData(string statprofile, bool overwrite, params SessionRecordEntry[] entries)
        {
            CreateStatProfile(statprofile);
            string path = Path.Combine(dir, $"{statprofile}.json");
            using StreamWriter writer = new(path, !overwrite);
            foreach (var entry in entries)
            {
                writer.WriteLine(JsonManager.SerializeObject(entry));
            }
        }

        public static List<SessionRecordEntry> GetStatsFromStatProfile(params string[] statprofiles)
        {
            List<SessionRecordEntry> records = [];
            foreach (var profile in statprofiles)
            {
                string path = Path.Combine(dir, $"{profile}.json");
                if (!File.Exists(path))
                {
                    MessageBox.Show($"Unable to get stats for stat profile '{profile}' because the file '{path}' doesn't exist", "File not found");
                    SystemSounds.Hand.Play();
                    continue;
                }
                foreach (string line in File.ReadAllLines(path))
                {
                    SessionRecordEntry? entry = JsonManager.DeserializeObject<SessionRecordEntry>(line);
                    if (entry == null) continue;
                    records.Add(entry);
                }
            }
            return records;
        }
    }
}
