using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class Pipes2 : MonoBehaviour {


    [SerializeField] private float movementSpeed;
    [SerializeField] private PIPES_Control2 pipesControl2;
    [SerializeField] private GameObject crackPattern;
    private bool broken = false;

    private bool hit = false;

    private void Start() {


        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
    
    }

    private void Update() {

        int chance = UnityEngine.Random.Range(1, 100);

        if (chance == 1) {

            broken = true;
        
        }

        movementSpeed = pipesControl2.getSpeed();

        if (transform.position.y <= 200) {

            this.transform.Translate(new Vector2(-1f, 0f) * movementSpeed * Time.deltaTime);
        }

       // Debug.Log("Pipes speed: " + movementSpeed.ToString());
       // Debug.Log(pipesControl2.getSpeed());

        if (transform.position.x <= 302.198) {

            Destroy(gameObject);

        }

        if (gameObject.tag=="Broken") {

            //gameObject.tag = "Broken";
            crackPattern.SetActive(true);
        
        }


    }



    public float getMovementSpeed() {

        return this.movementSpeed;

    }

    public void setMovementSpeed(float newSpeed) {

        //this.movementSpeed = newSpeed;

    }

    public void setBroken(bool newState) { 
    
        broken = newState;
    
    }

    public void setHit(bool newState) {

        hit = newState;
    
    }

}
