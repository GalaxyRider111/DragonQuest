using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Pipes1:MonoBehaviour
{

   
    [SerializeField] private float movementSpeed;
    [SerializeField]private PIPES_Control pipesControl;

    private void Update() {

        movementSpeed= pipesControl.getSpeed();

        this.transform.Translate(new Vector2(-1f, 0f) * movementSpeed * Time.deltaTime);

        if (transform.position.x <= -12.246) { 
        
            Destroy(gameObject);
        
        }

        
    }

   

    public float getMovementSpeed() { 
    
        return this.movementSpeed;
    
    }

    public void setMovementSpeed(float newSpeed) { 
    
        this.movementSpeed = newSpeed;
    
    }

}
