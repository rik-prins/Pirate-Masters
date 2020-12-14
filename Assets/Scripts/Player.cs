using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 7.5f;
    public float smoothMoveTime = 0.1f;
    public float turnSpeed = 8;

    private float angle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;

    private Vector3 velocity;

    private Rigidbody rb;

    public GameObject canonBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 _inputDirection = Vector3.zero;
        _inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        float _inputMagnitude = _inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, _inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float _targetAngle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, _targetAngle, Time.deltaTime * turnSpeed * _inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ |
                             RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezeRotationX |
                             RigidbodyConstraints.FreezeRotationY |
                             RigidbodyConstraints.FreezeRotationZ;
        }
        else
            rb.constraints = RigidbodyConstraints.None;

        if (Input.GetKey(KeyCode.R))
        {
            Scrubbing();
        }
        else
        {
            moveSpeed = 7.5f;
        }
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void Scrubbing()
    {
        if (Boat.Instance.win == false)
        {
            Boat.Instance.score += 1;
            moveSpeed = 0.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sea"))
        {
            Boat.Instance.deaths += 1;
            transform.position = new Vector3(0, 6, 24);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Canon"))
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("Shoot!");
                Instantiate(canonBall, other.gameObject.transform.position, other.gameObject.transform.rotation);
            }
        }
    }
}