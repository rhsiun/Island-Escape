using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //outlets
    public DialogueSystem dialogueSystem;
    public InventoryUI inventoryUI;
    public string Name;
    public GameObject player;
    public GameObject inventoryCanvas;
    public Enemy enemy;
    public Sprite achorn;
    public Sprite banana;
    public Sprite DesiredTree;
    public Sprite Rabbit;
    public Sprite key;
    public Sprite Barrel;
    
    private PlayerController playerController;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private bool init = true;
    private int currentFoodNum;
    private int currentDesiredTreeNum;
    private int currentRabbitNum;
    private int currentKeyNum;
    private int currentBarrelNum;


    [TextArea(5, 10)]
    public string[] sentences;
    void Start () {
        //Set up instances
        inventoryCanvas.SetActive(false);
        playerController = player.gameObject.GetComponent<PlayerController>();
        rigidbodyFirstPersonController = player.gameObject.GetComponent<RigidbodyFirstPersonController>();

        //Diasble walking and shooting motions
        playerController.enabled= false;
        rigidbodyFirstPersonController.movementSettings.ForwardSpeed = 0f;
        rigidbodyFirstPersonController.movementSettings.BackwardSpeed = 0f;
        rigidbodyFirstPersonController.movementSettings.StrafeSpeed = 0f;

        //Disable gun
        playerController.rifle.SetActive(false);

        //enable dialogue
        // this.gameObject.GetComponent<GameController>().enabled = true;
        // dialogueSystem.Names = Name;
        // dialogueSystem.dialogueLines = sentences;
        // dialogueSystem.NPCName();
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug
        // print("Dia: " + dialogueSystem.dialogueEnded);
        // print("Sent: " + dialogueSystem.sentenceEnded);

        if(dialogueSystem.sentenceEnded && init) {
            playerController.enabled = true;
            rigidbodyFirstPersonController.movementSettings.ForwardSpeed = 8.0f;
            rigidbodyFirstPersonController.movementSettings.BackwardSpeed = 4.0f;
            rigidbodyFirstPersonController.movementSettings.StrafeSpeed = 4.0f;
            init = false;
        }

        //Detect enemy death
        if(enemy.blood <= 0) {
            dialogueSystem.Names = Name;

            //change dialogue
            sentences = new string[]{"Couple barrels of freshwater?","You need those for sailing!"};

            //start conversatin
            dialogueSystem.dialogueLines = sentences;
            dialogueSystem.NPCName();

            enemy.blood=1;
        }

        //Open inventory UI
        if(Input.GetKeyDown(KeyCode.I)) {
            inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        }

        //If we have picked banana
        if(playerController.foodNum > currentFoodNum) {
            inventoryUI.updateInventory(banana, "banana");
            currentFoodNum = playerController.foodNum;
        }

        //If we have picked trees
        if(playerController.treeNum > currentDesiredTreeNum) {
            inventoryUI.updateInventory(DesiredTree, "tree");
            currentDesiredTreeNum = playerController.treeNum;
        }

        //If we picked up rabbits
        if(playerController.rabbitNum > currentRabbitNum) {
            inventoryUI.updateInventory(Rabbit, "rabbit");
            currentRabbitNum = playerController.rabbitNum;
        }

        //If we picked up a key
        if(playerController.keyNum > currentKeyNum) {
            inventoryUI.updateInventory(key, "key");
            currentKeyNum = playerController.keyNum;
        }

        //If we picked up a barrel
        if(playerController.barrelNum > currentBarrelNum) {
            inventoryUI.updateInventory(Barrel, "barrel");
            currentBarrelNum = playerController.barrelNum;
        }
        
        //If we have died
        // if(playerController.blood <= 0) {
        //     rigidbodyFirstPersonController.movementSettings.ForwardSpeed = 0f;
        //     rigidbodyFirstPersonController.movementSettings.BackwardSpeed = 0f;
        //     rigidbodyFirstPersonController.movementSettings.StrafeSpeed = 0f;
        // }
    }
}
