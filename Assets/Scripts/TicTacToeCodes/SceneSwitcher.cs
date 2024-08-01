using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private static string previousScene;

    // Sahneyi deðiþtirmek için çaðýrýlacak fonksiyon
    public void SwitchToScene(string sceneName)
    {
        // Geçerli sahneyi sakla
        previousScene = SceneManager.GetActiveScene().name;
        // Yeni sahneye geç
        SceneManager.LoadScene(sceneName);
    }

    // Önceki sahneye geri dönmek için çaðýrýlacak fonksiyon
    public void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
    }
}
