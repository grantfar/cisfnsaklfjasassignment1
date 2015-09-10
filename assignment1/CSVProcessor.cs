﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    private class CSVProcessor
    {
        private System.IO.StreamReader wineReader;
        private String[][] wineArray;
        private int longestDescriptionLength;
        private int longestIdLength;
        public CSVProcessor(String csvPathString)
        {
            wineReader = new System.IO.StreamReader(csvPathString);
            wineArrayCreator();
            setLengths();
        }

        public int LongestIdLength
        {
            get
            {
                return longestIdLength;
            }
            set
            {
                longestIdLength = value;
            }
                
        }
        public int LongestDescriptionLength
        {
            get
            {
                return longestDescriptionLength;
            }
            set
            {
                longestDescriptionLength = value;
            }

        }
        private void wineArrayCreator()
        {
            String[] tempWineArray;
            List<String> wineList = new List<string>();
            while (!wineReader.EndOfStream)
            {
                wineList.Add(wineReader.ReadLine());
            }
            wineReader.Close();
            wineArray = new String[wineList.Count][];
            for (int i = 0; i < wineList.Count; i++)
            {
                tempWineArray = wineList[i].Split(',');
                wineArray[i] = tempWineArray;
            }
        }
        private void setLengths()
        {
            longestDescriptionLength = 0;
            longestIdLength = 0;
            foreach (String[] s in wineArray)
            {
                if (s[0].Length > longestIdLength)
                    longestIdLength = s[0].Length;
                if (s[1].Length > longestDescriptionLength)
                    longestDescriptionLength = s[1].Length;
            }
        }
        public String[][] WineArray
        {
            get
            {
                return wineArray;
            }
        }
    }
}