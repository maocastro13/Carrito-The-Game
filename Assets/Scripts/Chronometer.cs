using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chronometer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject player;
    private float startTime;
    private bool isChronometerRunning = false;

    void Start()
    {
        Button button = GetComponentInChildren<Button>();
        button.onClick.AddListener(StartChronometer);
        ResetChronometer();
    }

    void Update()
    {
        if (isChronometerRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    void StartChronometer()
    {
        isChronometerRunning = true;
        startTime = Time.time;
        GetComponentInChildren<Button>().gameObject.SetActive(false);
    }

    public void EndChronometer()
    {
        isChronometerRunning = false;
    }

    void ResetChronometer()
    {
        isChronometerRunning = false;
        startTime = 0.0f;
        UpdateTimerText(0.0f);
    }

    void UpdateTimerText(float elapsedTime)
    {
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00.00");
        timerText.text = "Time: " + minutes + ":" + seconds;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha chocado con el colisionador del fin de la carrera
        if (other.gameObject == player && other.CompareTag("EndTrigger"))
        {
            // Detiene el cronómetro
            EndChronometer();
        }
    }
}

