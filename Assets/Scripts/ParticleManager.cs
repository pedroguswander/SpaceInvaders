using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public Sprite enemyDeathSprite;

    public bool applySparklesOnDeath(Transform killedEnemy)
    {
        GameObject sparkles = Instantiate(new GameObject(), killedEnemy.position, Quaternion.identity);
        sparkles.AddComponent<SpriteRenderer>().sprite = enemyDeathSprite;
        StartCoroutine(deleteSparkles(sparkles));

        return true;
    }

    private IEnumerator deleteSparkles(GameObject sparkles)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(sparkles);
    }
}
