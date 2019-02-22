using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Utils {

    public static class GameStaticTools {
        public static T Clone<T> (T RealObject) {
            using (Stream stream = new MemoryStream ()) {
                XmlSerializer serializer = new XmlSerializer (typeof (T));
                serializer.Serialize (stream, RealObject);
                stream.Seek (0, SeekOrigin.Begin);
                return (T) serializer.Deserialize (stream);
            }
        }
        public static T Clone2<T> (T RealObject) {
            using (Stream objectStream = new MemoryStream ()) {
                IFormatter formatter = new BinaryFormatter ();
                formatter.Serialize (objectStream, RealObject);
                objectStream.Seek (0, SeekOrigin.Begin);
                return (T) formatter.Deserialize (objectStream);
            }
        }
        /// <summary>
        /// 忽略大小写,比较字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains (this string source, string toCheck, StringComparison comp) {
            return source.IndexOf (toCheck, comp) >= 0;
        }

        /// <summary>
        /// 不区分大小写的序号比较
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool Contains (string str1, string str2) {
            return String.Equals (str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 不区分大小写的序号比较2,返回>0 1>2; 小于0 str1<str2 等于0 值相等
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="comp"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static int Contains (string str1, StringComparison comp, string str2) {
            return String.Compare (str1, str2, comp);
        }

        /// <summary>
        /// 截取 字段
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromatString (string str) {
            var str1 = str.Remove (0, 15);
            var str2 = "</color>";
            Regex r = new Regex (str2);
            Match m = r.Match (str1);
            if (m.Success) {
                str1 = str1.Replace (str2, "");
            }
            return str1;
        }

        /// <summary>
        /// 字符中,只是显示中文
        /// </summary>
        /// <param name="oriText">字符串</param>
        /// <returns></returns>
        public static string GetChineseWord (string oriText) {
            string x = @"[\u4E00-\u9FFF]+";
            MatchCollection Matches = Regex.Matches (oriText, x, RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder ();
            foreach (Match NextMatch in Matches) {
                sb.Append (NextMatch.Value);
            }
            return sb.ToString ();
        }

        /// <summary>
        /// 竖排显示字体
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatStr(string str)
        {
            string result = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                result += str[i] + "\n";
            }
            return result;
        }

    }
    class ByteArray {
        private byte[] m_data = null;
        public ByteArray (byte[] data) {
            m_data = data;
        }
        public byte[] GetBytes () {
            return m_data;
        }
        static public ByteArray operator + (ByteArray a, ByteArray b) {
            byte[] xo1 = a.GetBytes ();
            byte[] xo2 = b.GetBytes ();
            using (MemoryStream ms = new MemoryStream ()) {
                ms.Write (xo1, 0, xo1.Length);
                ms.Write (xo2, 0, xo2.Length);
                return new ByteArray (ms.ToArray ());
            }
        }
    }
}