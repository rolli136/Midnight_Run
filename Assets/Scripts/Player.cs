using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movementSpeed = 10f;
    private float frontalSpeed = 20f;
    //public float sideSpeed = 1f;
    private float rotationSpeed = 0.5f;
    
    //accessed by monster movement
    public Vector3 playerDirection = new Vector3(0,0,0);
    public Vector3 playerRotation = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }


    //Player movement control (for now also forward/backwards)
    void PlayerMovement()
    {
        //move left/right
        float sideSpeed = Input.GetAxis("Horizontal")* movementSpeed;

        //move forward/backwards
        float forwardSpeed = Input.GetAxis("Vertical")* frontalSpeed ;

        playerDirection.Set(sideSpeed, 0, forwardSpeed);
        transform.Translate(sideSpeed, 0, forwardSpeed);
    } 

    //Rotating the Player (w. the mouse)
    void PlayerRotation()
    {
        //move left/right
        float h = rotationSpeed * Input.GetAxis("Mouse X");
        playerRotation.Set(0, h, 0);
        transform.Rotate(0, h, 0);

    } 
}
