using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public interface IDamagable
    {
        void TakeHit(float damage, RaycastHit hit);
    }
}
