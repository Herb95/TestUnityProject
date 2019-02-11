#region 注释
/*
*         Title: TextureImportSetting : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using UnityEngine;
using UnityEditor;

namespace LianJian
{
    public class TextureImportSetting : EditorWindow
    {
        /// <summary>
        /// 临时存储int[]
        /// </summary>
        private int[] IntArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        //AnisoLevel
        private int AnisoLevel = 1;

        //Filter Mode

        private string[] FilterModeString = new string[] { "Point", "Bilinear", "Trilinear" };

        //Wrap Mode

        private int WrapModeInt = 0;

        private string[] WrapModeString = new string[] { "Repeat", "Clamp" };

        //Texture Type
        private int FilterModeInt = 0;

        private int TextureTypeInt = 0;
        private int MaxSizeInt = 5;


        private string[] TextureTypeString = new string[] { "Default", "Normal Map", "Editor GUI", "Sprite", "Cursor", "Cookie", "Lightmap", "Single Channel" };

        //Max Size

        private string[] MaxSizeString = new string[] { "32", "64", "128", "256", "512", "1024", "2048", "4096", "8192" };


        /// <summary>
        /// 创建、显示窗体
        /// </summary>
        [@MenuItem("DuanMenu/Texture Import Settings")]
        private static void Init()
        {
            TextureImportSetting window =
                (TextureImportSetting)EditorWindow.GetWindow(typeof(TextureImportSetting), true,
                    "TextureImportSetting");
            window.Show();
        }

        /// <summary>
        /// 显示窗体里面的内容
        /// </summary>
        private void OnGUI()
        {
            //AnisoLevel
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
            //Texture Type
            TextureTypeInt = EditorGUILayout.IntPopup("Texture Type", TextureTypeInt, TextureTypeString, IntArray);
            //Filter Mode
            FilterModeInt = EditorGUILayout.IntPopup("Filter Mode", FilterModeInt, FilterModeString, IntArray);
            //Wrap Mode
            WrapModeInt = EditorGUILayout.IntPopup("Wrap Mode", WrapModeInt, WrapModeString, IntArray);
            GUILayout.Label("Aniso Level  ");
            AnisoLevel = EditorGUILayout.IntSlider(AnisoLevel, 0, 9);
            //Max Size
            MaxSizeInt = EditorGUILayout.IntPopup("Max Size", MaxSizeInt, MaxSizeString,IntArray);
            if (GUILayout.Button("Set Texture ImportSettings"))
                LoopSetTexture();
        }

        /// <summary>
        /// 获取贴图设置
        /// </summary>
        public TextureImporter GetTextureSettings(string path)
        {
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            //AnisoLevel
            textureImporter.anisoLevel = AnisoLevel;
            //Filter Mode
            switch (FilterModeInt)
            {
                case 0:
                    textureImporter.filterMode = FilterMode.Point;
                    break;
                case 1:
                    textureImporter.filterMode = FilterMode.Bilinear;
                    break;
                case 2:
                    textureImporter.filterMode = FilterMode.Trilinear;
                    break;
            }
            //Wrap Mode
            switch (WrapModeInt)
            {
                case 0:
                    textureImporter.wrapMode = TextureWrapMode.Repeat;
                    break;
                case 1:
                    textureImporter.wrapMode = TextureWrapMode.Clamp;
                    break;
                case 2:
                    textureImporter.wrapMode = TextureWrapMode.Mirror;
                    break;
                case 3:
                    textureImporter.wrapMode = TextureWrapMode.MirrorOnce;
                    break;
            }
            //Texture Type
            switch (TextureTypeInt)
            {
                case 0:
                    textureImporter.textureType = TextureImporterType.Default;
                    break;
                case 1:
                    textureImporter.textureType = TextureImporterType.NormalMap;
                    break;
                case 2:
                    textureImporter.textureType = TextureImporterType.GUI;
                    break;
                case 3:
                    textureImporter.textureType = TextureImporterType.Sprite;
                    break;
                case 4:
                    textureImporter.textureType = TextureImporterType.Cursor;
                    break;
                case 5:
                    textureImporter.textureType = TextureImporterType.Cookie;
                    break;
                case 6:
                    textureImporter.textureType = TextureImporterType.Lightmap;
                    break;
                case 7:
                    textureImporter.textureType = TextureImporterType.SingleChannel;
                    break;
            }
            //Max Size 
            switch (MaxSizeInt)
            {
                case 0:
                    textureImporter.maxTextureSize = 32;
                    break;
                case 1:
                    textureImporter.maxTextureSize = 64;
                    break;
                case 2:
                    textureImporter.maxTextureSize = 128;
                    break;
                case 3:
                    textureImporter.maxTextureSize = 256;
                    break;
                case 4:
                    textureImporter.maxTextureSize = 512;
                    break;
                case 5:
                    textureImporter.maxTextureSize = 1024;
                    break;
                case 6:
                    textureImporter.maxTextureSize = 2048;
                    break;
                case 7:
                    textureImporter.maxTextureSize = 4096;
                    break;
                case 8:
                    textureImporter.maxTextureSize = 8192;
                    break;
            }
            Debug.Log(textureImporter.maxTextureSize);
            return textureImporter;
        }

        /// <summary>
        /// 循环设置选择的贴图
        /// </summary>
        private void LoopSetTexture()
        {
            Object[] textures = GetSelectedTextures();
            Selection.objects = new Object[0];
            foreach (Texture2D texture in textures)
            {
                string path = AssetDatabase.GetAssetPath(texture);
                TextureImporter texImporter = GetTextureSettings(path);
                TextureImporterSettings tis = new TextureImporterSettings();
                texImporter.ReadTextureSettings(tis);
                texImporter.SetTextureSettings(tis);
                AssetDatabase.ImportAsset(path);
            }
        }

        /// <summary>
        /// 获取选择的贴图
        /// </summary>
        /// <returns></returns>
        private Object[] GetSelectedTextures()
        {
            return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        }
    }
}