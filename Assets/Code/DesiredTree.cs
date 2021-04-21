using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredTree : MonoBehaviour
{
    // Start is called before the first frame update
    public void Interact() {
        
        print("Obtained tree");
        Destroy(gameObject);

    }
}
