using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleEnemyCollision : MonoBehaviour
{
    private Collider2D edgeCollider;
    private MoveEnemies moveEnemies;
    private EnemySpawnerScript enemySpawnerScript;
    private float maxDistance = 10f;
    public LayerMask layerMask;
    private Ray ray;
    private RaycastHit2D[] hits = new RaycastHit2D[5]; //substituir pelo numero de linhas de  inimigos
    public Transform shootCheck;

    void Start()
    {
        edgeCollider = GameObject.FindGameObjectWithTag("EnemyManager2").GetComponent<EdgeCollider2D>();
        moveEnemies = GameObject.FindAnyObjectByType<MoveEnemies>();
        enemySpawnerScript = GameObject.FindAnyObjectByType<EnemySpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(shootCheck.position, Vector3.down);
    }

    public bool checkIfCanShoot()
    {
        int numHits = Physics2D.RaycastNonAlloc(ray.origin, ray.direction, hits, maxDistance, layerMask);
        

        if (numHits > 0) {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.red);
            return false;
        }

        return true;
    }

    public bool checkIfCanShoot(int enemyRow, int enemyCol)
    {
        for (int i = enemyCol + 1; i < enemySpawnerScript.enemyRows; i++)
        {
            if (enemySpawnerScript.EnemyMatrix[enemyRow, i] != null)
            {
                return false;
            }
        }

        return true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (edgeCollider != null && collision.GetComponent<Collider2D>() == edgeCollider)
        {
            if (GameObject.FindGameObjectsWithTag("Defender").Length > 0)
            {
                Debug.Log("É pra parar de descer");
                moveEnemies.setCanMoveDown(false);
            }
            else
            {
                Debug.Log("Pode descer viu");
                moveEnemies.setCanMoveDown(true);
            }

        }
    }


}
