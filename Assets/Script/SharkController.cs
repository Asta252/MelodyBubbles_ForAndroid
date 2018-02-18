using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {
    public GameObject target;
    public GameObject gameManage;
    bool moveFlag;
    float speed = 1.0f;

    float m_interval = 10.0f;
    float m_timer;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Swimer");
        gameManage = GameObject.Find("GameManage");
        moveFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
        SharkTimer();
        if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
        {
            if (moveFlag == true)
            {
                if (this.transform.position.y <= 1.5)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(target.transform.position.x, target.transform.position.y), speed * Time.deltaTime);

                }
            }
        }
	}

    void SharkTimer()
    {
        m_timer += Time.deltaTime;
        if (moveFlag == false)
        {
            if (m_timer > m_interval)
            {
                moveFlag = true;
                m_timer = 0;
            }
        }else if (moveFlag == true)
        {
            if (m_timer > m_interval)
            {
                moveFlag = false;
                m_timer = 0;
            }
        }
    }
}
