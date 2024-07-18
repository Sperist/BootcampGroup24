/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueActive)
        {
            Debug.Log("Dialogue is already active.");
            return; // Eðer diyalog aktifse tekrar baþlatma
        }

        isDialogueActive = true;

        animator.SetBool("isOpen", true);
        Debug.Log("Animator SetBool 'isOpen' set to true");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if ( lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";

        foreach(char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        animator.SetBool("isOpen", false);
        Debug.Log("Animator SetBool 'isOpen' set to false");
    }
}

//dialogueBox a at
//*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image character;
    public Animator animator;
    public GameObject[] dialoguePanels; // Her konuþmacýnýn paneli

    private Queue<DialogueLine> dialogueLines;
    private bool isDialogueActive = false;

    void Start()
    {
        dialogueLines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueActive) return;

        isDialogueActive = true;

        // Diyalog kutusunun açýlma animasyonunu oynat
        animator.SetBool("isOpen", true);
        StartCoroutine(PlayAnimationAndDisplayDialogue(dialogue));
    }

    private IEnumerator PlayAnimationAndDisplayDialogue(Dialogue dialogue)
    {
        yield return new WaitForSeconds(1f); // Animasyon süresi (Örneðin 1 saniye)

        // Tüm panelleri kapat
        foreach (GameObject panel in dialoguePanels)
        {
            panel.SetActive(false);
        }

        // Diyalog satýrlarýný sýraya koy
        dialogueLines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(dialogueLine);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine dialogueLine = dialogueLines.Dequeue();

        // Konuþmacýnýn panelini aktif et
        foreach (GameObject panel in dialoguePanels)
        {
            if (panel == dialogueLine.character.dialoguePanel)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }

        nameText.text = dialogueLine.character.name;
        character.sprite = dialogueLine.character.icon;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueLine.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // or yield return new WaitForSeconds(0.05f); for a typing effect
        }
    }

    void EndDialogue()
    {
        // Diyalog kutusunun kapanma animasyonunu oynat
        animator.SetBool("isOpen", false);
        isDialogueActive = false;
    }
}
