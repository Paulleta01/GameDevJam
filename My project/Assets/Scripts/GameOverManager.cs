using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Referencia al panel de Game Over

    void Start()
    {
        if (gameOverPanel == null)
        {
            Debug.LogError("GameOverPanel no está asignado en el inspector.");
            return;
        }

        gameOverPanel.SetActive(false); // Asegúrate de que el panel esté oculto al inicio
    }

    public void ShowGameOver()
    {
        // Mostrar la pantalla de Game Over
        gameOverPanel.SetActive(true);
        Debug.Log("Mostrar pantalla de Game Over");
        
        // Reiniciar el nivel después de 3 segundos
        StartCoroutine(RestartLevelAfterDelay(3f));
    }

    private IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
