using UnityEngine;
using UnityEngine.SceneManagement;

public class guardManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Paneli buraya atacaðýz
    public string gameOverMessage = "Yakalandýn"; // Ekrandaki mesaj

    void Start()
    {
        // Oyunun baþýnda paneli gizle
        gameOverPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beeGuard"))
        {
            Debug.Log("Beeguard ile temas edildi!");
            SceneManagment.instance.ReloadScene();
            //Cursor.visible = true; // Fare imlecini görünür yap
            //Cursor.lockState = CursorLockMode.None; // Fare imlecinin kilidini aç
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Zamaný eski haline getir
        Cursor.visible = false; // Fare imlecini gizle (isteðe baðlý)
        Cursor.lockState = CursorLockMode.Locked; // Fare imlecini kilitle (isteðe baðlý)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}