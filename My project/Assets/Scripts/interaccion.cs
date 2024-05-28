using UnityEngine;

public class JengaInteraction : MonoBehaviour
{
    private Camera cam;
    private GameObject selectedBlock;
    private Vector3 offset;
    private float zCoord;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Block"))
                {
                    selectedBlock = hit.transform.gameObject;
                    zCoord = cam.WorldToScreenPoint(selectedBlock.transform.position).z;
                    offset = selectedBlock.transform.position - GetMouseWorldPos();
                }
            }
        }

        // Añadir una condición para verificar si el cubo está siendo arrastrado
        if (Input.GetMouseButton(0) && selectedBlock != null && !Input.GetMouseButtonDown(0))
        {
            selectedBlock.transform.position = GetMouseWorldPos() + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedBlock = null;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}
