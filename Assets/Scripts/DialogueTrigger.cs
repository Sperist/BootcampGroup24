using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharater
{
    public string name; // Karakter ismi
    public Sprite icon; // Karakter resmi
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharater character; // Diyalog karakteri
    [TextArea(3, 10)]
    public string line; // Diyalog metni
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>(); // Diyalog satýrlarýný saklayan liste
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Bu nesne için diyalog

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eðer tetikleyici "Player" etiketine sahipse
        {
            TriggerDialogue(); // Diyaloðu baþlat
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue); // Diyaloðu baþlat
        }
    }
}



// konuþacaðýmýz kiþinin üstüne koyacaðýz bu scripti listeyi oluþturacaðýz
// ayrýca collider eklememiz lazým o kiþiye (is Trigger ý açmayý unutma)
// button a DialogueBoxýmýzý at ve DisplayNextDialogueLine ý seç 
/*
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueSetup npc = GetComponent<DialogueSetup>();

            if (npc != null)
            {
                dialogueManager.StartDialogue(npc.dialogues);
            }
        }
    }
}

*/
