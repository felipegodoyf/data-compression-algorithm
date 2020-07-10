using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_compression_algorithm
{
    public static class Decompressor
    {
        public static string Decompress(string compressed)
        {
            string result = "";

            string[] packets = GetPackets(compressed);
            foreach (string packet in packets)
            {
                if (packet[0] == '1')
                {
                    int amount = (int)Char.GetNumericValue(packet[1]);
                    for (int i = 0; i < amount; i++)
                    {
                        result += packet[2];
                    }
                }
                if (packet[0] == '0')
                {
                    result += packet.Substring(1, packet.Length -1);
                }
            }

            return result;
        }

        static string[] GetPackets(string compressed)
        {
            return compressed.Split('/');
        }
    }
}
