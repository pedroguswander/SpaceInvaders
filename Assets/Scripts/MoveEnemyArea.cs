using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveEnemyArea : MonoBehaviour
{
    private EnemyMoveState mMoveState;
    private Collider2D enemyArea; //this is a trigger

    private float maxRightPostion = 3f;
    private float maxLeftPostion = -3f;

    void Start()
    {
        mMoveState = EnemyMoveState.MOVING_RIGHT;
        enemyArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (mMoveState)
        {
            case EnemyMoveState.MOVING_RIGHT:
                

                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RightTrigger"))
        {
            //Direction = 0;
            mMoveState = EnemyMoveState.MOVING_DOWN;
        }

        if (collider.gameObject.CompareTag("LeftTrigger"))
        {
            //Direction = 0;
            mMoveState = EnemyMoveState.MOVING_DOWN;
        }
    }
}
