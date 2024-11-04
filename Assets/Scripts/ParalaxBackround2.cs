using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParalaxBackround2 : MonoBehaviour
{
 
    [SerializeField] private PIPES_Control2 tower;

    [SerializeField]private float paralaxSpeed;
    private Material mat;
    private float offset;


    // Start is called before the first frame update
    void Start()
    {
        
        mat= GetComponent<Renderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime *tower.getSpeed()* paralaxSpeed)/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));


        

    }

}
