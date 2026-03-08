using Newtonsoft.Json;
using System.Media;

namespace Overwatch_Map_Statistics_v3
{
    internal static class StatProfileManager
    {
        private static readonly string dir = "Stat profiles";

        public static SortedSet<string> statprofiles = [];

        public static void LoadStatProfiles()
        {
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
            MessageBox.Show($"Successfully deleted stat profile '{statprofile}'");
        }

        public static void CreateStatProfile(string statprofile)
        {
            if (!statprofiles.Add(statprofile))
            {
                MessageBox.Show($"Cannot add stat profile '{statprofile}'. It already exists.", "Duplicate entry");
                SystemSounds.Hand.Play();
                return;
            }
            string path = Path.Combine(dir, $"{statprofile}.json");
            File.WriteAllLines(path, []);
            statprofiles.Add(statprofile);
            MessageBox.Show("Successfully created new stat profile");
        }

        public static void SaveStatProfileData(string statprofile, List<SessionRecordEntry> entries, bool overwrite)
        {
            string path = Path.Combine(dir, $"{statprofile}.json");
            using StreamWriter writer = new(path, !overwrite);
            foreach (var entry in entries)
            {
                writer.WriteLine(JsonConvert.SerializeObject(entry));
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
                    MessageBox.Show($"Unable to get stats from stat profile '{profile}' because the file '{path}' doesn't exist", "File not found");
                    SystemSounds.Hand.Play();
                    continue;
                }
                foreach (string line in File.ReadAllLines(path))
                {
                    SessionRecordEntry? entry = JsonConvert.DeserializeObject<SessionRecordEntry>(line);
                    if (entry == null) continue;
                    records.Add(entry);
                }
            }
            return records;
        }
    }
}
