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
        rigidbodyFirstPersonController.enabled=false;

        //Disable gun
        playerController.rifle.SetActive(false);

        //enable dialogue
        this.gameObject.GetComponent<GameController>().enabled = true;
        dialogueSystem.Names = Name;
        dialogueSystem.dialogueLines = sentences;
        dialogueSystem.NPCName();
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug
        // print("Dia: " + dialogueSystem.dialogueEnded);
        // print("Sent: " + dialogueSystem.sentenceEnded);

        if(dialogueSystem.sentenceEnded && init) {
            playerController.enabled = true;
            rigidbodyFirstPersonController.enabled=true;
            init = false;
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
        
        
    }
}
