using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importa el namespace de TextMesh Pro
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Referencia al panel de Game Over
    public TextMeshProUGUI countdownText; // Referencia al componente de texto de cuenta regresiva
    public TextMeshProUGUI levelText; // Referencia al componente de texto del nivel

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
        // Ocultar los textos del contador y del nivel
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
        }
        if (levelText != null)
        {
            levelText.gameObject.SetActive(false);
        }

        // Mostrar la pantalla de Game Over
        gameOverPanel.SetActive(true);
        Debug.Log("Mostrar pantalla de Game Over");

        // Pausar el juego
        Time.timeScale = 0;

        // Reiniciar el nivel después de 3 segundos
        StartCoroutine(RestartLevelAfterDelay(3f));
    }

    private IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Esperar en tiempo real, no en tiempo del juego
        Time.timeScale = 1; // Restaurar el tiempo del juego antes de recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
