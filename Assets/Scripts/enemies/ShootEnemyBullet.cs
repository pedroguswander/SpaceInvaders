using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyBullet : MonoBehaviour
{
    private float timeToshoot = 1f;
    private HandleEnemyCollision handleEnemyCollision;
    private EnemyBulletHandler enemyBulletHandler;

    void Start()
    {
        StartCoroutine(shootBullet());
        enemyBulletHandler = gameObject.GetComponent<EnemyBulletHandler>();
        handleEnemyCollision = gameObject.GetComponent<HandleEnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToshoot);
            
            if (handleEnemyCollision.checkIfCanShoot())
            {
                int ran = Random.Range(0, 4);

                if (ran == 3)
                {
                    enemyBulletHandler.SpawnEnemyBullet();
                }
            }
        }

    }
}
