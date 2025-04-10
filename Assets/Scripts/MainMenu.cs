using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoseGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
