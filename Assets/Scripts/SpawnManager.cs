using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _leftTurnRoadPrefab;
    [SerializeField] private GameObject _rightTurnRoadPrefab;
    [SerializeField] private GameObject _straightRoadForestPrefab;
    [SerializeField] private GameObject _straightRoadForestGraveyardPrefab;
    [SerializeField] private GameObject _straightRoadPubPrefab;
    [SerializeField] private GameObject _pubPrefab;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _monsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        generateMap(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateMap(int mapLength)
    {
        var mapParts = new List<MapPartInformation>();
        for (var i = 0; i < mapLength; i++)
        {
            Instantiate(_straightRoadForestPrefab, new Vector3(0, 0, i*200), Quaternion.identity, transform);
        }
    }

    void generateStaticObjects()
    {
        //Instantiate trees
        for (int i = 0; i < 20; i++)
        {
            Instantiate(_treePrefab, new Vector3(Random.Range(-1700f, 1700f), 0f, Random.Range(-1000f, 1000f)), Quaternion.identity, this.transform);
        }

        //Instantiate obstacles
        for (int i = 0; i < 20; i++)
        {
            Instantiate(_obstaclePrefab, new Vector3(Random.Range(-1700f, 1700f), 5f, Random.Range(-1000f, 1000f)), Quaternion.identity, this.transform);
        }

        //Instantiate Pub
        Instantiate(_pubPrefab, new Vector3(Random.Range(-2500f, 3800f), 40f, Random.Range(-5000f, 2800f)), Quaternion.identity, this.transform);
    }

    void generateMonsters()
    {
        //Instantiate monsters
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_monsterPrefab, new Vector3(Random.Range(-100f, 100f), 20f, Random.Range(-150f, -50f)), Quaternion.identity, this.transform);
        }
    }
}

public enum RoadDirection
{
    Left = -1,
    Straight = 0,
    Right = 1
}

public enum RoadType
{
    LeftTurn = -1,
    Straight = 0,
    RightTurn = 1,
    RoadEnd = 2
}

public class MapPartInformation
{
    public GameObject MapPart { get; set; }
    public float xStart { get; set; }
    public float zStart { get; set; }
    public float xEnd { get; set; }
    public float zEnd { get; set; }
    public int MyProperty { get; set; }
    public RoadDirection Direction { get; set; }
    public RoadType Type { get; set; }
}