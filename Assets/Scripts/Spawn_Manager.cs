using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate monsters
        for (int i = 0; i < 5; i++)
        {
            Vector3 startingPos = new Vector3(Random.Range(-200f, 200f), 1.5f, Random.Range(-200f, 200f));
            Instantiate(monsterPrefab, startingPos, Quaternion.identity, this.transform);
        }

        for (int i = 0; i < 5; i++)
        {
            Vector3 startingPos = new Vector3(Random.Range(-200f, 200f), 10f, Random.Range(-200f, 200f));
            Instantiate(coinPrefab, startingPos, Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
