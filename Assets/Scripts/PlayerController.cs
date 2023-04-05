using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;
    
    private float horizontalInput;
    private float forwardInput;
    private float horizontalArrowInput;
    private float verticalArrowInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        horizontalArrowInput = Input.GetAxis("HorizontalArrow");
        verticalArrowInput = Input.GetAxis("VerticalArrow");

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * (forwardInput + verticalArrowInput));
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * (horizontalInput + horizontalArrowInput) * Time.deltaTime);
    }
}
