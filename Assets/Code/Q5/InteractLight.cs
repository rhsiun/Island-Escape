using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLight : MonoBehaviour
{
    public void Interact() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
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
