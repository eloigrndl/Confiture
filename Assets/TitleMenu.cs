using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TitleMenu : MonoBehaviour
{
    public bool StoryIsShown = false;
    public GameObject MainMenu;
    public GameObject StoryCanvas;

    public GameObject OptionsCanvas;
    public GameObject MenuCanvas;

    public AudioMixer mainMixer;

    void Update(){
        if(StoryIsShown && Input.GetKeyDown(KeyCode.Space)){
            PlayGame();
        }
    }

    public void InvertCanvas(){
        Debug.Log("Here");
        MenuCanvas.SetActive(!MenuCanvas.activeSelf);
        OptionsCanvas.SetActive(!OptionsCanvas.activeSelf);
    }

    public void LaunchStory(){
        Debug.Log("Launching story");
        MainMenu.SetActive(false);
        StoryCanvas.SetActive(true);
        StoryIsShown = true;
    }

    public void PlayGame(){
        Debug.Log("Starting game");
        MainMenu.SetActive(true);
        StoryCanvas.SetActive(false);
        SceneManager.LoadScene("CarScene");
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void ChangeVolumne(float volume){
        mainMixer.SetFloat("MainVolume", volume);
    }
}
