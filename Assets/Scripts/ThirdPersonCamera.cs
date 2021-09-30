using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mPlayer;

    public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
    public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
    [Tooltip("The damping factor to smooth the changes " +
      "in position and rotation of the camera.")]
    public float mDamping = 1.0f;

    void Start()
    {
    }

    void Update()
    {
    }

    void LateUpdate()
    {
        CameraMove_Follow(true);
    }

    void CameraMove_Follow(bool allowRotationTracking = false)
    {
        //apply the initial rotation to the camera.
        Quaternion initialRotation = Quaternion.Euler(mAngleOffset);

        // allow rotation tracking of the player
        // so that our camera rotates when the player rotates and at the same
        // time maintain the initial rotation offset.
        if (allowRotationTracking)
        {
            Quaternion rot = Quaternion.Lerp(transform.rotation,
                mPlayer.rotation * initialRotation,
                Time.deltaTime * mDamping);

            transform.rotation = rot;
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(
              transform.rotation,
              initialRotation,
              mDamping * Time.deltaTime);
        }

        //calculate the camera transformed axes.
        Vector3 forward = transform.rotation * Vector3.forward;
        Vector3 right = transform.rotation * Vector3.right;
        Vector3 up = transform.rotation * Vector3.up;

        //calculate the offset in the 
        // camera's coordinate frame.
        Vector3 targetPos = mPlayer.position;
        Vector3 desiredPosition = targetPos
            + forward * mPositionOffset.z
            + right * mPositionOffset.x
            + up * mPositionOffset.y;

        // change the position of the camera, 
        // not directly, but by applying Lerp.
        Vector3 position = Vector3.Lerp(transform.position,
            desiredPosition,
            Time.deltaTime * mDamping);

        transform.position = position;
    }
}