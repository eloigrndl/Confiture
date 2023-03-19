using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    public AudioSource gameOverAudio;
    public AudioSource soundtrackAudio;

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "CarScene" && Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.W) && !GameIsOver){
                soundtrackAudio.mute = false;
            }

        if(Input.GetKeyDown(KeyCode.Q) && GameIsPaused){
            QuitGame();
        }

        if(Input.GetKeyDown(KeyCode.M) && GameIsPaused){
            QuitToMenu();
        }

        if(Input.GetKeyDown(KeyCode.G)){
            GameOver();
        }

        if(GameIsOver && Input.GetKeyDown(KeyCode.M)){
            QuitToMenu();
        }

        if(GameIsOver && Input.GetKeyDown(KeyCode.Q)){
            QuitGame();
        } 

        if(GameIsOver && Input.GetKeyDown(KeyCode.R)){
            RestartGame();
        }
    }

    public void PauseGame(){
        Debug.Log("Pausing game");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame(){
        Debug.Log("Resuming game");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void GameOver(){
        soundtrackAudio.Stop();
        gameOverAudio.PlayOneShot(gameOverAudio.clip, gameOverAudio.volume);

        Debug.Log("Game over");
        GameIsOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void RestartGame(){
        Debug.Log("Restarting");
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu(){
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        Debug.Log("Changing scene");
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame(){
        Debug.Log("quitting from pause");
        Application.Quit();
    }
}
