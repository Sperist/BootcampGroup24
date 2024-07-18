using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharater
{
    public string name;
    public Sprite icon;
}
[System.Serializable]
public class DialogueLine
{
    public DialogueCharater character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider collision) //colliderýn içine girince çalýþsýn
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
    {
            
    }
}

// konuþacaðýmýz kiþinin üstüne koyacaðýz bu scripti listeyi oluþturacaðýz
// ayrýca collider eklememiz lazým o kiþiye (is Trigger ý açmayý unutma)
// button a DialogueBoxýmýzý at ve DisplayNextDialogueLine ý seç
