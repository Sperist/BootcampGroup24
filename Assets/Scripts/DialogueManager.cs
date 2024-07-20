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

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueActive)
        {
            Debug.Log("Dialogue is already active.");
            return; // Eðer diyalog aktifse tekrar baþlatma
        }

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
        isTyping = false;
    }

    void OnNextButtonClicked()
    {
        if (isDialogueActive)
        {
            DisplayNextDialogueLine(); // Butona týklanýrsa bir sonraki diyaloðu göster
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.SetBool("isOpen", false); // Diyalog bittiðinde animasyonu kapat
    }
}




//dialogueBox a at

/*
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue
{
    public string characterName;
    public Sprite characterImage;
    public string dialogueText;
}

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox1;
    public GameObject dialogueBox2;

    public TextMeshProUGUI nameText1;
    public Image characterImage1;
    public TextMeshProUGUI dialogueText1;

    public TextMeshProUGUI nameText2;
    public Image characterImage2;
    public TextMeshProUGUI dialogueText2;

    public Button nextButton1;
    public Button nextButton2;

    private Dialogue[] dialogues;
    private int currentDialogueIndex = 0;
    public Animator animator1;
    public Animator animator2;

    private void Start()
    {
        if (nextButton1 != null)
        {
            nextButton1.onClick.AddListener(ShowNextDialogue);
        }
        if (nextButton2 != null)
        {
            nextButton2.onClick.AddListener(ShowNextDialogue);
        }

        // Baþlangýçta tüm diyalog kutularýnýn görünürlüðünü kontrol et
        dialogueBox1.SetActive(false);
        dialogueBox2.SetActive(false);
    }

    public void StartDialogue(Dialogue[] npcDialogues)
    {
        dialogues = npcDialogues;
        currentDialogueIndex = 0;

        // Diyalog kutularýný baþlat
        dialogueBox1.SetActive(true);
        dialogueBox2.SetActive(false);

        // Animasyonlarý baþlat
        if (animator1 != null)
        {
            animator1.SetBool("isOpen", true);
        }
        if (animator2 != null)
        {
            animator2.SetBool("isOpen", true);
        }

        ShowNextDialogue(); // Ýlk diyaloðu göster
    }

    public void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            Dialogue currentDialogue = dialogues[currentDialogueIndex];
            if (currentDialogueIndex % 2 == 0)
            {
                nameText1.text = currentDialogue.characterName;
                characterImage1.sprite = currentDialogue.characterImage;
                dialogueText1.text = currentDialogue.dialogueText;

                // Ýkinci kutuyu kapat ve birincisini aç
                dialogueBox2.SetActive(false);
                dialogueBox1.SetActive(true);

                // Butonu aktif hale getir
                nextButton1.gameObject.SetActive(true);
                nextButton2.gameObject.SetActive(false);
            }
            else
            {
                nameText2.text = currentDialogue.characterName;
                characterImage2.sprite = currentDialogue.characterImage;
                dialogueText2.text = currentDialogue.dialogueText;

                // Birinci kutuyu kapat ve ikincisini aç
                dialogueBox1.SetActive(false);
                dialogueBox2.SetActive(true);

                // Butonu aktif hale getir
                nextButton1.gameObject.SetActive(false);
                nextButton2.gameObject.SetActive(true);
            }
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        // Diyalog kutularýný kapat
        dialogueBox1.SetActive(false);
        dialogueBox2.SetActive(false);

        // Animasyonlarý durdur
        if (animator1 != null)
        {
            animator1.SetBool("isOpen", false);
        }
        if (animator2 != null)
        {
            animator2.SetBool("isOpen", false);
        }
    }
}
*/