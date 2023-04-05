using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // el objetivo a seguir (el vehículo)
    public float smoothSpeed = 0.125f; // la velocidad de seguimiento
    private Vector3 offset = new Vector3(0f, 4.0f, 6.0f); // el desplazamiento de la cámara con respecto al objetivo, valor predeterminado igual al input 1

    public GameObject objeto1; // objeto que será visible al inicio del juego
    public GameObject objeto2; // objeto que será invisible al inicio del juego
    public GameObject objeto3; // objeto que será invisible al inicio del juego

    private Vector3 defaultOffset; // variable para almacenar el valor predeterminado de offset
    private float turnSpeed = 10f; // la velocidad de giro de la cámara

    private Quaternion desiredRotation;
    private Quaternion smoothedRotation;

    void Start()
    {
        defaultOffset = offset; // almacena el valor predeterminado de offset

        // Hace visible el objeto1 y oculta el objeto2 y objeto3 al inicio del juego
        objeto1.SetActive(true);
        objeto2.SetActive(false);
        objeto3.SetActive(false);
    }

    void LateUpdate()
    {
        // Verifica si se ha presionado el Input 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            offset = defaultOffset; // restaura el valor predeterminado de offset
        }

        // Verifica si se ha presionado el Input 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Hace visible el objeto2 y oculta el objeto1 y objeto3
            objeto2.SetActive(true);
            objeto3.SetActive(false);
            objeto1.SetActive(false);

            offset = new Vector3(0f, 3f, -10f); // cambia el valor de offset según el input
        }

        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.TransformPoint(offset); // convierte la posición local de offset en una posición global
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // interpola suavemente la posición actual de la cámara hacia la posición deseada
        transform.position = smoothedPosition; // actualiza la posición de la cámara

        // Calcula la rotación deseada de la cámara
        desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);

        transform.rotation = smoothedRotation; // actualiza la rotación de la cámara
    }
}
