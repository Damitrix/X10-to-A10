using System;
using System.IO;

namespace X10_to_A10
{
    public static class PatternWriter
    {
        private static int Speed;
        private static int Time;
        private static StreamWriter Writer;

        /*Patterns:
         * 1: Continuous Rotation
         * 2: Continuous Rotation - Reverse
         * 3: Switching Rotation 90°
         * 4: Switching Rotation 180°
         * 5: 10s rotation, 3s pause
         * 6: Gradual mountain pattern speed increase/decrease over 7 seconds
         * 7: Big rotation clockwise with small rotation counter-clockwise
         * 8: 3 rotations to clockwise then 3 rotation counter-clockwise
         */

        public enum Pattern
        {
            Left = 1,
            Right = 2,
            Skip = 3,
            Viking = 4,
            TenCount = 5,
            Mountain = 6,
            QuickTurn = 7,
            OBriend = 8,
            Test = 9,
            Stop = 0
        }

        public static int Write(Pattern pattern, int tSpeed, StreamWriter tWriter, int tTime, int nTime)
        {
            Speed = tSpeed;
            Writer = tWriter;
            Time = tTime;

            switch (pattern)
            {
                case Pattern.Left:
                    return WriteLeft(nTime);
                case Pattern.Right:
                    return WriteRight(nTime);
                case Pattern.Skip:
                    return WriteSwitch90();
                case Pattern.Viking:
                    return WriteSwitch180();
                case Pattern.TenCount:
                    return WriteTenCount();
                case Pattern.Mountain:
                    return WriteMountain();
                case Pattern.QuickTurn:
                    return WriteSwitch90();
                case Pattern.OBriend:
                    return WriteMountain();
                case Pattern.Test:
                    return nTime;
                case Pattern.Stop:
                    return WriteStop(nTime);
            }

            return -1;
        }

        private static int GetSpeed(int speed)
        {
            if (speed == 0 || speed == 100)
            {
                return speed;
            }
            Random rnd = new Random(Time);
            return rnd.Next((speed * 10) - 5, speed * 10 + 5);
        }

        private static int WriteLeft(int nTime)
        {
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            return nTime;
        }

        private static int WriteRight(int nTime)
        {
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed));
            return nTime;
        }

        private static int WriteSwitch90()
        {
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            Time += 5;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed));
            Time += 5;
            return Time;
        }

        private static int WriteSwitch180()
        {
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            Time += 10;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed));
            Time += 10;
            return Time;
        }

        private static int WriteTenCount()
        {
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            Time += 100;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed));
            Time += 30;
            return Time;
        }

        private static int WriteMountain()
        {
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed - 14));
            Time += 7;
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed - 7));
            Time += 7;
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            Time += 7;
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed - 7));
            Time += 7;
            Writer.WriteLine(Time + "," + 0 + "," + GetSpeed(Speed));
            Time += 7;

            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed - 14));
            Time += 7;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed - 7));
            Time += 7;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed));
            Time += 7;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed - 7));
            Time += 7;
            Writer.WriteLine(Time + "," + 1 + "," + GetSpeed(Speed - 14));
            Time += 7;
            return Time;
        }

        private static int WriteStop(int nTime)
        {
            Writer.WriteLine(Time + "," + 0 + "," + "0");
            return nTime;
        }
    }
}