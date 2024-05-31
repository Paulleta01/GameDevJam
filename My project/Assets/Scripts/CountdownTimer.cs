using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // Importa el namespace de TextMesh Pro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10.0f; // Tiempo de cuenta regresiva
    public TextMeshProUGUI countdownText; // Referencia al componente de texto de TextMesh Pro
    public GameObject ground;
    public JengaInteraction jengaInteraction; // Referencia al script JengaInteraction
    public GameOverManager gameOverManager; // Referencia al script GameOverManager

    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("CountdownText no está asignado en el inspector.");
            return;
        }

        if (ground == null)
        {
            Debug.LogError("Ground no está asignado en el inspector.");
            return;
        }

        if (jengaInteraction == null)
        {
            Debug.LogError("JengaInteraction no está asignado en el inspector.");
            return;
        }

        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager no está asignado en el inspector.");
            return;
        }

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            countdownText.text = "Earthquake in: " + remainingTime.ToString("F1") + " seconds";
            yield return new WaitForSeconds(0.1f);
            remainingTime -= 0.1f;
        }

        ground.SetActive(false);

        // Desactivar la interacción con los objetos/Bloques
        jengaInteraction.enabled = false;

        countdownText.text = "<color=#FFE587>Earthquake!</color>";
        FindObjectOfType<Earthquake>().StartEarthquakeRoutine();

        yield return new WaitForSeconds(3.0f);

        // Reiniciar el nivel después del terremoto
        gameOverManager.ShowGameOver();
    }
}
