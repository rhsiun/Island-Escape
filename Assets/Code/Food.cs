using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public Image foodImage;
    public void Interact() {
        
        print("Obtained food");
        Destroy(gameObject);

    }
  
}
