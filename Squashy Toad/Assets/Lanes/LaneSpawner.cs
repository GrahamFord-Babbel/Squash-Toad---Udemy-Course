using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LaneType {  Safe, Danger};

public class LaneSpawner : MonoBehaviour {

    public GameObject[] safeLanePrefabs;
    public GameObject[] dangerousLanePrefabs;
    LaneType lastLaneType = LaneType.Safe;
    public float safeLaneRunPossibility = 0.2f;
    public float laneSpawnDistance = 5000;
    public GameObject player;

    int offset = 0;

	// Use this for initialization
	void Update () {
        while (offset < laneSpawnDistance + player.transform.position.z)
        {
            CreateRandomLane(offset);
            offset += 1000;
        }

        foreach(Transform laneTransform in this.transform)
        {
            if (laneTransform.position.z + laneSpawnDistance < player.transform.position.z)
            {
                print(laneTransform);
                Destroy(laneTransform.gameObject);
            }
        }
   
    }

    void CreateRandomLane(float offset)
    {
        GameObject lane;
        if (lastLaneType == LaneType.Safe)
        {
            if (Random.value < safeLaneRunPossibility)
            {
                lane = InstantiateRandomLane(safeLanePrefabs);
                lastLaneType = LaneType.Safe;
            }
            else
            {
                lane = InstantiateRandomLane(dangerousLanePrefabs);
                lastLaneType = LaneType.Danger;
            }
        }
        else
        {
            lane = InstantiateRandomLane(safeLanePrefabs);
            lastLaneType = LaneType.Safe;
        }
        lane.transform.SetParent(transform, false);
        lane.transform.Translate(0, 0, offset);
    }

    GameObject InstantiateRandomLane(GameObject[] lanes)
    {
        int laneIndex = Random.Range(0, lanes.Length);
        return Instantiate(lanes[laneIndex]);
    }
	
}
