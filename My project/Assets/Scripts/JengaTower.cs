using UnityEngine;

public class JengaTower : MonoBehaviour
{
    public GameObject blockPrefab;
    public int layers = 18; // Número de capas en la torre
    public float blockLength = 3f;
    public float blockHeight = 1f;
    public float blockWidth = 10f;
    public float spacing = 0.1f; // Espacio entre bloques

    void Start()
    {
        BuildTower();
    }

    void BuildTower()
    {
        for (int i = 0; i < layers; i++)
        {
            float yOffset = i * (blockHeight + spacing);
            if (i % 2 == 0)
            {
                // Bloques horizontales
                for (int j = 0; j < 3; j++)
                {
                    Vector3 position = new Vector3(j * (blockLength + spacing), yOffset, 0);
                    Instantiate(blockPrefab, position, Quaternion.identity, transform);
                }
            }
            else
            {
                // Bloques verticales
                for (int j = 0; j < 3; j++)
                {
                    Vector3 position = new Vector3(0, yOffset, j * (blockLength + spacing));
                    Instantiate(blockPrefab, position, Quaternion.Euler(0, 90, 0), transform);
                }
            }
        }
    }
}
