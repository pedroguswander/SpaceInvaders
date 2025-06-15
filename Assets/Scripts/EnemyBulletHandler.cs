using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBulletHandler : MonoBehaviour
{
    private GameObject enemyBullet;

    void Start()
    {
        enemyBullet = Resources.Load<GameObject>("Prefabs/EnemyBullet");
    }

    public void SpawnEnemyBullet()
    {
        GameObject newEnemyBullet = Instantiate(enemyBullet, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
        MoveBullet moveBullet = newEnemyBullet.GetComponent<MoveBullet>();
        moveBullet.Initialize(Vector2.down, new EnemyBulletEffect());
    }
}
