using System;

namespace Utils {
    /// <summary>
    /// 时间工具类
    /// </summary>
    public static class TimeUtil {

        public static DateTime DateTime1970 = new DateTime (1970, 1, 1).ToLocalTime ();
        /// <summary>
        ///获取本地时间毫秒 13位
        /// </summary>
        public static long GetLocalTime () {
            DateTime dtStart = System.TimeZoneInfo.ConvertTimeToUtc (DateTime1970, TimeZoneInfo.Local);
            TimeSpan toNow = (DateTime.UtcNow).Subtract (dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse (timeStamp.ToString ().Substring (0, timeStamp.ToString ().Length - 4));
            // TimeSpan ts = DateTime.UtcNow - new DateTime (1970, 1, 1, 0, 0, 0, 0);`
            return timeStamp;
        }

        /// <summary>
        /// 获取从 1970-01-01 到现在的毫秒数。10位
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp () {
            return (long) (DateTime.Now.ToLocalTime () - DateTime1970).TotalSeconds;
        }

        /// <summary>
        /// 计算 1970-01-01 到指定 <see cref="DateTime"/> 的毫秒  10位
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetTimeStamp (DateTime dateTime) {
            return (long) (dateTime.ToLocalTime () - DateTime1970).TotalSeconds;
        }
        public static DateTime GetUnixTime () {
            return TimeUtil.FormatToDateTime (GetTimeStamp ());
        }

        /// <summary>
        ///  转化为北京时间(北京时间=UTC时间+8小时 )   
        /// </summary>
        /// <param name="isChina"></param>
        /// <returns></returns>
        public static DateTime GetUnixTime (bool isChina) {
            DateTime startTime = TimeZoneInfo.ConvertTimeToUtc (DateTime1970);
            startTime = startTime.AddSeconds (FormatToTimeStamp (DateTime.Now.ToLocalTime ()));
            startTime = startTime.AddHours (8);
            return startTime;
        }

        /// <summary>
        /// 计算某日的周一
        /// </summary>
        /// <param name="someDate"></param>
        public static DateTime GetMondayDate (DateTime someDate) {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1)
                i = 6;
            TimeSpan ts = new TimeSpan (i, someDate.Hour, someDate.Minute, someDate.Second);
            return someDate.Subtract (ts);
        }
        /// <summary>
        /// 获取当前日的周一
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime GetHourToMonday (int hour) {
            int second = hour * 3600;
            DateTime time = GetMondayDate (DateTime.Now);
            long timeTemp = FormatToTimeStamp (time) + second;
            return FormatToDateTime (timeTemp);
        }
        /// <summary>
        /// 时间戳转换位DataTime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime FormatToDateTime (long timeStamp) {
            DateTime dt = DateTime1970.AddSeconds (timeStamp).ToLocalTime ();
            return dt;
        }
        public static DayOfWeek GetWeek (DateTime time) {
            return time.DayOfWeek;
        }
        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long FormatToTimeStamp (DateTime time) {
            long timeStamp = (long) (time - DateTime1970).TotalSeconds;
            return timeStamp;
        }
    }
}