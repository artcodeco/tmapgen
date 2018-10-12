using System;
using System.Text;
using System.Xml;
using System.IO;

namespace TMapGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToTMX = args[0]; // Get the path to the TMX file

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(pathToTMX);

            //Get the map width and the height.
            XmlNode propertiesNode = xdoc.SelectSingleNode("/map/layer");
            int width = Int32.Parse(propertiesNode.Attributes["width"].Value);
            int height = Int32.Parse(propertiesNode.Attributes["height"].Value);

            //Make a 2D array from the CSV data in the dataNode
            XmlNode dataNode = xdoc.SelectSingleNode("/map/layer/data");
            string csvList = dataNode.InnerText;
            string[] splitList = csvList.Split(',');

            // This will store the map in the native format with 0,0 being in the lower lefthand corner.
            long[,] tiles = new long[height, width];

            for (int lat = 0; lat < height; lat++)
            {
                for (int lon = 0; lon < width; lon++)
                {
                    long value = Int64.Parse(splitList[(lat * width) + lon]);
                    if (value != 0)
                    {
                        tiles[(height - 1) - lat, lon] = value;
                    }

                }
            }

            // Now, we generate a list of tiles from the tiles array.

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tiles[y, x] != 0)
                    {
                        sb.AppendLine(String.Format("tmap {1} {0} {2} {3}", (y + 1) * 4, x * 4, GetTileNumberFromTile(tiles[y, x]) - 1, GetRotationFromTile(tiles[y, x])));
                    }
                }
            }

            StreamWriter sw = File.CreateText(args[0] + ".txt");
            sw.Write(sb.ToString());
            sw.Close();
        }

        public static int GetRotationFromTile(long tile)
        {
            long maskedRotation = (tile & 0xE000_0000) >> 30;
            switch (maskedRotation)
            {
                case 0:
                    maskedRotation = 0;
                    break;
                case 1:
                    maskedRotation = 3;
                    break;
                case 2:
                    maskedRotation = 1;
                    break;
                case 3:
                    maskedRotation = 2;
                    break;
            }

            return (int) maskedRotation;
        }

        public static int GetTileNumberFromTile(long tile)
        {
            return (int) tile & 0x0FFF_FFFF;
        }
    }
}

