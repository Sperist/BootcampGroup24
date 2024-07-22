using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Kinematic yaparak fiziksel hesaplamalarý devre dýþý býrakýyoruz
        }
    }

    private void OnMouseDown()
    {
        // Fare týklama baþladýðýnda birimi seçmek için
        isDragging = true;
        // Seçili objenin pozisyonuna offset hesaplamak için
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        // Fare týklama býraktýðýnda birimi býrakmak için
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPos() + offset;
            newPos.y = transform.position.y; // Y düzleminde sabit tut
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Diðer birimlere çarptýðýnda hareket etmeyi durdur
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y; // Kamera yüksekliði ile mesafeyi belirleyin
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
