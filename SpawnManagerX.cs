using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabsEasy;
    public GameObject[] objectPrefabsHard;
    private float spawnDelay = 2;
    private float spawnIntervalEasy = 1.5f;
    private float spawnIntervalHard = 0.75f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnIntervalEasy);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        //if(gamemode == true) {
            // Set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
            int index = Random.Range(0, objectPrefabsEasy.Length);

            // If game is still active, spawn new object
            if (playerControllerScript.gameOver == false)
            {
                Instantiate(objectPrefabsEasy[index], spawnLocation, objectPrefabsEasy[index].transform.rotation);
            }

        //}
        
    }
}
