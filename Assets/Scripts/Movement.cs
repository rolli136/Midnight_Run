using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movementSpeed;
    private Vector3 monsterDirection;
    private Vector3 monsterRotation;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(0.8f, 1.0f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        monsterMovement();
    }

    void monsterMovement()
    {
        monsterDirection = player.GetComponent<Player>().playerDirection;
        monsterRotation = player.GetComponent<Player>().playerRotation;

        this.transform.Translate(monsterDirection*movementSpeed);
        this.transform.Rotate(monsterRotation);

    }
}
