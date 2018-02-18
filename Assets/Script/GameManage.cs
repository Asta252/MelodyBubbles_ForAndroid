using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {
    public enum GameState
    {
        START,
        PLAYABLE,
        CLEAR,
        GAMEOVER
    }

    public GameState gameState;
    public GameObject[] bubbles;
    Button ReButton;
    Button TiButton;
	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < bubbles.Length; i++)
        {
            DontDestroyOnLoad(bubbles[i]);
        }
        ReButton = GameObject.Find("Canvas/RestartButton").GetComponent<Button>();
        TiButton = GameObject.Find("Canvas/TitleButton").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.CLEAR:
                ReButton.interactable = true;
                TiButton.interactable = true;
                if (Input.GetKeyDown(KeyCode.Z))
                {

                    Restart();
                    //Application.LoadLevel("GameScene");
                }
                break;
            case GameState.GAMEOVER:
                ReButton.interactable = true;
                TiButton.interactable = true;
                break;
            case GameState.PLAYABLE:
                ReButton.interactable = false;
                TiButton.interactable = false;
                break;
            case GameState.START:

                break;
        }
	}
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
   
}
