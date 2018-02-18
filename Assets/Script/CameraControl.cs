using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Swimer");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.y < -55)
        {
            transform.position = new Vector3(transform.position.x, -55, transform.position.z);
        }
	}
}
