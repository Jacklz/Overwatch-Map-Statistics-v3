using System.Reflection;

namespace Overwatch_Map_Statistics_v3
{
    internal static class Settings
    {
        public static bool showconfirmdialogs = true;
        public static bool resetaftersave = false;
        public static bool exitprompt = true;

        public static IOrderedEnumerable<FieldInfo> GetSettings()
        {
            var flags = BindingFlags.Static | BindingFlags.Public;
            return typeof(Settings).GetFields(flags).OrderBy(entry => entry.Name);
        }
    }
}
