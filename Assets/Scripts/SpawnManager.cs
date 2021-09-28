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
        generateMap(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateMap(int mapLength)
    {
        var mapPartPrefabs = new GameObject[]
        {
            _leftTurnRoadPrefab,
            _straightRoadForestPrefab,
            _straightRoadForestGraveyardPrefab,
            _rightTurnRoadPrefab
        };
        var mapParts = new List<MapPartInformation>
        {
            new MapPartInformation
            {
                MapPart = mapPartPrefabs[1],
                xStart = 0,
                zStart = 0,
                xCenter = -50,
                zCenter = 0,
                xEnd = -50,
                zEnd = 100,
                Direction = Direction.Straight,
                Type = RoadType.Straight
            } 
        };
        for (var i = 1; i < mapLength; i++)
        {
            var mapChooseIndex = Random.Range(0, 4);
            var roadType = mapChooseIndex == 0 ? RoadType.LeftTurn : (mapChooseIndex == 3 ? RoadType.RightTurn : RoadType.Straight);
            var mapPartsCount = mapParts.Count;
            var lastMapPartInfo = mapParts[mapPartsCount - 1];
            if((lastMapPartInfo.Direction == Direction.Left && roadType == RoadType.LeftTurn) || (lastMapPartInfo.Direction == Direction.Right && roadType == RoadType.RightTurn))
            {
                i--;
                continue;
            }
            Direction newDirection = Direction.Straight;
            var xStart = 0f;
            var zStart = 0f;
            var xCenter = 0f;
            var zCenter = 0f;
            var xEnd = 0f;
            var zEnd = 0f;
            switch (lastMapPartInfo.Direction)
            {
                case Direction.Left:
                    xCenter = lastMapPartInfo.xCenter + 100;
                    zCenter = lastMapPartInfo.zCenter;
                    switch (roadType)
                    {
                        case RoadType.Straight:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd + 100;
                            zEnd = lastMapPartInfo.zEnd;
                            newDirection = Direction.Left;
                            break;
                        case RoadType.RightTurn:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd + 50;
                            zEnd = lastMapPartInfo.zEnd - 50;
                            newDirection = Direction.Straight;
                            break;
                    }
                    break;
                case Direction.Straight:
                    xCenter = lastMapPartInfo.xCenter;
                    zCenter = lastMapPartInfo.zCenter + 100;
                    switch (roadType)
                    {
                        case RoadType.LeftTurn:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd + 50;
                            zEnd = lastMapPartInfo.zEnd - 50;
                            newDirection = Direction.Left;
                            break;
                        case RoadType.Straight:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd;
                            zEnd = lastMapPartInfo.zEnd - 100;
                            newDirection = Direction.Straight;
                            break;
                        case RoadType.RightTurn:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd - 50;
                            zEnd = lastMapPartInfo.zEnd - 50;
                            newDirection = Direction.Right;
                            break;
                    }
                    break;
                case Direction.Right:
                    xCenter = lastMapPartInfo.xCenter - 100;
                    zCenter = lastMapPartInfo.zCenter;
                    switch (roadType)
                    {
                        case RoadType.LeftTurn:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd - 50;
                            zEnd = lastMapPartInfo.zEnd - 50;
                            newDirection = Direction.Straight;
                            break;
                        case RoadType.Straight:
                            xStart = lastMapPartInfo.xEnd;
                            zStart = lastMapPartInfo.zEnd;
                            xEnd = lastMapPartInfo.xEnd - 100;
                            zEnd = lastMapPartInfo.zEnd;
                            newDirection = Direction.Right;
                            break;
                    }
                    break;
            }
            mapParts.Add(new MapPartInformation
            {
                MapPart = mapPartPrefabs[mapChooseIndex],
                xStart = xStart,
                zStart = zStart,
                xCenter = xCenter,
                zCenter = zCenter,
                xEnd = xEnd,
                zEnd = zEnd,
                Direction = newDirection,
                Type = roadType
            });
        }
        var lastMapPartInfo2 = mapParts[mapParts.Count - 1];
        mapParts.Add(new MapPartInformation
        {
            MapPart = _straightRoadPubPrefab,
            xStart = lastMapPartInfo2.xEnd,
            zStart = lastMapPartInfo2.zEnd,
            xCenter = lastMapPartInfo2.xCenter + (lastMapPartInfo2.Direction == Direction.Left ? 100 : (lastMapPartInfo2.Direction == Direction.Right ? -100 : 0)),
            zCenter = lastMapPartInfo2.zCenter + (lastMapPartInfo2.Direction == Direction.Straight ? 100 : 0),
            xEnd = lastMapPartInfo2.xEnd + (lastMapPartInfo2.Direction == Direction.Left ? -50 : (lastMapPartInfo2.Direction == Direction.Right ? 50 : 0)),
            zEnd = lastMapPartInfo2.zEnd + (lastMapPartInfo2.Direction == Direction.Straight ? -50 : 0),
            Direction = lastMapPartInfo2.Direction,
            Type = RoadType.RoadEnd
        });

        foreach (var mapPart in mapParts)
        {
            Instantiate(mapPart.MapPart, new Vector3(mapPart.xCenter, 0, mapPart.zCenter), /*Quaternion.Euler(0f, mapPart.Direction == Direction.Left ? -90 : (mapPart.Direction == Direction.Right ? 90 : 0), 0f)*/Quaternion.identity, transform);
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

public enum Direction
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
    public float xCenter { get; set; }
    public float zCenter { get; set; }
    public float xEnd { get; set; }
    public float zEnd { get; set; }
    public Direction Direction { get; set; }
    public RoadType Type { get; set; }
}