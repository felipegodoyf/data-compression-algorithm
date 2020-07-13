using System;
using System.ComponentModel.Design;
using System.IO;

namespace data_compression_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int imageWidth = 256;
            int imageHeight = 256;
            string source = FileLoader.GetImageData(@"../../../../img/data-sample-2.png", imageWidth, imageHeight);
            string compressed = "";
            string decompressed = "";

            // Compressing
            Console.WriteLine(source);
            Console.WriteLine("\n[COMPRESSING...]\n");
            try
            {
                compressed = Compressor.Compress(source);
                Console.WriteLine(compressed);
                Console.WriteLine("\n[improvement of " + (1.0f - ((float)compressed.Length / (float)source.Length)) * 100.0f + "%]\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: an exception ocurred during compression:\n\n" + ex.StackTrace);
            }

            // Decompressing
            Console.WriteLine(compressed);
            Console.WriteLine("\n[DECOMPRESSING...]\n");
            try
            {
                decompressed = Decompressor.Decompress(compressed);
                Console.WriteLine(decompressed);
                FileWriter.SaveImage(@"image.png", imageWidth, imageHeight, decompressed);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: an exception ocurred during decompression:\n\n" + ex);
            }
        }
    }
}
