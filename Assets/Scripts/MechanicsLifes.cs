using UnityEngine;
using TMPro;

public class MechanicsLifes : MonoBehaviour
{
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI lostText;
    public Chronometer chronometer;
    public int lives = 3;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !hasCollided)
        {
            lives--;
            hasCollided = true;
            liveText.text = "Lives: " + lives;
            if (lives == 0)
            {
                // El jugador ha perdido
                lostText.text = "Game Over";
                Time.timeScale = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("salio");
            hasCollided = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            // Detiene el cronómetro
            chronometer.EndChronometer();
            Time.timeScale = 0;
        }
    }

    void Start()
    {
        liveText.text = "Lives: " + lives;
    }
}
