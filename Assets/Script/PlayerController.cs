using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private float playerSpeed = 5.0f;
    public GameObject[] Melody;
    public GameObject gameManage;
    private int score;
    private float depth;
    public int bress;
    public float rate;
    private int bressMax;
    private Animator myAnimator;
    private GameObject scoreText;
    private GameObject sinkText;
    private GameObject stateText;
    private GameObject rankText;
    public GameObject Blood;
    private Vector2 touchVec;
    //private Slider _slider;
    //bool totchBress;
	// Use this for initialization
	void Start () {
        gameManage = GameObject.Find("GameManage");
        myAnimator = GetComponent<Animator>();
        scoreText = GameObject.Find("scoreText");
        stateText = GameObject.Find("stateText");
        rankText = GameObject.Find("rankText");
        //_slider = GameObject.Find("Slider").GetComponent<Slider>();

        myAnimator.SetBool("live", true);

        depth = this.transform.position.y * (-1);
        rate = 1;

       // totchBress = false;
        //_slider.value = bress;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
        {
            

            PlayerMoves();
            PlayerRotate();
            // _slider.value = bress;
            depth = this.transform.position.y * (-1);
            rate = depth * (0.03f) + 0.93f;
        }else if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.CLEAR)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            myAnimator.speed = 0.3f;

            stateText.GetComponent<Text>().text = "Game Clear";
            
            Rank();

            
        }else if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.GAMEOVER)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            myAnimator.SetBool("live", false);
            stateText.GetComponent<Text>().text = "Game Over";

            Rank();
        }
        

        
	}

   

    void PlayerMoves()
    {
        if (Input.GetMouseButton(0))
        {
            touchVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("x=" + touchVec.x + " y=" + touchVec.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(touchVec.x, touchVec.y), playerSpeed * Time.deltaTime);
        /*
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = playerSpeed * direction;
          Clamp();
        */
        Clamp();
    }
    void Clamp()
    {
        float minX = -6.0f;
        float maxX = 6.0f;
        float minY = -58.0f;
        float maxY = 3.0f;

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
    void PlayerRotate()
    {
        float rightR = -90;
        float downR = 180;
        float leftR = 90;
        float upR = 0;
        Vector2 scale = transform.localScale;
        if (touchVec.x>transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rightR);
            scale.x = 1;
            myAnimator.speed = 1.2f;
        }
        else if (touchVec.y>transform.position.y)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, upR);
            myAnimator.speed = 1.2f;
        }
        else if (touchVec.x<transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, leftR);
            scale.x = -1;
            myAnimator.speed = 1.2f;
        }
        else if (touchVec.y<=transform.position.y)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, downR);
            myAnimator.speed = 1.2f;
        }
        else
        {
            myAnimator.speed = 0.5f;
        }
        transform.localScale = scale;

        this.scoreText.GetComponent<Text>().text = score + "pt";
    }
    void Rank()
    {
        string rankZero = "Empty...";
        string rankD = "So Good!";
        string rankC = "Cool!";
        string rankB = "Wanderful!";
        string rankA = "So Melodias!";
        string rankS = "Amazing!";
        if (score == 0)
        {
            rankText.GetComponent<Text>().text = score + " pt\n" + rankZero;
        }else if (score > 0 && score <= 100)
        {
            rankText.GetComponent<Text>().text = score + "pt \n" + rankD;
        }else if (score > 100 && score <= 300)
        {
            rankText.GetComponent<Text>().text = score + "pt \n" + rankC;
        }else if (score > 300 && score <= 800)
        {
            rankText.GetComponent<Text>().text = score + "pt \n" + rankB;
        }else if (score > 800 && score <= 1200)
        {
            rankText.GetComponent<Text>().text = score + "pt \n" + rankA;
        }else if (score > 1200)
        {
            rankText.GetComponent<Text>().text = score + "pt \n" + rankS;
        }
    }

    void BloodEff()
    {
        Instantiate(Blood, transform.position, transform.rotation);
    }

    void GausRank()
    {
        if (transform.position.y >= 0)
        {
            score += 5;
        }else if (transform.position.y < 0 && transform.position.y >= -2.5)
        {
            score += 10;
        }else if (transform.position.y < -2.5 && transform.position.y >= -4)
        {
            score += 20;
        }else if (transform.position.y < -4)
        {
            score += 30;
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "bubble")
        {
            
           
            //_slider.value = bress;
            Destroy(c.gameObject);

           
        }
        if (c.gameObject.tag == "melody")
        {
            c.gameObject.GetComponent<MelodyManage>().PlayMelody();

            // Destroy(c.gameObject,1.0f);
            if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
            {
                //score += 10*(int)rate;
                GausRank();
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "enemy")
        {
            BloodEff();
            gameManage.GetComponent<GameManage>().gameState = GameManage.GameState.GAMEOVER;
        }
    }
}
