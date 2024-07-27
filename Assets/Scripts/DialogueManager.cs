using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon; // Karakter resmini göstermek için
    public TextMeshProUGUI characterName; // Karakter ismini göstermek için
    public TextMeshProUGUI dialogueArea; // Diyalog metnini göstermek için
    public Button nextButton; // Sonraki diyaloga geçmek için buton

    private Queue<DialogueLine> lines; // Diyalog satýrlarýný saklamak için
    private bool isDialogueActive = false; // Diyalog aktif mi kontrolü
    private bool isTyping = false; // Metin yazýmýnýn devam edip etmediðini kontrol etmek
    public float typingSpeed = 0.05f; // Metin yazma hýzý
    public Animator animator; // Diyalog kutularýnýn animasyonunu kontrol etmek için

    private DialogueTrigger currentTrigger; // Mevcut diyalog tetikleyicisini sakla

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>(); // Kuyruðu baþlat
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClicked); // Butona týklama olayýný ekle
        }
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        if (isDialogueActive)
        {
            Debug.Log("Dialogue is already active.");
            return; // Eðer diyalog aktifse tekrar baþlatma
        }

        currentTrigger = trigger; // Mevcut diyalog tetikleyicisini sakla
        isDialogueActive = true;
        animator.SetBool("isOpen", true); // Diyalog açýldýðýnda animasyonu baþlat

        lines.Clear(); // Önceki diyaloglarý temizle

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine); // Diyalog satýrlarýný kuyruga ekle
        }

        DisplayNextDialogueLine(); // Ýlk diyaloðu göster
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue(); // Diyalog bitmiþse, diyalogu sonlandýr
            return;
        }

        if (isTyping) return; // Eðer yazým devam ediyorsa, geçiþ yapma

        DialogueLine currentLine = lines.Dequeue(); // Kuyruktan bir diyalog satýrý al

        characterIcon.sprite = currentLine.character.icon; // Karakter resmini güncelle
        characterName.text = currentLine.character.name; // Karakter ismini güncelle

        StopAllCoroutines(); // Önceki coroutine'leri durdur
        StartCoroutine(TypeSentence(currentLine.line)); // Yeni diyaloðu yazdýr
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true; // Yazma iþlemi baþlýyor

        dialogueArea.text = ""; // Metin alanýný temizle

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter; // Her harfi ekle
            yield return new WaitForSeconds(typingSpeed); // Yazma hýzýný ayarla
        }

        isTyping = false; // Yazma iþlemi bitti
    }

    void OnNextButtonClicked()
    {
        if (isDialogueActive && !isTyping)
        {
            DisplayNextDialogueLine(); // Butona týklanýrsa bir sonraki diyaloðu göster
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.SetBool("isOpen", false); // Diyalog bittiðinde animasyonu kapat

        // Mevcut diyalog tetikleyicisini yok et
        if (currentTrigger != null)
        {
            Destroy(currentTrigger.gameObject);
        }
    }
}

