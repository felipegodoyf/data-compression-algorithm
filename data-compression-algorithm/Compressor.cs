using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace data_compression_algorithm
{
    public static class Compressor
    {
        public static string Compress(string source)
        {
            string result = "";

            for (int i=0; i < source.Length; i++)
            {
                if (NeedsCompression(source, i))
                {
                    string siblingChars = GetSiblingChars(source, i);
                    result += "1" + siblingChars.Length + siblingChars[0] + "/";
                    i += siblingChars.Length -1;
                }
                else
                {
                    result += "0";
                    while (!NeedsCompression(source, i) || i == source.Length -1)
                    {
                        result += source[i];
                        if (i == source.Length)
                        {
                            result += "/";
                            break;
                        }
                        else
                        {
                            if (i < source.Length - 1)
                                i++;
                            else
                                break;
                        }
                    }
                    if (NeedsCompression(source, i))
                    {
                        result += "/";
                        i--;
                    }
                }
            }

            return result;
        }

        static bool NeedsCompression(string source, int index)
        {
            char c = source[index];
            for (int i=index +1; i < source.Length && i < index + 4; i++)
            {
                if (source[i] != c)
                {
                    return false;
                }
            }
            return true;
        }

        static string GetSiblingChars(string source, int index)
        {
            string result = "";
            char c = source[index];
            for (int i=index; i < index +9 && i < source.Length; i++)
            {
                if (source[i] == c)
                {
                    result += source[i];
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
