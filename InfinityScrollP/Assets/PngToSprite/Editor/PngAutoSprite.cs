using System;
using System.IO;
using UnityEditor;
using UnityEngine;
public class PngAutoSprite : AssetPostprocessor
{
    //void OnPreprocessTexture()
    //{
    //    /*
    //    //自动设置类型; 
    //    string dirName =Path.GetDirectoryName(assetPath);
    //    Debug.Log("Import --- " + dirName);
    //    string fullPath = "Assets/Icon/icon" + "/";
    //    if (dirName == fullPath)
    //    {

    //        TextureImporter textureImporter = (TextureImporter)assetImporter;
    //        textureImporter.textureType = TextureImporterType.Sprite;

    //        /*
    //        string folderStr = Path.GetFileName(dirName);
    //        Debug.Log("Set Packing Tag --- " + folderStr);
    //        textureImporter.spritePackingTag = folderStr;
    //        */
    //    //}
    //}
    /*
    private void OnPreprocessTexture()
    {
        if (assetPath.ToLower().IndexOf("Assets/Icon/", StringComparison.InvariantCultureIgnoreCase) != -1)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.alphaIsTransparency = true;
            textureImporter.mipmapEnabled = false;
        }
    }
    */
}


public class PngToSpriteTools : AssetPostprocessor
{

    [MenuItem("Assets/图片处理/Png转Sprite")]
    public static void PngToSprite()
    {
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        string path = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" + AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log(path);
        // OnPreprocessTexture();
    }

    public void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
        //textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.alphaIsTransparency = true;
        textureImporter.mipmapEnabled = false;
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
        textureImporter.anisoLevel = 1;
        return textureImporter;
    }
}