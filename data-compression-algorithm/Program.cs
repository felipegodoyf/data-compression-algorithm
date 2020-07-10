using System;
using System.ComponentModel.Design;

namespace data_compression_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "55555555555555555777789";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: an exception ocurred during decompression:\n\n" + ex.StackTrace);
            }
        }
    }
}
