using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private bool wasGameWon = false;
    private bool wasGameLost = false;
    Coroutine gameIsWon = null;
    void Start()
    {
        
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

    IEnumerator changeToWinningScreen()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0); //trocar para o indice 2 depois
    }

    private bool checkIfGameIsWon()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) return true;

        return false;
    }
}
