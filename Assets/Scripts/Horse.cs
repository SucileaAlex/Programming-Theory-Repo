using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Horse : Animal
{
    public Transform[] waypoints;

    private int waypointIndex;
    private float distance;
    private int speed = 4;

    private Rigidbody horseRb;

    // Start is called before the first frame update
    void Start()
    {
        horseRb = GetComponent<Rigidbody>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorse();
    }

    protected override void Move(int speed)
    {
        horseRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    private void MoveHorse()
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
