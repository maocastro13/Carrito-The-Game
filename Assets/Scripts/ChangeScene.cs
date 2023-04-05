using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Nombre de la escena a la que queremos cambiar
    public string sceneName;

    // Método para cambiar de escena al hacer clic en el botón
    public void ChangeToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
