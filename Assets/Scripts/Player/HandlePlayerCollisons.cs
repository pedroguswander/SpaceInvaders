using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandlePlayerCollisons : MonoBehaviour
{
    public Sprite deathSprite;
    private GameManager gameManager;
    public TextMeshProUGUI livesText;
    private bool isPlayerDead = false;
    private Coroutine killPlayerCoroutine;
    private int _playerLives = 3;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (_playerLives <= 0)
        {
            isPlayerDead = true;
        }

        if (isPlayerDead)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
            //start couroutine;
            if (killPlayerCoroutine == null)
            {
                 killPlayerCoroutine = StartCoroutine(killPlayer());
            }
        }
    }

    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(1f);

        destroyPlayer();
        gameManager.gameOver();

    }

    public void destroyPlayer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroyPlayer();
            isPlayerDead = true;
        }
    }

    public bool getIsPlayerDead()
    {
        return isPlayerDead;
    }

    public void setIsPlayerDead(bool bo)
    {
        isPlayerDead = bo;
    }

    public int getPlayerLives()
    {
        return _playerLives;
    }

    public void takeDamage(int damage = 1)
    {
        Debug.Log(_playerLives);
        _playerLives -= damage;
        if (_playerLives <= 0) _playerLives = 0;

        livesText.text = _playerLives+ " x";
    }

    [ContextMenu("do damage")]
    private void takeDamage()
    {
        Debug.Log(_playerLives);
        _playerLives -= 1;
        if (_playerLives <= 0) _playerLives = 0;

        livesText.text = _playerLives + " x";
    }
}
