using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //serializedFields
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float turnSpeed = 25.0f;

    //private vars
    private float horizontalInput;
    private float verticalInput;

    //public vars

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void driveCar()
    {
        // get input
        getInput();

        // move vehicle
        Move();
    }

    private void getInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        if(IsOnGround())
        {
            // move car FWD
            playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput);

            //rotate car
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    bool IsOnGround()
    {
        return true;
    }
}
