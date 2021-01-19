using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject boatObj;

    [SerializeField] private int spawnAmount = 3;
    [SerializeField] private float[] spawnMoment;

    private void Start()
    {
        spawnMoment = new float[spawnAmount];
        CalculateSpawnMoments();
    }

    public void CalculateSpawnMoments()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            spawnMoment[i] = Random.Range(0, boat.distance);

            print(boat.distance);
            print(spawnMoment);
        }
    }

    private void Update()
    {
        foreach (float moment in spawnMoment)
        {
            if (Mathf.Abs(moment - boat.progress) <= 0.0001f)
            {
                print("spawn");
            }
        }
    }
}