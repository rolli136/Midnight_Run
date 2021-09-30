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
            Instantiate(treePrefab, new Vector3(Random.Range(-170f, 170f), 10f, Random.Range(-170f, 170f)), Quaternion.identity, this.transform);
        }

        //Instantiate obstacles
        for (int i = 0; i < 20; i++)
        {
            Instantiate(obstaclePrefab, new Vector3(Random.Range(-170f, 170f), 5f, Random.Range(-170f, 170f)), Quaternion.identity, this.transform);
        }

        //Instantiate Pub
        Instantiate(pubPrefab, new Vector3(Random.Range(-170f, 170f), 13f, Random.Range(-170f, 170f)), Quaternion.identity, this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
