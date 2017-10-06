using System;

namespace X10_to_A10
{
    public static class TimeDecoder
    {
        public static int GetMiliseconds(int number)
        {
            int ret = Convert.ToInt32(Math.Floor(number / 1000f));
            return ret;
        }

        //Needed?
        public static int GetSeconds(int number)
        {
            return Convert.ToInt32(Math.Floor(number / 10000f));
        }

        public static DateTime ToDateTime(int number)
        {
            DateTime time = new DateTime();

            time.AddMilliseconds(GetMiliseconds(number));

            return time;
        }
    }
}