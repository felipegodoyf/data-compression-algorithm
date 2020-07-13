using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace data_compression_algorithm
{
    public static class FileWriter
    {
        public static void SaveImage(string imagePath, int imageWidth, int imageHeight, string data)
        {
            //Generating image
            Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
            List<int> values = GetPixelValuesFromData(data);
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageWidth; y++)
                {
                    float currentValue = 0;
                    try
                    {
                        currentValue = values[(x * imageHeight + y)] * 255;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb((byte)currentValue, (byte)currentValue, (byte)currentValue));
                }
            }

            //Saving file
            FileStream fileStream = new FileStream(imagePath, FileMode.Create);
            bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
            fileStream.Close();
        }

        public static List<int> GetPixelValuesFromData(string data)
        {
            List<string> stringValues = new List<string>();
            List<int> values = new List<int>();

            for (int i=0; i < data.Length -1;)
            {
                stringValues.Add("" + data[i]);
                i += 1;
            }

            foreach(string s in stringValues)
            {
                values.Add(int.Parse(s));
            }

            return values;
        }
    }
}
