using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace data_compression_algorithm
{
    public static class FileLoader
    {
        public static string GetRawData(string fileUrl)
        {
            string result = "";

            foreach (byte b in File.ReadAllBytes(fileUrl))
            {
                result += b.ToString();
            }

            return result;
        }

        public static string GetImageData(string fileUrl, int imageWidth, int imageHeight)
        {
            string result = "";

            Bitmap bitmap = new Bitmap(fileUrl);
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    float colorValue = (bitmap.GetPixel(x, y).R / 255+
                                        bitmap.GetPixel(x, y).G / 255 +
                                        bitmap.GetPixel(x, y).B / 255) / 3;

                    result += colorValue;
                }
            }

            return result;
        }
    }
}
