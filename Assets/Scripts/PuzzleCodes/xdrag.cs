using UnityEngine;

public class xdrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody rb;
    private bool isColliding = false;
    private Vector3 lastValidPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Rigidbody'nin fizik motoru tarafýndan kontrol edilmemesi için isKinematic'i true yap
        }
    }

    void Update()
    {
        // Sol týklamayý kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Ekrandaki fare pozisyonunu belirler
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Birim ile çarpýþmayý kontrol et
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                // Birim ile farenin arasýndaki mesafeyi belirler
                offset = transform.position - hit.point;
                lastValidPosition = transform.position; // Baþlangýç konumunu kaydet
            }
        }

        // Sol týklamayý býrakmayý kontrol et
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (isColliding)
            {
                transform.position = lastValidPosition; // Çarpýþma varsa son geçerli pozisyona dön
                isColliding = false; // Çarpýþma durumunu sýfýrla
            }
        }

        // Birimi sürükle
        if (isDragging && !isColliding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ekrandaki fare pozisyonunu belirler
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 newPosition = new Vector3(hit.point.x + offset.x, transform.position.y, transform.position.z); // Y pozisyonunu sabit tut, sadece X pozisyonunu deðiþtir
                if (rb != null)
                {
                    rb.MovePosition(newPosition); // Rigidbody'yi yeni pozisyona hareket ettir
                }
                else
                {
                    transform.position = newPosition; // Rigidbody yoksa direkt pozisyonu deðiþtir
                }
                lastValidPosition = transform.position; // Geçerli pozisyonu kaydet
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDragging)
        {
            isColliding = true; // Çarpýþma baþladýðýnda çarpýþma durumunu ayarla
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDragging)
        {
            isColliding = false; // Çarpýþma sona erdiðinde çarpýþma durumunu sýfýrla
        }
    }
}
