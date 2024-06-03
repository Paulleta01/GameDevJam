using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI; // Importa el namespace para UI

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10.0f; // Tiempo de cuenta regresiva
    public TextMeshProUGUI countdownText; // Referencia al componente de texto de TextMesh Pro
    public TextMeshProUGUI levelText; // Referencia al texto del nivel
    public GameObject ground;
    public JengaInteraction jengaInteraction; // Referencia al script JengaInteraction
    public Earthquake earthquake; // Referencia al script Earthquake
    public GameObject biscuitPrefab; // Prefab del objeto que debe aparecer en el nivel 2
    public GameObject gameOverScreen; // Pantalla de Game Over
    public Image imageToHide; // Referencia a la imagen que se debe ocultar

    private int currentLevel = 1; // Nivel actual
    private bool isGameOver = false; // Indicador de estado de juego terminado

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

        if (earthquake == null)
        {
            Debug.LogError("Earthquake no está asignado en el inspector.");
            return;
        }

        if (levelText == null)
        {
            Debug.LogError("LevelText no está asignado en el inspector.");
            return;
        }

        if (biscuitPrefab == null)
        {
            Debug.LogError("BiscuitPrefab no está asignado en el inspector.");
            return;
        }

        if (gameOverScreen == null)
        {
            Debug.LogError("GameOverScreen no está asignado en el inspector.");
            return;
        }

        if (imageToHide == null)
        {
            Debug.LogError("ImageToHide no está asignado en el inspector.");
            return;
        }

        UpdateLevelText();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (!isGameOver)
        {
            float remainingTime = countdownTime;

            while (remainingTime > 0 && !isGameOver)
            {
                countdownText.text = "Earthquake in: " + remainingTime.ToString("F1") + " seconds";
                yield return new WaitForSeconds(0.1f);
                remainingTime -= 0.1f;
            }

            if (isGameOver) yield break;

            ground.SetActive(false);

            // Desactivar la interacción con los objetos/Bloques
            jengaInteraction.enabled = false;

            countdownText.text = "<color=#FFE587>Earthquake!</color>";
            yield return StartCoroutine(earthquake.StartEarthquakeRoutine());

            countdownText.text = "<color=#FFE587>Get ready for the next round!</color>";
            yield return new WaitForSeconds(3.0f);

            // Preparar el siguiente nivel
            PrepareNextLevel();
        }
    }

    private void PrepareNextLevel()
    {
        Debug.Log("Preparando el siguiente nivel...");

        // Incrementar la magnitud del terremoto para el siguiente nivel, pero no exceder 0.4
        if (earthquake.magnitude < 0.4f)
        {
            earthquake.magnitude += 0.1f;
            if (earthquake.magnitude > 0.4f)
            {
                earthquake.magnitude = 0.4f;
            }
        }

        // Reiniciar la posición del suelo y activarlo
        ground.SetActive(true);

        // Reactivar la interacción con los objetos/Bloques
        jengaInteraction.enabled = true;

        // Reiniciar la posición de los bloques
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        Debug.Log("Número de bloques encontrados: " + blocks.Length);
        foreach (GameObject block in blocks)
        {
            Block blockComponent = block.GetComponent<Block>();
            if (blockComponent != null)
            {
                block.transform.position = blockComponent.initialPosition;
                Debug.Log("Posición del bloque reiniciada: " + block.name);
            }
            else
            {
                Debug.LogError("El bloque no tiene el componente Block: " + block.name);
            }
        }

        // Incrementar el nivel
        currentLevel++;
        UpdateLevelText();

        // Mostrar el objeto Biscuit (1) a partir del nivel 2
        if (currentLevel >= 2)
        {
            Vector3 biscuitPosition = new Vector3(-5.927f, -0.2422f, -2f); // Coordenadas específicas
            GameObject biscuitInstance = Instantiate(biscuitPrefab, biscuitPosition, Quaternion.identity);
            biscuitInstance.SetActive(true); // Asegúrate de que el objeto esté activo
            Debug.Log("Biscuit (1) instanciado en el nivel " + currentLevel + ".");
        }
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel;
    }

    public void GameOver()
    {
        isGameOver = true;
        countdownText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);
        imageToHide.gameObject.SetActive(false); // Ocultar la imagen
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
