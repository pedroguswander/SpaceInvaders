using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseEnemiesSpeed : MonoBehaviour
{
    private int amountOfEnemiesRemaining;
    private int totalAmountOfEnemies;
    private bool startChecking = false;
    MoveEnemies moveEnemies;

    void Start()
    {
        amountOfEnemiesRemaining = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawnerScript>().getAmountOfEnemies();
        moveEnemies = GameObject.FindAnyObjectByType<MoveEnemies>();
        totalAmountOfEnemies = amountOfEnemiesRemaining;
    }

    void Update()
    {
        if (amountOfEnemiesRemaining - GameObject.FindGameObjectsWithTag("Enemy").Length >= totalAmountOfEnemies * 0.2f)
        {
            amountOfEnemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
            moveEnemies.decreaseEnemyMoveDelay();
            Debug.Log(amountOfEnemiesRemaining);
        }
    }

    [ContextMenu("quantos inimigos tem ai")]
    public void boo()
    {
        Debug.Log(amountOfEnemiesRemaining);
    }

}
