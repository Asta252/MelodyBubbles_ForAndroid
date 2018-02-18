using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenelator : MonoBehaviour {
    
    public GameObject[] bubbleItem;
   
    // Use this for initialization
    IEnumerator Start () {
        while (true)
        {

            Vector2 pos = GetRandomPosition();

            int item = Random.Range(0, 5);
            /*
            if (item >= 1 && item <= 2)
            {
                Instantiate(bubbleItem[0], pos, Quaternion.identity);

            }
            else if(item==3)
            {
                Instantiate(bubbleItem[1], pos, Quaternion.identity);
            }
            else if(item==4)
            {
                Instantiate(bubbleItem[2], pos, Quaternion.identity);
            }
            else
            {
                Instantiate(bubbleItem[3], pos, Quaternion.identity);
            }
            */

            Instantiate(bubbleItem[item], pos, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
        
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-6, 6), Random.Range(-50, 0));
    }
}
