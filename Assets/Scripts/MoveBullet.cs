using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBullet : MonoBehaviour
{
    private DefenderScript defenderScript;
    private HandlePlayerCollisons playerScript;
    private ScoreManager scoreManager;
    private ParticleManager particleManager;

    Vector2 direction = Vector2.up;
    private float moveSpeed = 10f;
    private int bulletDamage = 20;
    private IBulletEffect bulletEffect;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("ScoreManager") != null) scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (GameObject.FindGameObjectWithTag("Defender") != null) defenderScript = GameObject.FindGameObjectWithTag("Defender").GetComponent<DefenderScript>();
        if (GameObject.FindGameObjectWithTag("Player") != null) playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HandlePlayerCollisons>();
        if (GameObject.FindGameObjectWithTag("ParticleManager") != null) particleManager = GameObject.FindGameObjectWithTag("ParticleManager").GetComponent<ParticleManager>();
    }

    public void Initialize(Vector2 direction, IBulletEffect bulletEffect)
    {
        this.direction = direction;
        this.bulletEffect = bulletEffect;

    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (bulletEffect.conditionToBeDestroyed(transform.position.y))
        {
            destroyBullet();
        }
    }

    public void destroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool shouldBulletBeDestroyed = false;

        if (collision.gameObject.CompareTag("Defender"))
        {
            collision.GetComponent<DefenderScript>().takeHit(bulletDamage);
            shouldBulletBeDestroyed = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerScript != null) playerScript.takeDamage(1);
            shouldBulletBeDestroyed = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (bulletEffect.checkIfCanDestroyEnemy())
            {
                scoreManager.addPoints(collision.gameObject.GetComponent<EnemyPoint>().getPointsToAdd());
                particleManager.applySparklesOnDeath(collision.gameObject.transform);
                Destroy(collision.gameObject);
            }
            shouldBulletBeDestroyed = true;
        }

        if (shouldBulletBeDestroyed)
        {
            destroyBullet();
        }
    }
}
