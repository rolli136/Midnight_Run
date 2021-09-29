using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField] private GameObject monsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate monsters
        for (int i = 0; i < 3; i++)
        {
            Vector3 startingPos = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
            Instantiate(monsterPrefab, startingPos, Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
