using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int balloonInScene;
    public int poppedBalloons=0;

    private void Start()
    {
        balloonInScene = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }

    public void ballonPopped()
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
      
    }
}
