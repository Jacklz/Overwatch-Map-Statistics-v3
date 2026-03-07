using Tesseract;

namespace Overwatch_Map_Statistics_v3
{
    internal static class ScreenshotManager
    {
        public static HashSet<string> CaptureMaps()
        {
            List<Rectangle> maps =
            [
                //new(360,610,330,30),
                //new(790,610,330,30),
                //new(1220,610,330,30),
                new(360, 605, 1200, 65),
            ];
            for (int a = 0; a < maps.Count; a++)
            {
                var rect = maps[a];
                int map = a;
                using Bitmap bmp = new(rect.Width, rect.Height);
                using Graphics g = Graphics.FromImage(bmp);
                {
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
                }
                bmp.Save($"map{map}.png");
            }
            return GetMapsFromImage();
        }

        private static HashSet<string> GetMapsFromImage()
        {
            HashSet<string> confirmedmaps = [];
            using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            for (int a = 0; a < 1; a++)
            {
                using (var img = Pix.LoadFromFile($"map{a}.png"))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        Main.LogText($"Raw text: {text}");
                        foreach (var map in Main.allmaps)
                        {
                            if (text.Contains(map.mapname, StringComparison.OrdinalIgnoreCase))
                            {
                                confirmedmaps.Add(map.mapname);
                                Main.LogText($"Map: {map.mapname}");
                            }
                        }
                        confirmedmaps = confirmedmaps.OrderBy(map => text.IndexOf(map, StringComparison.OrdinalIgnoreCase)).ToHashSet();
                    }
                }
            }
            return confirmedmaps;
        }
    }
}
