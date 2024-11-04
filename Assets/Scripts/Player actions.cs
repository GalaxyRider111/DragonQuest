using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Playeractions : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _rb2;
    private float input;
    private float _JumpTimer;
    private int points, intervalPoints;
    private bool dead = false;
    private bool isPressed = false;
    [SerializeField] private float setJumpTimer;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool Imunity;

    [SerializeField] private CameraMovement cameraMove;

    [SerializeField] private float breakingShakeIntensity;
    [SerializeField] private float breakingShakeTime;

    public float jumptTimer {

        get {

            return _JumpTimer;
        
        }

        set {

            if (_JumpTimer < 0) {

                _JumpTimer = 0;

            } else { 
            
                _JumpTimer = value;
            }
        
        }
    
    }


    void Start()
    {

        _rb2=gameObject.GetComponent<Rigidbody2D>();
        jumptTimer = 0f;
        points = 0;
        intervalPoints = 0;

        
    }

    // Update is called once per frame
    void Update()
    {

        jumptTimer-= Time.deltaTime;

        input = Input.GetAxisRaw("Vertical");

        if (input != 0) {


            if (!isPressed) {

                if (input < 0) {
                    input = 0;

                }
                _rb2.AddForce(new Vector2(0f, input * jumpForce), ForceMode2D.Impulse);
                if (gameObject.transform.localRotation.eulerAngles.z >= 310f
                || gameObject.transform.localRotation.eulerAngles.z < 45f) {

                    float currentAngle = gameObject.transform.localRotation.eulerAngles.z;
                    if (currentAngle >= 180) {

                        currentAngle = (360 - currentAngle) * -1;
                    
                    }

                    gameObject.transform.Rotate(Vector3.forward, 30-currentAngle);



                }
                isPressed = true;

            }

        } else {

            isPressed = false;
            if (gameObject.transform.localRotation.eulerAngles.z > 315f 
                || gameObject.transform.localRotation.eulerAngles.z<=90f) {

                gameObject.transform.Rotate(Vector3.forward,-20f*Time.deltaTime);

                

            }

        }

       


        /*
        if (jumptTimer == 0) {
            _rb2.AddForce(new Vector2(0f, input * jumpForce), ForceMode2D.Impulse);
            jumptTimer = setJumpTimer;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Game_Over" && !dead && !Imunity) {
            Debug.Log("GAME OVER");
            Debug.Log("CONGRATIOLATIONS, YOU GOT "+ points.ToString()+" POINTS");
            dead = true;
            Time.timeScale = 0;
            if (points > PlayerPrefs.GetInt("hs")) { 
            
                PlayerPrefs.SetInt("hs", points);
                StaticManagementScenes.highScore = points;
                
            
            }
        
        }
        if (collision.gameObject.tag == "CheckPoint" && !dead) {

            points++;
            intervalPoints++;
            Debug.Log(points.ToString() + " points");

        
        }

        if (collision.gameObject.tag == "Broken") {

            Destroy(collision.gameObject);
            cameraMove.StartShaking(breakingShakeIntensity, breakingShakeTime);
        
        }

    }

    public void RestartGame() {

        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    
    
    }

    public void MainMenu() {



        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Main_Menu");


    }

    public int getPoints() {

        return points;
    
    }

    public int getIntervalPoints() {

        return intervalPoints;
       
    
    }

    public void setIntervalPoints(int newPoints) { 
    
        intervalPoints = newPoints;
    
    
    }

    public bool getGameOver() {

        return dead;
    
    }
}
