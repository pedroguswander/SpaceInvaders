using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemiesBullet : MonoBehaviour
{
    private float timeMinToshoot = 1f;
    private float timeMaxToshoot = 2f;
    private EnemySpawnerScript enemySpawner;

    void Start()
    {
        StartCoroutine(shootEnemyBullet());
        enemySpawner = GameObject.FindAnyObjectByType<EnemySpawnerScript>();
    }

    IEnumerator shootEnemyBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(timeMinToshoot, timeMaxToshoot));

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponent<HandleEnemyCollision>().checkIfCanShoot())
                {
                    int fiftyPorcentangeToShoot = Random.Range(0, 2);

                    if (fiftyPorcentangeToShoot == 1)
                    {
                        enemy.GetComponent<EnemyBulletHandler>().SpawnEnemyBullet();
                    }
                }
            }
        }
    }

}
