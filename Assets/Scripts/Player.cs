using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
    private bool canonActive;

    private Vector3 velocity;
    private Vector3 camPos;

    private Rigidbody rb;

    public CinemachineVirtualCamera cam;

    public GameObject canonBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camPos = cam.transform.position;
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

        if (canonActive)
        {
            cam.LookAt = null;
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 0.1f), 10f * Time.deltaTime);
            if (Vector3.Distance(cam.transform.position, transform.position) <= 2)
            {
                cam.transform.position = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
                cam.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            cam.LookAt = this.transform;
            //cam.transform.position = camPos;
            cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, 10f * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (!canonActive)
        {
            rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!canonActive)
                {
                    canonActive = true;
                }
                else
                {
                    canonActive = false;
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (canonActive)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                other.gameObject.transform.LookAt(ray.GetPoint(100f));
                //cam.LookAt = null;
                //cam.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

                if (Input.GetMouseButtonUp(0))
                {
                    Instantiate(canonBall, other.gameObject.transform.position, other.gameObject.transform.rotation);
                }
            }
        }
    }
}