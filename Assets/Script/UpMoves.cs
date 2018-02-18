using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMoves : MonoBehaviour {
    public float speed=0.3f;
    Rigidbody2D myRigid2D;
	// Use this for initialization
	void Start () {
        myRigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Move(Vector2 direction)
    {
        this.myRigid2D.velocity = direction * speed;
    }
}
