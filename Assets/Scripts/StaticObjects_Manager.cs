using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjects_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pubPrefab;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate trees
        for (int i = 0; i < 20; i++)
        {
            Instantiate(treePrefab, new Vector3(Random.Range(-1700f, 1700f), 0f, Random.Range(-1000f, 1000f)), Quaternion.identity, this.transform);
        }

        //Instantiate obstacles
        for (int i = 0; i < 20; i++)
        {
            Instantiate(obstaclePrefab, new Vector3(Random.Range(-1700f, 1700f), 5f, Random.Range(-1000f, 1000f)), Quaternion.identity, this.transform);
        }

        //Instantiate Pub
        Instantiate(pubPrefab, new Vector3(0f, 40f, -1000f), Quaternion.identity, this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
