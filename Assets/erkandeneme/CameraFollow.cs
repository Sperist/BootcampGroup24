using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncu karakterinin transform bileþeni
    public Vector3 offset; // Kameranýn oyuncuya göre olan mesafesi

    // LateUpdate, Update'den sonra çaðrýlýr ve kamera hareketleri için daha uygundur
    void LateUpdate()
    {
        // Kamerayý oyuncunun konumuna offset ekleyerek ayarla
        transform.position = player.position + offset;
    }
}
