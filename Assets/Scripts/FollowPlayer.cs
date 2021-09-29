using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject objectToFollow;
    public float speed;
    private float tempTag;
    public Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = GameObject.Find("Player");
        target = objectToFollow.transform; 

        //set speed of object
        if (this.gameObject.CompareTag("Monster"))
        {
            speed = 0.7f;
            //tempTag = 1;


        }
        else if (this.gameObject.CompareTag("MainCamera"))
        {
            speed = 0.4f;
            //tempTag = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move towards the target 
        float interpolation = speed * Time.deltaTime;
        Vector3 position = this.transform.position;
        //Debug.Log("Tag: " + tempTag);
        //Debug.Log("Position: " + position);
        //Debug.Log("***********************");
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z, interpolation);
        this.transform.position = position;

        //Rotate towards the target
        transform.LookAt(objectToFollow.transform);
        //Vector3 relativePos = target.position - transform.position;
        //
        //// the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;

    }

}
