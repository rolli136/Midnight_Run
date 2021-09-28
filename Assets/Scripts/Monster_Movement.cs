using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : MonoBehaviour
{
    private float movementSpeed = 0.01f;
    Vector3 newMonsterPosition;
    Vector3 monsterPosition;

    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
            monsterMovement();
    }


    void monsterMovement()
    {
        Transform playerTransform = player.transform;
        Vector3 playerPosition = playerTransform.position;

        monsterPosition = this.transform.position;
        Vector3 monsterDirection = (playerPosition - monsterPosition) * movementSpeed;
        newMonsterPosition = monsterPosition + monsterDirection;
        this.transform.SetPositionAndRotation(newMonsterPosition, Quaternion.identity);

  
    }

    //private void OnCollisionEnter(Collision collision) //if the ship hits something, do something
    //{
    //    
    //    Debug.Log("On Trigger Enter");
    //    //If the player has been hit, substract some of its lives. The amount is defined by _damage
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //
    //    }
    //    //If Two Monsters 
    //    if (collision.collider.CompareTag("Monster"))
    //    {
    //        this.transform.SetPositionAndRotation(monsterPosition, Quaternion.identity);
    //    }
    //
    //
    //}
}
