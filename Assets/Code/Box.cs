using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //Congiguration
    public GameObject requiredSender;
    public int keyIdRequired = -1;

    public void Interact(GameObject sender = null) {
        bool openbox = false;

        if(!requiredSender) {
            openbox = true;
        } else if(requiredSender == sender) {
            openbox = true;
        }

        if(keyIdRequired >=0 && !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired)) {
            openbox = false;
        }

        if(openbox) {
            print("open box successfully");
        }
        else
        {
            print("the box can not be opened");
        }

    }
}
