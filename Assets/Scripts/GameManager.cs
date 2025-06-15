using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class GameManager : MonoBehaviour
{
    ScoreManager scoreManager;
    EnemySpawnerScript enemySpawner;
    Coroutine gameIsWon = null;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
        enemySpawner = GameObject.FindAnyObjectByType<EnemySpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfGameIsWon())
        {
            if (gameIsWon == null)
            {
                StartCoroutine(changeToWinningScreen());
            }
        }

    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        //tela de game over, espera o plyer clicar jogar dnv sla
        saveScore();


        restartGame();
    }

    private void saveScore()
    {
        PlayerPrefs.SetInt("highScore", scoreManager.getScore());
    }

    IEnumerator changeToWinningScreen()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0); //trocar para o indice 2 depois
    }

    private bool checkIfGameIsWon()
    {
        if (enemySpawner.EnemyMatrix.Length <= 0) return true;

        return false;
    }

}
