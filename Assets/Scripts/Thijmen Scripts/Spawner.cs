using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject boatObj;

    [SerializeField] private int spawnAmount = 3;
    private float spawninterval;
    private float Spawnpoint;
    private float Randomspawnpoint;

    private void Start()
    {
        Spawnpoint = (boat.distance / 3);
        spawninterval = (boat.distance / 3);

        Randomspawnpoint = Random.Range(Spawnpoint - 1, Spawnpoint + 1);

        print(Randomspawnpoint);
    }

    
    private void Update()
    {
        CalculateSpawnpoint();
    }

    private void CalculateSpawnpoint()
    {
        if (Mathf.Abs(Randomspawnpoint - boat.progress) <= 0.001f)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(boatObj, transform.position, Quaternion.identity);
        Spawnpoint += spawninterval;
        print(Spawnpoint);
        Randomspawnpoint = Random.Range(Spawnpoint - 1f, Spawnpoint);
        print(Randomspawnpoint);
    }

    public void MakeRandomPoints()
    {
        Spawnpoint = (boat.distance / 3);
        spawninterval = (boat.distance / 3);
    }
}