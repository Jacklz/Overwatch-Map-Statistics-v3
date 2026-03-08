//using Tesseract;

//namespace Overwatch_Map_Statistics_v3
//{
//    internal static class ScreenshotManager
//    {
//        public static List<Rectangle> maps =
//        [
//            new(360,610,330,30),
//            new(790,610,330,30),
//            new(1220,610,330,30),
//            new(360, 605, 1200, 65),
//        ];

//        public static HashSet<string> CaptureMaps()
//        {
//            int scale = 2;
//            for (int a = 0; a < maps.Count; a++)
//            {
//                var rect = maps[a];
//                int map = a;
//                using Bitmap bmp = new(rect.Width, rect.Height);
//                using Graphics g = Graphics.FromImage(bmp);
//                {
//                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
//                }
//                Bitmap scaled = new(bmp, bmp.Width * scale, bmp.Height * scale);
//                scaled.Save($"map{map}.png");
//                //Threshold(scaled).Save($"map{map}.png");
//                //bmp.Save($"map{map}.png");
//            }
//            return GetMapsFromImage();
//        }

//        public static Bitmap RemoveColor(Bitmap image, byte threshold = 140)
//        {
//            Bitmap result = new Bitmap(image.Width, image.Height);
//            for (int y = 0; y < image.Height; y++)
//            {
//                for (int x = 0; x < image.Width; x++)
//                {
//                    Color c = image.GetPixel(x, y);
//                    byte value = (byte)((c.R + c.G + c.B) / 3);

//                    result.SetPixel(x, y, value < threshold ? Color.Black : Color.White);
//                }
//            }
//            return result;
//        }

//        private static HashSet<string> GetMapsFromImage()
//        {
//            HashSet<string> confirmedmaps = [];
//            using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
//            for (int a = 0; a < 3; a++)
//            {
//                using (var img = Pix.LoadFromFile($"map{a}.png"))
//                {
//                    using (var page = engine.Process(img))
//                    {
//                        string text = page.GetText();
//                        Main.LogText($"Raw text: {text}");
//                        foreach (var map in Main.allmaps)
//                        {
//                            if (text.Contains(map.mapname, StringComparison.OrdinalIgnoreCase))
//                            {
//                                confirmedmaps.Add(map.mapname);
//                                Main.LogText($"Map: {map.mapname}");
//                            }
//                        }
//                        confirmedmaps = confirmedmaps.OrderBy(map => text.IndexOf(map, StringComparison.OrdinalIgnoreCase)).ToHashSet();
//                    }
//                }
//            }
//            Main.LogText($"final hashset: {string.Join(",", confirmedmaps)}");
//            return confirmedmaps;
//        }
//    }
//}
