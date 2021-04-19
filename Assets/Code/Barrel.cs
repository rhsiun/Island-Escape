using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int id;
    public void Interact(PlayerController player) {
        
        player.keyIdsObtained.Add(id);
        Destroy(gameObject);
    }
}
