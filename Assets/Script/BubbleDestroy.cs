using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDestroy : MonoBehaviour {
    public GameObject gameManage;
	// Use this for initialization
	void Start () {
        gameManage = GameObject.Find("GameManage");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "bubble"||c.gameObject.tag=="melody")
        {
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "player")
        {
            gameManage.GetComponent<GameManage>().gameState = GameManage.GameState.CLEAR;
        }
    }
}
