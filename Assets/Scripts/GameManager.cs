using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action BalloonPopped;
    public static GameManager Instance;
  
    public int balloonInScene;
    public int poppedBalloons=0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            balloonInScene = GameObject.FindGameObjectsWithTag("Balloon").Length;
            BalloonPopped += OnBallonPopped;
    }

    private void OnDestroy()
    {
       BalloonPopped -= OnBallonPopped;
    }

    public void OnBallonPopped()
    {
        poppedBalloons++;
        if (poppedBalloons >= balloonInScene)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        
        Debug.Log("You win!");
        StartCoroutine(UIManager.Instance.ShowWinPanel());

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }
}
