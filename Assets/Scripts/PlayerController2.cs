using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;
    
    private float horizontalInput;
    private float forwardInput;
    private float horizontalArrowInput;
    private float verticalArrowInput;

    private bool isMoving = false;

    public Button moveButton;

   public void Start()
    {
        moveButton.onClick.AddListener(StartMoving);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
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

    public void StartMoving()
    {
        isMoving = true;
    }
}
