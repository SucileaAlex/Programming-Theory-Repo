using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public Transform[] waypoints;

    private int waypointIndex;
    private float distance;
    private int speed = 4;

    private Rigidbody dogRb;

    // Start is called before the first frame update
    void Start()
    {
        dogRb = GetComponent<Rigidbody>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDog();
    }

    protected override void Move(int speed)
    {
        dogRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    private void MoveDog()
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
