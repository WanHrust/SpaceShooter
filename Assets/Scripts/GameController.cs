using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValue;

    void Start()
    {
        SpawnWaves();
    }
    void SpawnWaves()
    {
        Quaternion spawnRotation = new Quaternion.identity (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
        Vector3 spawnPosition = new Vector3 ();
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}
