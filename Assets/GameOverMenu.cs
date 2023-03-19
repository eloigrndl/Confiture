using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;
    // Start is called before the first frame update
    public void Restart(){
        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene("CarScene");
    }
}
