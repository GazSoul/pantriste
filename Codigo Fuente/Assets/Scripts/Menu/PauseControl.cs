    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{


    public static bool GameIsPaused = false;
    public static bool GameIsSlowed = false;
    public GameObject pauseMenuHUD;

    // Update is called once per frame
    void Update() {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(GameIsPaused){
                    Resume();
                } else
                {
                    Pause();
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if(GameIsSlowed){
                Time.timeScale = 1;
                GameIsSlowed = false;
                } else
                {
                Time.timeScale = 0.3f;
                GameIsSlowed = true;
                }
            }
        } 


    public void Resume(){
                pauseMenuHUD.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;

            }



    void Pause(){
                pauseMenuHUD.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }

}

