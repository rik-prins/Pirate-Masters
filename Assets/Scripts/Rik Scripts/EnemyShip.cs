using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject Canonball;
    private int activeCanon;

    private void Start()
    {
        StartCoroutine(ShootCanon());
    }

    private void Update()
    {
        if (activeCanon > 3)
        {
            activeCanon = 0;
        }
    }

    private IEnumerator ShootCanon()
    {
        while (true)
        {
            if (!GetComponent<Animation>().isPlaying)
            {
                transform.GetChild(activeCanon).transform.rotation = Quaternion.Euler(Random.Range(-10, 0), 180, 0);
                Instantiate(Canonball, transform.GetChild(activeCanon).transform.position, transform.GetChild(activeCanon).transform.rotation);
                activeCanon += 1;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}