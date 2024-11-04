using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{

    public GameObject checkPoint;
    private GameObject obj;
    [SerializeField] private float movementSpeed;
    [SerializeField]private float spawnTimer;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        obj = new GameObject();
       // obj = Instantiate(checkPoint, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f) {
            obj = Instantiate(checkPoint, transform.position, transform.rotation);
            timer = spawnTimer;
        }

        
        obj.transform.Translate(new Vector2(-1f, 0f) * movementSpeed * Time.deltaTime);
        
    }
}
