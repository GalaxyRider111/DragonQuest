using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{
    
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TMP_Text scoreText;
    

    private string score;
    [SerializeField] private Playeractions dragon;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField]private TMP_Text scoreFinal;
    private bool overOpen = false;

    [SerializeField] private GameObject pauseMenu;
    private bool pauseOpen=false;

    

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;

        pauseOpen = false;
        overOpen = false;

        gameOverPanel.SetActive(false);
       
        scorePanel.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = dragon.getPoints().ToString();
        if (dragon.getGameOver()) {

            scorePanel.SetActive(false);
            gameOverPanel.SetActive(true);

            overOpen = true;
           
          

            gameOverText.text = "GAME OVER";
            scoreFinal.text = "Congratulations, you got "+ dragon.getPoints().ToString()+" points";


        }

        if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen == false) {

            if (overOpen == false) {

                Time.timeScale = 0;

                pauseMenu.SetActive(true);
                pauseOpen = true;
            }

        } else if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen == true) {

            Time.timeScale = 1.0f;

            pauseMenu.SetActive(false);
            pauseOpen = false;


        }

    }


    public void Resume_Game() {

        Time.timeScale = 1.0f;

        pauseMenu.SetActive(false);
        pauseOpen = false;

    }

    public void Go_MainMenu() {


        SceneManager.LoadScene("Main_Menu");
    
    }

    public void HelpMenu() { 
    
    
    
    
    }


    
}
