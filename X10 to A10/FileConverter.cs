using System;
using System.Collections.Generic;
using System.IO;

namespace X10_to_A10
{
    public static class FileConverter
    {
        public static void ConvertToCSV(string inputFile, string outputFile)
        {
            StreamWriter writer = File.CreateText(outputFile);

            string[] lines = File.ReadAllLines(inputFile);
            int i = 0;
            for (i = 0; i <= lines.Length; i++)
            {
                if (lines[i] == "101010101010")
                {
                    i++;
                    break;
                }
            }

            int time = 0; //Passed Time in tenth of seconds

            string[] timings = new string[lines.Length - i];
            Array.Copy(lines, i, timings, 0, lines.Length - i);

            List<int[]> listedTimings = new List<int[]>();

            foreach (string timing in timings)
            {
                if(timing != String.Empty)
                {
                    listedTimings.Add(Array.ConvertAll(timing.Split('\t'), item => Convert.ToInt32(item)));
                }
            }

            for (int cTiming = 0; cTiming < listedTimings.Count; cTiming++)
            {
                time = TimeDecoder.GetMiliseconds(listedTimings[cTiming][0]);
                if (listedTimings.Count <= cTiming + 2)
                {
                    PatternWriter.Write(PatternWriter.Pattern.Stop, 0, writer, time, 0);
                    continue;
                }
                int nextTiming = TimeDecoder.GetMiliseconds(listedTimings[cTiming + 1][0]);

                while (time < nextTiming)
                {
                    time = PatternWriter.Write((PatternWriter.Pattern)listedTimings[cTiming][1], listedTimings[cTiming][2], writer, time, nextTiming);
                }
            }
            writer.Close();
        }
    }
}