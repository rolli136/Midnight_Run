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
            Instantiate(monsterPrefab, new Vector3(Random.Range(-100f, 100f), 20f, Random.Range(-150f, -50f)), Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
