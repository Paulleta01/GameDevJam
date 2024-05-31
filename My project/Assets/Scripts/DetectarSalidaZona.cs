using UnityEngine;

public class DetectarSalidaZona : MonoBehaviour
{
    private GameOverManager gameOverManager;

    private void Start()
    {
        // Buscar el GameOverManager en la escena
        gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager no está asignado en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Debug.Log("¡Has perdido! Un bloque ha entrado en la zona no segura.");
            Perder();
        }
    }

    private void Perder()
    {
        Debug.Log("Juego Terminado");
        // Mostrar la pantalla de Game Over y finalizar el juego
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
        else
        {
            Debug.LogError("No se encontró el GameOverManager.");
        }
    }
}