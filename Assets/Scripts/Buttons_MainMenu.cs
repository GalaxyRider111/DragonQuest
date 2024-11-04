using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject helpPanel;
    [SerializeField] private TMP_Text highScoreText;


    public void StartGame() { 
    
        SceneManager.LoadScene("SampleScene");
    
    
    
    
    }

    public void OpenHelpMenu() {

        helpPanel.SetActive(true);
        
    
    }

    public void CloseHelpMenu() {


        helpPanel.SetActive(false);
    
    }

    private void Update() {

        /*
        if (PlayerPrefs.GetInt("hs") == null) {

            PlayerPrefs.SetInt("hs", 0);
        
        }
        */

        highScoreText.text="Highscore: "+PlayerPrefs.GetInt("hs").ToString();

    }



}
