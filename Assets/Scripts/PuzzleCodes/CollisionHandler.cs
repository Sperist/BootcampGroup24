using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject panel;  // Paneli Inspector'dan sürükleyip býrakacaðýz

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;  // Oyunu duraklat
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;  // Oyunu tekrar baþlat
    }
}
