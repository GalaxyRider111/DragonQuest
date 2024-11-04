using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingTowers : MonoBehaviour
{

    private RaycastHit2D hit;
    [SerializeField] private int dif;


    // Start is called before the first frame update
    void Start()
    {

        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks+ dif);

    }

    // Update is called once per frame
    void Update()
    {

        hit = Physics2D.Raycast(transform.position, Vector2.left);

        if (hit.collider != null) {


            if (hit.collider.gameObject.tag =="None") {


                int index = UnityEngine.Random.Range(1,101);

                if (index <= 10) {


                    hit.collider.gameObject.tag = "Broken";

                } else {

                    hit.collider.gameObject.tag = "Game_Over";
                
                
                }
                
            
            }
        
        }

        
    }
}
