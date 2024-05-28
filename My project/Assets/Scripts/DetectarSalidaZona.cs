using UnityEngine;

public class DetectarSalidaZona : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block")) // Cambiado de "Player" a "Block"
        {
            if (gameObject.CompareTag("ZonaSegura")) // Ajusta el tag de la zona segura
            {
                // Lógica para cuando el bloque entra en la zona segura
                Debug.Log("El bloque ha entrado en una zona segura.");
            }
            else if (gameObject.CompareTag("ZonaNoSegura")) // Ajusta el tag de la zona no segura
            {
                // Lógica para cuando el bloque entra en la zona no segura
                Debug.Log("¡El bloque ha entrado en una zona no segura! ¡El jugador ha perdido!");
                // Implementa la lógica para que el jugador pierda
            }
        }
    }
}
