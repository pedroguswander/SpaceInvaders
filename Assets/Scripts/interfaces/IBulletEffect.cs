using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletEffect
{
    public abstract void applyEffect();

    public abstract bool conditionToBeDestroyed(float bulletPosY);

    public abstract bool checkIfCanDestroyEnemy();
}
