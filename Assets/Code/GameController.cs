using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueSystem dialogueSystem;
    public string Name;
    public GameObject player;


    [TextArea(5, 10)]
    public string[] sentences;
    void Start () {
        //player.gameObject.GetComponent<
        this.gameObject.GetComponent<GameController>().enabled = true;
        dialogueSystem.Names = Name;
        dialogueSystem.dialogueLines = sentences;
        dialogueSystem.NPCName();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && dialogueSystem.dialogueEnded) {
            dialogueSystem.OutOfRange();
            this.gameObject.GetComponent<GameController>().enabled = false;
        }
        
    }
}
