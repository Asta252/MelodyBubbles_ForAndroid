using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCntroller : MonoBehaviour {
    Slider _slider;
    int bress;
    int bressMax;
    public GameObject gameManage;
    public PlayerController PCtrl;
    private float timeleft;
    // Use this for initialization
    void Start () {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();

        gameManage = GameObject.Find("GameManage");
        PCtrl.GetComponent<PlayerController>().rate = 1;
        bressMax = 500;
        bress = bressMax;
        _slider.value = bress;
        timeleft = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
        {
            BressControl();
        }

        _slider.value = bress;
	}

    void BressControl()
    {
        
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0f)
        {
            timeleft = 1.0f;


            bress -= 10*(int)PCtrl.rate;
            //  _slider.value = bress;
        }

        //Debug.Log(bress);
        if (bress == 0)
        {
            gameManage.GetComponent<GameManage>().gameState = GameManage.GameState.GAMEOVER;
        }

    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "bubble")
        {
            bress += 30;
            if (bress >= bressMax)
            {
                bress = bressMax;
            }
        }
    }
}
