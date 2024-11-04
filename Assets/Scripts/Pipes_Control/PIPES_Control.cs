using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIPES_Control : MonoBehaviour
{
    [SerializeField] private List<Pipes1> pipeControl=new List<Pipes1>();
    [SerializeField] private Playeractions bird;
    public GameObject pipeToTest;
    public List<GameObject> pipes= new List<GameObject>();
    private float currentTimer = 0f;
    [SerializeField] private float spawnTimer;
    [SerializeField] private bool isRandomized;
    [SerializeField] private float movementSpeed;
    private int points = 0, pointsTotal=0;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        points=bird.getPoints()-pointsTotal;

        if (currentTimer <= 0f) { 
        

            int index= isRandomized ? Random.Range(0, pipes.Count-1):-1;

            if (index >= 0) {

               // pipeControl[index].setMovementSpeed(movementSpeed);
                Instantiate(pipes[index], transform.position, transform.rotation);

            } else { 
            
                Instantiate(pipeToTest,transform.position,transform.rotation);

            }


            
            currentTimer = spawnTimer;
        
        }

        currentTimer -= Time.deltaTime;

        if (points == 2 && movementSpeed < 7) {

            pointsTotal += points;
            points = 0;

            movementSpeed++;
            spawnTimer -= 0.25f;
        
        }

    }

    public float getSpeed() {

        return movementSpeed;
    
    }

}
