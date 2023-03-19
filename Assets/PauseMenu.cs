using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    public AudioSource gameOverAudio;
    public AudioSource soundtrackAudio;
    public PrometeoCarController playerCar;

    public GameObject winningScreen;

    public GameObject winPoint;

    public bool gameWon = false;

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

        Vector3 pos = playerCar.transform.position;

        double distance = Math.Pow(winPoint.transform.position.y - pos.y, 2) + Math.Pow(winPoint.transform.position.x - pos.x, 2) + Math.Pow(winPoint.transform.position.z - pos.z, 2);
        Debug.Log(distance);
        if(distance <= 200){
            Debug.Log("Game won");
            Time.timeScale = 0f;
            winningScreen.SetActive(true); 
            gameWon = true;
        }

        if(gameWon && Input.GetKeyDown(KeyCode.R)){
            RestartGame();
        }

        if(gameWon && Input.GetKeyDown(KeyCode.Q)){
            QuitGame();
        }

        if(gameWon && Input.GetKeyDown(KeyCode.M)){
            QuitToMenu();
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


        if(!GameIsOver && playerCar.life <= 0){
            GameOver();
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
        playerCar.life = 100;
        Debug.Log("Restarting");
        gameOverUI.SetActive(false);
        winningScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu(){
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        winningScreen.SetActive(false);
        Debug.Log("Changing scene");
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame(){
        Debug.Log("quitting from pause");
        Application.Quit();
    }
}
