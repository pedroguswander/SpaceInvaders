using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private GridSpeed_script grid = new GridSpeed_script();

    private Vector2 rightLimit = new Vector2(3f, 4f);
    private Vector2 leftLimit = new Vector2(-3f, 4f);

    private bool changeTurn = true;
    private int changeDirectionLogic = 1;
    private int enemySpeed;
    private float moveVerticaltimer = 1f;
    private float moveHorizontalTimer = 1f;
    private float direction = 1;

   Coroutine moveHCourotine;

    void Start()
    {
        enemySpeed = grid.getGridMoveSpeed();
        moveHCourotine = StartCoroutine(MoveHorizontalCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveHorizontalCoroutine()
    {
        while(true)             //some kind of condition
        {
            Debug.Log(changeTurn);
            Debug.Log(changeDirectionLogic);
            yield return new WaitForSeconds(moveHorizontalTimer);

            while (changeTurn && (transform.position.x >= rightLimit.x ||
                transform.position.x <= leftLimit.x))
            {
                yield return StartCoroutine(MoveVerticalCoroutine());
            }

            changeTurn = true;
            transform.position = new Vector3((transform.position.x + (enemySpeed * direction)),
            transform.position.y, transform.position.z); 
        }
    }

    IEnumerator MoveVerticalCoroutine()
    {
        transform.position = new Vector3((transform.position.x),
        transform.position.y - 1, transform.position.z);
        changeTurn = false;
        changeDirectionLogic++;

        if (changeDirectionLogic % 2 == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        yield return new WaitForSeconds(moveVerticaltimer);
    }

}
