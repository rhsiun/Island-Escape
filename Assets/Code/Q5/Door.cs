using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Outlets
    Animator animator;
    
    //Congiguration
    public GameObject requiredSender;
    public int keyIdRequired = -1;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Interact(GameObject sender = null) {
        bool shouldOpen = false;

        //Check if the interaction is valid
        if(!requiredSender) {
            shouldOpen = true;
        } else if(requiredSender == sender) {
            shouldOpen = true;
        }

        if(keyIdRequired >=0 && !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired)) {
            shouldOpen = false;
        }

        if(shouldOpen) {
            print("The door should open");
            animator.SetTrigger("open");
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
