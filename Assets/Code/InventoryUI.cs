using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryCanvas;
    public bool[] isOcuppied;
    public string[] inventoryNames;
    public InventorySlot[] slots;
    private int totalNum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInventory(Sprite inventoryImg, string inventoryName){
        for(int i = 0; i < slots.Length;i++) {
            if(!isOcuppied[i]) {
                slots[i].itemButton.icon.enabled = true;
                slots[i].itemButton.icon.sprite = inventoryImg;
                inventoryNames[i] = inventoryName;
                isOcuppied[i]=true;
                break;
            }
        }
        totalNum++;
    }

    public void removeInventory(string inventoryName, int num) {
        int counter = 0;

        //Remove the desired inventory
        for(int i = 0; i < slots.Length;i++) {
            if(inventoryNames[i].Equals(inventoryName) && counter<num) {
                slots[i].itemButton.icon.enabled = false;
                slots[i].itemButton.icon.sprite = null;
                isOcuppied[i]=false;
                inventoryNames[i] = null;
                counter++;
            }
        }

        //Move the inventories around
        int loopRecord = 0;
        for(int i = 0; i < slots.Length;i++) {
            if(!isOcuppied[i]) {
                for(int j = i; j < slots.Length;j++) {
                    if(isOcuppied[j] && loopRecord == 0) {
                        //Change i
                        slots[i].itemButton.icon.enabled = true;
                        slots[i].itemButton.icon.sprite = slots[j].itemButton.icon.sprite;
                        inventoryNames[i] = inventoryNames[j];
                        isOcuppied[i]=true;

                        //Disable j
                        slots[j].itemButton.icon.enabled = false;
                        slots[j].itemButton.icon.sprite = null;
                        inventoryNames[j] = null;
                        isOcuppied[j]=false;
                        loopRecord++;
                    }
                }
                loopRecord=0;
            }
        }
    }
}
