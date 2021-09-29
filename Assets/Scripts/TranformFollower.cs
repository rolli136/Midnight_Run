using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranformFollower : MonoBehaviour
{
    //[SerializeField]
    //private Transform target;
    //
    //[SerializeField]
    //private Vector3 offsetPosition;
    //
    //[SerializeField]
    //private Space offsetPositionSpace = Space.Self;
    //
    //[SerializeField]
    //private bool lookAt = true;
    //
    //private float speed = 0.4f;

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
      // target = GameObject.Find("Player").transform;
      // if (this.gameObject.CompareTag("Monster"))
      // {
      //     offsetPosition.x = Random.Range(-5f,5f);
      //     offsetPosition.y = 0;
      //     offsetPosition.z = Random.Range(-10f,-5f);
      // }
      // else if (this.gameObject.CompareTag("MainCamera"))
      // {
      //     offsetPosition.x = 0;
      //     offsetPosition.y = 5;
      //     offsetPosition.z = -12;
      // }
    }

    // Update is called once per frame
    void Update()
    {
        // Refresh();
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(target);
    }

    //{


}
   // public void Refresh()
   // {
   //     if (target == null)
   //     {
   //         Debug.LogWarning("Missing target ref !", this);
   //
   //         return;
   //     }
   //
   //
   //      //compute position
   //       if(offsetPositionSpace == Space.Self)
   //       {
   //           transform.position = target.TransformPoint(offsetPosition);
   //       }
   //       else
   //      {
   //          transform.position = target.position + offsetPosition;
   //      }
   //     //float interpolation = speed * Time.deltaTime;
   //     //Vector3 position = this.transform.position;
   //     ////Debug.Log("Tag: " + tempTag);
   //     ////Debug.Log("Position: " + position);
   //     ////Debug.Log("***********************");
   //     //position.x = Mathf.Lerp(this.transform.position.x, target.position.x, interpolation);
   //     //position.z = Mathf.Lerp(this.transform.position.z, target.position.z, interpolation);
   //     //this.transform.position = position;
   //
   //     // compute rotation
   //     if (lookAt)
   //     {
   //         transform.LookAt(target);
   //     }
   //     else
   //     {
   //         transform.rotation = target.rotation;
   //     }
   //  }
//}
