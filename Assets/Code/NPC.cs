using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;
    public InventoryUI inventoryUI;

    public DialogueSystem dialogueSystem;
    public GameObject player;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;

    private int encounterTime=0;
    private PlayerController playerController;
    private GameController gameController;
    private bool[] isCompleted;
    private int missionNum = 3;
    private int missionId = 0;

    //sprites
    public Sprite gun;
    public Sprite carrot;
    public Sprite boatSprite;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        //Initialization
        playerController = player.gameObject.GetComponent<PlayerController>();
        gameController = player.gameObject.GetComponent<GameController>();
        rigidbodyFirstPersonController = player.gameObject.GetComponent<RigidbodyFirstPersonController>();

        //Initialize mission states
        isCompleted = new bool[missionNum];
        //set intial values all to false
        for(int i = 0; i < missionNum; i++) {
            isCompleted[i] = false;
        }

    }
	
	void Update () {
        //   Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        //   Pos.y += 175;
        //   ChatBackGround.position = Pos;
    }

    public void OnTriggerEnter(Collider other) {
        //Mission 2 trigger
        if(Name.Equals("Hi")) {
            if ((other.gameObject.tag == "Player") && (this.gameObject.name == "Mission2TriggerZone")) {
                //start conversation
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;

                //conversation
                dialogueSystem.dialogueLines = sentences;
                dialogueSystem.NPCName();
            }
        }

        //When encountering the boss
        if ((other.gameObject.tag == "Player") && (this.gameObject.name == "BossTriggerZone")) {
            //start conversation
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            //conversation
            dialogueSystem.dialogueLines = sentences;
            dialogueSystem.NPCName();
        }

        //When at the final step
        if ((other.gameObject.tag == "Player") && (this.gameObject.name == "Final")) {
            //start conversation
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;

            //conversation
            dialogueSystem.dialogueLines = sentences;
            dialogueSystem.NPCName();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //Mission 1 LittleFox
        if(encounterTime==0 && Name.Equals("Little Fox")) {
            //instances
            int bananaNum = 5;

            //If we have completed the mission, we will change the dialogue
            if(isCompleted[0]) {
                //Show dialogue
                player.gameObject.GetComponent<PlayerController>().enabled= false;
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.EnterRangeOfNPC();
                if ((other.gameObject.tag == "Player") && (this.gameObject.name == "LittleFox"))
                {
                    //start conversation
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.Names = Name;

                    //Change sentences
                    sentences=new string[]{"I heard there's a maze on this island, wonder what's there..."};

                    //conversation
                    dialogueSystem.dialogueLines = sentences;
                    dialogueSystem.NPCName();
                    encounterTime = 1;
                }
            }

            //If we have not completed the mission
            if(!isCompleted[0]) {
                //If we does not have enough bananas
                if(playerController.foodNum < bananaNum ){
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
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

                //If we have collected enough bananas
                if(playerController.foodNum >= bananaNum ){
                    print("Mission complete");

                    //Show dialogue
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.EnterRangeOfNPC();
                    if ((other.gameObject.tag == "Player") && (this.gameObject.tag == "NPC"))
                    {
                        //start conversation
                        this.gameObject.GetComponent<NPC>().enabled = true;
                        dialogueSystem.Names = Name;

                        //Change sentences
                        sentences=new string[]{"Thanks for your bananas", "I got a weird toy from you when you were asleep","Here you go!"};
                        
                        //update inventory
                        inventoryUI.updateInventory(gun,"gun");

                        //we can now open fire
                        playerController.rifle.SetActive(true);
                        playerController.canOpenFire = true;

                        //conversation
                        dialogueSystem.dialogueLines = sentences;
                        dialogueSystem.NPCName();
                        encounterTime = 1;
                    }

                    //remove from inventory
                    inventoryUI.removeInventory("banana", bananaNum);

                    //remove from player controller
                    playerController.foodNum -= bananaNum;

                    //mark the mission as complete
                    isCompleted[0] = true;
                }
            }
        }

        //Mission 2 chop trees
        if(encounterTime==0 && Name.Equals("Isaac")) {
            //instances
            int treeNum = 3;

            //If we have completed the mission, we will change the dialogue
            if(isCompleted[1]) {
                //debug
                print("complete chop tree");
                //Show dialogue
                player.gameObject.GetComponent<PlayerController>().enabled= false;
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.EnterRangeOfNPC();
                if ((other.gameObject.tag == "Player") && (this.gameObject.name == "Isaac"))
                {
                    //start conversation
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.Names = Name;

                    //Change sentences
                    sentences=new string[]{"Keep forward, KEEP FORWARD!!"};

                    //conversation
                    dialogueSystem.dialogueLines = sentences;
                    dialogueSystem.NPCName();
                    encounterTime = 1;
                }
            }

            //If we have not completed the mission
            if(!isCompleted[1]) {
                //If we does not have enough trees
                if(playerController.treeNum < treeNum ){
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.EnterRangeOfNPC();
                    if ((other.gameObject.tag == "Player") && (this.gameObject.name == "Isaac"))
                    {
                        this.gameObject.GetComponent<NPC>().enabled = true;
                        dialogueSystem.Names = Name;
                        dialogueSystem.dialogueLines = sentences;
                        dialogueSystem.NPCName();
                        encounterTime = 1;
                    }
                }

                //If we have collected enough bananas
                if(playerController.treeNum >= treeNum ){
                    print("Mission complete");

                    //Show dialogue
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.EnterRangeOfNPC();
                    if ((other.gameObject.tag == "Player") && (this.gameObject.name == "Isaac"))
                    {
                        //start conversation
                        this.gameObject.GetComponent<NPC>().enabled = true;
                        dialogueSystem.Names = Name;

                        //Change sentences
                        sentences=new string[]{"Thanks YOUND MAN!", "Here's something to eat.","You may find other use of them."};

                        //update UI
                        for(int i = 0;i < 4; i++) {
                            inventoryUI.updateInventory(carrot,"carrot");
                        }
                        
                        //conversation
                        dialogueSystem.dialogueLines = sentences;
                        dialogueSystem.NPCName();
                        encounterTime = 1;
                    }

                    //remove from inventory
                    inventoryUI.removeInventory("tree", treeNum);

                    //update player controller
                    playerController.treeNum -= treeNum;

                    //mark the mission as complete
                    isCompleted[1] = true;
                }
            }
        }
        
        //Mission 3 catch rabbit
        //Mission 2 chop trees
        if(encounterTime==0 && Name.Equals("Mubai Li")) {
            //instances
            int rabbitNum = 1;

            //If we have completed the mission, we will change the dialogue
            if(isCompleted[2]) {
                //debug
                print("complete mubai");
                //Show dialogue
                player.gameObject.GetComponent<PlayerController>().enabled= false;
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.EnterRangeOfNPC();
                if ((other.gameObject.tag == "Player") && (this.gameObject.name == "MubaiLi"))
                {
                    //start conversation
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.Names = Name;

                    //Change sentences
                    sentences=new string[]{"Sail away now soldier!"};

                    //conversation
                    dialogueSystem.dialogueLines = sentences;
                    dialogueSystem.NPCName();
                    encounterTime = 1;
                }
            }

            //If we have not completed the mission
            if(!isCompleted[2]) {
                //If we does not have enough trees
                if(playerController.rabbitNum < rabbitNum ){
                    //print("debug");
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.EnterRangeOfNPC();
                    if ((other.gameObject.tag == "Player") && (this.gameObject.name == "MubaiLi"))
                    {
                        this.gameObject.GetComponent<NPC>().enabled = true;
                        dialogueSystem.Names = Name;
                        dialogueSystem.dialogueLines = sentences;
                        dialogueSystem.NPCName();
                        encounterTime = 1;
                    }
                }

                //If we have collected enough bananas
                if(playerController.rabbitNum >= rabbitNum ){
                    print("Mission complete");

                    //Show dialogue
                    player.gameObject.GetComponent<PlayerController>().enabled= false;
                    this.gameObject.GetComponent<NPC>().enabled = true;
                    dialogueSystem.EnterRangeOfNPC();
                    if ((other.gameObject.tag == "Player") && (this.gameObject.name == "MubaiLi"))
                    {
                        //start conversation
                        this.gameObject.GetComponent<NPC>().enabled = true;
                        dialogueSystem.Names = Name;

                        //Change sentences
                        sentences=new string[]{"谢谢您", "May the nature be with you","How do you like my KungFu anyway?"};

                        //update UI
                        inventoryUI.updateInventory(boatSprite,"boat");
                        
                        //conversation
                        dialogueSystem.dialogueLines = sentences;
                        dialogueSystem.NPCName();
                        encounterTime = 1;
                    }

                    //remove from inventory
                    inventoryUI.removeInventory("rabbit", rabbitNum);

                    //remove from player controller
                    playerController.rabbitNum -= rabbitNum;

                    //mark the mission as complete
                    isCompleted[2] = true;
                }
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

