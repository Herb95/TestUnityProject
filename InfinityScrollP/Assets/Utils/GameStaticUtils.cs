using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Utils
{
    /// <summary>
    /// enum OR Class CustomAttributes  To string
    /// </summary>
    public static class GameStaticUtils
    {
        public static string ToDescription<T>(this T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetEnumDescription<TEnum>(int value)
        {
            return ToDescription((Enum)(object)((TEnum)(object)value));
        }

        /// <summary>
        /// 忽略大小写,比较字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// 不区分大小写的序号比较
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool Contains(string str1, string str2)
        {
            return String.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 不区分大小写的序号比较2,返回>0 1>2; 小于0 str1<str2 等于0 值相等
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="comp"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static int Contains(string str1, StringComparison comp, string str2)
        {
            return String.Compare(str1, str2, comp);
        }

        /// <summary>
        /// 深度拷贝单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="realObject"></param>
        /// <returns></returns>
        /// 利用System.Xml.Serialization来实现序列化与反序列化
        public static T Clone<T>(T realObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, realObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

        /// <summary>
        /// 深度拷贝list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reList"></param>
        /// <returns></returns>
        public static List<T> CloeList<T>(List<T> reList)
        {
            List<T> t = new List<T>();
            if (reList.Count == 0)
                return t;
            for (int i = 0; i < reList.Count; i++)
            {
                t.Add(Clone(reList[i]));
            }
            return t;
        }

        #region 替换字符
        /// <summary>
        /// Tip 替换字
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="str2">替换字</param>
        /// <param name="changeStr">需要替换字符串</param>
        /// <returns></returns>
        public static string FormatString(string str, string str2, string changeStr)
        {
            return str.Replace(changeStr, str2);
        }

        public static string Format_Count(string _str, string _newValue)
        {
            return _str.Replace("%{count}", _newValue);
        }

        public static string Format_Item(string _str, string _newValue)
        {
            return _str.Replace("%{item}", _newValue);
        }

        public static string Format_Money(string _str, string _newValue)
        {
            return _str.Replace("%{money}", _newValue);
        }

        public static string Format_Name(string _str, string _newValue)
        {
            return _str.Replace("%{name}", _newValue);
        }

        #endregion

        /// <summary>
        /// 超过100万数字 中文输出
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string FormatBigNum(long num)
        {
            string str = string.Empty;
            if (num < 1000000)
            {
                str = num.ToString();
            }
            else if (num >= 100000 && num < 100000000)
            {
                long temp = num / 10000;
                str = temp.ToString() + "万";
            }
            else if (num >= 100000000)
            {
                long temp = num / 100000000;
                str = temp.ToString() + "亿";
            }
            return str;
        }
    }
}