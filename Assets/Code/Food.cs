using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   
    public void Interact() {
        
        print("Obtained food");
        Destroy(gameObject);

    }
  
}
