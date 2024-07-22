using UnityEngine;
using UnityEngine.UI; // UI bileþenleri için gerekli
using TMPro; // Eðer TextMeshPro kullanýyorsanýz bu namespace gerekli

public class CongratulationsDisplay : MonoBehaviour
{
    public GameObject targetObject; // Temas edilecek GameObject
    public GameObject playerObject; // Temas eden GameObject
    public TextMeshProUGUI congratulationsText; // TextMeshPro için
    // public Text congratulationsText; // Text bileþeni için
    // public GameObject congratulationsTextObject; // Eðer Text GameObject'ini referans olarak kullanýyorsanýz

    void Start()
    {
        // Baþlangýçta yazýyý gizle
        if (congratulationsText != null)
        {
            congratulationsText.enabled = false;
        }
        // Eðer Text GameObject'ini referans olarak kullanýyorsanýz
        // if (congratulationsTextObject != null)
        // {
        //     congratulationsTextObject.SetActive(false);
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýþan nesne hedef nesne ise ve hedef nesne Player nesnesiyle temas ediyorsa
        if (other.gameObject == targetObject)
        {
            if (playerObject.GetComponent<Collider>().bounds.Intersects(targetObject.GetComponent<Collider>().bounds))
            {
                // Temas edildiðinde yazýyý göster
                if (congratulationsText != null)
                {
                    congratulationsText.enabled = true;
                }
                // Eðer Text GameObject'ini referans olarak kullanýyorsanýz
                // if (congratulationsTextObject != null)
                // {
                //     congratulationsTextObject.SetActive(true);
                // }
            }
        }
    }
}
