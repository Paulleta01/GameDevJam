using UnityEngine;

public class DangerZone : MonoBehaviour
{
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
        // Aquí puedes agregar la lógica para finalizar el juego, como reiniciar el nivel
        // o mostrar una pantalla de Game Over.
    }
}
