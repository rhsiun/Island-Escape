using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyItem : MonoBehaviour
{
    public int id;
    public void Interact(PlayerController player) {
        
        player.keyIdsObtained.Add(id);
        Destroy(gameObject);
    }

    // void OnCollisionEnter(Collision other) {
    //     PlayerController targetPlayer = other.gameObject.GetComponent<PlayerController>();
    //     if(targetPlayer != null) {
    //         targetPlayer.keyIdsObtained.Add(id);
    //         Destroy(gameObject);
    //     }
    // }
}
