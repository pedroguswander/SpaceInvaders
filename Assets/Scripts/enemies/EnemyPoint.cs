using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    int pointsToAdd;
    public void initialize(int pointsToAdd)
    {
        this.pointsToAdd = pointsToAdd;
    }

    public int getPointsToAdd()
    {
        return pointsToAdd;
    }

}
