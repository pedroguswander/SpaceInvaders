using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderScript : MonoBehaviour
{
    private int health = 100;
    private int currentSprite = 0;
    private int amountOfSprites;
    private SpriteRenderer thisSprite;

    public Sprite[] sprites;

    private void Start()
    {
        amountOfSprites = sprites.Length;
        health = 100;
        currentSprite = 0;
        thisSprite = GetComponent<SpriteRenderer>();
        thisSprite.sprite = sprites[currentSprite];
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }

    [ContextMenu("Tomar Dano")]
    public void takeHit(int damage)
    {
        health -= damage;
        Debug.Log(health);
        currentSprite++;
        if (currentSprite < amountOfSprites)
        {
            thisSprite.sprite = sprites[currentSprite];
        }

    }
}
