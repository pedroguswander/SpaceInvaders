using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletEffect : IBulletEffect
{
    private float maxY = -9.2f;
    public void applyEffect()
    {
        throw new System.NotImplementedException();
    }

    public bool checkIfCanDestroyEnemy()
    {
        return false;
    }

    public bool conditionToBeDestroyed(float bulletPosY)
    {
        return bulletPosY <= maxY;
    }
}
