using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movementSpeed = 20f;
    //private float frontalSpeed = 6f;
    //public float sideSpeed = 1f;
    private float rotationSpeed = 20f;
    private float torque = 0.3f;

    //public GameObject wayPoint;
    //private float timer = 0.5f;
    //accessed by monster movement
    public Vector3 playerDirection = new Vector3(0,0,0);
    public Vector3 playerRotation = new Vector3(0, 0, 0);

    Rigidbody playerRigidbody;
    //Vector3 angleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovement();
        //PlayerRotation();

    }

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float s_Input = Input.GetAxis("Horizontal");
        float f_Input = Input.GetAxis("Vertical");
        //store Input as an angle
        //angleVelocity = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        //Debug.Log("Angle: " + angleVelocity);

        //Quaternion rotation = Quaternion.Euler(angleVelocity * Time.deltaTime);

        playerRigidbody.AddRelativeForce(transform.forward * f_Input * movementSpeed);

        playerRigidbody.AddRelativeForce(transform.right * s_Input * movementSpeed);

        float turn = Input.GetAxis("Mouse X");
        playerRigidbody.AddRelativeTorque(Vector3.up * torque * turn);

        //if(Input.GetAxis("Horizontal") > 0)
        //{
        //    playerRigidbody.AddRelativeForce(transform.right * movementSpeed);
        //}
        //else if(Input.GetAxis("Horizontal") < 0)
        //{
        //    playerRigidbody.AddRelativeForce(transform.left * movementSpeed);
        //}
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        //playerRigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * movementSpeed);
        //playerRigidbody.MoveRotation(playerRigidbody.rotation* rotation);
    }

    //Player movement control (for now also forward/backwards)

    //void PlayerMovement()
    //{
    //    //move left/right
    //    float sideSpeed = Input.GetAxis("Horizontal")* movementSpeed;
    //
    //    //move forward/backwards
    //    float forwardSpeed = Input.GetAxis("Vertical")* movementSpeed;
    //
    //    //playerDirection.Set(sideSpeed, 0, forwardSpeed);
    //    //transform.Translate(sideSpeed, 0, forwardSpeed);
    //    Rigidbody playerRigidbody = GetComponent<Rigidbody>();
    //    Vector3 position = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    playerRigidbody.MovePosition(transform.position + position * movementSpeed*Time.deltaTime);
    //    //Debug.Log("position X: " + position.x + " | " + "position Z: " + position.z);
    //    //Debug.Log("Insg position X: " + transform.position.x + " | " + "Insg position Z: " + transform.position.z);
    //} 

    //Rotating the Player (w. the mouse)
    void PlayerRotation()
    {
        //move left/right
        float h = rotationSpeed * Input.GetAxis("Mouse X")*Time.deltaTime ;
        //playerRotation.Set(0, h, 0);
        transform.Rotate(0, h, 0);
   
    }

   // void UpdatePosition()
   // {
   //     //The wayPoint's position will now be the player's current position.
   //     wayPoint.transform.position = transform.position;
   // }
}
