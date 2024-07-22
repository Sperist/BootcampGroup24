using UnityEngine;

public class DragObject3D : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + offset;
            newPosition.z = transform.position.z; // Z ekseninde hareket etmesini engelle
            if (!IsColliding(newPosition))
            {
                transform.position = newPosition;
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private bool IsColliding(Vector3 newPosition)
    {
        Collider[] hitColliders = Physics.OverlapBox(newPosition, transform.localScale / 2);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != this.gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
