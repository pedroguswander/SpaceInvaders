using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemySpawnerScript : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(-2f, 4f, 0.0f);

    private float distanceX = 1f;
    private float distanceY = -1;
    //enemySecondType = pos[x, y]
    public int enemyRows;
    public int enemyCols; 
    public Sprite enemySprite0;
    public Sprite enemySprite1;
    public Sprite enemySprite5;
    public Sprite enemySprite6;
    public Sprite enemySprite11;
    public Sprite enemySprite12;
    private Sprite enemySprite;

    private int amountOfEnemies;
    GameObject[,] enemyMatrix;

    void Awake()
    {
        amountOfEnemies = enemyRows * enemyCols;
    }

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        enemyMatrix = new GameObject[enemyRows, enemyCols];


        float dX = 0;
        float dY = 0;

        for (int i = 0; i < enemyRows; i++)
        {
            for (int j = 0; j < enemyCols; j++)
            {
                yield return null;

                enemyMatrix[i, j] = Instantiate(enemyPrefab, new Vector3(spawnPosition.x + dX, spawnPosition.y + dY,
                    0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                amountOfEnemies++;
                int pointsToAdd = 0;

                if (i == 0)
                {
                    enemySprite = enemySprite5;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite5, enemySprite6 });
                    pointsToAdd = 100;
                }
                else if (i == 1 || i == 2)
                {
                    enemySprite = enemySprite0;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite0, enemySprite1 });
                    pointsToAdd = 50;
                }
                else if (i == 3 || i == 4)
                {
                    enemySprite = enemySprite11;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite11, enemySprite12 });
                    pointsToAdd = 10;
                }

                enemyMatrix[i, j].AddComponent<SpriteRenderer>().sprite = enemySprite;
                enemyMatrix[i, j].AddComponent<EnemyPoint>().initialize(pointsToAdd);

                dX += distanceX;
            }
            dY += distanceY;
            dX = 0;
        }



    }

    /*void Start()
    {    
        GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        enemyMatrix = new GameObject[enemyRows, enemyCols];


        float dX = 0;
        float dY = 0;

        for (int i = 0; i < enemyRows; i++)
        {
            for (int j = 0; j < enemyCols; j++)
            {
                enemyMatrix[i, j] = Instantiate(enemyPrefab, new Vector3(spawnPosition.x + dX, spawnPosition.y + dY,
                    0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                amountOfEnemies++;
                int pointsToAdd = 0;

                if (i == 0)
                {
                    enemySprite = enemySprite5;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite5, enemySprite6 });
                    pointsToAdd = 100;
                }
                else if (i == 1 || i == 2)
                {
                    enemySprite = enemySprite0;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite0, enemySprite1 });
                    pointsToAdd = 50;
                }
                else if (i == 3 || i == 4)
                {
                    enemySprite = enemySprite11;
                    enemyMatrix[i, j].GetComponent<EnemySprite>().initialize(new List<Sprite> { enemySprite11, enemySprite12 });
                    pointsToAdd = 10;
                }
                  
                enemyMatrix[i, j].AddComponent<SpriteRenderer>().sprite = enemySprite;
                enemyMatrix[i, j].AddComponent<EnemyPoint>().initialize(pointsToAdd);

                dX += distanceX;
            }
            dY += distanceY;
            dX = 0;
        }
 
    }*/

    [ContextMenu("pegarQuantidadeDeInimigos")]
    public int getAmountOfEnemies()
    {
        Debug.Log(amountOfEnemies);
        return amountOfEnemies;
    }


    public GameObject[,] EnemyMatrix
    {
        get { return enemyMatrix; }
    }

}
