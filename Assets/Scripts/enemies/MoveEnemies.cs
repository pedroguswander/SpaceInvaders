using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    private float enemySpeed = 0.25f;
    private bool hasCollided = false;
    private float direction = 1f;
    private bool canMoveDown = true;
    private HandlePlayerCollisons handlePlayerCollisons;
    private int currentSpriteIndex = 0;

    private float enemyMoveDelay = 0.5f;

    void Start()
    {
        handlePlayerCollisons = GameObject.FindAnyObjectByType<HandlePlayerCollisons>();
        StartCoroutine(moveEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator moveEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyMoveDelay);

            if (handlePlayerCollisons.getIsPlayerDead()) yield break;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 currentPos = enemy.transform.position;
                enemy.transform.position = currentPos + new Vector3(enemySpeed * direction, 0, 0);
                EnemySprite enemySprite = enemy.GetComponent<EnemySprite>();

                enemy.GetComponent<SpriteRenderer>().sprite = enemySprite.getSprites()[currentSpriteIndex];
            }

            currentSpriteIndex++;
            if (currentSpriteIndex > 1) currentSpriteIndex = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && !hasCollided)
        {

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (canMoveDown)
                {
                    Vector3 currentPos = enemy.transform.position;
                    enemy.transform.position = currentPos - new Vector3(0, enemySpeed, 0);
                }
            }

            direction *= -1;
            hasCollided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && hasCollided)
        {
            hasCollided = false;
        }
    }

    public bool getCanMoveDown()
    {
        return canMoveDown;
    }

    public void setCanMoveDown(bool bo)
    {
        canMoveDown = bo;
    }

    public void decreaseEnemyMoveDelay()
    {
        enemyMoveDelay -= 0.1f;
        if (enemyMoveDelay <= 0) enemyMoveDelay = 0.1f;
        Debug.Log(enemyMoveDelay);
    }
}
