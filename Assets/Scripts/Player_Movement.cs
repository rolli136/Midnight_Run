using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{

    //[HideInInspector]
    [SerializeField] GameManager gameManager;

    public CharacterController mCharacterController;
    public Animator mAnimator;

    public float mWalkSpeed = 15f;
    public float mRunSpeed = 20f;
    public float mRotationSpeed = 50.0f;
    public float mGravity = -30.0f;

    public bool mFollowCameraForward = false;
    public float mTurnRate = 20.0f;
    private Vector3 mVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    

    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float h = Input.GetAxis("Mouse X");

        float v = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");

        float speed = mWalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = mRunSpeed;
        }

        if (mFollowCameraForward)
        {
            // Only allow aligning of player's direction 
            // when there is a movement.
            if (v > 0.1 || v < -0.1 || h > 0.1 || h < -0.1 || s > 0.1 || s < -0.1)
            {
               // rotate player towards the camera forward.
              
                Vector3 eu = Camera.main.transform.rotation.eulerAngles;
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.Euler(0.0f, eu.y, 0.0f),
                    mTurnRate * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);

        }
        transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);
        mCharacterController.Move(transform.forward * v * speed * Time.deltaTime);
        mCharacterController.Move(transform.right * s * speed * Time.deltaTime);


        if (mAnimator != null)
        {
            mAnimator.SetFloat("PosZ", v * speed / mRunSpeed); 
            mAnimator.SetFloat("PosX", s * speed / mRunSpeed);
        }

        // apply gravity.
        mVelocity.y += mGravity * Time.deltaTime;
        mCharacterController.Move(mVelocity * Time.deltaTime);
       
        if (mCharacterController.isGrounded && mVelocity.y < 0)
            mVelocity.y = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Type: " + other.GetType());
        if (other.CompareTag("Coin"))
        {
            other.transform.position = new Vector3(Random.Range(-200f, 200f), 10, Random.Range(-200f, 200f));
            //Destroy(other.gameObject);
            gameManager.updateCoinCount();
        }
        else if (other.CompareTag("Pub"))
        {
             gameManager.LevelCompleted();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.GameOver();
    }
}
