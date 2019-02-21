using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils {
    public class GameUtils {
        ///<summary>
        /// 中文转阿拉伯数字
        ///</summary>
        public static string ParseCnToInt (int i) {
            if (i < 10) { //个
                return NumberToChar (i);
            } else if (i < 100) { //十
                return NumberToTen (i);
            } else if (i < 1000) { //百
                return NumberToHundreds (i);
            } else if (i < 10000) { //千
                return NumberToThousand (i);
            } else if (i < 100000) { //万
                return NumberToOneHThousand (i);
            } else if (i < 1000000) { //十万
                return NumberToMillion (i);
            } else if (i < 10000000) { //百万
                return NumberToTenMillion (i);
            } else if (i < 100000000) { //千万
                return NumberToBillion (i);
            } else if (i < 1000000000) { //亿
                return NumberToTenBillion (i);
            } else {
                return "数字过大,无法计算";
            }
        }
        ///<summary>
        /// 10-99 十ten
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToTen (int i) {
            if (i % 10 == 0) {
                return i != 10 ? NumberToChar (i / 10) + NumberToUnit (10) : NumberToUnit (i);
            } else {
                return NumberToChar ((i - i % 10) / 10) + NumberToUnit (10) + NumberToChar (i % 10);
            }
        }
        ///<summary>
        /// 100-999 百hundred
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToHundreds (int i) {
            if (i % 100 == 0) {
                return NumberToChar (i / 100) + NumberToUnit (100);
            }
            return NumberToChar (i / 100) + NumberToUnit (100) + NumberToTen (i % 100);
        }

        ///<summary>
        /// 1000-9999 千thousand
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToThousand (int i) {
            if (i % 1000 == 0) {
                return NumberToChar (i / 1000) + NumberToUnit (1000);
            }
            return NumberToChar (i / 1000) + NumberToUnit (1000) + NumberToHundreds (i % 1000);
        }
        ///<summary>
        /// 1,0000-9,9999 万--十万one hundred thousand
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToOneHThousand (int i) {
            if (i % 10000 == 0) {
                return NumberToChar (i / 10000) + NumberToUnit (10000);
            }
            return NumberToChar (i / 10000) + NumberToUnit (10000) + NumberToThousand (i % 10000);
        }
        ///<summary>
        /// 10,0000-99,9999 十万--百万million
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToMillion (int i) {
            if (i % 100000 == 0) {
                return NumberToTen (i / 10000) + NumberToUnit (10000);
            }
            return NumberToTen (i / 10000) + NumberToUnit (10000) + NumberToThousand (i % 10000);
        }
        ///<summary>
        /// 100,0000-999,9999 百万--千万Ten million
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToTenMillion (int i) {
            if (i % 1000000 == 0) {
                return NumberToHundreds (i / 10000) + NumberToUnit (10000);
            }
            return NumberToHundreds (i / 10000) + NumberToUnit (10000) + NumberToThousand (i % 10000);
        }
        ///<summary>
        /// 1000,0000-9999,9999 千万-亿Billion
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToBillion (int i) {
            if (i % 10000000 == 0) {
                return NumberToThousand (i / 10000) + NumberToUnit (10000);
            }
            return NumberToThousand (i / 10000) + NumberToUnit (10000) + NumberToThousand (i % 10000);
        }
        ///<summary>
        /// 1,0000,0000-9,9999,9999 亿-十亿Billion
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToTenBillion (int i) {
            if (i % 100000000 == 0) {
                return NumberToChar (i / 100000000) + NumberToUnit (100000000);
            }
            return NumberToChar (i / 100000000) + NumberToUnit (100000000) + NumberToBillion (i % 100000000);
        }

        ///<summary>
        /// 数字转中文 首位
        ///</summary>
        ///<returns>string</returns>
        protected static string NumberToChar (int i) {
            switch (i) {
                case 1:
                    return "一";
                case 2:
                    return "二";
                case 3:
                    return "三";
                case 4:
                    return "四";
                case 5:
                    return "五";
                case 6:
                    return "六";
                case 7:
                    return "七";
                case 8:
                    return "八";
                case 9:
                    return "九";
                case 0:
                    return "零";
                default:
                    return string.Empty;
            }
        }
        ///<summary>
        /// 数字转汉字单位
        ///</summary>
        ///<returns>汉字单位</returns>
        protected static string NumberToUnit (int i) {
            switch (i) {
                case 10:
                    return "十";
                case 100:
                    return "百";
                case 1000:
                    return "千";
                case 10000:
                    return "万";
                case 100000000:
                    return "亿";
                default:
                    return "错误";
            }
        }
    }
}