using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    //Configuration
    public GameObject interactionTarget;

    //Methods
    public void Interact() {
        //Doors
        if(interactionTarget != null) {
            //Doors
            Door targetDoor = interactionTarget.GetComponent<Door>();
            if(targetDoor != null) {
                targetDoor.Interact(gameObject);
            }

            //Lights
            InteractLight targetLight = interactionTarget.GetComponent<InteractLight>();
            if(targetLight != null) {
                targetLight.Interact();
            }
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
