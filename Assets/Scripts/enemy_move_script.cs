using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class enemy_move_script : MonoBehaviour
{
    public GridSpeed_script gridSpeed;
    public Transform rightLimitTransform;
    public Transform leftLimitTransform;
    private int enemySpeed;

    private float direction = 1;

    //Refact later
    private float movVerticaltimer = 1f;
    private float contMoveDown = 0f;
    private bool isIttimeToMoveDown = false;

    private float movHorizontalTimer = 1f;
    private float contMoveHorizontal = 0f;
    private bool isIttimeToMoveHorizontal = true;

    private bool movTurn = true; //0 - H; 1 - v

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = gridSpeed.getGridMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= rightLimitTransform.position.x && movTurn)
        {
            isIttimeToMoveDown= true;
            isIttimeToMoveHorizontal = false;
            Debug.Log(transform.position);
        }

        if (isIttimeToMoveHorizontal)
        {
            contMoveHorizontal += Time.deltaTime;
            if (contMoveHorizontal >= movHorizontalTimer)
            {
                moveEnemyHorizontal();
                contMoveHorizontal = 0f;
            }
        }
        
        if (isIttimeToMoveDown)
        {   
            contMoveDown += Time.deltaTime;

            if (contMoveDown >= movVerticaltimer)
            {
                contMoveDown = 0f;
                isIttimeToMoveDown = false;
                isIttimeToMoveHorizontal = true;
                movTurn = false;
                moveEnemyDown();
            }
        }


        /*transform.position = new Vector3((transform.position.x + (axis * enemySpeed)),
            transform.position.y, transform.position.z);*/
    }

    [ContextMenu("Mover Inimigo na Horizontal")]
    public void moveEnemyHorizontal()
    {
        transform.position = new Vector3((transform.position.x + (enemySpeed * direction)),
            transform.position.y, transform.position.z);
    }

    public void moveEnemyDown()
    {
        transform.position = new Vector3((transform.position.x),
            transform.position.y - 1, transform.position.z);
    }
}
