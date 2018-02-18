using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MelodyManage : MonoBehaviour {
    public AudioClip melody;
    private AudioSource audioSource;
    private SpriteRenderer mySprite;
    float alpha = 1.0f;
    float interval = 0.2f;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = melody;
        mySprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fade()
    {
        

        mySprite.color = new Color(mySprite.color.r, mySprite.color.g, mySprite.color.b, alpha);

        alpha -= interval;
    }
    public void PlayMelody()
    {
        audioSource.Play();
        gameObject.layer = 11;
        InvokeRepeating("Fade", 0.1f, 0.2f);
        Destroy(gameObject, audioSource.clip.length);
    }
    
}
