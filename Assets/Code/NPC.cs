using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    public DialogueSystem dialogueSystem;
    public GameObject player;

    private int encounterTime=0;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
          Pos.y += 175;
          ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        if(encounterTime==0) {
            player.gameObject.GetComponent<PlayerController>().enabled= false;
            //player.gameObject.GetComponent<RigidbodyFirstPersonController>().enabled=false;
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.EnterRangeOfNPC();
            if ((other.gameObject.tag == "Player") && (this.gameObject.tag == "NPC"))
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
        player.gameObject.GetComponent<PlayerController>().enabled= true;
        this.gameObject.GetComponent<NPC>().enabled = false;
        encounterTime = 0;
    }
}

