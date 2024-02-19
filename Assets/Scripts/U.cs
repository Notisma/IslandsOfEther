using System.Collections.Generic;
using UnityEngine;
using System.IO;


/** Utils */
public static class U
{
    public static void PrintList<T>(List<T> l)
    {
        string result = "list : ";
        foreach (var item in l)
        {
            result += item + ", ";
        }

        Debug.Log(result);
    }

    public static Sprite GetSpriteFromFile(string filePath, float pixelsPerUnit = 100.0f)
    {
        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

        Texture2D spriteTexture = LoadTexture(filePath);

        return spriteTexture is null
            ? null
            : Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0),
                pixelsPerUnit);
    }

    private static Texture2D LoadTexture(string filePath)
    {
        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        if (!File.Exists(filePath)) return null; // Return null if load failed

        byte[] fileData = File.ReadAllBytes(filePath);

        Texture2D tex2D = new Texture2D(2, 2);

        return tex2D.LoadImage(fileData)
            ? // Load the imagedata into the texture (size is set automatically)
            tex2D
            : // If data = readable -> return texture
            null; // Return null if load failed
    }
}