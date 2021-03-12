using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
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
}
