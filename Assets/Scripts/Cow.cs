using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Cow : Animal
{
    public Transform[] waypoints;

    private int waypointIndex;
    private float distance;
    private int speed = 7;

    private Rigidbody cowRb;

    // Start is called before the first frame update
    void Start()
    {
        cowRb = GetComponent<Rigidbody>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCow();
    }

    protected override void Move(int speed)
    {
        cowRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    //ABSTRACTION
    private void MoveCow()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distance < 6f)
        {
            IncreaseIndex();
        }
        Move(speed);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
