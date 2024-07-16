using UnityEngine;

public class DragAndDropX : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        if (isDragging)
        {
            // Fare pozisyonunu dünya koordinatlarýna çevir
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

            // Yeni pozisyonu sadece x ekseninde güncelle
            Vector3 newPosition = new Vector3(worldPosition.x, transform.position.y, transform.position.z);

            // Rigidbody ile pozisyonu güncelle
            rb.MovePosition(newPosition);
        }
    }

    void OnMouseDown()
    {
        // Fare ile týklanýnca sürükleme baþlat
        isDragging = true;

        // Týklama anýndaki fare pozisyonu ile nesne arasýndaki farký hesapla
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        // Fare týklamasý býrakýlýnca sürükleme durdur
        isDragging = false;

        // Sürüklemeyi durdurduðumuzda Rigidbody'nin hýzýný sýfýrla
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma durumunda sürüklemeyi durdur ve son konumda kal
        if (isDragging)
        {
            isDragging = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
