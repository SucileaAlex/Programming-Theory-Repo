using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
 
    //POLYMORPHISM
    protected abstract void Move(int speed);

     protected virtual void IncreaseIndex(int waypointIndex , Transform[] waypoints)
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

}
