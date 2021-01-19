using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Boat boat;
    [SerializeField] private GameObject boatObj;

    [SerializeField] private int spawnAmount = 3;
    [SerializeField] private float[] spawnMoment;
    private float spawninterval;
    private float Spawnpoint;
    private float Randomspawnpoint;

    private void Start()
    {
        spawnMoment = new float[spawnAmount];
        Spawnpoint = (boat.distance / 3);
        spawninterval = (boat.distance / 3);

        Randomspawnpoint = Random.Range(Spawnpoint - 1, Spawnpoint + 1);

        print(Randomspawnpoint);
        //CalculateSpawnMoments();
    }

    //public void CalculateSpawnMoments()
    //{
    //    for (int i = 0; i < spawnAmount; i++)
    //    {
    //        spawnMoment[i] = Random.Range(0, boat.distance);

    //        print(boat.distance);
    //        print(spawnMoment);
    //    }
    //}

    private void Update()
    {
        //foreach (float moment in spawnMoment)
        //{
        //    if (Mathf.Abs(moment - boat.progress) <= 0.0001f)
        //    {
        //        print("spawn");
        //    }
        //}

        SpawnNiggas();
    }

    private void SpawnNiggas()
    {
        if (Mathf.Abs(Randomspawnpoint - boat.progress) <= 0.001f)
        {
            //Spawn Boat
            SpawnRealNiggas();
        }
    }

    private void SpawnRealNiggas()
    {
        print("spawn");
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