using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    private int encounterTime=0;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
          Pos.y += 175;
          ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        if(encounterTime==0) {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.EnterRangeOfNPC();
            if ((other.gameObject.tag == "Player"))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                dialogueSystem.NPCName();
                encounterTime = 1;
            }
        }
        
    }

    public void OnTriggerExit()
    {
        dialogueSystem.OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
        encounterTime = 0;
    }
}

