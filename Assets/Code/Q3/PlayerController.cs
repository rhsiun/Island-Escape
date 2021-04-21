using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //state tracking
    public List<int> keyIdsObtained;
    public int hungerValue = 0;
    public int blood = 100;
    public Transform povOrigin;
    public float attackRange;

    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    public int foodNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        instance = this;
        keyIdsObtained = new List<int>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(hungerValue < 20)
        {
            print("You are starving, please find something to eat");
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 3f)) {
                //Handle fps interations
                print("Interacted with" + hit.transform.name + " from" + hit.distance + "m.");

                //Doors
                Door targetDoor = hit.transform.GetComponent<Door>();
                if(targetDoor != null) {
                    print("door open");
                    targetDoor.Interact();
                }

                //Buttons
                InteractButton targetButton = hit.transform.GetComponent<InteractButton>();
                if(targetButton != null) {
                    targetButton.Interact();
                }

                //Box
                Box targetBox = hit.transform.GetComponent<Box>();
                if(targetBox != null) {
                    targetBox.Interact();
                }

                //Boat
                Boat targetBoat = hit.transform.GetComponent<Boat>();
                if(targetBoat != null) {
                    targetBoat.Interact();
                }

                //Food
                Food targetFood = hit.transform.GetComponent<Food>();
                if(targetFood != null) {
                    targetFood.Interact();
                    hungerValue += 5;
                    foodNum++;
                    print("Current hungerValue is "+hungerValue);
                }

                //Barrel
                Barrel targetBarrel = hit.transform.GetComponent<Barrel>();
                if(targetBarrel != null) {
                    targetBarrel.Interact(instance);
                    print("Obtained barrel");
                }
            }
        }
        if(Input.GetMouseButtonDown(0)){
            PrimaryAttack();
        }
        if(Input.GetMouseButtonDown(1)){
            SecondaryAttack();
        }
       
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("KillZone")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void PrimaryAttack()
    {
        print("primaryattack");
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(povOrigin.position, povOrigin.forward,out hit,attackRange);
        if(hitSomething){
            Rigidbody targetRigidbody = hit.transform.GetComponent<Rigidbody>();
            if(targetRigidbody){
                targetRigidbody.AddForce(povOrigin.forward*100f,ForceMode.Impulse);
            }
        }
    }
    void SecondaryAttack()
    {
        print("secondaryattack");
        GameObject projectile = Instantiate(projectilePrefab,projectileOrigin.position,Quaternion.LookRotation(povOrigin.forward));
        projectile.transform.localScale = Vector3.one*5f;
        projectile.GetComponent<Rigidbody>().AddForce(povOrigin.forward*25f,ForceMode.Impulse);
    }
}
