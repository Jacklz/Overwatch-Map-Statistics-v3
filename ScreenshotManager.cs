using Tesseract;

namespace Overwatch_Map_Statistics_v3
{
    internal static class ScreenshotManager
    {
        public static HashSet<string> CaptureMaps()
        {
            List<Rectangle> maps =
            [
                new(360,610,330,30),
                new(790,610,330,30),
                new(1220,610,330,30),
                //new(360, 605, 1200, 65),
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

        //public static async Task<HashSet<string>> GetMapsFromImage2()
        //{
        //    HashSet<string> confirmedmaps = [];
        //    byte[] bytes = File.ReadAllBytes("map0.png");

        //    using var stream = new InMemoryRandomAccessStream();
        //    await stream.WriteAsync(bytes.AsBuffer());
        //    stream.Seek(0);

        //    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
        //    SoftwareBitmap bitmap = await decoder.GetSoftwareBitmapAsync();

        //    var engine = OcrEngine.TryCreateFromUserProfileLanguages();
        //    var result = await engine.RecognizeAsync(bitmap);
        //    Main.LogText($"Raw text: {result.Text}");
        //    foreach (var map in Main.allmaps)
        //    {
        //        if (result.Text.Contains(map.mapname, StringComparison.OrdinalIgnoreCase))
        //        {
        //            confirmedmaps.Add(map.mapname);
        //            Main.LogText($"Map: {map.mapname}");
        //        }
        //    }
        //    confirmedmaps = confirmedmaps.OrderBy(map => result.Text.IndexOf(map, StringComparison.OrdinalIgnoreCase)).ToHashSet();
        //    Main.LogText($"final hashset: {string.Join(",", confirmedmaps)}");
        //    return confirmedmaps;
        //}

        private static HashSet<string> GetMapsFromImage()
        {
            HashSet<string> confirmedmaps = [];
            using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            for (int a = 0; a < 3; a++)
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
            Main.LogText($"final hashset: {string.Join(",",confirmedmaps)}");
            return confirmedmaps;
        }
    }
}
