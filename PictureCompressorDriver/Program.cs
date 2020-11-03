using System;
using System.IO;
using System.Linq;

namespace PictureCompressorDriver
{
    class Program
    {
        private const int COMPRESSION_QUALITY = 90;

        static void Main(string[] args)
        {
            const string INPUT_PATH = @"S:\Photos - Misc\Fred spine procedure";
            // @"C:\Users\fpmor\OneDrive\Elaine Morrison\Silver Chest\";
            // @"C:\Users\fpmor\OneDrive\Pictures\slides-to-digital\Mikes Wedding";
            // @"S:\slides-to-digital\2020-06-Test-Adjusted";
            // @"C:\Users\fpmor\OneDrive\Pictures\slides-to-digital\2020-06-Test-Adjusted";
            // "C:\projects\CompMath\unit02b\animation";
            // "C:\Users\fpmor\OneDrive\travel\2020-02 New Mexico\photos";
            //const string @"C:\Users\fpmor\OneDrive\travel\2019-11 Canada trip";
            Console.WriteLine("Start");

            // C:\Users\fpmor\OneDrive\2019 Driveway Pictures

            string OUTPUT_PATH = Path.Combine(INPUT_PATH, $"compressed-{COMPRESSION_QUALITY.ToString()}");
            Console.WriteLine(OUTPUT_PATH);
            if (!Directory.Exists(OUTPUT_PATH))
            {
                Directory.CreateDirectory(OUTPUT_PATH);
            }


            if (Directory.Exists(INPUT_PATH) && Directory.Exists(OUTPUT_PATH))
            {
                var di = new DirectoryInfo(INPUT_PATH);
                var pics = di.GetFiles("*.jpg");

                foreach (System.Drawing.Image file in di.GetFiles("*.jpg")
                                         .Select(f => new { f, outputFilename = Path.Combine(OUTPUT_PATH, f.Name) })
                                         .Where(@t => !File.Exists(@t.outputFilename))
                                         .Select(@t => ImageUtilities.ImageHelper.SaveCompressedJpegImage(@t.f.FullName, @t.outputFilename, COMPRESSION_QUALITY)))
                {
                    file.Dispose();
                }
            }
            else
            {
                Console.WriteLine($"Either the input directory {INPUT_PATH} does not exist or output directory {OUTPUT_PATH} does not exits or both don't exist.");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
