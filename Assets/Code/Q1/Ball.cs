using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    //Outlets
    Rigidbody _rb;

    //Configuration
    public float speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Combine into vector movement
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Apply camera perspective rotation
        if(Camera.main != null) {
            Vector3 cameraForward = Vector3.Scale(
                Camera.main.transform.forward,
                new Vector3(1,0,1)
            );
            cameraForward.Normalize();
            movement = moveVertical * cameraForward + moveHorizontal * Camera.main.transform.right;
        }

        _rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("KillZone")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
