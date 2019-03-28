using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
public class StringUtils {
    public static string BytesToString (byte[] bytes) {
        return System.Text.Encoding.Default.GetString (bytes);
    }

    public static byte[] StringToBytes (string s) {
        return System.Text.Encoding.Default.GetBytes (s);
    }

    /// <summary>
    /// 格式化数据大小
    /// </summary>
    /// <param name="s"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    public static string FormatDataSize (float s, int round = 2) {
        string suffix = "B";
        if (s > 1024) {
            s = s / 1024;
            suffix = "KB";
        }

        if (s > 1024) {
            s = s / 1024;
            suffix = "MB";
        }

        if (s > 1024) {
            s = s / 1024;
            suffix = "GB";
        }

        return System.Math.Round (s, round) + suffix;
    }

    /// <summary>
    /// 格式化Json字符串
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string FormatJsonString (string s) {
        System.Console.WriteLine (s);
        StringBuilder r = new StringBuilder ();
        List<char> stack = new List<char> ();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (c == '{' || c == '[') {
                if (r.Length > 0 &&
                    r[r.Length - 1] != '\t' &&
                    r[r.Length - 1] != '\n') {
                    r.Append ("\n");
                    for (int j = 0; j < stack.Count; j++) {
                        r.Append ("\t");
                    }
                }
                r.Append (c + "\n");
                stack.Add (c);
                for (int j = 0; j < stack.Count; j++) {
                    r.Append ("\t");
                }
            } else if (c.Equals ('}') || c.Equals (']')) {
                if ((stack[stack.Count - 1] == '{' && c == '}') ||
                    (stack[stack.Count - 1] == '[' && c == ']')) {
                    stack.RemoveAt (stack.Count - 1);
                    if (r.Length > 0 &&
                        r[r.Length - 1] == '\t') {
                        r.Remove (r.Length - 1, 1);
                    }

                    if (r.Length > 0 &&
                        r[r.Length - 1] != '\t' &&
                        r[r.Length - 1] != '\n') {
                        r.Append ("\n");
                        for (int j = 0; j < stack.Count; j++) {
                            r.Append ("\t");
                        }
                    }
                    r.Append (c + "\n");
                    for (int j = 0; j < stack.Count; j++) {
                        r.Append ("\t");
                    }
                } else {
                    System.Console.WriteLine ("CCC " + c + "  -  " + stack[stack.Count - 1]);
                }
            } else if (c == ',') {
                r.Append (c + "\n");
                for (int j = 0; j < stack.Count; j++) {
                    r.Append ("\t");
                }
            } else if (c != '\n' && c != '\t' && c != '\r') {
                r.Append (c);
            }
        }
        return r.ToString ();
    }

    /// <summary>
    /// 获取枚举变量
    /// </summary>
    public static T GetEnum<T> (string s) {
        if (string.IsNullOrEmpty (s))
            return default (T);

        return (T) System.Enum.Parse (typeof (T), s);
    }
    public static int ToInt32 (string s) {
        int _int = 0;
        if (string.IsNullOrEmpty (s))
            return _int;
        if (!int.TryParse (s, out _int)) {
            System.Console.WriteLine ("String To Int Error");
        }
        return _int;
    }

    public static long ToInt64 (string s) {
        if (string.IsNullOrEmpty (s))
            return 0;
        return System.Convert.ToInt64 (s);
    }

    public static float ToFloat (string s) {
        if (string.IsNullOrEmpty (s))
            return 0;
        return (float) System.Convert.ToDouble (s);
    }

    public static double ToDouble (string s) {
        if (string.IsNullOrEmpty (s))
            return 0;
        return System.Convert.ToDouble (s);
    }

    public static bool ToBool (string s, bool v = true) {
        if (string.IsNullOrEmpty (s))
            return v;

        if (s == "1")
            return true;

        if (s == "0")
            return false;

        bool.TryParse (s, out v);
        return v;
    }
    public static string ConnectList (List<int> l, string split = ",") {
        StringBuilder sb = new StringBuilder ();
        for (int i = 0; i < l.Count; i++) {
            sb.Append (l[i]);
            if (i != l.Count - 1)
                sb.Append (split);
        }
        return sb.ToString ();
    }

    public static void PringBytes (byte[] bytes, int len, string tag = "") {
        StringBuilder s = new StringBuilder ();
        for (int i = 0; i < len; i++) {
            s.Append (bytes[i] + " ");
        }
        System.Console.WriteLine (tag + " Bytes : " + s.ToString ());
    }

    public static string SetRichTextBold (string s) {
        return "<b>" + s + "</b>";
    }

    /// <summary>
    /// 字符转换为list
    /// </summary>
    /// <param name="str"></param>
    public static string[] FormatString (string str) {
        return str.Split (',');
    }
}