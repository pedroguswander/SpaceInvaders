using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    private List<Sprite> sprites;

    public void initialize(List<Sprite> sprites)
    {
        this.sprites = sprites;
    }

    public List<Sprite> getSprites()
    {
        return sprites;
    }

}
