using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    //Congiguration
    public GameObject requiredSender;
    public int keyIdRequired = -1;

    public void Interact(GameObject sender = null) {
        bool driveboat = false;

        if(!requiredSender) {
            driveboat = true;
        } else if(requiredSender == sender) {
            driveboat = true;
        }

        if(keyIdRequired >=0 && !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired)) {
            driveboat = false;
        }

        if(driveboat) {
            print("the boat is usable for the character");
        }
        else
        {
            print("please find the paddle");
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
