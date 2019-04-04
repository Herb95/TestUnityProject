#region 注释
/*
*         Title: ShowFPS : SystemScripts
*         Description:
*                功能：显示FPS 等
*         Author:            Herbie  
*         Time:              #time#
*         Version:           0.1版本
*         Path:              https://www.jianshu.com/p/1c22321d88af   
*         Modify Recoder: 
* ******************************************************
* Copyright@#username# #year# .All rights reserved.
* ******************************************************
*/
#endregion
using UnityEngine;
using UnityEditor;
using System.Text;

namespace Assets.SystemScripts
{
    public class ShowFPS : MonoBehaviour
    {
        public bool _isShow = true;
        private int _frameCounter;
        private float _clientTimeAccumulator;
        private float _renderTimeAccumulator;
        private float _maxTimeAccumulator;
        private GUIStyle _sectionHeaderStyle;
        private GUIStyle _labelStyle;
        [Range(0, 1)] public static float position = 0.5f;

        private void Start()
        {

        }

        private void OnGUI()
        {
            if (_isShow)
            {
                GameViewStatsGUI();
            }
        }

        private void GameViewStatsGUI()
        {
            GUI.skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene);
            GUI.color = new Color(1, 1, 1, 0.75f);
            float num = 300f;
            float num2 = 204f;
            int num3 = Network.connections.Length;
            if (num3 != 0)
            {
                num2 += 220f;
            }
            GUILayout.BeginArea(new Rect(Screen.width * position - num - 10f, 27f, num, num2), "Statistics",
                GUI.skin.window);
            GUILayout.Label("Audio: ", SectionHeaderStyle, new GUILayoutOption[0]);
            StringBuilder stringBuilder = new StringBuilder(400);
            float audioLevel = UnityStats.audioLevel;
            stringBuilder.Append(" Level: " + FormatDb(audioLevel) +
                                 ((!EditorUtility.audioMasterMute) ? "\n" : "(MUTED)\n"));
            stringBuilder.Append(string.Format(" Clipping: {0:F1}%", 100f * UnityStats.audioClippingAmount));
            GUILayout.Label(stringBuilder.ToString(), new GUILayoutOption[0]);
        }

        private GUIStyle SectionHeaderStyle
        {
            get
            {
                if (_sectionHeaderStyle != null)
                    return _sectionHeaderStyle;

                _sectionHeaderStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).GetStyle("Boldlabel");
                return _sectionHeaderStyle;
            }
        }

        private GUIStyle LabelStyle
        {
            get
            {
                if (_labelStyle != null)
                    return _labelStyle;
                _labelStyle = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).label);
                _labelStyle.richText = true;
                return _labelStyle;
            }
        }

        private string FormatNumber(int num)
        {
            if (num < 1000)
            {
                return num.ToString();
            }

            if (num < 1000000)
            {
                return ((double)num * 0.001).ToString("f1" + "k");
            }

            return ((double)num * 1E-06).ToString("f1" + "k");
        }

        public void UpdateFrameTime()
        {
            float frameTime = UnityStats.frameTime;
            float renderTime = UnityStats.renderTime;
            _clientTimeAccumulator += frameTime;
            _renderTimeAccumulator += renderTime;
            _maxTimeAccumulator += Mathf.Max(frameTime, renderTime);
            _frameCounter++;
            bool flag = _clientTimeAccumulator == 0f && _renderTimeAccumulator == 0f;
            bool flag2 = _frameCounter > 30 || _clientTimeAccumulator > 0.3f || _renderTimeAccumulator > 0.3f;
            if (flag || flag2)
            {
                _clientTimeAccumulator = _clientTimeAccumulator / (float)_frameCounter;
                _renderTimeAccumulator = _renderTimeAccumulator / (float)_frameCounter;
                _maxTimeAccumulator = _maxTimeAccumulator / (float)_frameCounter;
            }

            if (flag2)
            {
                _clientTimeAccumulator = 0f;
                _renderTimeAccumulator = 0f;
                _maxTimeAccumulator = 0f;
            }
        }

        private static string FormatDb(float vol)
        {
            if (vol <= 0f)
            {
                return "-∞ dB";
            }
            return string.Format("{0:F1} dB", 20f * Mathf.Log10(vol));
        }
    }
}