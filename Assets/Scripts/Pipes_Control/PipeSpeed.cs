using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpeed : MonoBehaviour {

    [SerializeField] private PIPES_Control2 pipeControl2;
    private float movementSpeed;
   

    // Update is called once per frame
   public float helpSpeed()
    {

        movementSpeed = pipeControl2.getSpeed();
        return movementSpeed;

    }
}
