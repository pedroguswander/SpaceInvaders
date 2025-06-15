using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Logic_script : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeConter = 0f;
    private float timeToMove = 1f;
    private bool isItTimeToMove = false;

    // Update is called once per frame
    void Update()
    {
        if (isItTimeToMove)
        {
            IncTimeConter(timeConter);
        }
    }

    public bool getIsItTimeToMove()
    {
        return isItTimeToMove;
    }

    private bool IncTimeConter(float timeConter)
    {
        timeConter += Time.deltaTime;
        return timeConter >= timeToMove;
    }
        
}
