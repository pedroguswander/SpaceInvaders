using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletEffect : IBulletEffect
{
    private float maxY = 9.2f;

    public void applyEffect()
    {
        Debug.Log("implementação para a bala do player");
    }

    public bool checkIfCanDestroyEnemy()
    {
        return true;
    }

    public bool conditionToBeDestroyed(float bulletPosY)
    {
        return bulletPosY >= maxY;
    }


}
