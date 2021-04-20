using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryCanvas;
    public bool[] isOcuppied;
    public InventorySlot[] slots;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInventory(Sprite inventoryImg){
        for(int i = 0; i < slots.Length;i++) {
            if(!isOcuppied[i]) {
                slots[i].itemButton.icon.enabled = true;
                slots[i].itemButton.icon.sprite = inventoryImg;
                //slots[i].icon.color.a = 255;
                isOcuppied[i]=true;
                break;
            }
        }
    }
}
