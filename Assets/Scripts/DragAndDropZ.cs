using UnityEngine;

public class DragAndDropZ : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;
    private Vector3 offset;
    private Vector3 initialPosition; // Baþlangýç pozisyonunu kaydetmek için
    private Collider collider; // Collider bileþeni için referans

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        // Baþlangýç pozisyonunu kaydet
        initialPosition = transform.position;

        // Collider bileþenini al
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (isDragging)
        {
            // Fare pozisyonunu dünya koordinatlarýna çevir
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

            // Yeni pozisyonu sadece z ekseninde güncelle
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, worldPosition.z);

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

        // Collider'ý tekrar etkinleþtir
        collider.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Eðer sürükleniyorsa ve bir baþka birime temas ediyorsa
        if (isDragging)
        {
            // Sürüklemeyi durdur
            isDragging = false;

            // Rigidbody'nin hýzýný sýfýrla
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Collider'ý tekrar etkinleþtir
            collider.enabled = true;
        }
    }
}
