using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackround : MonoBehaviour
{
    [SerializeField] private GameObject backround;

    public void spawnBackround() { 
    
        Instantiate(backround,transform.position, transform.rotation);
    
    
    }


}
