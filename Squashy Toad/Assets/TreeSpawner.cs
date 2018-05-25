using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    public GameObject treePrefabs;

    public int minTrees = 5;
    public int maxTrees = 15;

    // Use this for initialization
    void Start () {
        int treeNumber = Random.Range(minTrees, maxTrees);
        for (int currentTree = 0; currentTree < treeNumber; currentTree = currentTree + 1)
        {
            CreateTree();
        }
    }
    void CreateTree ()
    {
        var tree = Instantiate(treePrefabs);
        tree.transform.parent = transform;
        tree.transform.localPosition = new Vector3(Random.Range(-50,50), 0, Random.Range(-5,5));
    }


         // Update is called once per frame
    void Update()
    {
    }
}
