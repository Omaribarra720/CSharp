using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI balloonsPoppedUI;
    public CanvasGroup winPanel;
    public float fadeSpeed = 1;
  

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        GameManager.BalloonPopped += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        balloonsPoppedUI.text = GameManager.Instance.poppedBalloons + "/" + GameManager.Instance.balloonInScene;
    }

   public IEnumerator ShowWinPanel()
    {
        while (winPanel.alpha<1) 
        {
            winPanel.alpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
   
}
