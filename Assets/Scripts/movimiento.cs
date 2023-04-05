using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 20.0f;
    public float acceleration = 10.0f;
    public float braking = 20.0f;
    public float turnSpeed = 75.0f;
    public float maxTurnSpeed = 5.0f;

    private float horizontalInput;
    private float forwardInput;

    private bool isMoving = false;

    public Button moveButton;

    public void Start()
    {
        moveButton.onClick.AddListener(StartMoving);
    }

    public void Update()
    {
        if (isMoving)
        {
            horizontalInput = Input.GetAxis("HorizontalArrow");
            forwardInput = Input.GetAxis("VerticalArrow");

            float speed = Mathf.Clamp(GetComponent<Rigidbody>().velocity.magnitude, 0.0f, maxSpeed);

            if (forwardInput > 0.0f)
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * acceleration * Time.deltaTime);
            }
            else if (forwardInput < 0.0f)
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * braking * Time.deltaTime);
            }
            else
            {
                GetComponent<Rigidbody>().velocity *= 0.95f;
            }

            transform.Rotate(Vector3.up, Mathf.Clamp(horizontalInput, -1.0f, 1.0f) * turnSpeed * Mathf.Lerp(1.0f, maxTurnSpeed, speed / maxSpeed) * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
