using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PngAutoSprite
{
    public void OnPreprocessTexture(string path)
    {
        LoopSetTexture();
    }

    /// <summary>
    /// 循环设置选择的贴图
    /// </summary>
    private void LoopSetTexture()
    {
        System.Object[] textures = GetSelectedTextures();
        foreach (Texture2D texture in textures)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            TextureImporter texImporter = GetTextureSettings(path);
            TextureImporterSettings tis = new TextureImporterSettings();
            texImporter.ReadTextureSettings(tis);
            texImporter.SetTextureSettings(tis);
            AssetDatabase.ImportAsset(path);
        }
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 获取选择的贴图
    /// </summary>
    /// <returns></returns>
    private UnityEngine.Object[] GetSelectedTextures()
    {
        return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
    }

    public TextureImporter GetTextureSettings(string path)
    {
        TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        if (textureImporter != null)
        {
            textureImporter.anisoLevel = 1;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.alphaIsTransparency = true;
            textureImporter.mipmapEnabled = false;
            return textureImporter;
        }
        return null;
    }
}

public class PngToSpriteTools : Editor
{
    [MenuItem("Assets/Png转Sprite")]
    public static void PngToSprite()
    {
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        string path = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" + AssetDatabase.GetAssetPath(arr[0]);
        PngAutoSprite p = new PngAutoSprite();
        p.OnPreprocessTexture(path);
    }
}