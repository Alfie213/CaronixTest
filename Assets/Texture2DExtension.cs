using UnityEngine;

public static class Texture2DExtension
{
    public static Sprite ConvertToSprite(this Texture2D texture2D)
    {
        return Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
    }
}
