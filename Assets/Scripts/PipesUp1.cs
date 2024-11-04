using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesUp1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject upperPipe;
    private GameObject obj;
    private bool on = false;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float spawnTimer;
    private float timer = 0f;

    void Start()
    {
        obj = new GameObject();
       //obj= Instantiate(upperPipe, transform.position, transform.rotation);
        on = true;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0f) {
            obj = Instantiate(upperPipe, transform.position, transform.rotation);
            timer = spawnTimer;
        }

        if (on)
        obj.transform.Translate(new Vector2(-1f, 0f) * movementSpeed * Time.deltaTime);


    }
}
