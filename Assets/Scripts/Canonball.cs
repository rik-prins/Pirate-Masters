using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonball : MonoBehaviour
{
    //private void Start()
    //{
    //    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2000);
    //    Destroy(gameObject, 4);
    //}

    //private void Update()
    //{
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Destroy(gameObject);
    //}

    public LayerMask collisionMask;

    private float speed = 100;
    private float damage = 1;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    private void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    private void OnHitObject(RaycastHit hit)
    {
        //IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        //if (damageableObject != null)
        //{
        //    damageableObject.TakeHit(damage, hit);
        //}
        Destroy(gameObject);
    }
}