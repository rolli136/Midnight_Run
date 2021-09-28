using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movementSpeed = 0.01f;
    private float offSetRed = 0.01f;
    private float offSetLimit = 0.5f;
    private Vector3 monsterOffset;
    //private float monsterMovementFlag = 100f;
    //private float monsterSlowDown = 1f;

    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //movementSpeed = Random.Range(0.1f, 0.3f);
        player = GameObject.Find("Player");
        monsterOffset = new Vector3(Random.Range(0f, 5f), 0, Random.Range(0f, 5f));

    }

    // Update is called once per frame
    void Update()
    {
      //  if(monsterSlowDown % monsterMovementFlag == 0)
      //  {
            monsterMovement();
     //       Debug.Log("monsterSlowDown: " + monsterSlowDown);
     //       Debug.Log("monsterMovementFlag: " + monsterMovementFlag);
     //   }
     //   else
     //   {
     //       monsterSlowDown += 1;
     //   }

    }

    //void monsterMovement()
    //{
    //    monsterDirection = player.GetComponent<Player>().playerDirection;
    //    monsterRotation = player.GetComponent<Player>().playerRotation;
    //
    //    this.transform.Translate(monsterDirection*movementSpeed);
    //    this.transform.Rotate(monsterRotation);
    //
    //}
    void monsterMovement()
    {
        Transform playerTransform = player.transform;
        Vector3 playerPosition = playerTransform.position;


        Vector3 monsterPosition = this.transform.position;

        Vector3 monsterDirection = (playerPosition - monsterPosition) * movementSpeed;
        Vector3 newMonsterPosition = monsterPosition + monsterDirection + monsterOffset;

        //monsterDirection = player.GetComponent<Player>().playerDirection;
        //monsterRotation = player.GetComponent<Player>().playerRotation;

        this.transform.SetPositionAndRotation(newMonsterPosition, Quaternion.identity);

            // monsterOffset.x -= offSetRed;
            // monsterOffset.y -= offSetRed;
            //monsterOffset.x /= offSetRed;
            //monsterOffset.z /= offSetRed;
            //Debug.Log("monsterOffset:" + monsterOffset);
            //


        if(monsterOffset.x > offSetLimit && monsterOffset.z > offSetLimit)
        {
             monsterOffset.x -= offSetRed;
             monsterOffset.z -= offSetRed;

            Debug.Log("monsterOffset:" + monsterOffset);
        }
        else if(monsterOffset.x > offSetLimit && monsterOffset.z <= offSetLimit)
        {
            monsterOffset.x -= offSetRed;
        }
        else if (monsterOffset.z > offSetLimit && monsterOffset.x <= offSetLimit)
        {
            monsterOffset.z -= offSetRed;
        }
        else
        {
        
        }
        //if(movementSpeed <= 1.5)
        //movementSpeed += 0.01f;
        //this.transform.Rotate(monsterRotation);    
    }
}
