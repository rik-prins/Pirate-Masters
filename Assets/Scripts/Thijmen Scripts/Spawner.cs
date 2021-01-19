using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject boatObj;

    [SerializeField] private int spawnAmount = 3;
    [SerializeField] private float[] spawnMoment;
    int i;

    void Start()
    {
        spawnMoment = new float[spawnAmount];
        CalculateSpawnMoments();
    }

    public void CalculateSpawnMoments()
    {
        for (i = 0; i < spawnAmount; i++)
        {
            spawnMoment[i] = Random.Range(0, boat.distance);

            print(boat.distance);
            print(spawnMoment);
        }
    }

    void Update()
    {
        foreach (float moment in spawnMoment)
        {
            if (moment == boat.progress)
            {
              print("spawn");
            }
        }
    }
}
