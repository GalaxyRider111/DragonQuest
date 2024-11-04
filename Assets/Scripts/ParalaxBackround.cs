using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ParalaxBackround : MonoBehaviour {

    [SerializeField] private float paralaxSpeed;
    [SerializeField] private float spawnPos;
    [SerializeField] private float destroyPos;
    [SerializeField] private PIPES_Control2 pipeControl2;
    [SerializeField] private SpawnBackround backround;
    [SerializeField] private int number;

    [SerializeField]private bool once ;
    private float movementSpeed;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update() {
        if (number == 1) {

            //  movementSpeed = pipeControl.getSpeed();
        } else if (number == 2) {

            movementSpeed = pipeControl2.getSpeed();

        }


        if (transform.position.y <= 204) {

            this.transform.Translate(new Vector2(-1f, 0) * movementSpeed * paralaxSpeed * Time.deltaTime);
        }


        if (transform.position.x > spawnPos) {

        
            this.once = false;
        


        }
        /*
        if (transform.position.x <= spawnPos && !this.once) {

            backround.spawnBackround();
            this.once = true;
            Debug.Log("Mommy");


        }
        */

        if (transform.position.x <= destroyPos) {

            // Destroy(gameObject);
            
            transform.position = new Vector3(342.66f, transform.position.y, transform.position.z);

        }

    }


    

}
