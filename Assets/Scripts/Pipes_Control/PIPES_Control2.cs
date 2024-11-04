using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PIPES_Control2 : MonoBehaviour {



    [SerializeField] private List<GameObject> upperPipes = new List<GameObject>();
    [SerializeField] private List<GameObject> lowerPipes = new List<GameObject>();
    [SerializeField] private GameObject checkPoint;
    [SerializeField] private Playeractions dragon;

    [SerializeField] private List<float> spawnTimer = new List<float>();
    [SerializeField] private bool isRandomized;
    [SerializeField] private List<float> levelSpeed = new List<float>();
    //[SerializeField] private int scaleDifficulty;
    [SerializeField] private List<int> minDifficulty = new List<int>();
    [SerializeField] private List<int> maxDifficulty = new List<int>();

    
   [SerializeField] private List<int> previousIndexes= new List<int>();
    private int temp;
    private float movementSpeed=1;
    private int currentLevel=0;

    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {



        currentLevel = 0;

        currentTimer = 0f;
        Debug.Log(upperPipes.Count);

          temp = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.InitState(temp);

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(" MOVEMENT SPEED: " + movementSpeed.ToString());
        Debug.Log("Current level; " + currentLevel.ToString());
        Debug.Log("Level Speed: "+levelSpeed[currentLevel].ToString());

        movementSpeed = levelSpeed[currentLevel];

        if (currentTimer <= 0f) {

            int upperIndex=0;
            int lowerIndex=0;
            int tries=0;

            do {
                upperIndex = UnityEngine.Random.Range(0, upperPipes.Count);
            } while (upperIndex == previousIndexes[0] || upperIndex>maxDifficulty[currentLevel]);

            do {

                tries++;

                if (tries > 1000) {

                    upperIndex = 0;
                    lowerIndex = 0;

                    Debug.Log("INFINITE LOOP");

                    break;

                }

                
                lowerIndex = UnityEngine.Random.Range(0, lowerPipes.Count - upperIndex);

              //  Debug.Log(tries);

            } while (upperIndex + lowerIndex <minDifficulty[currentLevel] || upperIndex+lowerIndex>maxDifficulty[currentLevel]);

         
       
            previousIndexes[0] = upperIndex;
      

            Instantiate(upperPipes[upperIndex], transform.position, transform.rotation);
            Instantiate(lowerPipes[lowerIndex], transform.position, transform.rotation);


            //Debug.Log(upperIndex.ToString() + " " + lowerIndex.ToString());
   
            Instantiate(checkPoint, transform.position, transform.rotation);

            currentTimer = spawnTimer[currentLevel];

          

        }

        currentTimer-=Time.deltaTime;

        /*

        if (dragon.getIntervalPoints() == scaleDifficulty) { 
        
            dragon.setIntervalPoints(0);

            if (currentLevel < 4) {

                currentLevel++;
            }
        
        }
        */

        switch (dragon.getPoints()) {

            case <1:

                currentLevel = 0;

                break;

            case < 10:
                currentLevel = 1;

                break;

            case < 30:
                currentLevel = 2;
                break;

            case < 60:
                currentLevel = 3;
                break;

            case >=60:
                currentLevel = 4;
                break;

            
        }



    }

    public float getSpeed() {

        Debug.Log(movementSpeed);
        return this.movementSpeed;

    }


    public int getCurrentlevel() {

        return currentLevel;
    
    }
}
