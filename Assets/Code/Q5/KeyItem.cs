using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    //Configuration
    public int id;

    void OnCollisionEnter(Collision other) {
        PlayerController targetPlayer = other.gameObject.GetComponent<PlayerController>();
        if(targetPlayer != null) {
            targetPlayer.keyIdsObtained.Add(id);
            Destroy(gameObject);
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
