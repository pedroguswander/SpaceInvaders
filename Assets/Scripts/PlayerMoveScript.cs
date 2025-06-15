using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    Vector2 movement;
    private float halthOfPlayerSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
        halthOfPlayerSprite = gameObject.GetComponent<SpriteRenderer>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

 
    }
    private void FixedUpdate()
    {
        if (rb.position.x - halthOfPlayerSprite > -4f && movement.x == -1f)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (rb.position.x + halthOfPlayerSprite < 4f && movement.x == 1f)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

    }
}
